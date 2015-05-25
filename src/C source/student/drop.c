//
//  drop.c
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

void finishWithError(MYSQL *mysql)
{
    fprintf(stderr, "%s\n", mysql_error(mysql));
    mysql_close(mysql);
    exit(1);
}

int drop(MYSQL *mysql)
{
    MYSQL_RES *result = NULL;
    
    char loginName[20];
    char query[200];
    char courseID[20];
    
    // Read loginName, loginPassword from loginInfo.dat
    // freopen("loginInfo.dat", "r", stdin);
    scanf("%s", loginName);
    
    // freopen("dropInfo.dat", "r", stdin);
    scanf("%s", courseID);
    
    // check course ID
    memset(query, 0, sizeof(query));
    sprintf(query, "SELECT * FROM CourseList WHERE courseID = \"%s\"", courseID);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    result = mysql_store_result(mysql);
    if (!mysql_num_rows(result)) {
        // Invalid course ID
        return -2;
    }
    
    // check enrollment
    memset(query, 0, sizeof(query));
    sprintf(query, "SELECT * FROM CourseEnrollment WHERE course = \"%s\" AND student = %s", courseID, loginName);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    result = mysql_store_result(mysql);
    if (!mysql_num_rows(result)) {
        // Not enrolled
        return -1;
    }
    
    // drop start
    memset(query, 0, sizeof(query));
    sprintf(query, "DELETE FROM CourseEnrollment WHERE course = \"%s\" AND student = %s", courseID, loginName);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    
    // update course list
    memset(query, 0, sizeof(query));
    sprintf(query, "update CourseList set courseTaken=courseTaken-1 where courseID = \"%s\"", courseID);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    
    return 1;
}

int main(int argc, const char * argv[]) {

    int dropStateCode;
    MYSQL *mysql = mysql_init(NULL);
    if (mysql == NULL) {
        fprintf(stderr, "mysql_init() failed\n");
        exit(1);
    }

    // Connect to database
    if (mysql_real_connect(mysql, SERVER, TESTUSERNAME, TESTPASSWORD, DATABASE, 0, NULL, 0) == NULL) {
        // Connection failed
        return -1;
    }
    
    dropStateCode = drop(mysql);

    if (dropStateCode == 1) {
        printf("退课成功");
    } else if (dropStateCode == -1) {
        printf("未选择该课程");
    } else if (dropStateCode == -2) {
        printf("无效课程号");
    }

    mysql_close(mysql);
    return 0;
}