using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using rAthena_Database_Editing_Tools.Properties;

namespace rAthena_Database_Editing_Tools
{
    public class mob
    {
        List<bool> bChangedCols;
        bool bIsInitializing;

        public bool bIsNewMob;

        public bool bCritFailure { get; private set; }
        public bool bWarningsOccurred { get; private set; }
        public String mobLocale { get; set; }
        bool bMobWasUpdated;
        bool bShowErrorsInApp;

        Logging mobLog;
       
        int _mID;
        public int mID {
            get { return _mID; }
            set {
                _mID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[0] = true; }
            }
        }

        String _mSprName;
        public String mSprName
        {
            get{  return _mSprName; }
            set {
                _mSprName = value;

                if (!bIsInitializing && !bIsNewMob) { bChangedCols[1] = true; }
            }
        }

        String _mJpnName;
        public String mJpnName {
            get { return _mJpnName; }
            set {
                _mJpnName = value;

                if (!bIsInitializing && !bIsNewMob) { bChangedCols[2] = true; }
            }
        }

        String _mEngName;
        public String mEngName {
            get { return _mEngName; }
            set {
                _mEngName = value;

                if (!bIsInitializing && !bIsNewMob) { bChangedCols[3] = true; }
            }
        }

        int _mLvl;
        public int mLvl {
            get { return _mLvl; }
            set {
                _mLvl = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[4] = true; }
            }
        }

        int _mHP;
        public int mHP {
            get { return _mHP; }
            set {
                _mHP = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[5] = true; }
            }
        }

        int _mSP;
        public int mSP {
            get { return _mSP; }
            set {
                _mSP = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[6] = true; }
            }
        }

        int _mBaseXP;
        public int mBaseXP {
            get { return _mBaseXP; }
            set {
                _mBaseXP = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[7] = true; }
            }
        }

        int _mJobXP;
        public int mJobXP {
            get { return _mJobXP; }
            set {
                _mJobXP = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[8] = true; }
            }
        }

        int _mAtkRng;
        public int mAtkRng {
            get { return _mAtkRng; }
            set {
                _mAtkRng = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[9] = true; }
            }
        }

        int _mMinAtk;
        public int mMinAtk {
            get { return _mMinAtk; }
            set {
                _mMinAtk = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[10] = true; }
            }
        }

        int _mMaxAtk;
        public int mMaxAtk {
            get { return _mMaxAtk; }
            set {
                _mMaxAtk = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[11] = true; }
            }
        }

        int _mDef;
        public int mDef {
            get { return _mDef; }
            set {
                _mDef = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[12] = true; }
            }
        }

        int _mMDef;
        public int mMDef {
            get { return _mMDef; }
            set {
                _mMDef = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[13] = true; }
            }
        }

        int _mStr;
        public int mStr {
            get { return _mStr; }
            set {
                _mStr = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[14] = true; }
            }
        }

        int _mAgi;
        public int mAgi {
            get { return _mAgi; }
            set {
                _mAgi = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[15] = true; }
            }
        }

        int _mVit;
        public int mVit {
            get { return _mVit; }
            set {
                _mVit = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[16] = true; }
            }
        }

        int _mInt;
        public int mInt {
            get { return _mInt; }
            set {
                _mInt = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[17] = true; }
            }
        }

        int _mDex;
        public int mDex {
            get { return _mDex; }
            set {
                _mDex = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[18] = true; }
            }
        }

        int _mLuk;
        public int mLuk {
            get { return _mLuk; }
            set {
                _mLuk = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[19] = true; }
            }
        }

        int _mSkRng;
        public int mSkRng {
            get { return _mSkRng; }
            set {
                _mSkRng = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[20] = true; }
            }
        }

        int _mVwRng;
        public int mVwRng {
            get { return _mVwRng; }
            set {
                _mVwRng = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[21] = true; }
            }
        }

        int _mScale;
        public int mScale {
            get { return _mScale; }
            set {
                _mScale = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[22] = true; }
            }
        }

        int _mRace;
        public int mRace {
            get { return _mRace; }
            set {
                _mRace = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[23] = true; }
            }
        }

        int _mEle;
        public int mEle {
            get { return _mEle; }
            set {
                _mEle = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[24] = true; }
            }
        }

        uint _mBevMask;
        public uint mBevMask {
            get { return _mBevMask; }
            set {
                _mBevMask = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[25] = true; }
            }
        }

        int _mWlkSpd;
        public int mWlkSpd {
            get { return _mWlkSpd; }
            set {
                _mWlkSpd = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[26] = true; }
            }
        }

        int _mAtkDly;
        public int mAtkDly {
            get { return _mAtkDly; }
            set {
                _mAtkDly = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[27] = true; }
            }
        }

        int _mAtkMot;
        public int mAtkMot {
            get { return _mAtkMot; }
            set {
                _mAtkMot = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[28] = true; }
            }
        }

        int _mDmgMot;
        public int mDmgMot {
            get { return _mDmgMot; }
            set {
                _mDmgMot = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[29] = true; }
            }
        }

        int _mMXP;
        public int mMXP {
            get { return _mMXP; }
            set {
                _mMXP = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[30] = true; }
            }
        }

        int _mMDrop1ID;
        public int mMDrop1ID {
            get { return _mMDrop1ID; }
            set {
                _mMDrop1ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[31] = true; }
            }
        }

        int _mMDrop1Perc;
        public int mMDrop1Perc {
            get { return _mMDrop1Perc; }
            set {
                _mMDrop1Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[32] = true; }
            }
        }        

        int _mMDrop2ID;
        public int mMDrop2ID {
            get { return _mMDrop2ID; }
            set {
                _mMDrop2ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[33] = true; }
            }
        }

        int _mMDrop2Perc;
        public int mMDrop2Perc {
            get { return _mMDrop2Perc; }
            set {
                _mMDrop2Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[34] = true; }
            }
        }

        int _mMDrop3ID;
        public int mMDrop3ID {
            get { return _mMDrop3ID; }
            set {
                _mMDrop3ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[35] = true; }
            }
        }

        int _mMDrop3Perc;
        public int mMDrop3Perc {
            get { return _mMDrop3Perc; }
            set {
                _mMDrop3Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[36] = true; }
            }
        }

        int _mDrop1ID;
        public int mDrop1ID {
            get { return _mDrop1ID; }
            set {
                _mDrop1ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[37] = true; }
            }
        }

        int _mDrop1Perc;
        public int mDrop1Perc {
            get { return _mDrop1Perc; }
            set {
                _mDrop1Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[38] = true; }
            }
        }

        int _mDrop2ID;
        public int mDrop2ID {
            get { return _mDrop2ID; }
            set {
                _mDrop2ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[39] = true; }
            }
        }

        int _mDrop2Perc;
        public int mDrop2Perc {
            get { return _mDrop2Perc; }
            set {
                _mDrop2Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[40] = true; }
            }
        }

        int _mDrop3ID;
        public int mDrop3ID {
            get { return _mDrop3ID; }
            set {
                _mDrop3ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[41] = true; }
            }
        }

        int _mDrop3Perc;
        public int mDrop3Perc {
            get { return _mDrop3Perc; }
            set {
                _mDrop3Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[42] = true; }
            }
        }

        int _mDrop4ID;
        public int mDrop4ID {
            get { return _mDrop4ID; }
            set {
                _mDrop4ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[43] = true; }
            }
        }

        int _mDrop4Perc;
        public int mDrop4Perc {
            get { return _mDrop4Perc; }
            set {
                _mDrop4Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[44] = true; }
            }
        }

        int _mDrop5ID;
        public int mDrop5ID {
            get { return _mDrop5ID; }
            set {
                _mDrop5ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[45] = true; }
            }
        }

        int _mDrop5Perc;
        public int mDrop5Perc {
            get { return _mDrop5Perc; }
            set {
                _mDrop5Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[46] = true; }
            }
        }

        int _mDrop6ID;
        public int mDrop6ID {
            get { return _mDrop6ID; }
            set {
                _mDrop6ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[47] = true; }
            }
        }

        int _mDrop6Perc;
        public int mDrop6Perc {
            get { return _mDrop6Perc; }
            set {
                _mDrop6Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[48] = true; }
            }
        }

        int _mDrop7ID;
        public int mDrop7ID {
            get { return _mDrop7ID; }
            set {
                _mDrop7ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[49] = true; }
            }
        }

        int _mDrop7Perc;
        public int mDrop7Perc {
            get { return _mDrop7Perc; }
            set {
                _mDrop7Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[50] = true; }
            }
        }

        int _mDrop8ID;
        public int mDrop8ID {
            get { return _mDrop8ID; }
            set {
                _mDrop8ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[51] = true; }
            }
        }

        int _mDrop8Perc;
        public int mDrop8Perc {
            get { return _mDrop8Perc; }
            set {
                _mDrop8Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[52] = true; }
            }
        }

        int _mDrop9ID;
        public int mDrop9ID {
            get { return _mDrop9ID; }
            set {
                _mDrop9ID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[53] = true; }
            }
        }

        int _mDrop9Perc;
        public int mDrop9Perc {
            get { return _mDrop9Perc; }
            set {
                _mDrop9Perc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[54] = true; }
            }
        }

        int _mCardDropID;
        public int mCardDropID {
            get { return _mCardDropID; }
            set {
                _mCardDropID = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[55] = true; }
            }
        }

        int _mCardDropPerc;
        public int mCardDropPerc {
            get { return _mCardDropPerc; }
            set {
                _mCardDropPerc = value;
                if (!bIsInitializing && !bIsNewMob) { bChangedCols[56] = true; }
            }
        }

        public mob(){
            bMobWasUpdated = false;
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            bChangedCols = new List<bool>();
            for (int i1 = 0; i1 < 57; i1++) { bChangedCols.Add(false); }
        }

        public mob(bool bIsNew, bool bIsInit) {
            bIsNewMob = bIsNew;
            bIsInitializing = bIsInit;
            bMobWasUpdated = false;
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            bChangedCols = new List<bool>();
            for (int i1 = 0; i1 < 57; i1++) { bChangedCols.Add(false); }
        }

        public mob(String mobData, bool bIsNew, String mobLocal, Logging log)
        {
            bMobWasUpdated = false;
            bIsNewMob = bIsNew;
            mobLog = log;
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            bChangedCols = new List<bool>();
            for (int i1 = 0; i1 < 57; i1++) { bChangedCols.Add(false); }

            String[] mobCols = Regex.Split(mobData, ",(?![^rand(]*\\)|[^{]*\\}|[^']*;)");
            bIsInitializing = true;
            bCritFailure = false;

            int parseCheck;

            for (int i1 = 0; i1 < mobCols.Count(); i1++)
            {   
                if (!bCritFailure)
                {
                    switch (i1)
                    {
                        case 0:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck))
                            {
                                if (bShowErrorsInApp) { MessageBox.Show(null, "Mob " + mobCols[0] + " " + mobCols[3] + "'s value failed to parse correctly.  Please check your " + mobLocale + " source file.\r\r  Invalid row: " + mobData, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                else
                                {
                                    mobLog.addLogEntry("err","Mob " + mobCols[0] + " " + mobCols[3] + "'s ID value failed to parse correctly.  Please check your " + mobLocale + " source file.");
                                }
                                bCritFailure = true;
                            }

                            mID = parseCheck;
                            break;

                        case 1:
                            mSprName = mobCols[i1].Replace("'", "");
                            break;

                        case 2:
                            mJpnName = mobCols[i1].Replace("'", "");
                            break;

                        case 3:
                            mEngName = mobCols[i1].Replace("'", "");
                            break;

                        case 4:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mLvl = 0; }
                            else { mLvl = parseCheck; }
                            break;

                        case 5:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mHP = 0; }
                            else { mHP = parseCheck; }
                            break;

                        case 6:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mSP = 0; }
                            else { mSP = parseCheck; }
                            break;

                        case 7:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mBaseXP = 0; }
                            else { mBaseXP = parseCheck; }
                            break;

                        case 8:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mJobXP = 0; }
                            else { mJobXP = parseCheck; }
                            break;

                        case 9:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mAtkRng = 0; }
                            else { mAtkRng = parseCheck; }
                            break;

                        case 10:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMinAtk = 0; }
                            else { mMinAtk = parseCheck; }
                            break;

                        case 11:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMaxAtk = 0; }
                            else { mMaxAtk = parseCheck; }
                            break;

                        case 12:
                            if (!Int32.TryParse(mobCols[i1],out parseCheck)) { mDef = 0; }
                            else { mDef = parseCheck; }
                            break;

                        case 13:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMDef = 0; }
                            else { mMDef = parseCheck; }
                            break;

                        case 14:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mStr = 0; }
                            else { mStr = parseCheck; }
                            break;

                        case 15:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mAgi = 0; }
                            else { mAgi = parseCheck; }
                            break;

                        case 16:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mVit = 0; }
                            else { mVit = parseCheck; }
                            break;

                        case 17:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mInt = 0; }
                            else { mInt = parseCheck; }
                            break;

                        case 18:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDex = 0; }
                            else { mDex = parseCheck; }
                            break;

                        case 19:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mLuk = 0; }
                            else { mLuk = parseCheck; }
                            break;

                        case 20:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mSkRng = 0; }
                            else { mSkRng = parseCheck; }
                            break;

                        case 21:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mVwRng = 0; }
                            else { mVwRng = parseCheck; }
                            break;

                        case 22:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mScale = 0; }
                            else { mScale = parseCheck; }
                            break;

                        case 23:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mRace = 0; }
                            else { mRace = parseCheck; }
                            break;

                        case 24:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mEle = 0; }
                            else { mEle = parseCheck; }
                            break;

                        case 25:
                            String formattedHex = "";
                            uint parseCheck2 = 0;
                            bool bInputIsHex = false;
                            if (mobCols[i1].Contains("0x") || mobCols[i1].Contains("0X")){
                                String hexStr = mobCols[i1];
                                formattedHex = hexStr.Substring(2, hexStr.Length - 2);
                                bInputIsHex = true;
                            }

                            if (bInputIsHex){
                                if (!UInt32.TryParse(formattedHex, System.Globalization.NumberStyles.HexNumber, null, out parseCheck2)){
                                    if (bShowErrorsInApp)
                                    {
                                        MessageBox.Show(null, "Mob " + mobCols[0] + " " + mobCols[3] + "'s mode value failed to parse correctly.  Please check your " + mobLocale + " source file.", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mobLog.addLogEntry("warn", "Mob " + mobCols[0] + " " + mobCols[3] + "'s mode value failed to parse correctly.  Please check your " + mobLocale + " source file.");
                                    }

                                    bWarningsOccurred = true;
                                }
                            } else {
                                if (!UInt32.TryParse(mobCols[i1], out parseCheck2)) {
                                    if (bShowErrorsInApp)
                                    {
                                        MessageBox.Show(null, "Mob " + mobCols[0] + " " + mobCols[3] + "'s mode value failed to parse correctly.  Please check your " + mobLocale + " source file.", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mobLog.addLogEntry("warn", "Mob " + mobCols[0] + " " + mobCols[3] + "'s mode value failed to parse correctly.  Please check your " + mobLocale + " source file.");
                                    }

                                    bWarningsOccurred = true;
                                }
                            }

                            mBevMask = parseCheck2;
                            break;

                        case 26:
                            Int32.TryParse(mobCols[i1], out parseCheck);
                            mWlkSpd = parseCheck;
                            break;

                        case 27:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mAtkDly = 0; }
                            else { mAtkDly = parseCheck; }
                            break;

                        case 28:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mAtkMot = 0; }
                            else { mAtkMot = parseCheck; }
                            break;

                        case 29:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDmgMot = 0; }
                            else { mDmgMot = parseCheck; }
                            break;

                        case 30:
                            if (getMasks(mBevMask).Contains(524288)) {
                                if (!Int32.TryParse(mobCols[i1], out parseCheck)){
                                    if (bShowErrorsInApp)
                                    {
                                        MessageBox.Show(null, "Mob " + mobCols[0] + " " + mobCols[3] + "'s MVP EXP value failed to parse correctly.  Please check your " + mobLocale + " source file.", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mobLog.addLogEntry("warn", "Mob " + mobCols[0] + " " + mobCols[3] + "'s MVP EXP value failed to parse correctly.  Please check your " + mobLocale + " source file.");
                                    }

                                    bWarningsOccurred = true;
                                }
                                else { mMXP = parseCheck; }
                            } else {
                                if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMXP = 0; }
                                else { mMXP = parseCheck; }
                            }
                            break;

                        case 31:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMDrop1ID = 0; }
                            else { mMDrop1ID = parseCheck; }
                            break;

                        case 32:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMDrop1Perc = 0; }
                            else { mMDrop1Perc = parseCheck; }
                            break;

                        case 33:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMDrop2ID = 0; }
                            else { mMDrop2ID = parseCheck; }
                            break;

                        case 34:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMDrop2Perc = 0; }
                            else { mMDrop2Perc = parseCheck; }
                            break;

                        case 35:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMDrop3ID = 0; }
                            else { mMDrop3ID = parseCheck; }
                            break;

                        case 36:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mMDrop3Perc = 0; }
                            else { mMDrop3Perc = parseCheck; }
                            break;

                        case 37:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop1ID = 0; }
                            else { mDrop1ID = parseCheck; }
                            break;

                        case 38:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop1Perc = 0; }
                            else { mDrop1Perc = parseCheck; }
                            break;

                        case 39:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop2ID = 0; }
                            else { mDrop2ID = parseCheck; }
                            break;

                        case 40:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop2Perc = 0; }
                            else { mDrop2Perc = parseCheck; }
                            break;

                        case 41:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop3ID = 0; }
                            else { mDrop3ID = parseCheck; }
                            break;

                        case 42:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop3Perc = 0; }
                            else { mDrop3Perc = parseCheck; }
                            break;

                        case 43:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop4ID = 0; }
                            else { mDrop4ID = parseCheck; }
                            break;

                        case 44:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop4Perc = 0; }
                            else { mDrop4Perc = parseCheck; }
                            break;

                        case 45:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop5ID = 0; }
                            else { mDrop5ID = parseCheck; }
                            break;

                        case 46:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop5Perc = 0; }
                            else { mDrop5Perc = parseCheck; }
                            break;

                        case 47:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop6ID = 0; }
                            else { mDrop6ID = parseCheck; }
                            break;

                        case 48:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop6Perc = 0; }
                            else { mDrop6Perc = parseCheck; }
                            break;

                        case 49:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop7ID = 0; }
                            else { mDrop7ID = parseCheck; }
                            break;

                        case 50:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop7Perc = 0; }
                            else { mDrop7Perc = parseCheck; }
                            break;

                        case 51:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop8ID = 0; }
                            else { mDrop8ID = parseCheck; }
                            break;

                        case 52:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop8Perc = 0; }
                            else { mDrop8Perc = parseCheck; }
                            break;

                        case 53:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop9ID = 0; }
                            else { mDrop9ID = parseCheck; }
                            break;

                        case 54:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mDrop9Perc = 0; }
                            else { mDrop9Perc = parseCheck; }
                            break;

                        case 55:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mCardDropID = 0; }
                            else { mCardDropID = parseCheck; }
                            break;

                        case 56:
                            if (!Int32.TryParse(mobCols[i1], out parseCheck)) { mCardDropPerc = 0; }
                            else { mCardDropPerc = parseCheck; }
                            break;
                    }
                }
            }

            bIsInitializing = false;

            mobLocale = mobLocal;
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

        public String generateSQLStatement() {
            string rtnStr = "";

            if (bIsNewMob) {
                if (mobLocale == "custom_mobs") { rtnStr = "Insert Into `" + (String)Settings.Default["cust_mob_loc"] + "` Values("; }
                else { rtnStr = "Insert Into `" + mobLocale + "` Values("; }

                for (int i1 = 0; i1 < ConstData.mobColNames.Count(); i1++) { rtnStr = formatColData(rtnStr, i1); }

                rtnStr = rtnStr.TrimEnd(',');
                rtnStr += ");\r\n";
            } else if (bMobWasUpdated) {
                if (mobLocale == "custom_mobs") { rtnStr = "Update `" + (String)Settings.Default["cust_mob_loc"] + "`\r\nSet"; }
                else { rtnStr = "Update `" + mobLocale + "`\r\nSet"; }

                for (int i1 = 0; i1 < bChangedCols.Count(); i1++) {
                    if (bChangedCols[i1]) {
                        rtnStr += " " + ConstData.mobColNames[i1] + " = ";
                        rtnStr = formatColData(rtnStr, i1);
                    }
                }

                rtnStr = rtnStr.TrimEnd(',');
                rtnStr += "\r\nwhere id = " + mID.ToString() + ";\r\n\r\n";
            }

            return rtnStr;
        }

        public String generateGenLine() {
            string rtnStr = "";
            if (bMobWasUpdated) {
                for (int i1 = 0; i1 < bChangedCols.Count(); i1++) { rtnStr = formatColData(rtnStr, i1); }

                rtnStr = rtnStr.TrimEnd(',');
                rtnStr += "\r\n";
            }

            return rtnStr;
        }

        public void updateMob(mob updMob)
        {
            if (mID != updMob.mID) { mID = updMob.mID; }
            if (mSprName != updMob.mSprName) { mSprName = updMob.mSprName; }
            if (mJpnName != updMob.mJpnName) { mJpnName = updMob.mJpnName; }
            if (mEngName != updMob.mEngName) { mEngName = updMob.mEngName; }
            if (mLvl != updMob.mLvl) { mLvl = updMob.mLvl; }
            if (mHP != updMob.mHP) { mHP = updMob.mHP; }
            if (mSP != updMob.mSP) { mSP = updMob.mSP; }
            if (mBaseXP != updMob.mBaseXP) { mBaseXP = updMob.mBaseXP; }
            if (mJobXP != updMob.mJobXP) { mJobXP = updMob.mJobXP; }
            if (mAtkRng != updMob.mAtkRng) { mAtkRng = updMob.mAtkRng; }
            if (mMinAtk != updMob.mMinAtk) { mMinAtk = updMob.mMinAtk; }
            if (mMaxAtk != updMob.mMaxAtk) { mMaxAtk = updMob.mMaxAtk; }
            if (mDef != updMob.mDef) { mDef = updMob.mDef; }
            if (mMDef != updMob.mMDef) { mMDef = updMob.mMDef; }
            if (mStr != updMob.mStr) { mStr = updMob.mStr; }
            if (mAgi != updMob.mAgi) { mAgi = updMob.mAgi; }
            if (mVit != updMob.mVit) { mVit = updMob.mVit; }
            if (mInt != updMob.mInt) { mInt = updMob.mInt; }
            if (mDex != updMob.mDex) { mDex = updMob.mDex; }
            if (mLuk != updMob.mLuk) { mLuk = updMob.mLuk; }
            if (mSkRng != updMob.mSkRng) { mSkRng = updMob.mSkRng; }
            if (mVwRng != updMob.mVwRng) { mVwRng = updMob.mVwRng; }
            if (mScale != updMob.mScale) { mScale = updMob.mScale; }
            if (mRace != updMob.mRace) { mRace = updMob.mRace; }
            if (mEle != updMob.mEle) { mEle = updMob.mEle; }
            if (mBevMask != updMob.mBevMask) { mBevMask = updMob.mBevMask; }
            if (mWlkSpd != updMob.mWlkSpd) { mWlkSpd = updMob.mWlkSpd; }
            if (mAtkDly != updMob.mAtkDly) { mAtkDly = updMob.mAtkDly; }
            if (mAtkMot != updMob.mAtkMot) { mAtkMot = updMob.mAtkMot; }
            if (mDmgMot != updMob.mDmgMot) { mDmgMot = updMob.mDmgMot; }
            if (mMXP != updMob.mMXP) { mMXP = updMob.mMXP; }
            if (mMDrop1ID != updMob.mMDrop1ID) { mMDrop1ID = updMob.mMDrop1ID; }
            if (mMDrop1Perc != updMob.mMDrop1Perc) { mMDrop1Perc = updMob.mMDrop1Perc; }
            if (mMDrop2ID != updMob.mMDrop2ID) { mMDrop2ID = updMob.mMDrop2ID; }
            if (mMDrop2Perc != updMob.mMDrop2Perc) { mMDrop2Perc = updMob.mMDrop2Perc; }
            if (mMDrop3ID != updMob.mMDrop3ID) { mMDrop3ID = updMob.mMDrop3ID; }
            if (mMDrop3Perc != updMob.mMDrop3Perc) { mMDrop3Perc = updMob.mMDrop3Perc; }
            if (mDrop1ID != updMob.mDrop1ID) { mDrop1ID = updMob.mDrop1ID; }
            if (mDrop1Perc != updMob.mDrop1Perc) { mDrop1Perc = updMob.mDrop1Perc; }
            if (mDrop2ID != updMob.mDrop2ID) { mDrop2ID = updMob.mDrop2ID; }
            if (mDrop2Perc != updMob.mDrop2Perc) { mDrop2Perc = updMob.mDrop2Perc; }
            if (mDrop3ID != updMob.mDrop3ID) { mDrop3ID = updMob.mDrop3ID; }
            if (mDrop3Perc != updMob.mDrop3Perc) { mDrop3Perc = updMob.mDrop3Perc; }
            if (mDrop4ID != updMob.mDrop4ID) { mDrop4ID = updMob.mDrop4ID; }
            if (mDrop4Perc != updMob.mDrop4Perc) { mDrop4Perc = updMob.mDrop4Perc; }
            if (mDrop5ID != updMob.mDrop5ID) { mDrop5ID = updMob.mDrop5ID; }
            if (mDrop5Perc != updMob.mDrop5Perc) { mDrop5Perc = updMob.mDrop5Perc; }
            if (mDrop6ID != updMob.mDrop6ID) { mDrop6ID = updMob.mDrop6ID; }
            if (mDrop6Perc != updMob.mDrop6Perc) { mDrop6Perc = updMob.mDrop6Perc; }
            if (mDrop7ID != updMob.mDrop7ID) { mDrop7ID = updMob.mDrop7ID; }
            if (mDrop7Perc != updMob.mDrop7Perc) { mDrop7Perc = updMob.mDrop7Perc; }
            if (mDrop8ID != updMob.mDrop8ID) { mDrop8ID = updMob.mDrop8ID; }
            if (mDrop8Perc != updMob.mDrop8Perc) { mDrop8Perc = updMob.mDrop8Perc; }
            if (mDrop9ID != updMob.mDrop9ID) { mDrop9ID = updMob.mDrop9ID; }
            if (mDrop9Perc != updMob.mDrop9Perc) { mDrop9Perc = updMob.mDrop9Perc; }
            if (mCardDropID != updMob.mCardDropID) { mCardDropID = updMob.mCardDropID; }
            if (mCardDropPerc != updMob.mCardDropPerc) { mCardDropPerc = updMob.mCardDropPerc; }

            bMobWasUpdated = true;
        }

        String formatColData(String rtnStr, int i1)
        {
            switch (i1)
            {
                case 0:
                    rtnStr += mID.ToString() + ",";
                    break;

                case 1:
                    rtnStr += "\"" + mSprName + "\",";
                    break;

                case 2:
                    rtnStr += "\"" + mJpnName + "\",";
                    break;

                case 3:
                    rtnStr += "\"" + mEngName + "\",";
                    break;

                case 4:
                    rtnStr += mLvl.ToString() + ",";
                    break;

                case 5:
                    rtnStr += mHP.ToString() + ",";
                    break;

                case 6:
                    rtnStr += mSP.ToString() + ",";
                    break;

                case 7:
                    rtnStr += mBaseXP.ToString() + ",";
                    break;

                case 8:
                    rtnStr += mJobXP.ToString() + ",";
                    break;

                case 9:
                    rtnStr += mAtkRng.ToString() + ",";
                    break;

                case 10:
                    rtnStr += mMinAtk.ToString() + ",";
                    break;

                case 11:
                    rtnStr += mMaxAtk.ToString() + ",";
                    break;

                case 12:
                    rtnStr += mDef.ToString() + ",";
                    break;

                case 13:
                    rtnStr += mMDef.ToString() + ",";
                    break;

                case 14:
                    rtnStr += mStr.ToString() + ",";
                    break;

                case 15:
                    rtnStr += mAgi.ToString() + ",";
                    break;

                case 16:
                    rtnStr += mVit.ToString() + ",";
                    break;

                case 17:
                    rtnStr += mInt.ToString() + ",";
                    break;

                case 18:
                    rtnStr += mDex.ToString() + ",";
                    break;

                case 19:
                    rtnStr += mLuk.ToString() + ",";
                    break;

                case 20:
                    rtnStr += mSkRng.ToString() + ",";
                    break;

                case 21:
                    rtnStr += mVwRng.ToString() + ",";
                    break;

                case 22:
                    rtnStr += mScale.ToString() + ",";
                    break;

                case 23:
                    rtnStr += mRace.ToString() + ",";
                    break;

                case 24:
                    rtnStr += mEle.ToString() + ",";
                    break;

                case 25:
                    rtnStr += mBevMask.ToString() + ",";
                    break;

                case 26:
                    rtnStr += mWlkSpd.ToString() + ",";
                    break;

                case 27:
                    rtnStr += mAtkDly.ToString() + ",";
                    break;

                case 28:
                    rtnStr += mAtkMot.ToString() + ",";
                    break;

                case 29:
                    rtnStr += mDmgMot.ToString() + ",";
                    break;

                case 30:
                    rtnStr += mMXP.ToString() + ",";
                    break;

                case 31:
                    rtnStr += mMDrop1ID.ToString() + ",";
                    break;

                case 32:
                    rtnStr += mMDrop1Perc.ToString() + ",";
                    break;

                case 33:
                    rtnStr += mMDrop2ID.ToString() + ",";
                    break;

                case 34:
                    rtnStr += mMDrop2Perc.ToString() + ",";
                    break;

                case 35:
                    rtnStr += mMDrop3ID.ToString() + ",";
                    break;

                case 36:
                    rtnStr += mMDrop3Perc.ToString() + ",";
                    break;

                case 37:
                    rtnStr += mDrop1ID.ToString() + ",";
                    break;

                case 38:
                    rtnStr += mDrop1Perc.ToString() + ",";
                    break;

                case 39:
                    rtnStr += mDrop2ID.ToString() + ",";
                    break;

                case 40:
                    rtnStr += mDrop2Perc.ToString() + ",";
                    break;

                case 41:
                    rtnStr += mDrop3ID.ToString() + ",";
                    break;

                case 42:
                    rtnStr += mDrop3Perc.ToString() + ",";
                    break;

                case 43:
                    rtnStr += mDrop4ID.ToString() + ",";
                    break;

                case 44:
                    rtnStr += mDrop4Perc.ToString() + ",";
                    break;

                case 45:
                    rtnStr += mDrop5ID.ToString() + ",";
                    break;

                case 46:
                    rtnStr += mDrop5Perc.ToString() + ",";
                    break;

                case 47:
                    rtnStr += mDrop6ID.ToString() + ",";
                    break;

                case 48:
                    rtnStr += mDrop6Perc.ToString() + ",";
                    break;

                case 49:
                    rtnStr += mDrop7ID.ToString() + ",";
                    break;

                case 50:
                    rtnStr += mDrop7Perc.ToString() + ",";
                    break;

                case 51:
                    rtnStr += mDrop8ID.ToString() + ",";
                    break;

                case 52:
                    rtnStr += mDrop8Perc.ToString() + ",";
                    break;

                case 53:
                    rtnStr += mDrop9ID.ToString() + ",";
                    break;

                case 54:
                    rtnStr += mDrop9Perc.ToString() + ",";
                    break;

                case 55:
                    rtnStr += mCardDropID.ToString() + ",";
                    break;

                case 56:
                    rtnStr += mCardDropPerc.ToString() + ",";
                    break;
            }

            return rtnStr;
        }
    }
}
