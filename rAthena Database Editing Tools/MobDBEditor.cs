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

namespace rAthena_Database_Editing_Tools {
    public partial class MobDBEditor : Form {
        public DataHandler dHandle;
        Dictionary<uint, CheckBox> behaviorMaskCKBoxes;
        Dictionary<String, int> itemList;
        Dictionary<String, int> cardList;
        uint mobBehviorVal;
        MobSelect mobSel;
        mob tempMob;
        bool bMobIsNew;
        bool bShowErrorsInApp;
        bool bREIsEnabled;
        bool bSecIsEnabled;
        bool bCustIsEnabled;
        bool bWasDataInputError;

        public MobDBEditor(DataHandler dHdl) {
            this.AutoScroll = true;
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];
            bREIsEnabled = (bool)Settings.Default["use_re"];
            bSecIsEnabled = (bool)Settings.Default["use_sec"];
            bCustIsEnabled = (bool)Settings.Default["use_cust"];
            bWasDataInputError = false;

            if (bREIsEnabled)
            {
                cboxMobLocal.Items.Add("mob_db_re");
            }

            if (bSecIsEnabled)
            {
                cboxMobLocal.Items.Add("mob_db2");
                cboxMobLocal.Items.Add("mob_db2_re");
            }

            if (bCustIsEnabled)
            {
                cboxMobLocal.Items.Add("custom_mobs");
            }


            behaviorMaskCKBoxes = new Dictionary<uint, CheckBox>();

            buildBehaviorValIndex();

            dHandle = dHdl;
            mobBehviorVal = 0;

            itemList = new Dictionary<String, int>();
            cardList = new Dictionary<String, int>();
            itemList = dHandle.getItemList(false, 0); //Get Cards Only
            cardList = dHandle.getItemList(true, 6); //Get Cards Only
            
            setCBoxDataSource<String,uint>(cboxMBPresets, ConstData.mobBehaviorMasks);
            setCBoxDataSource<String,uint>(cboxMClassPresets,ConstData.mobClassMasks);
            setCBoxDataSource<String,int>(cboxMRace, ConstData.mobRaces);
            setCBoxDataSource<String,int>(cboxMScale, ConstData.mobSizes);
            setCBoxDataSource<String, int>(cboxMMDrop1ID, itemList);
            setCBoxDataSource<String, int>(cboxMMDrop2ID, itemList);
            setCBoxDataSource<String, int>(cboxMMDrop3ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop1ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop2ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop3ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop4ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop5ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop6ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop7ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop8ID, itemList);
            setCBoxDataSource<String, int>(cboxMDrop9ID, itemList);
            setCBoxDataSource<String, int>(cboxMCardDropID, cardList);

            bMobIsNew = true;
        }

        void buildBehaviorValIndex() {
            int i1 = 0;
            foreach (Control c in gboxMobBehaviors.Controls.OfType<CheckBox>().OrderBy(c => c.TabIndex)) {
                behaviorMaskCKBoxes.Add(ConstData.mobBehaviorVals[i1], c as CheckBox);
                i1++;
            }
        }

        private void OnExitMDBClicked(object sender, EventArgs e) => this.Close();
        void setCBoxDataSource<t1,t2>(ComboBox cbox, Dictionary<t1,t2> dSrc){
            cbox.DataSource = new BindingSource(dSrc, null);
            cbox.DisplayMember = "Key";
            cbox.ValueMember = "Value";
            cbox.SelectedIndex = -1;
        }

        private void OnMobBhvBoxCheckChanged(object sender, EventArgs e) {
            foreach (KeyValuePair<uint, CheckBox> keyVal in behaviorMaskCKBoxes) {
                if (sender.Equals(keyVal.Value)){
                    if (keyVal.Value.Checked) { mobBehviorVal += keyVal.Key; }
                    else { mobBehviorVal -= keyVal.Key; }
                }
            }
        }

        List<uint> getMasks(uint n) {
            List<uint> maskList = new List<uint>();

            //Iterate over mask starting from 0x01 (1) and then left shift by one each iteration
            //to find every possible bit mask which has a value in common with the passed argument
            for (uint mask = 0x01; mask != 0; mask <<= 1)
            {
                if ((mask & n) != 0) { maskList.Add(mask); }
            }

            return maskList;
        }

        private void OnBehaviorPresetChanged(object sender, EventArgs e) {
            int index = cboxMBPresets.SelectedIndex;
            uint maskVal = 0;

            if (index != -1 && index != 0) {
                maskVal = ((KeyValuePair<String, uint>)cboxMBPresets.Items[index]).Value;
            } else { maskVal = 0; }

            resetBehaviorCheckboxes();
            setBehaviorBoxes(maskVal);
        }

        void resetBehaviorCheckboxes() {
            foreach (KeyValuePair<uint, CheckBox> keyVal in behaviorMaskCKBoxes) { keyVal.Value.Checked = false; }
        }

        private void OnClassPresetChanged(object sender, EventArgs e) {
            int index = cboxMClassPresets.SelectedIndex;
            uint maskVal = 0;

            if (index != 0 && index != -1) {
                maskVal = ((KeyValuePair<String, uint>)cboxMClassPresets.Items[index]).Value;

                OnBehaviorPresetChanged(null, null);
                setBehaviorBoxes(maskVal);
            }
            else {
                maskVal = 0;
                OnBehaviorPresetChanged(null, null);
            }
        }

        private void setBehaviorBoxes(uint maskVal) {
            if (maskVal != 0) {
                foreach (uint mask in getMasks(maskVal)) {
                    foreach (KeyValuePair<uint, CheckBox> keyVal in behaviorMaskCKBoxes) {
                        if (keyVal.Key == mask && !keyVal.Value.Checked) { keyVal.Value.Checked = true; }
                    }
                }
            }
        }

        private void OnLoadMob(object sender, EventArgs e) {
            using (mobSel = new MobSelect(dHandle)) {
                DialogResult rst = mobSel.ShowDialog();

                if (rst == DialogResult.OK) { tempMob = mobSel.selectedMob; }

                mobSel.Dispose();
            }

            if (tempMob != null) {
                bMobIsNew = false;
                tboxMID.Text = tempMob.mID.ToString();
                tboxMSprName.Text = tempMob.mSprName;
                tboxMEngName.Text = tempMob.mEngName;
                tboxMJpnName.Text = tempMob.mJpnName;
                tboxMLvl.Text = tempMob.mLvl.ToString();
                tboxMHP.Text = tempMob.mHP.ToString();
                tboxMSP.Text = tempMob.mSP.ToString();
                tboxMBaseXP.Text = tempMob.mBaseXP.ToString();
                tboxMJobXP.Text = tempMob.mJobXP.ToString();
                tboxMAtkRng.Text = tempMob.mAtkRng.ToString();
                tboxMMinAtk.Text = tempMob.mMinAtk.ToString();
                tboxMMaxAtk.Text = tempMob.mMaxAtk.ToString();
                tboxMDef.Text = tempMob.mDef.ToString();
                tboxMMDef.Text = tempMob.mMDef.ToString();
                tboxMStr.Text = tempMob.mStr.ToString();
                tboxMAgi.Text = tempMob.mAgi.ToString();
                tboxMVit.Text = tempMob.mVit.ToString();
                tboxMInt.Text = tempMob.mInt.ToString();
                tboxMDex.Text = tempMob.mDex.ToString();
                tboxMLuk.Text = tempMob.mLuk.ToString();
                tboxMSkRng.Text = tempMob.mSkRng.ToString();
                tboxMVwRng.Text = tempMob.mVwRng.ToString();
                setSelectedIndex(cboxMScale, tempMob.mScale);
                setSelectedIndex(cboxMRace, tempMob.mRace);
                tboxMEle.Text = tempMob.mEle.ToString();
                setBehaviorBoxes(tempMob.mBevMask);
                tboxMWlkSpd.Text = tempMob.mWlkSpd.ToString();
                tboxMAtkDly.Text = tempMob.mAtkDly.ToString();
                tboxMAtkMot.Text = tempMob.mAtkMot.ToString();
                tboxMDmgMot.Text = tempMob.mDmgMot.ToString();
                tboxMMXP.Text = tempMob.mMXP.ToString();
                setSelectedIndex(cboxMMDrop1ID, tempMob.mMDrop1ID);
                tboxMMDrop1Perc.Text = tempMob.mMDrop1Perc.ToString();
                setSelectedIndex(cboxMMDrop2ID, tempMob.mMDrop2ID);
                tboxMMDrop2Perc.Text = tempMob.mMDrop2Perc.ToString();
                setSelectedIndex(cboxMMDrop3ID, tempMob.mMDrop3ID);
                tboxMMDrop3Perc.Text = tempMob.mMDrop3Perc.ToString();
                setSelectedIndex(cboxMDrop1ID, tempMob.mDrop1ID);
                tboxMDrop1Perc.Text = tempMob.mDrop1Perc.ToString();
                setSelectedIndex(cboxMDrop2ID, tempMob.mDrop2ID);
                tboxMDrop2Perc.Text = tempMob.mDrop2Perc.ToString();
                setSelectedIndex(cboxMDrop3ID, tempMob.mDrop3ID);
                tboxMDrop3Perc.Text = tempMob.mDrop3Perc.ToString();
                setSelectedIndex(cboxMDrop4ID, tempMob.mDrop4ID);
                tboxMDrop4Perc.Text = tempMob.mDrop4Perc.ToString();
                setSelectedIndex(cboxMDrop5ID, tempMob.mDrop5ID);
                tboxMDrop5Perc.Text = tempMob.mDrop5Perc.ToString();
                setSelectedIndex(cboxMDrop6ID, tempMob.mDrop6ID);
                tboxMDrop6Perc.Text = tempMob.mDrop6Perc.ToString();
                setSelectedIndex(cboxMDrop7ID, tempMob.mDrop7ID);
                tboxMDrop7Perc.Text = tempMob.mDrop7Perc.ToString();
                setSelectedIndex(cboxMDrop8ID, tempMob.mDrop8ID);
                tboxMDrop8Perc.Text = tempMob.mDrop8Perc.ToString();
                setSelectedIndex(cboxMDrop9ID, tempMob.mDrop9ID);
                tboxMDrop9Perc.Text = tempMob.mDrop9Perc.ToString();
                setSelectedIndex(cboxMCardDropID, tempMob.mCardDropID);
                tboxMCardDropPerc.Text = tempMob.mCardDropPerc.ToString();
                setSelectedIndex(cboxMobLocal, tempMob.mobLocale);
            }
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

        void setSelectedIndex(ComboBox cbox, String targetVal)
        {
            for (int i1 = 0; i1 < cbox.Items.Count; i1++)
            {
                cbox.SelectedIndex = i1;
                if (cbox.GetItemText(cbox.SelectedItem) != targetVal) { cbox.SelectedIndex = -1; }
                else { break; }
            }
        }

        private void OnSaveMobClicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mob newMob;
            String indStr;

            if (bMobIsNew) { newMob = new mob(true, true); }
            else { newMob = new mob(); }

            newMob.mID = parseIVal(tboxMID.Text);
            newMob.mSprName = tboxMSprName.Text;
            newMob.mJpnName = tboxMJpnName.Text;
            newMob.mEngName = tboxMEngName.Text;
            newMob.mLvl = parseIVal(tboxMLvl.Text);
            newMob.mHP = parseIVal(tboxMHP.Text);
            newMob.mSP = parseIVal(tboxMSP.Text);
            newMob.mBaseXP = parseIVal(tboxMBaseXP.Text);
            newMob.mJobXP = parseIVal(tboxMJobXP.Text);
            newMob.mAtkRng = parseIVal(tboxMAtkRng.Text);
            newMob.mMinAtk = parseIVal(tboxMMinAtk.Text);
            newMob.mMaxAtk = parseIVal(tboxMMaxAtk.Text);
            newMob.mDef = parseIVal(tboxMDef.Text);
            newMob.mMDef = parseIVal(tboxMMDef.Text);
            newMob.mStr = parseIVal(tboxMStr.Text);
            newMob.mAgi = parseIVal(tboxMAgi.Text);
            newMob.mVit = parseIVal(tboxMVit.Text);
            newMob.mInt = parseIVal(tboxMInt.Text);
            newMob.mDex = parseIVal(tboxMDex.Text);
            newMob.mLuk = parseIVal(tboxMLuk.Text);
            newMob.mSkRng = parseIVal(tboxMSkRng.Text);
            newMob.mVwRng = parseIVal(tboxMVwRng.Text);

            if (cboxMScale.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMScale.Items[cboxMScale.SelectedIndex]).Key;
                if (ConstData.mobSizes.ContainsKey(indStr)) { newMob.mScale = ConstData.mobSizes[indStr]; }
            } else { newMob.mScale = 0; }

            if (cboxMRace.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMRace.Items[cboxMRace.SelectedIndex]).Key;
                if (ConstData.mobRaces.ContainsKey(indStr)) { newMob.mRace = ConstData.mobRaces[indStr]; }
            } else { newMob.mRace = 0; }

            newMob.mEle = parseIVal(tboxMEle.Text);
            newMob.mBevMask = mobBehviorVal;
            newMob.mWlkSpd = parseIVal(tboxMWlkSpd.Text);
            newMob.mAtkDly = parseIVal(tboxMAtkDly.Text);
            newMob.mAtkMot = parseIVal(tboxMAtkMot.Text);
            newMob.mDmgMot = parseIVal(tboxMDmgMot.Text);
            newMob.mMXP = parseIVal(tboxMMXP.Text);

            if (cboxMMDrop1ID.SelectedIndex != -1) {
				indStr =  ((KeyValuePair<String, int>)cboxMMDrop1ID.Items[cboxMMDrop1ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mMDrop1ID = itemList[indStr]; }
            } else { newMob.mMDrop1ID = 0; }

            newMob.mMDrop1Perc = parseIVal(tboxMMDrop1Perc.Text);

            if (cboxMMDrop2ID.SelectedIndex != -1) {
				indStr =  ((KeyValuePair<String, int>)cboxMMDrop2ID.Items[cboxMMDrop2ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mMDrop2ID = itemList[indStr]; }
            } else { newMob.mMDrop2ID = 0; }

            newMob.mMDrop2Perc = parseIVal(tboxMMDrop2Perc.Text);

            if (cboxMMDrop3ID.SelectedIndex != -1) {
				indStr =  ((KeyValuePair<String, int>)cboxMMDrop3ID.Items[cboxMMDrop3ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mMDrop3ID = itemList[indStr]; }
            } else { newMob.mMDrop3ID = 0; }

            newMob.mMDrop3Perc = parseIVal(tboxMMDrop3Perc.Text);

            if (cboxMDrop1ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop1ID.Items[cboxMDrop1ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop1ID = itemList[indStr]; }
            } else { newMob.mDrop1ID = 0; }

            newMob.mDrop1Perc = parseIVal(tboxMDrop1Perc.Text);

            if (cboxMDrop2ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop2ID.Items[cboxMDrop2ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop2ID = itemList[indStr]; }
            } else { newMob.mDrop2ID = 0; }

            newMob.mDrop2Perc = parseIVal(tboxMDrop2Perc.Text);

            if (cboxMDrop3ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop3ID.Items[cboxMDrop3ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop3ID = itemList[indStr]; }
            } else { newMob.mDrop3ID = 0; }

            newMob.mDrop3Perc = parseIVal(tboxMDrop3Perc.Text);

            if (cboxMDrop4ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop4ID.Items[cboxMDrop4ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop4ID = itemList[indStr]; }
            } else { newMob.mDrop4ID = 0; }

            newMob.mDrop4Perc = parseIVal(tboxMDrop4Perc.Text);

            if (cboxMDrop5ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop5ID.Items[cboxMDrop5ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop5ID = itemList[indStr]; }
            } else { newMob.mDrop5ID = 0; }

            newMob.mDrop5Perc = parseIVal(tboxMDrop5Perc.Text);

            if (cboxMDrop6ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop6ID.Items[cboxMDrop6ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop6ID = itemList[indStr]; }
            } else { newMob.mDrop6ID = 0; }

            newMob.mDrop6Perc = parseIVal(tboxMDrop6Perc.Text);

            if (cboxMDrop7ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop7ID.Items[cboxMDrop7ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop7ID = itemList[indStr]; }
            } else { newMob.mDrop7ID = 0; }

            newMob.mDrop7Perc = parseIVal(tboxMDrop7Perc.Text);

            if (cboxMDrop8ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop8ID.Items[cboxMDrop8ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop8ID = itemList[indStr]; }
            } else { newMob.mDrop8ID = 0; }

            newMob.mDrop8Perc = parseIVal(tboxMDrop8Perc.Text);

            if (cboxMDrop9ID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMDrop9ID.Items[cboxMDrop9ID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mDrop9ID = itemList[indStr]; }
            } else { newMob.mDrop9ID = 0; }

            newMob.mDrop9Perc = parseIVal(tboxMDrop9Perc.Text);

            if (cboxMCardDropID.SelectedIndex != -1) {
                indStr = ((KeyValuePair<String, int>)cboxMCardDropID.Items[cboxMCardDropID.SelectedIndex]).Key;
                if (itemList.ContainsKey(indStr)) { newMob.mCardDropID = itemList[indStr]; }
            } else { newMob.mCardDropID = 0; }

            newMob.mCardDropPerc = parseIVal(tboxMCardDropPerc.Text);

            if (cboxMobLocal.SelectedIndex != -1)
            {
                newMob.mobLocale = cboxMobLocal.GetItemText(cboxMobLocal.SelectedItem);
            } else { newMob.mobLocale = "custom_mob"; }

            if (!bWasDataInputError)
            {
                if (bMobIsNew)
                {
                    if (dHandle.createMob(newMob))
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(this, "The mob was created successfully.", "Mob Creation Successful", MessageBoxButtons.OK);
                        clearData();
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        if (!bShowErrorsInApp) { MessageBox.Show(this, "There were errors creating your new mob.  Please refer to the log file(s) for more information.", "Mob Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        dHandle.removeMob(newMob.mID);
                    }
                }
                else
                {
                    if (dHandle.updateMob(newMob, newMob.mID))
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(this, "The updates to this mob have been applied.", "Mob Updated Successfully", MessageBoxButtons.OK);
                        clearData();
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        if (!bShowErrorsInApp) { MessageBox.Show(this, "There were errors updating this mob.  Please refer to the log file(s) for more information.", "Mob Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    }
                }
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(this, "One of more of the fields are missing data and could not be parsed.  Please check for non-numerical characters or blank fields and try saving again.", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bWasDataInputError = false;
        }

        private void clearData()
        {
            bMobIsNew = true;
            tboxMID.Clear();
            tboxMSprName.Clear();
            tboxMJpnName.Clear();
            tboxMEngName.Clear();
            tboxMLvl.Clear();
            tboxMHP.Clear();
            tboxMSP.Clear();
            tboxMBaseXP.Clear();
            tboxMJobXP.Clear();
            tboxMAtkRng.Clear();
            tboxMMinAtk.Clear();
            tboxMMaxAtk.Clear();
            tboxMDef.Clear();
            tboxMMDef.Clear();
            tboxMStr.Clear();
            tboxMAgi.Clear();
            tboxMVit.Clear();
            tboxMInt.Clear();
            tboxMDex.Clear();
            tboxMLuk.Clear();
            tboxMSkRng.Clear();
            tboxMVwRng.Clear();
            cboxMScale.SelectedIndex = -1;
            cboxMRace.SelectedIndex = -1;
            tboxMEle.Clear();
            
            foreach (CheckBox ckbox in gboxMobBehaviors.Controls.OfType<CheckBox>()) { ckbox.Checked = false; }

            tboxMWlkSpd.Clear();
            tboxMAtkDly.Clear();
            tboxMAtkMot.Clear();
            tboxMDmgMot.Clear();
            tboxMMXP.Clear();
            cboxMMDrop1ID.SelectedIndex = -1;
            tboxMMDrop1Perc.Clear();
            cboxMMDrop2ID.SelectedIndex = -1;
            tboxMMDrop2Perc.Clear();
            cboxMMDrop3ID.SelectedIndex = -1;
            tboxMMDrop3Perc.Clear();
            cboxMDrop1ID.SelectedIndex = -1;
            tboxMDrop1Perc.Clear();
            cboxMDrop2ID.SelectedIndex = -1;
            tboxMDrop2Perc.Clear();
            cboxMDrop3ID.SelectedIndex = -1;
            tboxMDrop3Perc.Clear();
            cboxMDrop4ID.SelectedIndex = -1;
            tboxMDrop4Perc.Clear();
            cboxMDrop5ID.SelectedIndex = -1;
            tboxMDrop5Perc.Clear();
            cboxMDrop6ID.SelectedIndex = -1;
            tboxMDrop6Perc.Clear();
            cboxMDrop7ID.SelectedIndex = -1;
            tboxMDrop7Perc.Clear();
            cboxMDrop8ID.SelectedIndex = -1;
            tboxMDrop8Perc.Clear();
            cboxMDrop9ID.SelectedIndex = -1;
            tboxMDrop9Perc.Clear();
            cboxMCardDropID.SelectedIndex = -1;
            tboxMCardDropPerc.Clear();
            cboxMobLocal.SelectedIndex = -1;
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

        private int parseIVal(String inVal)
        {
            int rtnInt = 0;

            if (!Int32.TryParse(inVal,out rtnInt)){
                bWasDataInputError = true;
                rtnInt = 0;
            }

            return rtnInt;
        }

        private uint parseUVal(String inVal)
        {
            uint rtnUint = 0;

            if (!UInt32.TryParse(inVal, out rtnUint))
            {
                bWasDataInputError = true;
                rtnUint = 0;
            }

            return rtnUint;
        }

        private void OnMobDBEditorLoaded(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}
