using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CESadmin
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static bool IsNumber(string str)
        {
            if (str == null || str.Length == 0)
                return false;  
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(str);

            foreach (byte c in bytestr) 
            {
                if (c < 48 || c > 57)
                {
                    return false;
                }
            }
            return true;
        }

        public void writeQuery(string str)
        {
            FileStream fs = new FileStream("query.dat", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(str);
            sw.Close();
            fs.Close();
        }

        private void executeQuery()
        {
            Process processExe = new Process();
            processExe.StartInfo.UseShellExecute = false;
            processExe.StartInfo.CreateNoWindow = true;
            processExe.StartInfo.FileName = "executeQuery.exe";
            processExe.Start();
            processExe.WaitForExit();
            processExe.Close();
            // show result
            FileStream fs = new FileStream("queryState.dat", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string state = sr.ReadLine();
            if (state.Contains("成功"))
                MessageBox.Show("修改成功");
            else
                MessageBox.Show("修改失败");
            sr.Close();
            fs.Close();
        }

        private void clearStudentInfo()
        {
            studentIDBox.Text = "";
            studentNameBox.Text = "";
            studentPswBox.Text = "";
            studentMajorBox.Text = "";
            studentDeptBox.Text = "";
            studentNoteBox.Text = "";
        }

        private void clearCourseInfo()
        {
            courseIDBox.Text = "";
            courseNameBox.Text = "";
            courseTypeBox.Text = "";
            courseCreditBox.Text = "";
            courseTeacherBox.Text = "";
            courseTeacherTypeBox.Text = "";
            courseClassroomBox.Text = "";
            courseTimeBox.Text = "";
            courseNoteBox.Text = "";
            courseRestrictionBox.Text = "";
            courseDeptBox.Text = "";
            courseVacancyBox.Text = "";
        }

        private bool checkStudentInfo()
        {
            if (string.IsNullOrEmpty(studentIDBox.Text) || string.IsNullOrEmpty(studentPswBox.Text) || string.IsNullOrEmpty(studentNameBox.Text) || string.IsNullOrEmpty(studentMajorBox.Text) || string.IsNullOrEmpty(studentDeptBox.Text))
            {
                MessageBox.Show("缺少必要信息");
                return false;
            }

            if (!IsNumber(studentIDBox.Text))
            {
                MessageBox.Show("非法学号");
                return false;
            }

            return true;
        }

        private bool checkCourseInfo()
        {
            if (string.IsNullOrEmpty(courseIDBox.Text) || string.IsNullOrEmpty(courseNameBox.Text) || string.IsNullOrEmpty(courseTypeBox.Text) || string.IsNullOrEmpty(courseCreditBox.Text) || string.IsNullOrEmpty(courseTeacherBox.Text) || string.IsNullOrEmpty(courseVacancyBox.Text) || string.IsNullOrEmpty(courseClassroomBox.Text) || string.IsNullOrEmpty(courseTimeBox.Text) || string.IsNullOrEmpty(courseDeptBox.Text))
            {
                MessageBox.Show("缺少必要信息");
                return false;
            }

            if (!IsNumber(courseVacancyBox.Text))
            {
                MessageBox.Show("非法人数限制");
                return false;
            }

            return true;
        }

        private string encodePsw(string inStr)
        {
            string outStr = "";
            Process processEncode = new Process();
            processEncode.StartInfo.RedirectStandardOutput = true;
            processEncode.StartInfo.UseShellExecute = false;
            processEncode.StartInfo.CreateNoWindow = true;
            processEncode.StartInfo.FileName = "base64.exe";
            processEncode.StartInfo.RedirectStandardInput = true;
            processEncode.Start();
            processEncode.StandardInput.WriteLine(inStr);
            processEncode.WaitForExit();
            if (processEncode.HasExited)
            {
                outStr = processEncode.StandardOutput.ReadLine();
            }
            processEncode.Close();
            return outStr;
        }
        private void newStudentButton_Click(object sender, EventArgs e)
        {
            if (!checkStudentInfo())
                return;

            string newStudentQuery = "INSERT INTO Student VALUES (" + studentIDBox.Text + ", \"" + encodePsw(studentPswBox.Text) + "\", \"" + studentNameBox.Text + "\", \"" + studentMajorBox.Text + "\", \"" + studentDeptBox.Text + "\", \"" + studentNoteBox.Text + "\")";
            
            string newStudentInfo;
            newStudentInfo = "学号：" + studentIDBox.Text + "\n密码：" + studentPswBox.Text + "\n姓名：" + studentNameBox.Text + "\n专业：" + studentMajorBox.Text + "\n院系：" + studentDeptBox.Text + "\n备注：" + studentNoteBox.Text;
            DialogResult newstudentDR= MessageBox.Show(newStudentInfo,"新建学生", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (newstudentDR == DialogResult.OK)
            {
                writeQuery(newStudentQuery);
                executeQuery();
                clearStudentInfo();
                clearCourseInfo();
            }
            else
            {
                clearStudentInfo();
                clearCourseInfo();
                return;
            }
        }

        private void deleteStudentButton_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(studentIDBox.Text))
            {
                MessageBox.Show("输入有效学号来删除");
                return;
            }
            string deleteStudentQuery = "DELETE FROM Student WHERE studentID = " + studentIDBox.Text;
            
            string deleteStudentInfo;
            deleteStudentInfo = "删除学号为：" + studentIDBox.Text + "的学生";
            DialogResult deleteStudentDR = MessageBox.Show(deleteStudentInfo, "删除学生", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (deleteStudentDR == DialogResult.OK)
            {
                writeQuery(deleteStudentQuery);
                executeQuery();
                clearStudentInfo();
                clearCourseInfo();
            }
            else
            {
                clearStudentInfo();
                clearCourseInfo();
                return;
            }
        }

        private void newCourseButton_Click(object sender, System.EventArgs e)
        {
            if (!checkCourseInfo())
                return;
            // get courseTimeslot
            string courseTimeslot = "";
            if (courseTimeBox.Text.Contains("一"))
                courseTimeslot = "1 ";
            if (courseTimeBox.Text.Contains("二"))
                courseTimeslot = "2 ";
            if (courseTimeBox.Text.Contains("三"))
                courseTimeslot = "3 ";
            if (courseTimeBox.Text.Contains("四"))
                courseTimeslot = "4 ";
            if (courseTimeBox.Text.Contains("五"))
                courseTimeslot = "5 ";
            if (courseTimeBox.Text.Contains("六"))
                courseTimeslot = "6 ";
            if (courseTimeBox.Text.Contains("日"))
                courseTimeslot = "7 ";
            int tmpDigit;
            string tmpStr;
            for (tmpDigit = 14; tmpDigit > 0; tmpDigit--)
            {
                tmpStr = string.Format("{0}-", tmpDigit);
                if (courseTimeBox.Text.Contains(tmpStr))
                {
                    courseTimeslot += string.Format("{0} ", tmpDigit);
                    break;
                }
            }
            
            for (tmpDigit = 14; tmpDigit > 0; tmpDigit--)
            {
                tmpStr = string.Format("-{0}", tmpDigit);
                if (courseTimeBox.Text.Contains(tmpStr))
                {
                    courseTimeslot += string.Format("{0}", tmpDigit);
                    break;
                }
            }

            string newCourseQuery;
            newCourseQuery = "INSERT INTO CourseList VALUES (\"" + courseIDBox.Text + "\", \"" + courseNameBox.Text + "\", \"" + courseTypeBox.Text + "\", \"" + courseCreditBox.Text + "\", \"" + courseTeacherBox.Text + "\", \"" + courseTeacherTypeBox.Text + "\", " + courseVacancyBox.Text + ", \"" + courseClassroomBox.Text + "\", \"" + courseTimeBox.Text + "\", \"" + courseNoteBox.Text + "\", \"" + courseDeptBox.Text + "\", \"" + courseRestrictionBox.Text + "\", \"" + courseTimeslot + "\", " + "0)";

            string newCourseInfo = "课程代码：" + courseIDBox.Text
                + "\n课程名：" + courseNameBox.Text
                + "\n类型" + courseTypeBox.Text
                + "\n学分" + courseCreditBox.Text
                + "\n教师" + courseTeacherBox.Text
                + "\n职称" + courseTeacherTypeBox.Text
                + "\n人数限制" + courseVacancyBox.Text
                + "\n教室" + courseClassroomBox.Text
                + "\n时间" + courseTimeBox.Text
                + "\n开课院系" + courseDeptBox.Text
                + "\n备注" + courseNoteBox.Text
                + "\n选课限制" + courseRestrictionBox.Text;

            DialogResult newCourseDR = MessageBox.Show(newCourseInfo, "新建课程", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (newCourseDR == DialogResult.OK)
            {
                writeQuery(newCourseQuery);
                executeQuery();
                clearStudentInfo();
                clearCourseInfo();
            }
            else
            {
                clearStudentInfo();
                clearCourseInfo();
                return;
            }
        }

        private void deleteCourseButton_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(courseIDBox.Text))
            {
                MessageBox.Show("输入有效课程代码来删除");
                return;
            }

            string deleteCourseQuery = "DELETE FROM CourseList WHERE courseID = \"" + courseIDBox.Text + "\"";

            string deleteCourseInfo;
            deleteCourseInfo = "删除代码为：" + studentIDBox.Text + "的课程";
            DialogResult deleteCourseDR = MessageBox.Show(deleteCourseInfo, "删除课程", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (deleteCourseDR == DialogResult.OK)
            {
                writeQuery(deleteCourseQuery);
                executeQuery();
                clearStudentInfo();
                clearCourseInfo();
            }
            else
            {
                clearStudentInfo();
                clearCourseInfo();
                return;
            }

        }
    }
}
