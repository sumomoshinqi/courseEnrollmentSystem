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

namespace CES
{
    public partial class Main : Form
    {
        public Main(string studentID)
        {
            InitializeComponent();
            studentIDLabel.Text = studentID;
            courseTable.Visible = true;
            courseTable.BringToFront();
            searchBox.Visible = false;
            searchGridView.Visible = false;
            searchLabel.Visible = false;
            refreshCourseGridView();
            //refreshCourseTable();
        }

        private void refreshCourseGridView()
        {
            // clear courseFridView
            while (this.courseGridView.Rows.Count != 0)
            {
                this.courseGridView.Rows.RemoveAt(0);
            }

            Process processList = new Process();
            processList.StartInfo.RedirectStandardOutput = true;
            processList.StartInfo.UseShellExecute = false;
            processList.StartInfo.CreateNoWindow = true;
            processList.StartInfo.FileName = "list.exe";
            processList.StartInfo.RedirectStandardInput = true;
            processList.Start();
            processList.StandardInput.WriteLine(studentIDLabel.Text);
            processList.WaitForExit();
            if (processList.HasExited)
            {
                string gridData;
                gridData = processList.StandardOutput.ReadLine();
                while (gridData != null)
                {
                    int index = this.courseGridView.Rows.Add();
                    for (int i = 0; i < 2; i++)
                    {
                        if (i > 0) gridData = processList.StandardOutput.ReadLine();
                        this.courseGridView.Rows[index].Cells[i].Value = gridData;

                    }
                    gridData = processList.StandardOutput.ReadLine();
                }
            }
            processList.Close();
            refreshCourseTable();
        }

        private void refreshSearchGridView()
        {

            // clear searchGriddView
            while (this.searchGridView.Rows.Count != 0)
            {
                this.searchGridView.Rows.RemoveAt(0);
            }

            Process processRefreshSearch = new Process();
            processRefreshSearch.StartInfo.UseShellExecute = false;
            processRefreshSearch.StartInfo.CreateNoWindow = true;
            processRefreshSearch.StartInfo.FileName = "searchAll.exe";
            processRefreshSearch.Start();
            processRefreshSearch.WaitForExit();
            if (processRefreshSearch.HasExited)
            {
                StreamReader searchAllReader = new StreamReader("searchAllResult.dat", Encoding.GetEncoding("GB2312"));

                string searchAllGridData;
                searchAllGridData = searchAllReader.ReadLine();
                while (searchAllGridData != null)
                {
                    int index = this.searchGridView.Rows.Add();
                    for (int i = 0; i < 13; i++)
                    {
                        if (i > 0)
                            searchAllGridData = searchAllReader.ReadLine();
                        this.searchGridView.Rows[index].Cells[i].Value = searchAllGridData;
                    }
                    searchAllGridData = searchAllReader.ReadLine();
                }

                searchAllReader.Close();
                 
            }
            processRefreshSearch.Close();
            
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("登出成功");
            Application.ExitThread();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void enrollButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(courseIDBox.Text))
            {
                MessageBox.Show("课程号不能为空");
                return;
            }
            Process processEnroll = new Process();
            processEnroll.StartInfo.RedirectStandardOutput = true;
            processEnroll.StartInfo.UseShellExecute = false;
            processEnroll.StartInfo.CreateNoWindow = true;
            processEnroll.StartInfo.FileName = "enroll.exe";
            processEnroll.StartInfo.RedirectStandardInput = true;
            processEnroll.Start();
            processEnroll.StandardInput.WriteLine(studentIDLabel.Text);
            processEnroll.StandardInput.WriteLine(courseIDBox.Text);
            processEnroll.WaitForExit();
            if (processEnroll.HasExited)
            {
                string enrollState = processEnroll.StandardOutput.ReadToEnd();
                MessageBox.Show(enrollState);
            }
            processEnroll.Close();

            refreshCourseGridView();
            courseIDBox.Text = "";
        }

        private void dropbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(courseIDBox.Text))
            {
                MessageBox.Show("课程号不能为空");
                return;
            }
            Process processDrop = new Process();
            processDrop.StartInfo.RedirectStandardOutput = true;
            processDrop.StartInfo.UseShellExecute = false;
            processDrop.StartInfo.CreateNoWindow = true;
            processDrop.StartInfo.FileName = "drop.exe";
            processDrop.StartInfo.RedirectStandardInput = true;
            processDrop.Start();
            processDrop.StandardInput.WriteLine(studentIDLabel.Text);
            processDrop.StandardInput.WriteLine(courseIDBox.Text);
            processDrop.WaitForExit();
            if (processDrop.HasExited)
            {
                string dropState = processDrop.StandardOutput.ReadToEnd();
                MessageBox.Show(dropState);
            }
            processDrop.Close();

            refreshCourseGridView();
            courseIDBox.Text = "";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            courseTable.Visible = false;
            searchLabel.Visible = true;
            searchGridView.Visible = true;
            searchBox.Visible = true;
            searchBox.Text = "";
            
            
            refreshSearchGridView();
        }

        private void refreshSearchResult()
        {
            // clear searchGriddView
            while (this.searchGridView.Rows.Count != 0)
            {
                this.searchGridView.Rows.RemoveAt(0);
            }

            Process processSearch = new Process();
            processSearch.StartInfo.UseShellExecute = false;
            processSearch.StartInfo.CreateNoWindow = true;
            processSearch.StartInfo.FileName = "search.exe";
            processSearch.StartInfo.RedirectStandardInput = true;
            processSearch.Start();
            processSearch.StandardInput.WriteLine(searchBox.Text);
            processSearch.WaitForExit();
            if (processSearch.HasExited)
            {

                StreamReader searchReader = new StreamReader("searchResult.dat", Encoding.GetEncoding("GB2312"));

                string searchGridData;
                searchGridData = searchReader.ReadLine();
                while (searchGridData != null)
                {
                    int index = this.searchGridView.Rows.Add();
                    for (int i = 0; i < 13; i++)
                    {
                        if (i > 0)
                            searchGridData = searchReader.ReadLine();
                        this.searchGridView.Rows[index].Cells[i].Value = searchGridData;
                    }
                    searchGridData = searchReader.ReadLine();
                }

                searchReader.Close();
            }
            processSearch.Close();
            searchBox.Text = "";
        }
        private void searchStartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                refreshSearchGridView();
                return;
            }

            refreshSearchResult();
        }

        private void refreshCourseTable()
        {
            // clear courseTable
            while (this.courseTable.Rows.Count != 0)
            {
                this.courseTable.Rows.RemoveAt(0);
            }

            DataTable dt = new DataTable("课程表");
            dt.Columns.Add("周 节", typeof(string));
            dt.Columns.Add("周一", typeof(string));
            dt.Columns.Add("周二", typeof(string));
            dt.Columns.Add("周三", typeof(string));
            dt.Columns.Add("周四", typeof(string));
            dt.Columns.Add("周五", typeof(string));
            dt.Columns.Add("周六", typeof(string));
            dt.Columns.Add("周日", typeof(string));
            for (int i = 0; i < 14; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
            for(int j = 1; j < 15; j++)
                dt.Rows[j-1][0] = string.Format("第{0}节", j);
            
            int weekday, courseStart, courseEnd;
            Process processListAll = new Process();
            processListAll.StartInfo.UseShellExecute = false;
            processListAll.StartInfo.CreateNoWindow = true;
            processListAll.StartInfo.FileName = "listAll.exe";
            processListAll.StartInfo.RedirectStandardInput = true;
            processListAll.Start();
            processListAll.StandardInput.WriteLine(studentIDLabel.Text);
            processListAll.WaitForExit();
            if (processListAll.HasExited)
            {

                StreamReader courseTableReader = new StreamReader("courseTable.dat", Encoding.GetEncoding("GB2312"));

                string courseTableGridData;
                courseTableGridData = courseTableReader.ReadLine();
                while (courseTableGridData != null)
                {
                    if(courseTableGridData.Contains("NULL"))
                        break;
                    string[] tmp = courseTableGridData.Split(' ');

                    weekday = Convert.ToInt32(tmp[0]);
                    courseStart = Convert.ToInt32(tmp[1]);
                    courseEnd = Convert.ToInt32(tmp[2]);

                    courseTableGridData = courseTableReader.ReadLine().ToString() + "\n" + courseTableReader.ReadLine().ToString() + "\n" + courseTableReader.ReadLine().ToString() + "\n" + courseTableReader.ReadLine().ToString();
         
                    for (int j = courseStart; j <= courseEnd; j++)
                        dt.Rows[j][weekday] = courseTableGridData;

                    courseTableGridData = courseTableReader.ReadLine();
                }

                courseTableReader.Close();
            }
            processListAll.Close();

            this.courseTable.DataSource = dt;
            foreach (DataGridViewColumn column in courseTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void listButton_Click(object sender, EventArgs e)
        {
            courseTable.Visible = true;
            courseTable.BringToFront();
            searchBox.Visible = false;
            searchGridView.Visible = false;
            searchLabel.Visible = false;

            refreshCourseTable();
        }

    }
}
