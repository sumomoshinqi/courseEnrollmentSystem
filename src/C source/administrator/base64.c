//
//  base64.c
//  Course Enrolment System

#pragma execution_character_set("gb2312")

#include <winsock2.h>

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

int main(int argc, char const *argv[])
{
    char in[200];
    scanf("%s", in);
    puts(base64Encode(in,(int) strlen(in)));
    return 0;
}