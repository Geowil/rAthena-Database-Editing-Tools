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

namespace rAthena_Database_Editing_Tools
{
    public partial class ItemDBEditor : Form
    {
        public DataHandler dHandle;
        item tempItem;
        ItemSelect itmSel;
        bool bItemIsNew;
        uint jobEqpVal;
        int jobEqpUpperVal;

        bool bShowErrorsInApp;
        bool bREIsEnabled;
        bool bSecIsEnabled;
        bool bCustIsEnabled;
        bool bWasDataInputError;
        Dictionary<uint, CheckBox> jobMaskCKBoxes;
        Dictionary<int, CheckBox> classMaskCKBoxes;

        public ItemDBEditor(DataHandler dHnd)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            dHandle = dHnd;
            tempItem = new item();
            bWasDataInputError = false;



            bREIsEnabled = (bool)Settings.Default["use_re"];
            bSecIsEnabled = (bool)Settings.Default["use_sec"];
            bCustIsEnabled = (bool)Settings.Default["use_cust"];
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            if (bREIsEnabled)
            {
                cboxItemLocal.Items.Add("item_db_re");
            }

            if (bSecIsEnabled)
            {
                cboxItemLocal.Items.Add("item_db2");
                cboxItemLocal.Items.Add("item_db2_re");
            }

            if (bCustIsEnabled)
            {
                cboxItemLocal.Items.Add("custom_items");
            }

            jobEqpVal = 0;
            jobEqpUpperVal = 0;

            jobMaskCKBoxes = new Dictionary<uint, CheckBox>();
            classMaskCKBoxes = new Dictionary<int, CheckBox>();

            buildJobValIndex();
            buildClassValIndex();

            if (bREIsEnabled)
            {
                lblIAtk.Text = "Attack:M. Attack";
            }
            else
            {
                lblIAtk.Text = "Attack";
            }

            bItemIsNew = true;

            setCBoxDataSource<String, int>(cboxIType, ConstData.itemTypes);
            setCBoxDataSource<String, uint>(cboxIEqpLocal, ConstData.itemLocations);
            setCBoxDataSource<String, int>(cboxIEqpGen, ConstData.genderTypes);
        }

        private void loadItem(object sender, EventArgs e)
        {
            using (itmSel = new ItemSelect(dHandle))
            {
                DialogResult rst = itmSel.ShowDialog();

                if (rst == DialogResult.OK)
                {
                    tempItem = itmSel.selectedItem;
                }

                itmSel.Dispose();
            }

            if (tempItem != null)
            {
                bItemIsNew = false;
                tboxIID.Text = tempItem.iID.ToString();
                tboxIEngName.Text = tempItem.iEngName;
                tboxIJpnName.Text = tempItem.iJpnName;
                setSelectedIndex(cboxIType, tempItem.iType);
                tboxIBP.Text = tempItem.iBPrice.ToString();
                tboxISP.Text = tempItem.iSPrice.ToString();
                tboxIWeight.Text = tempItem.iWeight.ToString();
                tboxISlots.Text = tempItem.iSlots.ToString();
                ckboxIRefinable.Checked = Convert.ToBoolean(tempItem.iRefinable);
                tboxIViewID.Text = tempItem.iView.ToString();
                tboxIAtk.Text = tempItem.iAtkMAtk;
                tboxIDef.Text = tempItem.iDef.ToString();
                tboxIRng.Text = tempItem.iRng.ToString();
                tboxIWepLvl.Text = tempItem.iWeapLvl.ToString();
                tboxIEqpLvl.Text = tempItem.iEqpLvl.ToString();

                foreach (uint mask in getMasks(tempItem.iEqpJobs))
                {
                    if (jobMaskCKBoxes.ContainsKey(mask))
                    {
                        jobMaskCKBoxes[mask].Checked = true;
                    }
                }

                foreach (int mask in getMasks(tempItem.iEqpUpper))
                {
                    if (classMaskCKBoxes.ContainsKey(mask))
                    {
                        classMaskCKBoxes[mask].Checked = true;
                    }
                }

                setSelectedIndex(cboxIEqpLocal, tempItem.iEqpLocals);
                setSelectedIndex(cboxIEqpGen, tempItem.iEqpGen);
                tboxIScript.Text= tempItem.iScript;
                tboxIEqpScript.Text = tempItem.iEqpScript;
                tboxIUneqpScript.Text = tempItem.iUneqpScript;
                setSelectedIndex(cboxItemLocal, tempItem.itemLocale);
                
            }
        }

        private void OnSaveItem(object sender, EventArgs e)
        {
            item itm;
            String indKey;

            if (bItemIsNew) { itm = new item(true,true); }
            else { itm = new item(); }

            itm.iID = parseIVal(tboxIID.Text);
            itm.iEngName = tboxIEngName.Text;
            itm.iJpnName = tboxIJpnName.Text;

            indKey = ((KeyValuePair<String, int>)cboxIType.Items[cboxIType.SelectedIndex]).Key;
            if (ConstData.itemTypes.ContainsKey(indKey)) { itm.iType = ConstData.itemTypes[indKey]; }   

            itm.iBPrice = parseIVal(tboxIBP.Text);
            itm.iSPrice = parseIVal(tboxISP.Text);
            itm.iWeight = parseIVal(tboxIWeight.Text);
            itm.iAtkMAtk = tboxIAtk.Text;
            itm.iDef = parseIVal(tboxIDef.Text);
            itm.iRng = parseIVal(tboxIRng.Text);
            itm.iSlots = parseIVal(tboxISlots.Text);
            itm.iEqpJobs = jobEqpVal;
            itm.iEqpUpper = jobEqpUpperVal;

            indKey = ((KeyValuePair<String, int>)cboxIEqpGen.Items[cboxIEqpGen.SelectedIndex]).Key;
            if (ConstData.genderTypes.ContainsKey(indKey)) { itm.iEqpGen = ConstData.genderTypes[indKey]; }

            if (cboxIEqpLocal.SelectedIndex != -1) {
                indKey = ((KeyValuePair<String, uint>)cboxIEqpLocal.Items[cboxIEqpLocal.SelectedIndex]).Key;
                if (ConstData.itemLocations.ContainsKey(indKey)) { itm.iEqpLocals = ConstData.itemLocations[indKey]; }
            } else { itm.iEqpLocals = 0; }
            
            itm.iWeapLvl = parseIVal(tboxIWepLvl.Text);
            itm.iEqpLvl = parseIVal(tboxIEqpLvl.Text);
            itm.iRefinable = Convert.ToInt32(ckboxIRefinable.Checked);
            itm.iView = parseIVal(tboxIViewID.Text);
            itm.iScript = tboxIScript.Text;
            itm.iEqpScript = tboxIEqpScript.Text;
            itm.iUneqpScript = tboxIUneqpScript.Text;
            itm.itemLocale = cboxItemLocal.Text;

            if (!bWasDataInputError)
            {
                if (itm.itemLocale.Length < 1)
                {
                    MessageBox.Show(this, "Item location cannot be empty.  Aborting save procedure.", "Missing or Invalid Data", MessageBoxButtons.OK);
                    return;
                }

                if (bItemIsNew)
                {
                    if (dHandle.createItem(itm))
                    {
                        MessageBox.Show(this, "The item was created successfully.", "Item Creation Successful", MessageBoxButtons.OK);
                        clearData();
                    }
                    else
                    {
                        if (!bShowErrorsInApp) { MessageBox.Show(this, "There were errors creating your new item.  Please refer to the log file(s) for more information.", "Item Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        dHandle.removeItem(itm.iID);
                    }
                }
                else
                {
                    if (dHandle.updateItem(itm, Int32.Parse(tboxIID.Text)))
                    {
                        MessageBox.Show(this, "The updates to this item have been applied.", "Item Updated Successfully", MessageBoxButtons.OK);
                        clearData();
                    }
                    else
                    {
                        if (!bShowErrorsInApp) { MessageBox.Show(this, "There were errors updating this item.  Please refer to the log file(s) for more information.", "Item Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "One of more of the fields are missing data and could not be parsed.  Please check for non-numerical characters or blank fields and try saving again.", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bWasDataInputError = false;
        }

        private int parseIVal(String inVal)
        {
            int rtnInt = 0;

            if (!Int32.TryParse(inVal, out rtnInt))
            {
                bWasDataInputError = true;
                rtnInt = 0;
            }

            return rtnInt;
        }

        private void clearData()
        {
            bItemIsNew = true;
            tboxIID.Clear();
            tboxIEngName.Clear();
            tboxIJpnName.Clear();
            cboxIType.SelectedIndex = -1;
            tboxIBP.Clear();
            tboxISP.Clear();
            tboxIWeight.Clear();
            tboxISlots.Clear();
            ckboxIRefinable.Checked = false;
            tboxIViewID.Clear();
            tboxIAtk.Clear();
            tboxIDef.Clear();
            tboxIRng.Clear();
            tboxIWepLvl.Clear();
            tboxIEqpLvl.Clear();

            foreach (CheckBox ckbox in gboxEqpJobs.Controls.OfType<CheckBox>()) { ckbox.Checked = false; }
            foreach (CheckBox ckbox in gboxClassTypes.Controls.OfType<CheckBox>()) { ckbox.Checked = false; }

            cboxIEqpGen.SelectedIndex = -1;
            cboxIEqpLocal.SelectedIndex = -1;
            tboxIScript.Clear();
            tboxIEqpScript.Clear();
            tboxIUneqpScript.Clear();
            cboxItemLocal.SelectedIndex = -1;
        }

        private void OnClearDataClick(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "You are about to clear the data without saving.  Continue?", "Clear Data Without Saving Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    clearData();
                    break;

                default:
                    break;
            }
        }

        List<uint> getMasks(uint n)
        {
            List<uint> maskList = new List<uint>();
          
            //Iterate over mask starting from 0x01 (1) and then left shift by one each iteration
            //to find every possible bit mask which has a value in common with the passed argument
            for (uint mask = 0x01; mask != 0; mask <<= 1) {
                if ((mask & n) != 0) { maskList.Add(mask); }
            }

            return maskList;
        }

        List<int> getMasks(int n)
        {
            List<int> maskList = new List<int>();

            //Iterate over mask starting from 0x01 (1) and then left shift by one each iteration
            //to find every possible bit mask which has a value in common with the passed argument
            for (int mask = 0x01; mask != 0; mask <<= 1)
            {
                if ((mask & n) != 0) { maskList.Add(mask); }
            }

            return maskList;
        }

        void setSelectedIndex(ComboBox cbox, int targetVal) {
            for (int i1 = 0; i1 < cbox.Items.Count; i1++) {
                if (((KeyValuePair<String, int>)cbox.Items[i1]).Value == targetVal) { cbox.SelectedIndex = i1; }
            }
        }

        void setSelectedIndex(ComboBox cbox, uint targetVal) {
            for (int i1 = 0; i1 < cbox.Items.Count; i1++) {
                if (((KeyValuePair<String, uint>)cbox.Items[i1]).Value == targetVal) { cbox.SelectedIndex = i1; }
            }
        }

        void setSelectedIndex(ComboBox cbox, String targetVal) {
            for (int i1 = 0; i1 < cbox.Items.Count; i1++) {
                cbox.SelectedIndex = i1;
                if (cbox.GetItemText(cbox.SelectedItem) != targetVal) { cbox.SelectedIndex = -1; }
                else { break; }
            }
        }

        void buildJobValIndex() {
            int i1 = 0;
            foreach (Control c in gboxEqpJobs.Controls.OfType<CheckBox>().OrderBy(c => c.TabIndex)){
                jobMaskCKBoxes.Add(ConstData.jobMaskVals[i1], c as CheckBox);
                i1++;
            }
        }

        void buildClassValIndex()
        {
            int i1 = 0;
            foreach (Control c in gboxClassTypes.Controls.OfType<CheckBox>().OrderBy(c => c.TabIndex))
            {
                classMaskCKBoxes.Add(ConstData.classMaskVals[i1], c as CheckBox);
                i1++;
            }
        }

        private void OnExitIDBClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnEqpJbBoxCheckChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<uint,CheckBox> ckbox in jobMaskCKBoxes){
                if (sender.Equals(ckbox.Value)){
                    if (ckbox.Value.Checked) { jobEqpVal += ckbox.Key; }
                    else { jobEqpVal -= ckbox.Key; }
                }
            }
        }

        private void OnClassUpperBoxCheckChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, CheckBox> ckbox in classMaskCKBoxes)
            {
                if (sender.Equals(ckbox.Value)){
                    if (ckbox.Value.Checked) { jobEqpUpperVal += ckbox.Key; }
                    else { jobEqpUpperVal -= ckbox.Key; }
                }
            }
        }

        void setCBoxDataSource<t1, t2>(ComboBox cbox, Dictionary<t1, t2> dSrc)
        {
            cbox.DataSource = new BindingSource(dSrc, null);
            cbox.DisplayMember = "Key";
            cbox.ValueMember = "Value";
            cbox.SelectedIndex = -1;
        }

        private void OnItemDBEditorLoaded(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}
