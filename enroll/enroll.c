//
//  enroll.c
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

int enroll(MYSQL *mysql)
{
    MYSQL_RES *result = NULL, *resultEnroll = NULL;
    MYSQL_ROW row, rowEnroll;
    
    unsigned long loginName;
    char query[200];
    char courseID[20];
    char timeSlot[30];
    char tmp[5];
    int i, j, weekday, courseStart, courseEnd;
    int weekdayEnroll, courseStartEnroll, courseEndEnroll;
    
    // Read loginName, loginPassword from loginInfo.dat
    freopen("loginInfo.dat", "r", stdin);
    scanf("%ld", &loginName);
    
    freopen("enrollInfo.dat", "r", stdin);
    scanf("%s", courseID);
    
    // Check if time slots are available
    memset(query, 0, sizeof(query));
    sprintf(query, "select courseTimeslot from CourseList where courseID=\"%s\";", courseID);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    result = mysql_store_result(mysql);
    if (!mysql_num_rows(result)) {
        // Invalid course ID
        return -2;
    } else {
        // Get timeslot
        while ((row = mysql_fetch_row(result))) {
            strcpy(timeSlot, row[0]);
            
            weekday = timeSlot[0] - '0';
            for (i = 2, j = 0; timeSlot[i] >= '0' && timeSlot[i] <= '9'; i++) {
                tmp[j++] = timeSlot[i];
            }
            tmp[j] = '\0';
            courseStart = atoi(tmp);
            
            ++i;
            for (j = 0; timeSlot[i] >= '0' && timeSlot[i] <= '9'; i++) {
                tmp[j++] = timeSlot[i];
            }
            tmp[j] = '\0';
            courseEnd = atoi(tmp);
            
            // Check if timeslot is available
            // Compare with courses in CourseEnrollment
            memset(query, 0, sizeof(query));
            sprintf(query, "SELECT courseTimeslot FROM CourseEnrollment, CourseList WHERE CourseEnrollment.course = CourseList.courseID AND CourseEnrollment.student = \"%ld\";", loginName);
            if (mysql_query(mysql, query)) {
                finishWithError(mysql);
            }
            resultEnroll = mysql_store_result(mysql);
            
            while ((rowEnroll = mysql_fetch_row(resultEnroll))) {
                strcpy(timeSlot, rowEnroll[0]);
                
                weekdayEnroll = timeSlot[0] - '0';
                for (i = 2, j = 0; timeSlot[i] >= '0' && timeSlot[i] <= '9'; i++) {
                    tmp[j++] = timeSlot[i];
                }
                tmp[j] = '\0';
                courseStartEnroll = atoi(tmp);
                
                ++i;
                for (j = 0; timeSlot[i] >= '0' && timeSlot[i] <= '9'; i++) {
                    tmp[j++] = timeSlot[i];
                }
                tmp[j] = '\0';
                courseEndEnroll = atoi(tmp);
                
                // Time conflict
                if ((weekday == weekdayEnroll) && !(courseEnd < courseStartEnroll || courseStart > courseEndEnroll)) {
                    return -3;
                }
            }
        }
        
    }
    
    
    // Check if the there's vacancy
    memset(query, 0, sizeof(query));
    sprintf(query, "select * from CourseList where courseVacancy > courseTaken and courseID=\"%s\";", courseID);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    result = mysql_store_result(mysql);
    if (!mysql_num_rows(result)) {
        // Full
        return 0;
    }
    
    // Test if the student is already enrolled in the course
    memset(query, 0, sizeof(query));
    sprintf(query, "select * from CourseEnrollment where student=%ld and course=\"%s\";", loginName, courseID);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    result = mysql_store_result(mysql);
    if (mysql_num_rows(result)) {
        // Already enrolled
        return -1;
    }
    
    // update course list
    memset(query, 0, sizeof(query));
    sprintf(query, "insert into CourseEnrollment values (\"%s\", %ld);", courseID, loginName);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }
    
    memset(query, 0, sizeof(query));
    sprintf(query, "update CourseList set courseTaken=courseTaken+1 where courseID = \"%s\";", courseID);
    if (mysql_query(mysql, query)) {
        finishWithError(mysql);
    }

    return 1;
}

int main(int argc, const char * argv[]) {

    int enrollStateCode;
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
    
    enrollStateCode = enroll(mysql);

    if (enrollStateCode == 0) {
        printf("选课失败，人数已满");
    } else if (enrollStateCode == 1) {
        printf("选课成功");
    } else if (enrollStateCode == -1) {
        printf("已经选择该课程");
    } else if (enrollStateCode == -2) {
        printf("无效课程号");
    } else if (enrollStateCode == -3) {
        printf("时间冲突，已选择其他课程");
    }
    
    // Write enroll state into enrollState.dat
    freopen("enrollState.dat", "w", stdout);
    if (enrollStateCode == 0) {
        printf("选课失败，人数已满");
    } else if (enrollStateCode == 1) {
        printf("选课成功");
    } else if (enrollStateCode == -1) {
        printf("已经选择该课程");
    } else if (enrollStateCode == -2) {
        printf("无效课程号");
    } else if (enrollStateCode == -3) {
        printf("时间冲突，已选择其他课程");
    }

    mysql_close(mysql);
    return 0;
}
