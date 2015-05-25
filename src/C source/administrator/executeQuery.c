//
//  executeQuery.c
//  Course Enrolment System

#pragma execution_character_set("utf-8")

#include <winsock2.h>

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
// Include MySQL headers
#include <mysql.h>
#include <my_global.h>

const char SERVER[] = "10.141.249.176";
const char DATABASE[] = "Courses";
const char TESTUSERNAME[] = "Test";
const char TESTPASSWORD[] = "Test";

int main(int argc, const char * argv[]) {

    MYSQL *mysql = mysql_init(NULL);
    MYSQL_RES *result = NULL;
    MYSQL_ROW row;
    
    char query[1024];
    int num;

    if (mysql == NULL) {
        fprintf(stderr, "mysql_init() failed\n");
        exit(1);
    }

    // Connect to database
    if (mysql_real_connect(mysql, SERVER, TESTUSERNAME, TESTPASSWORD, DATABASE, 0, NULL, 0) == NULL) {
        // Connection failed
        return -1;
    }

    freopen("query.dat", "r", stdin);
    scanf ("%[^\n]", query);
    // execute query
    mysql_query(mysql, "set names gb2312");
    if (mysql_query(mysql, query)) {
        mysql_close(mysql);
        exit(1);
    } else {
        num = (int)mysql_affected_rows(mysql);
        freopen("queryState.dat", "w", stdout);
        if(num > 0)
            printf("成功\n");
        else
            printf("失败\n");
    }

    mysql_close(mysql);
    return 0;
}