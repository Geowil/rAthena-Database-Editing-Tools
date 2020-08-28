namespace rAthena_Database_Editing_Tools
{
    partial class sql_file_form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sql_file_form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxPrimaryFileList = new System.Windows.Forms.TextBox();
            this.tboxSecondaryFileList = new System.Windows.Forms.TextBox();
            this.tboxGenFileDir = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.fldBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.tboxSourceFileDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboxCustItemLocal = new System.Windows.Forms.ComboBox();
            this.cboxCustMobLocal = new System.Windows.Forms.ComboBox();
            this.ckboxUseSecondary = new System.Windows.Forms.CheckBox();
            this.ckboxUseCustom = new System.Windows.Forms.CheckBox();
            this.cboxDataSource = new System.Windows.Forms.ComboBox();
            this.tboxCustFileList = new System.Windows.Forms.TextBox();
            this.ckboxInAppErrs = new System.Windows.Forms.CheckBox();
            this.nudLogLevel = new System.Windows.Forms.NumericUpDown();
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpDFSettings = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDBSettings = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.ckboxUseRE = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tpOtherSettings = new System.Windows.Forms.TabPage();
            this.ckboxLogLvlsIndy = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tboxErrSufx = new System.Windows.Forms.TextBox();
            this.tboxWarnSufx = new System.Windows.Forms.TextBox();
            this.tboxInfoSufx = new System.Windows.Forms.TextBox();
            this.lblErrSufx = new System.Windows.Forms.Label();
            this.lblWarnSufx = new System.Windows.Forms.Label();
            this.lblInfoSufx = new System.Windows.Forms.Label();
            this.lblLogLvl = new System.Windows.Forms.Label();
            this.ckboxLogging = new System.Windows.Forms.CheckBox();
            this.btnBrowseLog = new System.Windows.Forms.Button();
            this.tboxLogDir = new System.Windows.Forms.TextBox();
            this.lblLogDir = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxSrcFileExt = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLogLevel)).BeginInit();
            this.tcSettings.SuspendLayout();
            this.tpDFSettings.SuspendLayout();
            this.tbDBSettings.SuspendLayout();
            this.tpOtherSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary Source File List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Generated Files Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Secondary Source File List";
            // 
            // tboxPrimaryFileList
            // 
            this.tboxPrimaryFileList.Location = new System.Drawing.Point(23, 33);
            this.tboxPrimaryFileList.Name = "tboxPrimaryFileList";
            this.tboxPrimaryFileList.Size = new System.Drawing.Size(243, 20);
            this.tboxPrimaryFileList.TabIndex = 3;
            // 
            // tboxSecondaryFileList
            // 
            this.tboxSecondaryFileList.Location = new System.Drawing.Point(23, 85);
            this.tboxSecondaryFileList.Name = "tboxSecondaryFileList";
            this.tboxSecondaryFileList.Size = new System.Drawing.Size(243, 20);
            this.tboxSecondaryFileList.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tboxSecondaryFileList, "Custom file names should be in the format for <regular_file_name>_custom\r\n\r\nEX: i" +
        "tem_db_custom");
            // 
            // tboxGenFileDir
            // 
            this.tboxGenFileDir.Location = new System.Drawing.Point(23, 202);
            this.tboxGenFileDir.Name = "tboxGenFileDir";
            this.tboxGenFileDir.Size = new System.Drawing.Size(243, 20);
            this.tboxGenFileDir.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(272, 202);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 20);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.openDialog);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(140, 420);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.saveSettings);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(272, 257);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(32, 20);
            this.btnBrowse2.TabIndex = 10;
            this.btnBrowse2.Text = "...";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.openDialog);
            // 
            // tboxSourceFileDir
            // 
            this.tboxSourceFileDir.Location = new System.Drawing.Point(23, 258);
            this.tboxSourceFileDir.Name = "tboxSourceFileDir";
            this.tboxSourceFileDir.Size = new System.Drawing.Size(243, 20);
            this.tboxSourceFileDir.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Source Files Directory";
            // 
            // cboxCustItemLocal
            // 
            this.cboxCustItemLocal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCustItemLocal.FormattingEnabled = true;
            this.cboxCustItemLocal.Items.AddRange(new object[] {
            "item_db"});
            this.cboxCustItemLocal.Location = new System.Drawing.Point(192, 7);
            this.cboxCustItemLocal.Name = "cboxCustItemLocal";
            this.cboxCustItemLocal.Size = new System.Drawing.Size(121, 25);
            this.cboxCustItemLocal.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cboxCustItemLocal, "Select the file or table where your items sould be stored\r\nwhen generated.  These" +
        " generatd versions will be\r\nformatted for your chosen database solution as per\r\n" +
        "the \"Data Source\" field below.");
            // 
            // cboxCustMobLocal
            // 
            this.cboxCustMobLocal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxCustMobLocal.FormattingEnabled = true;
            this.cboxCustMobLocal.Items.AddRange(new object[] {
            "mob_db"});
            this.cboxCustMobLocal.Location = new System.Drawing.Point(192, 48);
            this.cboxCustMobLocal.Name = "cboxCustMobLocal";
            this.cboxCustMobLocal.Size = new System.Drawing.Size(121, 25);
            this.cboxCustMobLocal.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cboxCustMobLocal, "Select the file or table where your mobs sould be stored\r\nwhen generated.  These " +
        "generatd versions will be\r\nformatted for your chosen database solution as per\r\nt" +
        "he \"Data Source\" field below.\r\n");
            // 
            // ckboxUseSecondary
            // 
            this.ckboxUseSecondary.AutoSize = true;
            this.ckboxUseSecondary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckboxUseSecondary.Location = new System.Drawing.Point(9, 163);
            this.ckboxUseSecondary.Name = "ckboxUseSecondary";
            this.ckboxUseSecondary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckboxUseSecondary.Size = new System.Drawing.Size(193, 21);
            this.ckboxUseSecondary.TabIndex = 5;
            this.ckboxUseSecondary.Text = "Use Secondary Source Files";
            this.toolTip1.SetToolTip(this.ckboxUseSecondary, "IE: item_db2, item_db2_re, etc.");
            this.ckboxUseSecondary.UseVisualStyleBackColor = true;
            this.ckboxUseSecondary.CheckedChanged += new System.EventHandler(this.OnSrcFileCheckedChanged);
            // 
            // ckboxUseCustom
            // 
            this.ckboxUseCustom.AutoSize = true;
            this.ckboxUseCustom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckboxUseCustom.Location = new System.Drawing.Point(9, 190);
            this.ckboxUseCustom.Name = "ckboxUseCustom";
            this.ckboxUseCustom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckboxUseCustom.Size = new System.Drawing.Size(177, 21);
            this.ckboxUseCustom.TabIndex = 6;
            this.ckboxUseCustom.Text = "Use Custom Source Files";
            this.toolTip1.SetToolTip(this.ckboxUseCustom, "If you have custom items or mobs and don\'t want to import them with official impo" +
        "rt files, check this and set your files names in Directory and File Settings tab" +
        ".");
            this.ckboxUseCustom.UseVisualStyleBackColor = true;
            // 
            // cboxDataSource
            // 
            this.cboxDataSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDataSource.FormattingEnabled = true;
            this.cboxDataSource.Items.AddRange(new object[] {
            "Flat Files",
            "MySQL Database"});
            this.cboxDataSource.Location = new System.Drawing.Point(192, 90);
            this.cboxDataSource.Name = "cboxDataSource";
            this.cboxDataSource.Size = new System.Drawing.Size(121, 25);
            this.cboxDataSource.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cboxDataSource, "Flat Files: Use rAthena\\db folder tables\r\nMySQL Database: Use SQL database tables" +
        "");
            // 
            // tboxCustFileList
            // 
            this.tboxCustFileList.Location = new System.Drawing.Point(23, 140);
            this.tboxCustFileList.Name = "tboxCustFileList";
            this.tboxCustFileList.Size = new System.Drawing.Size(243, 20);
            this.tboxCustFileList.TabIndex = 12;
            this.toolTip1.SetToolTip(this.tboxCustFileList, "Custom file names should be in the format for <regular_file_name>_custom\r\n\r\nEX: i" +
        "tem_db_custom");
            // 
            // ckboxInAppErrs
            // 
            this.ckboxInAppErrs.AutoSize = true;
            this.ckboxInAppErrs.BackColor = System.Drawing.Color.Azure;
            this.ckboxInAppErrs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckboxInAppErrs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ckboxInAppErrs.Location = new System.Drawing.Point(3, 12);
            this.ckboxInAppErrs.Name = "ckboxInAppErrs";
            this.ckboxInAppErrs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckboxInAppErrs.Size = new System.Drawing.Size(186, 21);
            this.ckboxInAppErrs.TabIndex = 23;
            this.ckboxInAppErrs.Text = "Report Data Errors In App";
            this.toolTip1.SetToolTip(this.ckboxInAppErrs, resources.GetString("ckboxInAppErrs.ToolTip"));
            this.ckboxInAppErrs.UseVisualStyleBackColor = false;
            // 
            // nudLogLevel
            // 
            this.nudLogLevel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nudLogLevel.Enabled = false;
            this.nudLogLevel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nudLogLevel.Location = new System.Drawing.Point(157, 80);
            this.nudLogLevel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudLogLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLogLevel.Name = "nudLogLevel";
            this.nudLogLevel.Size = new System.Drawing.Size(44, 20);
            this.nudLogLevel.TabIndex = 29;
            this.toolTip1.SetToolTip(this.nudLogLevel, resources.GetString("nudLogLevel.ToolTip"));
            this.nudLogLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpDFSettings);
            this.tcSettings.Controls.Add(this.tbDBSettings);
            this.tcSettings.Controls.Add(this.tpOtherSettings);
            this.tcSettings.Location = new System.Drawing.Point(10, 56);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(334, 354);
            this.tcSettings.TabIndex = 14;
            // 
            // tpDFSettings
            // 
            this.tpDFSettings.BackColor = System.Drawing.Color.Azure;
            this.tpDFSettings.Controls.Add(this.cboxSrcFileExt);
            this.tpDFSettings.Controls.Add(this.label5);
            this.tpDFSettings.Controls.Add(this.label9);
            this.tpDFSettings.Controls.Add(this.tboxCustFileList);
            this.tpDFSettings.Controls.Add(this.label1);
            this.tpDFSettings.Controls.Add(this.label2);
            this.tpDFSettings.Controls.Add(this.label3);
            this.tpDFSettings.Controls.Add(this.tboxPrimaryFileList);
            this.tpDFSettings.Controls.Add(this.btnBrowse2);
            this.tpDFSettings.Controls.Add(this.tboxSecondaryFileList);
            this.tpDFSettings.Controls.Add(this.tboxSourceFileDir);
            this.tpDFSettings.Controls.Add(this.tboxGenFileDir);
            this.tpDFSettings.Controls.Add(this.label4);
            this.tpDFSettings.Controls.Add(this.btnBrowse);
            this.tpDFSettings.Location = new System.Drawing.Point(4, 22);
            this.tpDFSettings.Name = "tpDFSettings";
            this.tpDFSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpDFSettings.Size = new System.Drawing.Size(326, 328);
            this.tpDFSettings.TabIndex = 0;
            this.tpDFSettings.Text = "Directory & File Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Custom Source File List";
            // 
            // tbDBSettings
            // 
            this.tbDBSettings.BackColor = System.Drawing.Color.Azure;
            this.tbDBSettings.Controls.Add(this.label10);
            this.tbDBSettings.Controls.Add(this.cboxDataSource);
            this.tbDBSettings.Controls.Add(this.ckboxUseCustom);
            this.tbDBSettings.Controls.Add(this.ckboxUseSecondary);
            this.tbDBSettings.Controls.Add(this.ckboxUseRE);
            this.tbDBSettings.Controls.Add(this.cboxCustMobLocal);
            this.tbDBSettings.Controls.Add(this.cboxCustItemLocal);
            this.tbDBSettings.Controls.Add(this.label8);
            this.tbDBSettings.Controls.Add(this.label7);
            this.tbDBSettings.Location = new System.Drawing.Point(4, 22);
            this.tbDBSettings.Name = "tbDBSettings";
            this.tbDBSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbDBSettings.Size = new System.Drawing.Size(326, 328);
            this.tbDBSettings.TabIndex = 1;
            this.tbDBSettings.Text = "Database Settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Data Source";
            // 
            // ckboxUseRE
            // 
            this.ckboxUseRE.AutoSize = true;
            this.ckboxUseRE.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckboxUseRE.Location = new System.Drawing.Point(9, 136);
            this.ckboxUseRE.Name = "ckboxUseRE";
            this.ckboxUseRE.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckboxUseRE.Size = new System.Drawing.Size(145, 21);
            this.ckboxUseRE.TabIndex = 4;
            this.ckboxUseRE.Text = "Use RE Source Files";
            this.ckboxUseRE.UseVisualStyleBackColor = true;
            this.ckboxUseRE.CheckedChanged += new System.EventHandler(this.OnSrcFileCheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Custom Mob Save Location";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Custom Item Save Location";
            // 
            // tpOtherSettings
            // 
            this.tpOtherSettings.BackColor = System.Drawing.Color.Azure;
            this.tpOtherSettings.Controls.Add(this.ckboxLogLvlsIndy);
            this.tpOtherSettings.Controls.Add(this.nudLogLevel);
            this.tpOtherSettings.Controls.Add(this.label15);
            this.tpOtherSettings.Controls.Add(this.tboxErrSufx);
            this.tpOtherSettings.Controls.Add(this.tboxWarnSufx);
            this.tpOtherSettings.Controls.Add(this.tboxInfoSufx);
            this.tpOtherSettings.Controls.Add(this.ckboxInAppErrs);
            this.tpOtherSettings.Controls.Add(this.lblErrSufx);
            this.tpOtherSettings.Controls.Add(this.lblWarnSufx);
            this.tpOtherSettings.Controls.Add(this.lblInfoSufx);
            this.tpOtherSettings.Controls.Add(this.lblLogLvl);
            this.tpOtherSettings.Controls.Add(this.ckboxLogging);
            this.tpOtherSettings.Controls.Add(this.btnBrowseLog);
            this.tpOtherSettings.Controls.Add(this.tboxLogDir);
            this.tpOtherSettings.Controls.Add(this.lblLogDir);
            this.tpOtherSettings.Location = new System.Drawing.Point(4, 22);
            this.tpOtherSettings.Name = "tpOtherSettings";
            this.tpOtherSettings.Size = new System.Drawing.Size(326, 289);
            this.tpOtherSettings.TabIndex = 2;
            this.tpOtherSettings.Text = "Other Settings";
            // 
            // ckboxLogLvlsIndy
            // 
            this.ckboxLogLvlsIndy.AutoSize = true;
            this.ckboxLogLvlsIndy.BackColor = System.Drawing.Color.Azure;
            this.ckboxLogLvlsIndy.Enabled = false;
            this.ckboxLogLvlsIndy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckboxLogLvlsIndy.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ckboxLogLvlsIndy.Location = new System.Drawing.Point(3, 106);
            this.ckboxLogLvlsIndy.Name = "ckboxLogLvlsIndy";
            this.ckboxLogLvlsIndy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckboxLogLvlsIndy.Size = new System.Drawing.Size(185, 21);
            this.ckboxLogLvlsIndy.TabIndex = 30;
            this.ckboxLogLvlsIndy.Text = "Log Levels Independently";
            this.ckboxLogLvlsIndy.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(11, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(301, 2);
            this.label15.TabIndex = 28;
            this.label15.Text = "label15";
            // 
            // tboxErrSufx
            // 
            this.tboxErrSufx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tboxErrSufx.Enabled = false;
            this.tboxErrSufx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tboxErrSufx.Location = new System.Drawing.Point(157, 257);
            this.tboxErrSufx.Name = "tboxErrSufx";
            this.tboxErrSufx.Size = new System.Drawing.Size(138, 20);
            this.tboxErrSufx.TabIndex = 26;
            // 
            // tboxWarnSufx
            // 
            this.tboxWarnSufx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tboxWarnSufx.Enabled = false;
            this.tboxWarnSufx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tboxWarnSufx.Location = new System.Drawing.Point(157, 224);
            this.tboxWarnSufx.Name = "tboxWarnSufx";
            this.tboxWarnSufx.Size = new System.Drawing.Size(138, 20);
            this.tboxWarnSufx.TabIndex = 25;
            // 
            // tboxInfoSufx
            // 
            this.tboxInfoSufx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tboxInfoSufx.Enabled = false;
            this.tboxInfoSufx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tboxInfoSufx.Location = new System.Drawing.Point(157, 190);
            this.tboxInfoSufx.Name = "tboxInfoSufx";
            this.tboxInfoSufx.Size = new System.Drawing.Size(138, 20);
            this.tboxInfoSufx.TabIndex = 24;
            // 
            // lblErrSufx
            // 
            this.lblErrSufx.AutoSize = true;
            this.lblErrSufx.Enabled = false;
            this.lblErrSufx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrSufx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblErrSufx.Location = new System.Drawing.Point(3, 257);
            this.lblErrSufx.Name = "lblErrSufx";
            this.lblErrSufx.Size = new System.Drawing.Size(104, 17);
            this.lblErrSufx.TabIndex = 21;
            this.lblErrSufx.Text = "Error File Suffix";
            // 
            // lblWarnSufx
            // 
            this.lblWarnSufx.AutoSize = true;
            this.lblWarnSufx.Enabled = false;
            this.lblWarnSufx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnSufx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblWarnSufx.Location = new System.Drawing.Point(3, 224);
            this.lblWarnSufx.Name = "lblWarnSufx";
            this.lblWarnSufx.Size = new System.Drawing.Size(127, 17);
            this.lblWarnSufx.TabIndex = 20;
            this.lblWarnSufx.Text = "Warning File Suffix";
            // 
            // lblInfoSufx
            // 
            this.lblInfoSufx.AutoSize = true;
            this.lblInfoSufx.Enabled = false;
            this.lblInfoSufx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoSufx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInfoSufx.Location = new System.Drawing.Point(3, 190);
            this.lblInfoSufx.Name = "lblInfoSufx";
            this.lblInfoSufx.Size = new System.Drawing.Size(148, 17);
            this.lblInfoSufx.TabIndex = 19;
            this.lblInfoSufx.Text = "Information File Suffix";
            // 
            // lblLogLvl
            // 
            this.lblLogLvl.AutoSize = true;
            this.lblLogLvl.Enabled = false;
            this.lblLogLvl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogLvl.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLogLvl.Location = new System.Drawing.Point(3, 79);
            this.lblLogLvl.Name = "lblLogLvl";
            this.lblLogLvl.Size = new System.Drawing.Size(95, 17);
            this.lblLogLvl.TabIndex = 18;
            this.lblLogLvl.Text = "Logging Level";
            // 
            // ckboxLogging
            // 
            this.ckboxLogging.AutoSize = true;
            this.ckboxLogging.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckboxLogging.Location = new System.Drawing.Point(90, 39);
            this.ckboxLogging.Name = "ckboxLogging";
            this.ckboxLogging.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckboxLogging.Size = new System.Drawing.Size(135, 24);
            this.ckboxLogging.TabIndex = 17;
            this.ckboxLogging.Text = "Enable Logging";
            this.ckboxLogging.UseVisualStyleBackColor = true;
            this.ckboxLogging.CheckedChanged += new System.EventHandler(this.OnLoggingToggled);
            // 
            // btnBrowseLog
            // 
            this.btnBrowseLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBrowseLog.Enabled = false;
            this.btnBrowseLog.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnBrowseLog.Location = new System.Drawing.Point(282, 152);
            this.btnBrowseLog.Name = "btnBrowseLog";
            this.btnBrowseLog.Size = new System.Drawing.Size(32, 20);
            this.btnBrowseLog.TabIndex = 16;
            this.btnBrowseLog.Text = "...";
            this.btnBrowseLog.UseVisualStyleBackColor = false;
            // 
            // tboxLogDir
            // 
            this.tboxLogDir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tboxLogDir.Enabled = false;
            this.tboxLogDir.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tboxLogDir.Location = new System.Drawing.Point(20, 152);
            this.tboxLogDir.Name = "tboxLogDir";
            this.tboxLogDir.Size = new System.Drawing.Size(242, 20);
            this.tboxLogDir.TabIndex = 15;
            // 
            // lblLogDir
            // 
            this.lblLogDir.AutoSize = true;
            this.lblLogDir.Enabled = false;
            this.lblLogDir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogDir.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLogDir.Location = new System.Drawing.Point(3, 132);
            this.lblLogDir.Name = "lblLogDir";
            this.lblLogDir.Size = new System.Drawing.Size(92, 17);
            this.lblLogDir.TabIndex = 14;
            this.lblLogDir.Text = "Log Directory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "Application Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Source File Extension";
            // 
            // cboxSrcFileExt
            // 
            this.cboxSrcFileExt.FormattingEnabled = true;
            this.cboxSrcFileExt.Items.AddRange(new object[] {
            ".sql",
            ".txt",
            ".csv"});
            this.cboxSrcFileExt.Location = new System.Drawing.Point(167, 296);
            this.cboxSrcFileExt.Name = "cboxSrcFileExt";
            this.cboxSrcFileExt.Size = new System.Drawing.Size(121, 21);
            this.cboxSrcFileExt.TabIndex = 14;
            // 
            // sql_file_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(354, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tcSettings);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sql_file_form";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudLogLevel)).EndInit();
            this.tcSettings.ResumeLayout(false);
            this.tpDFSettings.ResumeLayout(false);
            this.tpDFSettings.PerformLayout();
            this.tbDBSettings.ResumeLayout(false);
            this.tbDBSettings.PerformLayout();
            this.tpOtherSettings.ResumeLayout(false);
            this.tpOtherSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxPrimaryFileList;
        private System.Windows.Forms.TextBox tboxSecondaryFileList;
        private System.Windows.Forms.TextBox tboxGenFileDir;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog fldBrowser;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.TextBox tboxSourceFileDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpDFSettings;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxCustFileList;
        private System.Windows.Forms.TabPage tbDBSettings;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxDataSource;
        private System.Windows.Forms.CheckBox ckboxUseCustom;
        private System.Windows.Forms.CheckBox ckboxUseSecondary;
        private System.Windows.Forms.CheckBox ckboxUseRE;
        private System.Windows.Forms.ComboBox cboxCustMobLocal;
        private System.Windows.Forms.ComboBox cboxCustItemLocal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tpOtherSettings;
        private System.Windows.Forms.CheckBox ckboxLogLvlsIndy;
        private System.Windows.Forms.NumericUpDown nudLogLevel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tboxErrSufx;
        private System.Windows.Forms.TextBox tboxWarnSufx;
        private System.Windows.Forms.TextBox tboxInfoSufx;
        private System.Windows.Forms.CheckBox ckboxInAppErrs;
        private System.Windows.Forms.Label lblErrSufx;
        private System.Windows.Forms.Label lblWarnSufx;
        private System.Windows.Forms.Label lblInfoSufx;
        private System.Windows.Forms.Label lblLogLvl;
        private System.Windows.Forms.CheckBox ckboxLogging;
        private System.Windows.Forms.Button btnBrowseLog;
        private System.Windows.Forms.TextBox tboxLogDir;
        private System.Windows.Forms.Label lblLogDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxSrcFileExt;
    }
}