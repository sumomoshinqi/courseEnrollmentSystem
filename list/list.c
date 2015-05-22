//
//  searchAll.c
//  Course Enrolment System
//
//  Created by ÀîÇØçù on 15/5/9.
//  Copyright (c) 2015Äê ÀîÇØçù. All rights reserved.
//
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

int search(MYSQL *mysql)
{
    MYSQL_RES *result = NULL;
    MYSQL_ROW row;
    
    char query[500];
    
    // list all available courses
    mysql_query(mysql, "set names gb2312");
    memset(query, 0, sizeof(query));
	sprintf(query, "SELECT courseID, courseName, courseType, courseCredit, courseTeacher, courseTeacherType, courseClassroom, courseTime, courseNote, courseDept, courseRestriction, courseTaken, courseVacancy FROM CourseList WHERE courseTaken < courseVacancy");
    if (mysql_query(mysql, query)) {
		finishWithError(mysql);
    }
    result = mysql_store_result(mysql);
	if (!mysql_num_rows(result)) {
        // No result
		return -2;
    }
    freopen("searchAllResult.dat", "w", stdout);
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
        // courseTaken
        printf("%s\n", row[11] ? row[11] : "");
		// courseVacancy
        printf("%s\n", row[12] ? row[12] : "");
    }

    return 1;
}

int main(int argc, const char * argv[]) {

    int searchStateCode;
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
    
    searchStateCode = search(mysql);

    mysql_close(mysql);
    return 0;
}