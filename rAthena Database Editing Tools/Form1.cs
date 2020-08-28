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
using rAthena_Database_Editing_Tools.Properties;

namespace rAthena_Database_Editing_Tools
{
    public partial class Form1 : Form
    {
        sql_file_form settingsSQLFiles;
        DataHandler dHandle;
        ItemDBEditor iDBEditor;
        MobDBEditor mDBEditor;
        bool bHasDataBeenLoaded;
        bool bDidDataLoad;
        Logging log;

        public Form1()
        {
            InitializeComponent();

            log = new Logging();
        }

        private void openSQLFileSettings(object sender, EventArgs e)
        {
            settingsSQLFiles = new sql_file_form();
            settingsSQLFiles.Show();

            bHasDataBeenLoaded = false;
        }

        private void loadData(object sender, EventArgs e)
        {
            if (bDidDataLoad)
            {
                if (sender.Equals(btnItemDB))
                {
                    using (iDBEditor = new ItemDBEditor(dHandle))
                    {
                        DialogResult rst = iDBEditor.ShowDialog();

                        if (rst == DialogResult.OK)
                        {
                            dHandle = iDBEditor.dHandle;
                        }

                        iDBEditor.Dispose();
                    }
                }
                else if (sender.Equals(btnMobDB))
                {
                    using (mDBEditor = new MobDBEditor(dHandle))
                    {
                        DialogResult rst = mDBEditor.ShowDialog();

                        if (rst == DialogResult.OK)
                        {
                            dHandle = mDBEditor.dHandle;
                        }

                        mDBEditor.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "There were critical errors loading the data files or no data was loaded.  Please refer to any previous error messages you received for further information.  Correct these issues and restart the program or click 'Load source files' in the 'File' menu option.", "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void OnGenerateSQLFilesClick(object sender, EventArgs e) => dHandle.writeSQL();
        private void OnGenerateFlatFilesClick(object sender, EventArgs e) {  }
        private void OnLoadFilesClicked(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            bool bDataLoaded = false;

            dHandle = new DataHandler(out bDataLoaded, log);

            if (bDataLoaded)
            {
                MessageBox.Show(this, "Items and mobs reloaded successfully.", "File Load Successful.", MessageBoxButtons.OK);
                bDidDataLoad = true;
            }
            else
            {
                MessageBox.Show(this, "There were critical errors loading the data files.  Please refer to any previous error messages you received for further information.  Correct these issues and restart the program or click 'Load source files' in the 'File' menu option.", "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bDidDataLoad = false;
            }

            bDidDataLoad = bDataLoaded;
            Cursor.Current = Cursors.Default;
        }
    }
}
