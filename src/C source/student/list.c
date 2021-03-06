//
//  list.c
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

int list(MYSQL *mysql)
{
    MYSQL_RES *result = NULL;
    MYSQL_ROW row;
    
    char query[500];
    char loginName[20];
    
    // freopen("loginInfo.dat", "r", stdin);
    scanf("%s", loginName);
    
    // freopen("courseList.dat", "w", stdout);
    
    // search CourseList and list all results
    mysql_query(mysql, "set names gb2312");
    memset(query, 0, sizeof(query));
    sprintf(query, "SELECT courseID, courseName, courseType, courseCredit, courseTeacher, courseTeacherType, courseClassroom, courseTime, courseNote, courseDept, courseRestriction FROM CourseList, CourseEnrollment WHERE CourseList.courseID = CourseEnrollment.course and CourseEnrollment.student=%s", loginName);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    result = mysql_store_result(mysql);
    if (!mysql_num_rows(result)) {
        // No row returned
        return -1;
    }
    
    while ((row = mysql_fetch_row(result)))
    {
        // courseID
        printf("%s\n", row[0] ? row[0] : "");
        // courseName
        printf("%s\n", row[1] ? row[1] : "");
        // courseType
        printf("%s\n", row[2] ? row[2] : "");
        // courseCredit
        printf("%s\n", row[3] ? row[3] : "");
        // courseTeacher
        printf("%s\n", row[4] ? row[4] : "");
        // courseTeacherType
        printf("%s\n", row[5] ? row[5] : "");
        // courseClassroom
        printf("%s\n", row[6] ? row[6] : "");
        // courseTime
        printf("%s\n", row[7] ? row[7] : "");
        // courseNote
        printf("%s\n", row[8] ? row[8] : "");
        // coutseDept
        printf("%s\n", row[9] ? row[9] : "");
        // courseRestriction
        printf("%s\n", row[10] ? row[10] : "");
        printf("\n");
    }
    
    return 1;
}

int main(int argc, const char * argv[]) {

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
    
    list(mysql);

    mysql_close(mysql);
    return 0;
}
