//
//  search.c
//  Course Enrolment System
//
//  Created by 李秦琦 on 15/5/9.
//  Copyright (c) 2015年 李秦琦. All rights reserved.
//

#include "header.h"

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
    char courseID[20];
    
    freopen("searchInfo.dat", "r", stdin);
    scanf("%s", courseID);
    
    if (strlen(courseID) > 0) {
        // check course ID
        memset(query, 0, sizeof(query));
        sprintf(query, "SELECT * FROM CourseList WHERE courseID = \"%s\"", courseID);
        if (mysql_query(mysql, query)) {
            finishWithError(mysql);
        }
        result = mysql_store_result(mysql);
        if (!mysql_num_rows(result)) {
            // Invalid course ID
            return -1;
        }
        
        // search start
        mysql_query(mysql, "set names utf8");
        memset(query, 0, sizeof(query));
        sprintf(query, "SELECT courseID, courseName, courseType, courseCredit, courseTeacher, courseTeacherType, courseClassroom, courseTime, courseNote, courseDept, courseRestriction, courseTaken, courseVacancy FROM CourseList WHERE courseID LIKE \"");
        strcat(query, "%");
        strcat(query, courseID);
        strcat(query, "%\"");
        strcat(query, " AND courseTaken < courseVacancy OR courseName LIKE \"");
        strcat(query, "%");
        strcat(query, courseID);
        strcat(query, "%\"  AND courseTaken < courseVacancy");
        
        if (mysql_query(mysql, query)) {
            finishWithError(mysql);
        }
        result = mysql_store_result(mysql);
        if (!mysql_num_rows(result)) {
            // No result
            return -2;
        }
        freopen("searchResult.dat", "w", stdout);
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
            printf("\n");
        }
    } else {
        // list all available courses
        mysql_query(mysql, "set names utf8");
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
        freopen("searchResult.dat", "w", stdout);
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
            printf("\n");
        }
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
    
    freopen("searchState.dat", "w", stdout);
    if (searchStateCode == -1) {
        printf("无效课程号");
    } else if (searchStateCode == -2){
        printf("无可选课程");
    } else {
        printf("查询完成");
    }

    mysql_close(mysql);
    return 0;
}
