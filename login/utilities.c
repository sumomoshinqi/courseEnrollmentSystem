//
//  utilities.c
//  Course Enrolment System
//
//  Created by 李秦琦 on 15/5/11.
//  Copyright (c) 2015年 李秦琦. All rights reserved.
//
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

const char base[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

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

static char findPosition(char ch)
{
    char *ptr = (char *)strrchr(base, ch);
    return (ptr - base);
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
void testBase64()
{
    char *testingMessage = "11307120292";
    int  encodedLength  = (int)strlen(testingMessage);
    char *encodedMessage = base64Encode(testingMessage, encodedLength);
    int  decodedLength = (int)strlen(encodedMessage);
    char *decodedMessage = base64Decode(encodedMessage, decodedLength);
    printf("\noriginal:  %s\n", testingMessage);
    printf("\nencoded :  %s\n", encodedMessage);
    printf("\ndecoded :  %s\n", decodedMessage);
}
int main(int argc, char const *argv[])
{
    testBase64();
    return 0;
}