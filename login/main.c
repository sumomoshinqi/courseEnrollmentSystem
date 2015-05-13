//
//  main.c
//  Course Enrolment System
//
//  Created by 李秦琦 on 15/5/9.
//  Copyright (c) 2015年 李秦琦. All rights reserved.
//

#include "header.h"

char *base64Encode(const char *data, int data_len);
char *base64Decode(const char *data, int data_len);

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
    
    unsigned long loginName;
    char loginPassword[100];
    char query[100];
    // Read loginName, loginPassword from loginInfo.dat
    freopen("loginInfo.dat", "r", stdin);
    
    scanf("%ld %s", &loginName, loginPassword);
    
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
    sprintf(query, "select * from Student where studentID=%ld", loginName);
    //sprintf(query, "select * from users");
    if(mysql_query(test, query))
        finishWithError (test);
    result = mysql_store_result(test);
    //printf("%d\n", mysql_field_count(test));
        
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
        //get password
        //scanf ("%[^\n]", LoginPsw);
        int len = (int)strlen(loginPassword);
        char * enc = base64Encode(loginPassword, len);
            
        // Test connection to the database
        if (mysql_real_connect(test, SERVER, TESTUSERNAME, TESTPASSWORD, DATABASE, 0, NULL, 0) == NULL) {
            // Connection failed
            return -1;
        }
        sprintf(query, "select * from Student where studentID=%ld and Psw = \'%s\';", loginName, enc);
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
        printf("密码无效\n");
    }
    else if (loginStateCode == 1) {
        printf("登陆成功\n");
    }
    
    // Write login state into loginState.dat
    freopen("loginState.dat", "w", stdout);
    if (loginStateCode == -1) {
        printf("无法连接至数据库\n");
    }
    else if (loginStateCode == -2) {
        printf("无效用户名\n");
    }
    else if (loginStateCode == -3) {
        printf("密码无效\n");
    }
    else if (loginStateCode == 1) {
        printf("登陆成功\n");
    }

    
    mysql_close(mysql);
    return 0;
}
