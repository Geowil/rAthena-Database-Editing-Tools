using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rAthena_Database_Editing_Tools
{
    public partial class MobSelect : Form
    {
        public mob selectedMob { get; set; }
        DataHandler dHandle;
        public MobSelect(DataHandler dHnd)
        {
            InitializeComponent();

            dHandle = dHnd;

            foreach (String mobRec in dHandle.getMobList()) {
                cboxMobList.Items.Add(mobRec);
            }
        }

        private void getMob(object sender, EventArgs e)
        {
            selectedMob = dHandle.getMob(cboxMobList.SelectedIndex);
        }

        private void OnMobSelected(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
