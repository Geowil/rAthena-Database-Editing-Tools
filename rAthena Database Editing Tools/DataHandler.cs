using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rAthena_Database_Editing_Tools.Properties;
using System.IO;

namespace rAthena_Database_Editing_Tools
{
    public class DataHandler
    {
        public List<item> items;
        public List<mob> mobs;
        String prmeFiles;
        String secFiles;
        String custFiles;
        String fileNames;
        String srcFldPath;
        String genFldPath;
        String custItemLoc;
        String custMobLoc;
        String[] files;
        List<String> usedFiles;

        StreamReader fileReader;
        StreamWriter fileWriter;

        Logging dhLog;

        bool bDataConstraintErrExists;
        bool bDataConstraintWarnExists;
        bool bReIsEnabled;
        bool bSecIsEnabled;
        bool bCustIsEnabled;
        bool bShowErrorsInApp;

        public DataHandler(out bool bData, Logging log)
        {
            dhLog = log;
            prmeFiles = (String)Settings.Default["prme_src_files"];
            secFiles = (String)Settings.Default["sec_src_files"];
            custFiles = (String)Settings.Default["cust_src_files"];

            custItemLoc = (String)Settings.Default["cust_itm_loc"];
            custMobLoc = (String)Settings.Default["cust_mob_loc"];

            srcFldPath = (String)Settings.Default["src_dir"] + "\\";
            genFldPath = (String)Settings.Default["gen_dir"] + "\\";

            bReIsEnabled = (bool)Settings.Default["use_re"];
            bSecIsEnabled = (bool)Settings.Default["use_sec"];
            bCustIsEnabled = (bool)Settings.Default["use_cust"];
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            usedFiles = new List<String>();

            bDataConstraintErrExists = false;
            bDataConstraintWarnExists = false;

            items = new List<item>();
            mobs = new List<mob>();

            bData = false;

            fileNames = prmeFiles;

            if (bSecIsEnabled) { fileNames += "," + secFiles; }
            

            files = fileNames.Split(',');

            foreach (String file in files)
            {
                if (bReIsEnabled)
                {
                    if (file.Contains("re")) { usedFiles.Add(file); }
                }
                else
                {
                    if (!file.Contains("re")) { usedFiles.Add(file); }
                }
            }

            files = custFiles.Split(',');

            if (bCustIsEnabled) {
                foreach (String file in files) { usedFiles.Add(file); }
            }

            foreach (string file in usedFiles)
            {
                String filePath = srcFldPath + file + ".sql";
                if (File.Exists(filePath))
                {
                    if (filePath.Contains("item")) { readData(filePath, "item", file); }
                    else if (filePath.Contains("mob")) { readData(filePath, "mob", file); }                    
                }
                else
                {
                    if (bShowErrorsInApp) { MessageBox.Show(null, file + " is not located in the designated folder: " + srcFldPath, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    else {
                        dhLog.addLogEntry("err", file + " is not located in the designated folder: " + srcFldPath + ".");
                        break;
                    }

                    bData = false;
                    break;
                }
            }

            checkConstraints("item");

            if (bDataConstraintErrExists && !bDataConstraintWarnExists)
            {
                if (!bShowErrorsInApp) { MessageBox.Show(null, "One or more errors occurred while loading in the item source data.  Please refer to the log file(s) for more information.   Item data was not loaded.", "Data Load Error", MessageBoxButtons.OK); }
            }
            else if (!bDataConstraintErrExists && bDataConstraintWarnExists)
            {
                if (!bShowErrorsInApp) { MessageBox.Show(null, "One or more warnings occurred while loading in the item source data.  Please refer to the log file(s) for more information.  Item data was loaded.", "Data Load Complete", MessageBoxButtons.OK); }
            }
            else if (bDataConstraintErrExists && bDataConstraintWarnExists)
            {
                if (!bShowErrorsInApp) { MessageBox.Show(null, "One or more errors and warnings occurred while loading in the item source data.  Please refer to the log file(s) for more information.  Item data was not loaded.", "Data Load Error", MessageBoxButtons.OK); }
            }

            bDataConstraintErrExists = false;
            bDataConstraintWarnExists = false;

            checkConstraints("mob");

            if (bDataConstraintErrExists && !bDataConstraintWarnExists)
            {
                if (!bShowErrorsInApp) { MessageBox.Show(null, "One or more errors occurred while loading in the mob source data.  Please refer to the log file(s) for more information.   Mob data was not loaded.", "Data Load Error", MessageBoxButtons.OK); }
            }
            else if (!bDataConstraintErrExists && bDataConstraintWarnExists)
            {
                if (!bShowErrorsInApp) { MessageBox.Show(null, "One or more warnings occurred while loading in the mob source data.  Please refer to the log file(s) for more information.   Mob data was loaded.", "Data Load Complete", MessageBoxButtons.OK); }
            }
            else if (bDataConstraintErrExists && bDataConstraintWarnExists)
            {
                if (!bShowErrorsInApp) { MessageBox.Show(null, "One or more errors and warnings occurred while loading in the mob source data.  Please refer to the log file(s) for more information.    Mob data was not loaded.", "Data Load Error", MessageBoxButtons.OK); }
            }

            if (!bDataConstraintErrExists) { bData = true; }
            else { bData = false; }
        }

        private void createItem(String text, String filName) => items.Add(new item(text, false, filName, dhLog));
        private void createMob(string text, String filName) => mobs.Add(new mob(text, false,filName, dhLog));
        private void readData(String fPath, String typ, String fName)
        {
            using (fileReader = File.OpenText(fPath))
            {
                String line;
                while ((line = fileReader.ReadLine()) != null) {
                    if (!String.IsNullOrEmpty(line))
                    {
                        if (typ == "item") { createItem(line, fName); }
                        else if (typ == "mob") { createMob(line, fName); }
                    }
                }
            }
        }

        public List<item> getItems() => items;
        public List<mob> getMobs() => mobs;

        private void checkConstraints(String type)
        {
            if (type == "item")
            {
                for (int i1 = 0; i1 < items.Count(); i1++)
                {
                    if (i1 != items.Count() - 1) {
                        for (int j1 = i1 + 1; j1 < items.Count(); j1++) {
                            if ((items[i1].iEngName == items[j1].iEngName && items[i1].itemLocale == items[j1].itemLocale))
                            {
                                if (bShowErrorsInApp)
                                {
                                    MessageBox.Show(null, "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constraint error.  Name_english value is already used.  Please check your " + items[i1].itemLocale + " source file.", "Data Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    dhLog.addLogEntry("err", "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constraint error.  Name_english value is already used.  Please check your " + items[i1].itemLocale + " source file.");
                                }
                                bDataConstraintErrExists = true;
                                break;
                            }
                            else if (items[i1].iID == items[j1].iID)
                            {
                                if (bShowErrorsInApp)
                                {
                                    MessageBox.Show(null, "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constraint error.  ID value is already used.  Please check your " + items[i1].itemLocale + " source file.", "Data Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    dhLog.addLogEntry("err", "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constraint error.  ID value is already used.  Please check your " + items[i1].itemLocale + " source file.");
                                }
                                bDataConstraintErrExists = true;
                                break;
                            }                            
                            else { bDataConstraintErrExists = false; }
                        }

                        if (items[i1].iType < 0 || items[i1].iType == 1 || items[i1].iType == 9 || (items[i1].iType >= 13 && items[i1].iType <= 17) || items[i1].iType > 18)
                        {
                            dhLog.addLogEntry("warn", "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constrained warning.  Item type is not valid, defaulting to Etc item (3).  Please check your " + items[i1].itemLocale + " source file.");
                            items[i1].iType = 3;
                            bDataConstraintWarnExists = true;
                        } else if (items[i1].iBPrice < items[i1].iSPrice)
                        {
                            dhLog.addLogEntry("warn", "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constrained warning.  Item buy price is lower than its sell price.  Zeny exploit possible.  Please check your " + items[i1].itemLocale + " source file.");
                            bDataConstraintWarnExists = true;
                        } else if (items[i1].iSlots > 4)
                        {
                            dhLog.addLogEntry("warn", "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constrained warning.  Item indicates more than 4 card slots, but server only supports 4.  Defaulting to 4.  Please check your " + items[i1].itemLocale + " source file.");
                            items[i1].iSlots = 4;
                            bDataConstraintWarnExists = true;
                        } else if ((items[i1].iType == 4 || items[i1].iType == 5 || items[i1].iType == 6 || items[i1].iType == 10 || items[i1].iType == 12) && (items[i1].iEqpLocals <= 0 || (getMasks(items[i1].iEqpLocals)).Count == 0)){
                            dhLog.addLogEntry("warn", "Item " + items[i1].iID.ToString() + " " + items[i1].iEngName + " has a constrained warning.  Item indicates more than 4 card slots, but server only supports 4.  Defaulting to 4.  Please check your " + items[i1].itemLocale + " source file.");
                            items[i1].iSlots = 4;
                            bDataConstraintWarnExists = true;
                        }
                        
                    }

                    if (bDataConstraintErrExists) { break; }
                }
            } else if (type == "mob")
            {
                for (int i1 = 0; i1 < mobs.Count(); i1++)
                {
                    if (i1 != mobs.Count() - 1)
                    {
                        for (int j1 = i1 + 1; j1 < mobs.Count(); j1++)
                        {
                            if (mobs[i1].mID == mobs[j1].mID)
                            {
                                if (bShowErrorsInApp)
                                { MessageBox.Show(null, "Mob " + mobs[i1].mID.ToString() + " " + mobs[i1].mEngName + " has a constraint error.  The ID value is already used.  Please check your " + mobs[i1].mobLocale + " source file.", "Data Constraint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                {
                                    dhLog.addLogEntry("err", "Mob " + mobs[i1].mID.ToString() + " " + mobs[i1].mEngName + " has a constraint error.  The ID value is already used.  Please check your " + items[i1].itemLocale + " source file.");
                                }
                                bDataConstraintErrExists = true;
                                break;
                            }
                            else { bDataConstraintErrExists = false; }
                        }
                    }

                    if (bDataConstraintErrExists) { break; }
                }
            }

        }

        public item getItem(int pos) => items[pos];
        public mob getMob(int pos) => mobs[pos];            
        public item getItemByID(int id){
            item rtnItm = new item();
            foreach (item itm in items){
                if (itm.iID == id) { rtnItm = itm; }
            }

            return rtnItm;
        }

        public mob getMobByID(int id)
        {
            mob rtnMob = new mob();
            foreach (mob m in mobs) {
                if (m.mID == id) { rtnMob = m; }
            }

            return rtnMob;
        }

        public List<String> getItemList(){
            List<String> itmList = new List<String>();
            foreach (item itm in items) { itmList.Add(itm.iJpnName + " -- " + itm.iID); }

            return itmList;
        }

        public List<String> getMobList()
        {
            List<String> mobList = new List<String>();
            foreach (mob m in mobs) { mobList.Add(m.mEngName + " -- " + m.mID); }

            return mobList;
        }

        public Dictionary<String,int> getItemList(bool bUseSpecificItem, int itype)
        {
            Dictionary<String, int> itmList = new Dictionary<String, int>();
            foreach (item itm in items) {
                if (!bUseSpecificItem) { itmList.Add(itm.iJpnName + " -- " + itm.iID, itm.iID); }
                else {
                    if (itm.iType == itype) { itmList.Add(itm.iJpnName + " -- " + itm.iID, itm.iID); }
                }
            }
             
            return itmList;
        }

        public bool createItem(item newItem)
        {
            String itemStr = newItem.iID.ToString();
            itemStr += ",'" + newItem.iEngName;
            itemStr += "','" + newItem.iJpnName;
            itemStr += "'," + newItem.iType.ToString();
            itemStr += "," + newItem.iBPrice.ToString();
            itemStr += "," + newItem.iSPrice.ToString();
            itemStr += "," + newItem.iWeight.ToString();

            if (bReIsEnabled) { itemStr += ",'" + newItem.iAtkMAtk + "'"; }
            else { itemStr += "," + newItem.iAtkMAtk; }

            itemStr += "," + newItem.iDef.ToString();
            itemStr += "," + newItem.iRng.ToString();
            itemStr += "," + newItem.iSlots.ToString();
            itemStr += "," + newItem.iEqpJobs.ToString();
            itemStr += "," + newItem.iEqpUpper.ToString();
            itemStr += "," + newItem.iEqpGen.ToString();
            itemStr += "," + newItem.iEqpLocals.ToString();
            itemStr += "," + newItem.iWeapLvl.ToString();
            itemStr += "," + newItem.iEqpLvl.ToString();
            itemStr += "," + newItem.iRefinable.ToString();
            itemStr += "," + newItem.iView.ToString();
            itemStr += ",'" + newItem.iScript;
            itemStr += "','" + newItem.iEqpScript;
            itemStr += "','" + newItem.iUneqpScript;
            itemStr += "'";

            items.Add(new item(itemStr, true, newItem.itemLocale, dhLog));

            if (items[items.LastIndexOf(items.Last())].bWarningsOccurred && !bShowErrorsInApp) { MessageBox.Show(null, "Warnings occurred while saving this item.  Please check the log file(s) for more information.", "Item Creation Generated Warnings", MessageBoxButtons.OK); }

            if (items[items.LastIndexOf(items.Last())].bCritFailure) { return false; }

            checkConstraints("item");

            if (bDataConstraintErrExists) { return false; }

            appendSourceFile(newItem.itemLocale, itemStr);

            return true;
        }

        public bool createMob(mob newMob)
        {
            String mobStr = newMob.mID.ToString();
            mobStr += ",'" + newMob.mSprName;
            mobStr += "','" + newMob.mJpnName;
            mobStr += "','" + newMob.mEngName;
            mobStr += "'," + newMob.mLvl.ToString();
            mobStr += "," + newMob.mHP.ToString();
            mobStr += "," + newMob.mSP.ToString();
            mobStr += "," + newMob.mBaseXP.ToString();
            mobStr += "," + newMob.mJobXP.ToString();
            mobStr += "," + newMob.mAtkRng.ToString();
            mobStr += "," + newMob.mMinAtk.ToString();
            mobStr += "," + newMob.mMaxAtk.ToString();
            mobStr += "," + newMob.mDef.ToString();
            mobStr += "," + newMob.mMDef.ToString();
            mobStr += "," + newMob.mStr.ToString();
            mobStr += "," + newMob.mAgi.ToString();
            mobStr += "," + newMob.mVit.ToString();
            mobStr += "," + newMob.mInt.ToString();
            mobStr += "," + newMob.mDex.ToString();
            mobStr += "," + newMob.mLuk.ToString();
            mobStr += "," + newMob.mSkRng.ToString();
            mobStr += "," + newMob.mVwRng.ToString();
            mobStr += "," + newMob.mScale.ToString();
            mobStr += "," + newMob.mRace.ToString();
            mobStr += "," + newMob.mEle.ToString();
            mobStr += "," + newMob.mBevMask.ToString();
            mobStr += "," + newMob.mWlkSpd.ToString();
            mobStr += "," + newMob.mAtkDly.ToString();
            mobStr += "," + newMob.mAtkMot.ToString();
            mobStr += "," + newMob.mDmgMot.ToString();
            mobStr += "," + newMob.mMXP.ToString();
            mobStr += "," + newMob.mMDrop1ID.ToString();
            mobStr += "," + newMob.mMDrop1Perc.ToString();
            mobStr += "," + newMob.mMDrop2ID.ToString();
            mobStr += "," + newMob.mMDrop2Perc.ToString();
            mobStr += "," + newMob.mMDrop3ID.ToString();
            mobStr += "," + newMob.mMDrop3Perc.ToString();
            mobStr += "," + newMob.mDrop1ID.ToString();
            mobStr += "," + newMob.mDrop1Perc.ToString();
            mobStr += "," + newMob.mDrop2ID.ToString();
            mobStr += "," + newMob.mDrop2Perc.ToString();
            mobStr += "," + newMob.mDrop3ID.ToString();
            mobStr += "," + newMob.mDrop3Perc.ToString();
            mobStr += "," + newMob.mDrop4ID.ToString();
            mobStr += "," + newMob.mDrop4Perc.ToString();
            mobStr += "," + newMob.mDrop5ID.ToString();
            mobStr += "," + newMob.mDrop5Perc.ToString();
            mobStr += "," + newMob.mDrop6ID.ToString();
            mobStr += "," + newMob.mDrop6Perc.ToString();
            mobStr += "," + newMob.mDrop7ID.ToString();
            mobStr += "," + newMob.mDrop7Perc.ToString();
            mobStr += "," + newMob.mDrop8ID.ToString();
            mobStr += "," + newMob.mDrop8Perc.ToString();
            mobStr += "," + newMob.mDrop9ID.ToString();
            mobStr += "," + newMob.mDrop9Perc.ToString();
            mobStr += "," + newMob.mCardDropID.ToString();
            mobStr += "," + newMob.mCardDropPerc.ToString();

            mobs.Add(new mob(mobStr, true, newMob.mobLocale, dhLog));


            if (mobs[mobs.LastIndexOf(mobs.Last())].bWarningsOccurred && !bShowErrorsInApp) { MessageBox.Show(null, "Warnings occurred while saving this mob.  Please check the log file(s) for more information.", "Mob Creation Generated Warnings", MessageBoxButtons.OK); }
            if (mobs[mobs.LastIndexOf(mobs.Last())].bCritFailure) { return false; }

            checkConstraints("mob");

            if (bDataConstraintErrExists) { return false; }

            appendSourceFile(newMob.mobLocale, mobStr);

            return true;
        }
        
        private void appendSourceFile(String fileName,String data) {
            String filePath = srcFldPath + fileName + ".sql";
            using (fileWriter = new StreamWriter(filePath, true)) {
                fileWriter.AutoFlush = true;
                fileWriter.WriteLine(data + "\r\n");
            }
        }

        public void writeSQL() {
            Dictionary<String, String> output = generateSQL();
            String fName;

            foreach (String f in usedFiles){
                List<String> writeList = new List<String>();

                foreach (KeyValuePair<String, String> data in output){
                    if (data.Value == f) { writeList.Add(data.Key); }
                }


                if (f == "custom_items") { fName = (String)Settings.Default["cust_itm_loc"]; }
                else if (f == "custom_mobs") { fName = (String)Settings.Default["cust_mob_loc"]; }
                else { fName = f; }

                using (fileWriter = new StreamWriter(genFldPath + fName + ".sql",true)){
                    foreach (String line in writeList) { fileWriter.WriteLine(line); }
                }
            }

            writeGenFiles();

            MessageBox.Show(null, "Updated mob and/or item records have been generated successfully.\r\nUpdated item and mob records to place back into your source files are located in your source directory in 'gened' files.", "File Generation Succeeded", MessageBoxButtons.OK);
        }

        private void writeGenFiles() {
            Dictionary<String, String> output = generateGen();
            String srcGenPath;

            String fileExt = (String)Settings.Default["src_file_ext"];

            foreach (String f in usedFiles) {
                List<String> writeList = new List<String>();

                foreach (KeyValuePair<String, String> data in output) {
                    if (data.Value == f) { writeList.Add(data.Key); }
                }

                if (f == "custom_items") { srcGenPath = (String)Settings.Default["src_dir"] + "\\gened_custom_item_records" + fileExt; }
                else if (f == "custom_mobs") { srcGenPath = (String)Settings.Default["src_dir"] + "\\gened_custom_mob_records" + fileExt; }
                else { srcGenPath = (String)Settings.Default["src_dir"] + "\\gened_" + f + "_records" + fileExt; }

                using (fileWriter = new StreamWriter(srcGenPath, true)) {
                    foreach (String line in writeList) { fileWriter.WriteLine(line); }
                }
            }
        }

        public Dictionary<String,String> generateSQL() {
            String newLine = "";
            Dictionary<String, String> rtnList = new Dictionary<String, String>();

            foreach (item itm in items) {
                newLine = itm.generateSQLStatement();

                if (newLine.Length > 0) {
                    rtnList.Add(newLine,itm.itemLocale); }
            }

            foreach (mob m in mobs) {
                newLine = m.generateSQLStatement();
                
                if (newLine.Length > 0) {
                    rtnList.Add(newLine,m.mobLocale); }
            }

            return rtnList;
        }

        public Dictionary<String, String> generateGen()
        {
            String newLine = "";
            Dictionary<String, String> rtnList = new Dictionary<String, String>();

            foreach (item itm in items)
            {
                newLine = itm.generateGenLine();

                if (newLine.Length > 0)
                {
                    rtnList.Add(newLine, itm.itemLocale);
                }
            }

            foreach (mob m in mobs)
            {
                newLine = m.generateGenLine();

                if (newLine.Length > 0)
                {
                    rtnList.Add(newLine, m.mobLocale);
                }
            }

            return rtnList;
        }

        public bool updateItem(item updItm, int id) {
            getItemByID(id).updateItem(updItm);
            checkConstraints("item");

            if (bDataConstraintErrExists) { return false; }
            return true;
        }

        public bool updateMob(mob updMob, int id) {
            getMobByID(id).updateMob(updMob);
            checkConstraints("mob");

            if (bDataConstraintErrExists) { return false; }
            return true;
        }

        public void removeItem(int id) {
            item removeItm = null;

            foreach (item itm in items) {
                if (itm.iID == id) { removeItm = itm; }
            }

            if (removeItm != null) { items.Remove(removeItm); }
        }

        public void removeMob(int id) {
            mob removeMob = null;

            foreach (mob m in mobs) {
                if (m.mID == id) { removeMob = m; }
            }

            if (removeMob != null) { mobs.Remove(removeMob); }
        }

        List<uint> getMasks(uint n)
        {
            List<uint> maskList = new List<uint>();

            //Iterate over mask starting from 0x01 (1) and then left shift by one each iteration
            //to find every possible bit mask which has a value in common with the passed argument
            for (uint mask = 0x01; mask != 0; mask <<= 1)
            {
                if ((mask & n) != 0) { maskList.Add(mask); }
            }

            return maskList;
        }
    }
}
