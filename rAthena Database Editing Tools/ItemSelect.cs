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
    public partial class ItemSelect : Form
    {
        public item selectedItem { get; set; }
        DataHandler dHandle;

        public ItemSelect(DataHandler dHnd){
            InitializeComponent();
            dHandle = dHnd;

            foreach (String itmRec in dHandle.getItemList()) { cboxItemList.Items.Add(itmRec); }
        }

        private void getItem(object sender, EventArgs e){
            selectedItem = dHandle.getItem(cboxItemList.SelectedIndex);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
