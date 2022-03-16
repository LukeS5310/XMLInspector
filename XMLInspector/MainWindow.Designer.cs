namespace XMLInspector
{
    partial class MainWindow
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
            this.BTN_SelectFolder = new System.Windows.Forms.Button();
            this.LBL_Path = new System.Windows.Forms.Label();
            this.FBD_Sel = new System.Windows.Forms.FolderBrowserDialog();
            this.GB_WorkFolder = new System.Windows.Forms.GroupBox();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.GB_CheckState = new System.Windows.Forms.GroupBox();
            this.LBL_DOUBLES_FOUND = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBL_ERRS_FOUND = new System.Windows.Forms.Label();
            this.LBL_FilesChecked = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBL_FileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GB_Report = new System.Windows.Forms.GroupBox();
            this.LBL_LastReportName = new System.Windows.Forms.Label();
            this.BTN_OpenLastReport = new System.Windows.Forms.Button();
            this.BTN_OpenReportFolder = new System.Windows.Forms.Button();
            this.BW_Process = new System.ComponentModel.BackgroundWorker();
            this.GB_SysNumDoubles = new System.Windows.Forms.GroupBox();
            this.LBL_SYSNUMSTOTAL = new System.Windows.Forms.Label();
            this.LBL_CONNSTAT = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GB_WorkFolder.SuspendLayout();
            this.GB_CheckState.SuspendLayout();
            this.GB_Report.SuspendLayout();
            this.GB_SysNumDoubles.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_SelectFolder
            // 
            this.BTN_SelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SelectFolder.Location = new System.Drawing.Point(4, 17);
            this.BTN_SelectFolder.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_SelectFolder.Name = "BTN_SelectFolder";
            this.BTN_SelectFolder.Size = new System.Drawing.Size(56, 24);
            this.BTN_SelectFolder.TabIndex = 0;
            this.BTN_SelectFolder.Text = "Обзор...";
            this.BTN_SelectFolder.UseVisualStyleBackColor = true;
            this.BTN_SelectFolder.Click += new System.EventHandler(this.BTN_SelectFolder_Click);
            // 
            // LBL_Path
            // 
            this.LBL_Path.AutoSize = true;
            this.LBL_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Path.Location = new System.Drawing.Point(65, 23);
            this.LBL_Path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_Path.Name = "LBL_Path";
            this.LBL_Path.Size = new System.Drawing.Size(35, 13);
            this.LBL_Path.TabIndex = 1;
            this.LBL_Path.Text = "label1";
            // 
            // GB_WorkFolder
            // 
            this.GB_WorkFolder.Controls.Add(this.BTN_SelectFolder);
            this.GB_WorkFolder.Controls.Add(this.LBL_Path);
            this.GB_WorkFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_WorkFolder.Location = new System.Drawing.Point(9, 10);
            this.GB_WorkFolder.Margin = new System.Windows.Forms.Padding(2);
            this.GB_WorkFolder.Name = "GB_WorkFolder";
            this.GB_WorkFolder.Padding = new System.Windows.Forms.Padding(2);
            this.GB_WorkFolder.Size = new System.Drawing.Size(344, 50);
            this.GB_WorkFolder.TabIndex = 2;
            this.GB_WorkFolder.TabStop = false;
            this.GB_WorkFolder.Text = "Рабочая Папка";
            // 
            // BTN_Start
            // 
            this.BTN_Start.Location = new System.Drawing.Point(14, 65);
            this.BTN_Start.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(339, 24);
            this.BTN_Start.TabIndex = 3;
            this.BTN_Start.Text = "СТАРТ";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // GB_CheckState
            // 
            this.GB_CheckState.Controls.Add(this.LBL_DOUBLES_FOUND);
            this.GB_CheckState.Controls.Add(this.label6);
            this.GB_CheckState.Controls.Add(this.LBL_ERRS_FOUND);
            this.GB_CheckState.Controls.Add(this.LBL_FilesChecked);
            this.GB_CheckState.Controls.Add(this.label4);
            this.GB_CheckState.Controls.Add(this.label3);
            this.GB_CheckState.Controls.Add(this.label2);
            this.GB_CheckState.Controls.Add(this.LBL_FileName);
            this.GB_CheckState.Controls.Add(this.label1);
            this.GB_CheckState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_CheckState.Location = new System.Drawing.Point(14, 95);
            this.GB_CheckState.Margin = new System.Windows.Forms.Padding(2);
            this.GB_CheckState.Name = "GB_CheckState";
            this.GB_CheckState.Padding = new System.Windows.Forms.Padding(2);
            this.GB_CheckState.Size = new System.Drawing.Size(339, 159);
            this.GB_CheckState.TabIndex = 4;
            this.GB_CheckState.TabStop = false;
            this.GB_CheckState.Text = "Процесс проверки";
            // 
            // LBL_DOUBLES_FOUND
            // 
            this.LBL_DOUBLES_FOUND.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_DOUBLES_FOUND.Location = new System.Drawing.Point(133, 70);
            this.LBL_DOUBLES_FOUND.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_DOUBLES_FOUND.Name = "LBL_DOUBLES_FOUND";
            this.LBL_DOUBLES_FOUND.Size = new System.Drawing.Size(77, 43);
            this.LBL_DOUBLES_FOUND.TabIndex = 8;
            this.LBL_DOUBLES_FOUND.Text = "0";
            this.LBL_DOUBLES_FOUND.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(130, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 31);
            this.label6.TabIndex = 7;
            this.label6.Text = "Двойников обнаружено";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_ERRS_FOUND
            // 
            this.LBL_ERRS_FOUND.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_ERRS_FOUND.Location = new System.Drawing.Point(257, 70);
            this.LBL_ERRS_FOUND.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_ERRS_FOUND.Name = "LBL_ERRS_FOUND";
            this.LBL_ERRS_FOUND.Size = new System.Drawing.Size(77, 43);
            this.LBL_ERRS_FOUND.TabIndex = 6;
            this.LBL_ERRS_FOUND.Text = "0";
            this.LBL_ERRS_FOUND.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_FilesChecked
            // 
            this.LBL_FilesChecked.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_FilesChecked.Location = new System.Drawing.Point(8, 70);
            this.LBL_FilesChecked.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_FilesChecked.Name = "LBL_FilesChecked";
            this.LBL_FilesChecked.Size = new System.Drawing.Size(77, 43);
            this.LBL_FilesChecked.TabIndex = 5;
            this.LBL_FilesChecked.Text = "0";
            this.LBL_FilesChecked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(255, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ошибок обнаружено";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Файлов проверено";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Структурная проверка:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBL_FileName
            // 
            this.LBL_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_FileName.Location = new System.Drawing.Point(47, 18);
            this.LBL_FileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_FileName.Name = "LBL_FileName";
            this.LBL_FileName.Size = new System.Drawing.Size(287, 28);
            this.LBL_FileName.TabIndex = 1;
            this.LBL_FileName.Text = "Выберите папку и нажмите СТАРТ для проверки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файл:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GB_Report
            // 
            this.GB_Report.Controls.Add(this.LBL_LastReportName);
            this.GB_Report.Controls.Add(this.BTN_OpenLastReport);
            this.GB_Report.Controls.Add(this.BTN_OpenReportFolder);
            this.GB_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_Report.Location = new System.Drawing.Point(9, 260);
            this.GB_Report.Margin = new System.Windows.Forms.Padding(2);
            this.GB_Report.Name = "GB_Report";
            this.GB_Report.Padding = new System.Windows.Forms.Padding(2);
            this.GB_Report.Size = new System.Drawing.Size(344, 98);
            this.GB_Report.TabIndex = 5;
            this.GB_Report.TabStop = false;
            this.GB_Report.Text = "Файл Отчета";
            // 
            // LBL_LastReportName
            // 
            this.LBL_LastReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_LastReportName.Location = new System.Drawing.Point(4, 45);
            this.LBL_LastReportName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_LastReportName.Name = "LBL_LastReportName";
            this.LBL_LastReportName.Size = new System.Drawing.Size(334, 22);
            this.LBL_LastReportName.TabIndex = 4;
            this.LBL_LastReportName.Text = "Имя последнего сформированного отчета будет здесь";
            this.LBL_LastReportName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_OpenLastReport
            // 
            this.BTN_OpenLastReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_OpenLastReport.Location = new System.Drawing.Point(4, 69);
            this.BTN_OpenLastReport.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_OpenLastReport.Name = "BTN_OpenLastReport";
            this.BTN_OpenLastReport.Size = new System.Drawing.Size(334, 24);
            this.BTN_OpenLastReport.TabIndex = 1;
            this.BTN_OpenLastReport.Text = "Открыть последний отчет";
            this.BTN_OpenLastReport.UseVisualStyleBackColor = true;
            this.BTN_OpenLastReport.Click += new System.EventHandler(this.BTN_OpenLastReport_Click);
            // 
            // BTN_OpenReportFolder
            // 
            this.BTN_OpenReportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_OpenReportFolder.Location = new System.Drawing.Point(4, 18);
            this.BTN_OpenReportFolder.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_OpenReportFolder.Name = "BTN_OpenReportFolder";
            this.BTN_OpenReportFolder.Size = new System.Drawing.Size(334, 24);
            this.BTN_OpenReportFolder.TabIndex = 0;
            this.BTN_OpenReportFolder.Text = "Открыть папку с отчетами";
            this.BTN_OpenReportFolder.UseVisualStyleBackColor = true;
            this.BTN_OpenReportFolder.Click += new System.EventHandler(this.BTN_OpenReportFolder_Click);
            // 
            // BW_Process
            // 
            this.BW_Process.WorkerReportsProgress = true;
            this.BW_Process.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Process_DoWork);
            this.BW_Process.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_Process_ProgressChanged);
            this.BW_Process.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Process_RunWorkerCompleted);
            // 
            // GB_SysNumDoubles
            // 
            this.GB_SysNumDoubles.Controls.Add(this.LBL_SYSNUMSTOTAL);
            this.GB_SysNumDoubles.Controls.Add(this.LBL_CONNSTAT);
            this.GB_SysNumDoubles.Controls.Add(this.label7);
            this.GB_SysNumDoubles.Controls.Add(this.label5);
            this.GB_SysNumDoubles.Location = new System.Drawing.Point(9, 364);
            this.GB_SysNumDoubles.Margin = new System.Windows.Forms.Padding(2);
            this.GB_SysNumDoubles.Name = "GB_SysNumDoubles";
            this.GB_SysNumDoubles.Padding = new System.Windows.Forms.Padding(2);
            this.GB_SysNumDoubles.Size = new System.Drawing.Size(344, 49);
            this.GB_SysNumDoubles.TabIndex = 6;
            this.GB_SysNumDoubles.TabStop = false;
            this.GB_SysNumDoubles.Text = "База учета Системных номеров";
            // 
            // LBL_SYSNUMSTOTAL
            // 
            this.LBL_SYSNUMSTOTAL.AutoSize = true;
            this.LBL_SYSNUMSTOTAL.Location = new System.Drawing.Point(179, 28);
            this.LBL_SYSNUMSTOTAL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_SYSNUMSTOTAL.Name = "LBL_SYSNUMSTOTAL";
            this.LBL_SYSNUMSTOTAL.Size = new System.Drawing.Size(85, 13);
            this.LBL_SYSNUMSTOTAL.TabIndex = 3;
            this.LBL_SYSNUMSTOTAL.Text = "Подключение...";
            // 
            // LBL_CONNSTAT
            // 
            this.LBL_CONNSTAT.AutoSize = true;
            this.LBL_CONNSTAT.Location = new System.Drawing.Point(179, 14);
            this.LBL_CONNSTAT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_CONNSTAT.Name = "LBL_CONNSTAT";
            this.LBL_CONNSTAT.Size = new System.Drawing.Size(85, 13);
            this.LBL_CONNSTAT.TabIndex = 2;
            this.LBL_CONNSTAT.Text = "Подключение...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Номеров в базе:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Подключение:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 421);
            this.Controls.Add(this.GB_SysNumDoubles);
            this.Controls.Add(this.GB_Report);
            this.Controls.Add(this.GB_CheckState);
            this.Controls.Add(this.BTN_Start);
            this.Controls.Add(this.GB_WorkFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "XML Inspector 1.6.0 (16.03.2022)";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.GB_WorkFolder.ResumeLayout(false);
            this.GB_WorkFolder.PerformLayout();
            this.GB_CheckState.ResumeLayout(false);
            this.GB_CheckState.PerformLayout();
            this.GB_Report.ResumeLayout(false);
            this.GB_SysNumDoubles.ResumeLayout(false);
            this.GB_SysNumDoubles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_SelectFolder;
        private System.Windows.Forms.Label LBL_Path;
        private System.Windows.Forms.FolderBrowserDialog FBD_Sel;
        private System.Windows.Forms.GroupBox GB_WorkFolder;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.GroupBox GB_CheckState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_FileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GB_Report;
        private System.Windows.Forms.Button BTN_OpenReportFolder;
        private System.Windows.Forms.Label LBL_LastReportName;
        private System.Windows.Forms.Button BTN_OpenLastReport;
        private System.ComponentModel.BackgroundWorker BW_Process;
        private System.Windows.Forms.Label LBL_ERRS_FOUND;
        private System.Windows.Forms.Label LBL_FilesChecked;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBL_DOUBLES_FOUND;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox GB_SysNumDoubles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBL_SYSNUMSTOTAL;
        private System.Windows.Forms.Label LBL_CONNSTAT;
    }
}

