namespace rAthena_Database_Editing_Tools
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateOutFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filesForTextDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadSQLFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnItemDB = new System.Windows.Forms.Button();
            this.btnMobDB = new System.Windows.Forms.Button();
            this.fldBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(481, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadSQLFilesToolStripMenuItem,
            this.generateOutFilesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // generateOutFilesToolStripMenuItem
            // 
            this.generateOutFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLFilesToolStripMenuItem1,
            this.filesForTextDBToolStripMenuItem});
            this.generateOutFilesToolStripMenuItem.Name = "generateOutFilesToolStripMenuItem";
            this.generateOutFilesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.generateOutFilesToolStripMenuItem.Text = "Generate files";
            // 
            // sQLFilesToolStripMenuItem1
            // 
            this.sQLFilesToolStripMenuItem1.Name = "sQLFilesToolStripMenuItem1";
            this.sQLFilesToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.sQLFilesToolStripMenuItem1.Text = "Files for SQL DB";
            this.sQLFilesToolStripMenuItem1.Click += new System.EventHandler(this.OnGenerateSQLFilesClick);
            // 
            // filesForTextDBToolStripMenuItem
            // 
            this.filesForTextDBToolStripMenuItem.Name = "filesForTextDBToolStripMenuItem";
            this.filesForTextDBToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.filesForTextDBToolStripMenuItem.Text = "Files for text DB";
            this.filesForTextDBToolStripMenuItem.Click += new System.EventHandler(this.OnGenerateFlatFilesClick);
            // 
            // reloadSQLFilesToolStripMenuItem
            // 
            this.reloadSQLFilesToolStripMenuItem.Name = "reloadSQLFilesToolStripMenuItem";
            this.reloadSQLFilesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.reloadSQLFilesToolStripMenuItem.Text = "Load source files";
            this.reloadSQLFilesToolStripMenuItem.Click += new System.EventHandler(this.OnLoadFilesClicked);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLFilesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // sQLFilesToolStripMenuItem
            // 
            this.sQLFilesToolStripMenuItem.Name = "sQLFilesToolStripMenuItem";
            this.sQLFilesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sQLFilesToolStripMenuItem.Text = "Settings";
            this.sQLFilesToolStripMenuItem.Click += new System.EventHandler(this.openSQLFileSettings);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(360, 115);
            this.textBox1.TabIndex = 100;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // btnItemDB
            // 
            this.btnItemDB.Location = new System.Drawing.Point(84, 208);
            this.btnItemDB.Name = "btnItemDB";
            this.btnItemDB.Size = new System.Drawing.Size(75, 23);
            this.btnItemDB.TabIndex = 2;
            this.btnItemDB.Text = "Item DB";
            this.btnItemDB.UseVisualStyleBackColor = true;
            this.btnItemDB.Click += new System.EventHandler(this.loadData);
            // 
            // btnMobDB
            // 
            this.btnMobDB.Location = new System.Drawing.Point(320, 208);
            this.btnMobDB.Name = "btnMobDB";
            this.btnMobDB.Size = new System.Drawing.Size(75, 23);
            this.btnMobDB.TabIndex = 3;
            this.btnMobDB.Text = "Mob DB";
            this.btnMobDB.UseVisualStyleBackColor = true;
            this.btnMobDB.Click += new System.EventHandler(this.loadData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(481, 300);
            this.Controls.Add(this.btnMobDB);
            this.Controls.Add(this.btnItemDB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "rAthena Database Editing Tools V1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLFilesToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnItemDB;
        private System.Windows.Forms.Button btnMobDB;
        private System.Windows.Forms.FolderBrowserDialog fldBrowser;
        private System.Windows.Forms.ToolStripMenuItem generateOutFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLFilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filesForTextDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadSQLFilesToolStripMenuItem;
    }
}

