using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rAthena_Database_Editing_Tools.Properties;

namespace rAthena_Database_Editing_Tools{
    public partial class sql_file_form : Form{
        bool bSettingsChanged;
        bool bErrorOccurred;

        public sql_file_form(){
            InitializeComponent();

            //Load Directory & File Settings
            tboxPrimaryFileList.Text = (String)Settings.Default["prme_src_files"];
            tboxSecondaryFileList.Text = (String)Settings.Default["sec_src_files"];
            tboxCustFileList.Text = (String)Settings.Default["cust_src_files"];
            tboxGenFileDir.Text = (String)Settings.Default["gen_dir"];
            tboxSourceFileDir.Text = (String)Settings.Default["src_dir"];
            cboxSrcFileExt.SelectedIndex = cboxSrcFileExt.FindStringExact((String)Settings.Default["src_file_ext"]);


            //Load Database Settings
            ckboxUseRE.Checked = (bool)Settings.Default["use_re"];
            ckboxUseSecondary.Checked = (bool)Settings.Default["use_sec"];
            ckboxUseCustom.Checked = (bool)Settings.Default["use_cust"];
            cboxCustItemLocal.SelectedIndex = cboxCustItemLocal.FindStringExact((String)Settings.Default["cust_itm_loc"]);
            cboxCustMobLocal.SelectedIndex = cboxCustMobLocal.FindStringExact((String)Settings.Default["cust_mob_loc"]);
            cboxDataSource.SelectedIndex = cboxDataSource.FindStringExact((String)Settings.Default["data_src"]);
            


            //Load Logging Settings
            ckboxInAppErrs.Checked = (bool)Settings.Default["rpt_errs_in_app"];
            ckboxLogging.Checked = (bool)Settings.Default["enable_logging"];
            nudLogLevel.Value = (int)Settings.Default["log_level"];
            ckboxLogLvlsIndy.Checked = (bool)Settings.Default["indy_logging"];
            tboxLogDir.Text = (String)Settings.Default["log_location"];
            tboxInfoSufx.Text = (String)Settings.Default["info_sufx"];
            tboxWarnSufx.Text = (String)Settings.Default["warn_sufx"];
            tboxErrSufx.Text = (String)Settings.Default["err_sufx"];

            bSettingsChanged = false;
            bErrorOccurred = false;
        }

        private void saveSettings(object sender, EventArgs e){
            //Save Directory & File Settings
            if (tboxPrimaryFileList.Text == "")
            {
                bErrorOccurred = true;
                MessageBox.Show(this, "Enter your source file names for your official item and mob databases", "Official Source File Field Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (tboxPrimaryFileList.Text != (String)Settings.Default["prme_src_files"]){
                Settings.Default["prme_src_files"] = tboxPrimaryFileList.Text;
                bSettingsChanged = true;
            }

            if (tboxSecondaryFileList.Text == "")
            {
                bErrorOccurred = true;
                MessageBox.Show(this, "Enter your source file names for your official secondary item and mob databases", "Official Secondary Source File Field Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if(tboxSecondaryFileList.Text != (String)Settings.Default["sec_src_files"]) {
                Settings.Default["sec_src_files"] = tboxSecondaryFileList.Text;
                bSettingsChanged = true;
            }

            if (tboxCustFileList.Text != (String)Settings.Default["cust_src_files"])
            {
                Settings.Default["cust_src_files"] = tboxCustFileList.Text;
                bSettingsChanged = true;
            }

            if (tboxGenFileDir.Text == "")
            {
                bErrorOccurred = true;
                MessageBox.Show(this, "Enter the directory path to the folder you want app output to be generated in", "Generation Folder Path Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if(tboxGenFileDir.Text != (String)Settings.Default["gen_dir"]) { 
                Settings.Default["gen_dir"] = tboxGenFileDir.Text;
                bSettingsChanged = true;
            }

            if (tboxSourceFileDir.Text == "")
            {
                bErrorOccurred = true;
                MessageBox.Show(this, "Enter the directory path to the folder you want app load data from", "Source Folder Path Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (tboxSourceFileDir.Text != (String)Settings.Default["src_dir"])
            {
                Settings.Default["src_dir"] = tboxSourceFileDir.Text;
                bSettingsChanged = true;
            }

            if (cboxSrcFileExt.SelectedIndex == -1)
            {
                bErrorOccurred = true;
                MessageBox.Show(this, "Please select the file extension type for your source files", "Source File Extension Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (cboxSrcFileExt.GetItemText(cboxSrcFileExt.SelectedItem) != (String)Settings.Default["src_file_ext"])
            {
                Settings.Default["src_file_ext"] = cboxSrcFileExt.GetItemText(cboxSrcFileExt.SelectedItem);
                bSettingsChanged = true;
            }


            cboxDataSource.SelectedIndex = cboxDataSource.FindStringExact((String)Settings.Default["data_src"]);


            //Save Database Settings
            if (cboxCustItemLocal.GetItemText(cboxCustItemLocal.SelectedItem) != (String)Settings.Default["cust_itm_loc"])
            {
                Settings.Default["cust_itm_loc"] = cboxCustItemLocal.GetItemText(cboxCustItemLocal.SelectedItem);
                bSettingsChanged = true;
            }

            if (cboxCustMobLocal.GetItemText(cboxCustItemLocal.SelectedItem) != (String)Settings.Default["cust_mob_loc"])
            {
                Settings.Default["cust_mob_loc"] = cboxCustMobLocal.GetItemText(cboxCustMobLocal.SelectedItem);
                bSettingsChanged = true;
            }           

            if (cboxDataSource.GetItemText(cboxDataSource.SelectedItem) != (String)Settings.Default["data_src"])
            {
                Settings.Default["data_src"] = cboxDataSource.GetItemText(cboxDataSource.SelectedItem);
                bSettingsChanged = true;
            }

            if (ckboxUseRE.Checked != (bool)Settings.Default["use_re"])
            {
                Settings.Default["use_re"] = ckboxUseRE.Checked;
                bSettingsChanged = true;
            }

            if (ckboxUseSecondary.Checked != (bool)Settings.Default["use_sec"])
            {
                Settings.Default["use_sec"] = ckboxUseSecondary.Checked;
                bSettingsChanged = true;
            }

            if (ckboxUseCustom.Checked != (bool)Settings.Default["use_cust"])
            {
                Settings.Default["use_cust"] = ckboxUseCustom.Checked;
                bSettingsChanged = true;
            }


            //Save Logging Settings           
            if (ckboxInAppErrs.Checked != (bool)Settings.Default["rpt_errs_in_app"])
            {
                Settings.Default["rpt_errs_in_app"] = ckboxInAppErrs.Checked;
                bSettingsChanged = true;
            }

            if (ckboxLogging.Checked != (bool)Settings.Default["enable_logging"])
            {
                Settings.Default["enable_logging"] = ckboxLogging.Checked;
                bSettingsChanged = true;
            }

            if (nudLogLevel.Value != (int)Settings.Default["log_level"])
            {
                Settings.Default["log_level"] = Convert.ToInt32(nudLogLevel.Value);
                bSettingsChanged = true;
            }

            if (ckboxLogLvlsIndy.Checked != (bool)Settings.Default["indy_logging"])
            {
                Settings.Default["indy_logging"] = ckboxLogLvlsIndy.Checked;
                bSettingsChanged = true;
            }

            if (tboxLogDir.Text != (String)Settings.Default["log_location"])
            {
                Settings.Default["log_location"] = tboxLogDir.Text;
                bSettingsChanged = true;
            }

            if (tboxInfoSufx.Text != (String)Settings.Default["info_sufx"])
            {
                Settings.Default["info_sufx"] = tboxInfoSufx.Text;
                bSettingsChanged = true;
            }

            if (tboxWarnSufx.Text != (String)Settings.Default["warn_sufx"])
            {
                Settings.Default["warn_sufx"] = tboxWarnSufx.Text;
                bSettingsChanged = true;
            }

            if (tboxErrSufx.Text != (String)Settings.Default["err_sufx"])
            {
                Settings.Default["err_sufx"] = tboxErrSufx.Text;
                bSettingsChanged = true;
            }

            if (bSettingsChanged && !bErrorOccurred) {
                Settings.Default.Save();
                this.Dispose();
            }
        }

        private void openDialog(object sender, EventArgs e){
            if (sender.Equals(btnBrowse2)) { MessageBox.Show(this, "Please note that your sql files should have the following formatting for each row:\rcol1,col2,col3,col4...lastcol", "File Format Notice", MessageBoxButtons.OK); }
            DialogResult res = fldBrowser.ShowDialog();

            if (res == DialogResult.OK){
                if (sender.Equals(btnBrowse)) { tboxGenFileDir.Text = fldBrowser.SelectedPath; }
                else if (sender.Equals(btnBrowse2)) { tboxSourceFileDir.Text = fldBrowser.SelectedPath; }
                else if (sender.Equals(btnBrowseLog)) { tboxLogDir.Text = fldBrowser.SelectedPath; }
            }
        }

        private void OnLoggingToggled(object sender, EventArgs e) {
            if (ckboxLogging.Checked) {
                lblLogLvl.Enabled = true;
                nudLogLevel.Enabled = true;
                ckboxLogLvlsIndy.Enabled = true;
                lblLogDir.Enabled = true;
                tboxLogDir.Enabled = true;
                btnBrowseLog.Enabled = true;
                lblInfoSufx.Enabled = true;
                tboxInfoSufx.Enabled = true;
                lblWarnSufx.Enabled = true;
                tboxWarnSufx.Enabled = true;
                lblErrSufx.Enabled = true;
                tboxErrSufx.Enabled = true;
            } else {
                lblLogLvl.Enabled = false;
                nudLogLevel.Enabled = false;
                ckboxLogLvlsIndy.Enabled = false;
                lblLogDir.Enabled = false;
                tboxLogDir.Enabled = false;
                btnBrowseLog.Enabled = false;
                lblInfoSufx.Enabled = false;
                tboxInfoSufx.Enabled = false;
                lblWarnSufx.Enabled = false;
                tboxWarnSufx.Enabled = false;
                lblErrSufx.Enabled = false;
                tboxErrSufx.Enabled = false;
            }
        }

        private void OnSrcFileCheckedChanged(object sender, EventArgs e)
        {
            if (sender.Equals(ckboxUseRE))
            {
                if (ckboxUseRE.Checked)
                {
                    cboxCustItemLocal.Items.Add("item_db_re");
                    cboxCustMobLocal.Items.Add("mob_db_re");
                }
                else
                {
                    cboxCustItemLocal.Items.Remove("item_db_re");
                    cboxCustMobLocal.Items.Remove("mob_db_re");
                }
            }
            
            else if (sender.Equals(ckboxUseSecondary))
            {
                if (ckboxUseSecondary.Checked)
                {
                    cboxCustItemLocal.Items.Add("item_db2");
                    cboxCustMobLocal.Items.Add("mob_db2");
                    cboxCustItemLocal.Items.Add("item_db2_re");
                    cboxCustMobLocal.Items.Add("mob_db2_re");
                }
                else
                {
                    cboxCustItemLocal.Items.Remove("item_db2");
                    cboxCustMobLocal.Items.Remove("mob_db2");
                    cboxCustItemLocal.Items.Remove("item_db2_re");
                    cboxCustMobLocal.Items.Remove("mob_db2_re");
                }
            }
        }
    }
}
