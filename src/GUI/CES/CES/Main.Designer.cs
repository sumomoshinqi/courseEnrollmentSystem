namespace CES
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.studentLabel = new System.Windows.Forms.Label();
            this.studentIDLabel = new System.Windows.Forms.Label();
            this.courseIDLabel = new System.Windows.Forms.Label();
            this.courseIDBox = new System.Windows.Forms.TextBox();
            this.enrollButton = new System.Windows.Forms.Button();
            this.dropbutton = new System.Windows.Forms.Button();
            this.listButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.avatarBox = new System.Windows.Forms.PictureBox();
            this.courseListLabel = new System.Windows.Forms.Label();
            this.courseGridView = new System.Windows.Forms.DataGridView();
            this.courseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseTable = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchStartButton = new System.Windows.Forms.Button();
            this.searchGridView = new System.Windows.Forms.DataGridView();
            this.searchCourseVacancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseRestriction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseTeacherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // studentLabel
            // 
            this.studentLabel.AutoSize = true;
            this.studentLabel.Font = new System.Drawing.Font("宋体", 11F);
            this.studentLabel.Location = new System.Drawing.Point(99, 43);
            this.studentLabel.Name = "studentLabel";
            this.studentLabel.Size = new System.Drawing.Size(37, 15);
            this.studentLabel.TabIndex = 0;
            this.studentLabel.Text = "学生";
            // 
            // studentIDLabel
            // 
            this.studentIDLabel.AutoSize = true;
            this.studentIDLabel.Font = new System.Drawing.Font("宋体", 11F);
            this.studentIDLabel.Location = new System.Drawing.Point(100, 66);
            this.studentIDLabel.Name = "studentIDLabel";
            this.studentIDLabel.Size = new System.Drawing.Size(0, 15);
            this.studentIDLabel.TabIndex = 1;
            // 
            // courseIDLabel
            // 
            this.courseIDLabel.AutoSize = true;
            this.courseIDLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.courseIDLabel.Location = new System.Drawing.Point(41, 119);
            this.courseIDLabel.Name = "courseIDLabel";
            this.courseIDLabel.Size = new System.Drawing.Size(63, 14);
            this.courseIDLabel.TabIndex = 2;
            this.courseIDLabel.Text = "课程代码";
            // 
            // courseIDBox
            // 
            this.courseIDBox.Font = new System.Drawing.Font("宋体", 10F);
            this.courseIDBox.Location = new System.Drawing.Point(110, 115);
            this.courseIDBox.Name = "courseIDBox";
            this.courseIDBox.Size = new System.Drawing.Size(100, 23);
            this.courseIDBox.TabIndex = 3;
            // 
            // enrollButton
            // 
            this.enrollButton.Location = new System.Drawing.Point(44, 152);
            this.enrollButton.Name = "enrollButton";
            this.enrollButton.Size = new System.Drawing.Size(166, 25);
            this.enrollButton.TabIndex = 4;
            this.enrollButton.Text = "选课";
            this.enrollButton.UseVisualStyleBackColor = true;
            this.enrollButton.Click += new System.EventHandler(this.enrollButton_Click);
            // 
            // dropbutton
            // 
            this.dropbutton.Location = new System.Drawing.Point(44, 183);
            this.dropbutton.Name = "dropbutton";
            this.dropbutton.Size = new System.Drawing.Size(166, 25);
            this.dropbutton.TabIndex = 5;
            this.dropbutton.Text = "退课";
            this.dropbutton.UseVisualStyleBackColor = true;
            this.dropbutton.Click += new System.EventHandler(this.dropbutton_Click);
            // 
            // listButton
            // 
            this.listButton.Location = new System.Drawing.Point(44, 214);
            this.listButton.Name = "listButton";
            this.listButton.Size = new System.Drawing.Size(166, 25);
            this.listButton.TabIndex = 6;
            this.listButton.Text = "显示课表";
            this.listButton.UseVisualStyleBackColor = true;
            this.listButton.Click += new System.EventHandler(this.listButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(44, 245);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(166, 25);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "可选课程";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(44, 303);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(166, 25);
            this.logoutButton.TabIndex = 8;
            this.logoutButton.Text = "退出";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // avatarBox
            // 
            this.avatarBox.Image = ((System.Drawing.Image)(resources.GetObject("avatarBox.Image")));
            this.avatarBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("avatarBox.InitialImage")));
            this.avatarBox.Location = new System.Drawing.Point(28, 27);
            this.avatarBox.Name = "avatarBox";
            this.avatarBox.Size = new System.Drawing.Size(64, 64);
            this.avatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.avatarBox.TabIndex = 9;
            this.avatarBox.TabStop = false;
            // 
            // courseListLabel
            // 
            this.courseListLabel.AutoSize = true;
            this.courseListLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.courseListLabel.Location = new System.Drawing.Point(29, 345);
            this.courseListLabel.Name = "courseListLabel";
            this.courseListLabel.Size = new System.Drawing.Size(63, 14);
            this.courseListLabel.TabIndex = 11;
            this.courseListLabel.Text = "已选课程";
            // 
            // courseGridView
            // 
            this.courseGridView.AllowUserToAddRows = false;
            this.courseGridView.AllowUserToDeleteRows = false;
            this.courseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.courseID,
            this.courseName});
            this.courseGridView.Location = new System.Drawing.Point(28, 373);
            this.courseGridView.Name = "courseGridView";
            this.courseGridView.ReadOnly = true;
            this.courseGridView.RowHeadersVisible = false;
            this.courseGridView.RowTemplate.Height = 23;
            this.courseGridView.Size = new System.Drawing.Size(204, 137);
            this.courseGridView.TabIndex = 13;
            // 
            // courseID
            // 
            this.courseID.HeaderText = "课程代码";
            this.courseID.Name = "courseID";
            this.courseID.ReadOnly = true;
            // 
            // courseName
            // 
            this.courseName.HeaderText = "课程名称";
            this.courseName.Name = "courseName";
            this.courseName.ReadOnly = true;
            // 
            // courseTable
            // 
            this.courseTable.AllowUserToAddRows = false;
            this.courseTable.AllowUserToDeleteRows = false;
            this.courseTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.courseTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.courseTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.courseTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseTable.Location = new System.Drawing.Point(238, 8);
            this.courseTable.Name = "courseTable";
            this.courseTable.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.courseTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.courseTable.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.courseTable.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.courseTable.RowTemplate.Height = 23;
            this.courseTable.Size = new System.Drawing.Size(684, 504);
            this.courseTable.TabIndex = 17;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("宋体", 10F);
            this.searchBox.Location = new System.Drawing.Point(424, 24);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 23);
            this.searchBox.TabIndex = 15;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.searchLabel.Location = new System.Drawing.Point(244, 28);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(175, 14);
            this.searchLabel.TabIndex = 15;
            this.searchLabel.Text = "课程代码 / 课程名称 包含";
            // 
            // searchStartButton
            // 
            this.searchStartButton.Location = new System.Drawing.Point(542, 22);
            this.searchStartButton.Name = "searchStartButton";
            this.searchStartButton.Size = new System.Drawing.Size(78, 25);
            this.searchStartButton.TabIndex = 15;
            this.searchStartButton.Text = "查询";
            this.searchStartButton.UseVisualStyleBackColor = true;
            this.searchStartButton.Click += new System.EventHandler(this.searchStartButton_Click);
            // 
            // searchGridView
            // 
            this.searchGridView.AllowUserToAddRows = false;
            this.searchGridView.AllowUserToDeleteRows = false;
            this.searchGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.searchCourseID,
            this.searchCourseName,
            this.searchCourseType,
            this.searchCourseCredit,
            this.searchCourseTeacher,
            this.searchCourseTeacherType,
            this.searchCourseClassroom,
            this.searchCourseTime,
            this.searchCourseNote,
            this.searchCourseDept,
            this.searchCourseRestriction,
            this.searchCourseTaken,
            this.searchCourseVacancy});
            this.searchGridView.Location = new System.Drawing.Point(247, 66);
            this.searchGridView.Name = "searchGridView";
            this.searchGridView.ReadOnly = true;
            this.searchGridView.RowHeadersVisible = false;
            this.searchGridView.RowTemplate.Height = 23;
            this.searchGridView.Size = new System.Drawing.Size(671, 444);
            this.searchGridView.TabIndex = 16;
            // 
            // searchCourseVacancy
            // 
            this.searchCourseVacancy.HeaderText = "人数限制";
            this.searchCourseVacancy.Name = "searchCourseVacancy";
            this.searchCourseVacancy.ReadOnly = true;
            // 
            // searchCourseTaken
            // 
            this.searchCourseTaken.HeaderText = "已选人数";
            this.searchCourseTaken.Name = "searchCourseTaken";
            this.searchCourseTaken.ReadOnly = true;
            // 
            // searchCourseRestriction
            // 
            this.searchCourseRestriction.HeaderText = "选课限制条件";
            this.searchCourseRestriction.Name = "searchCourseRestriction";
            this.searchCourseRestriction.ReadOnly = true;
            // 
            // searchCourseDept
            // 
            this.searchCourseDept.HeaderText = "开课院系";
            this.searchCourseDept.Name = "searchCourseDept";
            this.searchCourseDept.ReadOnly = true;
            // 
            // searchCourseNote
            // 
            this.searchCourseNote.HeaderText = "备注";
            this.searchCourseNote.Name = "searchCourseNote";
            this.searchCourseNote.ReadOnly = true;
            // 
            // searchCourseTime
            // 
            this.searchCourseTime.HeaderText = "时间";
            this.searchCourseTime.Name = "searchCourseTime";
            this.searchCourseTime.ReadOnly = true;
            // 
            // searchCourseClassroom
            // 
            this.searchCourseClassroom.HeaderText = "教室";
            this.searchCourseClassroom.Name = "searchCourseClassroom";
            this.searchCourseClassroom.ReadOnly = true;
            // 
            // searchCourseTeacherType
            // 
            this.searchCourseTeacherType.HeaderText = "职称";
            this.searchCourseTeacherType.Name = "searchCourseTeacherType";
            this.searchCourseTeacherType.ReadOnly = true;
            this.searchCourseTeacherType.Width = 80;
            // 
            // searchCourseTeacher
            // 
            this.searchCourseTeacher.HeaderText = "教师";
            this.searchCourseTeacher.Name = "searchCourseTeacher";
            this.searchCourseTeacher.ReadOnly = true;
            this.searchCourseTeacher.Width = 80;
            // 
            // searchCourseCredit
            // 
            this.searchCourseCredit.HeaderText = "学分";
            this.searchCourseCredit.Name = "searchCourseCredit";
            this.searchCourseCredit.ReadOnly = true;
            this.searchCourseCredit.Width = 30;
            // 
            // searchCourseType
            // 
            this.searchCourseType.HeaderText = "性质";
            this.searchCourseType.Name = "searchCourseType";
            this.searchCourseType.ReadOnly = true;
            this.searchCourseType.Width = 20;
            // 
            // searchCourseName
            // 
            this.searchCourseName.HeaderText = "课程名称";
            this.searchCourseName.Name = "searchCourseName";
            this.searchCourseName.ReadOnly = true;
            // 
            // searchCourseID
            // 
            this.searchCourseID.HeaderText = "课程代码";
            this.searchCourseID.Name = "searchCourseID";
            this.searchCourseID.ReadOnly = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 528);
            this.Controls.Add(this.searchStartButton);
            this.Controls.Add(this.searchGridView);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.courseGridView);
            this.Controls.Add(this.courseListLabel);
            this.Controls.Add(this.courseTable);
            this.Controls.Add(this.avatarBox);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.listButton);
            this.Controls.Add(this.dropbutton);
            this.Controls.Add(this.enrollButton);
            this.Controls.Add(this.courseIDBox);
            this.Controls.Add(this.courseIDLabel);
            this.Controls.Add(this.studentIDLabel);
            this.Controls.Add(this.studentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生选课系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.avatarBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label studentLabel;
        private System.Windows.Forms.Label studentIDLabel;
        private System.Windows.Forms.Label courseIDLabel;
        private System.Windows.Forms.TextBox courseIDBox;
        private System.Windows.Forms.Button enrollButton;
        private System.Windows.Forms.Button dropbutton;
        private System.Windows.Forms.Button listButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.PictureBox avatarBox;
        private System.Windows.Forms.Label courseListLabel;
        private System.Windows.Forms.DataGridView courseGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseName;
        private System.Windows.Forms.DataGridView courseTable;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button searchStartButton;
        private System.Windows.Forms.DataGridView searchGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseTeacherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseClassroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseRestriction;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchCourseVacancy;
    }
}