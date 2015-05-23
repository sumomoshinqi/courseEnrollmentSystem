//
//  login.c
//  Course Enrolment System
//
//  Created by 李秦琦 on 15/5/9.
//  Copyright (c) 2015年 李秦琦. All rights reserved.
//
#pragma execution_character_set("utf-8")
#include <winsock2.h>

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
// Include MySQL headers
#include <mysql.h>
#include <my_global.h>

const char SERVER[] = "10.141.249.176";
const char DATABASE[] = "Courses";
const char TESTUSERNAME[] = "Test";
const char TESTPASSWORD[] = "Test";
const char base[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

static char findPosition(char ch)
{
    char *ptr = (char *)strrchr(base, ch);
    return (ptr - base);
}

char *base64Encode(const char *data, int dataLen)
{
    int prepare = 0;
    int retLen;
    int temp = 0;
    char *ret = NULL;
    char *f = NULL;
    int tmp = 0;
    char changed[4];
    int i = 0;
    
    retLen = dataLen / 3;
    temp = dataLen % 3;
    
    if (temp > 0) {
        retLen += 1;
    }
    retLen = retLen * 4 + 1;
    ret = (char *)malloc(retLen);
    if (ret == NULL) {
        printf("No enough memory.\n");
        exit(0);
    }
    
    memset(ret, 0, retLen);
    f = ret;
    
    while (tmp < dataLen) {
        temp = 0;
        prepare = 0;
        memset(changed, '\0', 4);
        
        while (temp < 3) {
            if (tmp >= dataLen) {
                break;
            }
            prepare = ((prepare << 8) | (data[tmp] & 0xFF));
            tmp++;
            temp++;
        }
        
        prepare = (prepare << ((3 - temp) * 8));
        
        for (i = 0; i < 4 ; i++) {
            if (temp < i) {
                changed[i] = 0x40;
            }
            else {
                changed[i] = (prepare >> ((3 - i) * 6)) & 0x3F;
            }
            *f = base[changed[i]];
            f++;
        }
    }
    *f = '\0';
    
    return ret;
    
}

char *base64Decode(const char *data, int dataLen)
{
    int retLen = (dataLen / 4) * 3;
    int equalCount = 0;
    char *ret = NULL;
    char *f = NULL;
    int tmp = 0;
    int temp = 0;
    char need[3];
    int prepare = 0;
    int i = 0;
    
    if (*(data + dataLen - 1) == '=') {
        equalCount += 1;
    }
    if (*(data + dataLen - 2) == '=') {
        equalCount += 1;
    }
    if (*(data + dataLen - 3) == '=') {
        equalCount += 1;
    }
    
    switch (equalCount) {
        case 0:
            retLen += 4;//3 + 1 [1 for NULL]
            break;
        case 1:
            retLen += 4;//Ceil((6*3)/8)+1
            break;
        case 2:
            retLen += 3;//Ceil((6*2)/8)+1
            break;
        case 3:
            retLen += 2;//Ceil((6*1)/8)+1
            break;
    }
    
    ret = (char *)malloc(retLen);
    if (ret == NULL) {
        printf("No enough memory.\n");
        exit(0);
    }
    memset(ret, 0, retLen);
    f = ret;
    
    while (tmp < (dataLen - equalCount)) {
        temp = 0;
        prepare = 0;
        memset(need, 0, sizeof(need));
        
        while (temp < 4) {
            if (tmp >= (dataLen - equalCount)) {
                break;
            }
            prepare = (prepare << 6) | (findPosition(data[tmp]));
            temp++;
            tmp++;
        }
        
        prepare = prepare << ((4-temp) * 6);
        
        for (i=0; i<3 ;i++ ) {
            if (i == temp) {
                break;
            }
            *f = (char)((prepare >> ((2 - i) * 8)) & 0xFF);
            f++;
        }
    }
    
    *f = '\0';
    
    return ret;
}

void finishWithError(MYSQL *mysql)
{
    fprintf(stderr, "%s\n", mysql_error(mysql));
    mysql_close(mysql);
    exit(1);
}

void testBase64()
{
    char *testingMessage = "TestingMessage";
    int  encodedLength  = (int)strlen(testingMessage);
    char *encodedMessage = base64Encode(testingMessage, encodedLength);
    int  decodedLength = (int)strlen(encodedMessage);
    char *decodedMessage = base64Decode(encodedMessage, decodedLength);
    printf("\noriginal:  %s\n", testingMessage);
    printf("\nencoded :  %s\n", encodedMessage);
    printf("\ndecoded :  %s\n", decodedMessage);
}

int login(MYSQL *mysql)
{
    MYSQL *test = mysql_init(NULL);
    MYSQL_RES *result = NULL;
    
    char loginName[20];
    char loginPassword[100];
    char query[100];
	int len;
    char * enc;

    // Read loginName, loginPassword from loginInfo.dat
    // freopen("loginInfo.dat", "r", stdin);
    
    scanf("%s %s", loginName, loginPassword);
    
    if (test == NULL) {
        fprintf(stderr, "mysql_init() failed\n");
        exit(1);
    }
    
    // Test network connection
    if (mysql_real_connect(test, SERVER, TESTUSERNAME, TESTPASSWORD, DATABASE, 0, NULL, 0) == NULL) {
        // Connection failed
        return -1;
    }
    
    // Try to login
    memset(query, 0, sizeof(query));
    sprintf(query, "select * from Student where studentID=%s", loginName);
    
    if(mysql_query(test, query))
        finishWithError (test);
    result = mysql_store_result(test);
        
    if (!mysql_num_rows(result)) {
        // Username not found
        return -2;
    }
    else {
        test = mysql_init(NULL);
        if (test == NULL) {
            fprintf(stderr, "mysql_init() failed\n");
            exit(1);
        }
        
        len = (int)strlen(loginPassword);
        enc = base64Encode(loginPassword, len);
            
        // Test connection to the database
        if (mysql_real_connect(test, SERVER, TESTUSERNAME, TESTPASSWORD, DATABASE, 0, NULL, 0) == NULL) {
            // Connection failed
            return -1;
        }
        sprintf(query, "select * from Student where studentID=%s and Psw = \'%s\';", loginName, enc);
        mysql_query(test, query);
        result = mysql_store_result(test);
        if (!mysql_num_rows(result)) {
            // Wrong password
            mysql_close(test);
            mysql_free_result(result);
            return -3;
        }
    }
    if (mysql_real_connect(mysql, SERVER, TESTUSERNAME, TESTPASSWORD, DATABASE, 0, NULL, 0) == NULL) {
        // Connection failed
        return -1;
    }
    // Login successful
    return 1;
}

int main(int argc, const char * argv[]) {
    //testBase64();

    int loginStateCode;
    MYSQL *mysql = mysql_init(NULL);
    if (mysql == NULL) {
        fprintf(stderr, "mysql_init() failed\n");
        exit(1);
    }

    loginStateCode = login(mysql);

    if (loginStateCode == -1) {
        printf("无法连接至数据库\n");
    }
    else if (loginStateCode == -2) {
        printf("无效用户名\n");
    }
    else if (loginStateCode == -3) {
        printf("密码错误\n");
    }
    else if (loginStateCode == 1) {
        printf("登录成功\n");
    }

    mysql_close(mysql);
    return 0;
}