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
    public class item
    {
        List<bool> bChangedCols;
        bool bIsInitializing;

        public bool bIsNewItem;

        public bool bCritFailure { get; private set; }
        public bool bWarningsOccurred { get; private set; }
        public String itemLocale { get; set; }
        bool bItemWasUpdated;
        bool bShowErrorsInApp;

        Logging itmLog;

        int _iID;
        public int iID{
            get { return _iID; }
            set {
                _iID = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[0] = true; }
            }
        }

        String _iEngName;
        public String iEngName {
            get { return _iEngName; }
            set {
                _iEngName = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[1] = true; }
            }
        }

        String _iJpnName;
        public String iJpnName {
            get { return _iJpnName; }
            set
            {
                _iJpnName = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[2] = true; }
            }
        }

        int _iType;
        public int iType {
            get { return _iType; }
            set
            {
                _iType = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[3] = true; }
            }
        }

        int _iBPrice;
        public int iBPrice {
            get { return _iBPrice; }
            set
            {
                _iBPrice = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[4] = true; }
            }
        }

        int _iSPrice;
        public int iSPrice {
            get { return _iSPrice; }
            set
            {
                _iSPrice = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[5] = true; }
            }
        }

        int _iWeight;
        public int iWeight {
            get { return _iWeight; }
            set
            {
                _iWeight = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[6] = true; }
            }
        }

        String _iAtkMAtk;
        public String iAtkMAtk {
            get { return _iAtkMAtk; }
            set
            {
                _iAtkMAtk = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[7] = true; }
            }
        }

        int _iDef;
        public int iDef {
            get { return _iDef; }
            set
            {
                _iDef = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[8] = true; }
            }
        }

        int _iRng;
        public int iRng {
            get { return _iRng; }
            set
            {
                _iRng = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[9] = true; }
            }
        }

        int _iSlots;
        public int iSlots {
            get { return _iSlots; }
            set
            {
                _iSlots = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[10] = true; }
            }
        }

        uint _iEqpJobs;
        public uint iEqpJobs {
            get { return _iEqpJobs; }
            set
            {
                _iEqpJobs = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[11] = true; }
            }
        }

        int _iEqpUpper;
        public int iEqpUpper {
            get { return _iEqpUpper; }
            set
            {
                _iEqpUpper = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[12] = true; }
            }
        }

        int _iEqpGen;
        public int iEqpGen {
            get { return _iEqpGen; }
            set
            {
                _iEqpGen = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[13] = true; }
            }
        }

        uint _iEqpLocals;
        public uint iEqpLocals {
            get { return _iEqpLocals; }
            set
            {
                _iEqpLocals = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[14] = true; }
            }
        }

        int _iWeapLvl;
        public int iWeapLvl {
            get { return _iWeapLvl; }
            set
            {
                _iWeapLvl = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[15] = true; }
            }
        }

        int _iEqpLvl;
        public int iEqpLvl {
            get { return _iEqpLvl; }
            set
            {
                _iEqpLvl = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[16] = true; }
            }
        }

        int _iRefinable;
        public int iRefinable {
            get { return _iRefinable; }
            set
            {
                _iRefinable = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[17] = true; }
            }
        }

        int _iView;
        public int iView {
            get { return _iView; }
            set
            {
                _iView = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[18] = true; }
            }
        }

        String _iScript;
        public String iScript
        {
            get { return _iScript; }
            set
            {
                _iScript = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[19] = true; }
            }
        }

        String _iEqpScript;
        public String iEqpScript {
            get { return _iEqpScript; }
            set
            {
                _iEqpScript = value;
                if (!bIsInitializing && !bIsNewItem) { bChangedCols[20] = true; }
            }
        }

        String _iUneqpScript;
        public String iUneqpScript
        {
            get { return _iUneqpScript; }
            set
            {
                _iUneqpScript = value;

                if (!bIsInitializing && !bIsNewItem) { bChangedCols[21] = true; }
            }
        }

        public item() {
            bChangedCols = new List<bool>();
            bItemWasUpdated = false;
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            for (int i1 = 0; i1 < 22; i1++)
            {
                bChangedCols.Add(false);
            }            
        }

        public item(bool bIsNew, bool bIsInit) {
            bIsNewItem = bIsNew;
            bIsInitializing = bIsInit;
            bItemWasUpdated = false;
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            bChangedCols = new List<bool>();

            for (int i1 = 0; i1 < 22; i1++)
            {
                bChangedCols.Add(false);
            }            
        }

        public item(String itmData, bool bIsNew, String itmLocale, Logging log) {
            bChangedCols = new List<bool>();
            bItemWasUpdated = false;
            bShowErrorsInApp = (bool)Settings.Default["rpt_errs_in_app"];

            itemLocale = itmLocale;

            itmLog = log;

            for (int i1 = 0; i1 < 22; i1++) {
                bChangedCols.Add(false);
            }

            String[] itmCols = Regex.Split(itmData, ",(?![^rand(]*\\)|[^{]*\\}|[^']*;)");
            bIsInitializing = true;
           // bIsNewItem = bIsNew;
            bCritFailure = false;

            int parseCheck;

            for (int i1 = 0; i1 < itmCols.Count(); i1++) {
                if (!bCritFailure) {
                    switch (i1) {
                        case 0:
                            iID = checkValidity(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 1:
                            iEngName = itmCols[i1].Replace("'","");
                            break;

                        case 2:
                            iJpnName = itmCols[i1].Replace("'", "");
                            break;

                        case 3:
                            iType = checkValidity(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 4:
                            if (!Int32.TryParse(itmCols[i1], out parseCheck)) { iBPrice = 0; }
                            else { iBPrice = parseCheck; }
                            break;

                        case 5:
                            if (!Int32.TryParse(itmCols[i1], out parseCheck)) { iSPrice = 0; }
                            else { iSPrice = parseCheck; }
                            break;

                        case 6:
                            if (!Int32.TryParse(itmCols[i1], out parseCheck)) { iWeight = 0; }
                            else { iWeight = parseCheck; }
                            break;

                        case 7:
                            iAtkMAtk = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]).ToString();
                            break;

                        case 8:
                            iDef = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 9:
                            iRng = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 10:
                            if (!Int32.TryParse(itmCols[i1], out parseCheck)) { iSlots = 0; }
                            else { iSlots = parseCheck; }
                            break;

                        case 11:
                            iEqpJobs = constraintChecking(itmCols[i1], Convert.ToUInt32(i1), itmData, itmCols[0]);
                            break;

                        case 12:
                            iEqpUpper = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 13:
                            iEqpGen = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 14:
                            iEqpLocals = constraintChecking(itmCols[i1], Convert.ToUInt32(i1), itmData, itmCols[0]);
                            break;

                        case 15:
                            iWeapLvl = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 16:
                            iEqpLvl = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 17:
                            if (!Int32.TryParse(itmCols[i1], out parseCheck)) { iRefinable = 0; }
                            else { iRefinable = parseCheck; }
                            break;

                        case 18:
                            iView = constraintChecking(itmCols[i1], i1, itmData, itmCols[0]);
                            break;

                        case 19:
                            iScript = itmCols[i1].Replace("'", "");
                            break;

                        case 20:
                            iEqpScript = itmCols[i1].Replace("'", "");
                            break;

                        case 21:
                            iUneqpScript = itmCols[i1].Replace("'", "");
                            break;
                    }
                }
            }

            bIsInitializing = false;
            bIsNewItem = bIsNew;
        }

        private int checkValidity(String iptStr, int caseVal, String data, String id)
        {
            int rtnVal = 0;

            switch (caseVal){
                case 0:
                    if (!Int32.TryParse(iptStr, out rtnVal)){
                        if (bShowErrorsInApp)
                        {
                            MessageBox.Show(null, "Item " + id + "'s ID value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            itmLog.addLogEntry("err","Item " + id + "'s ID value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                        }

                        bCritFailure = true;
                    }
                    break;

                case 3:
                    if (!Int32.TryParse(iptStr, out rtnVal)){
                        if (bShowErrorsInApp)
                        {
                            MessageBox.Show(null, "Item " + id + "'s type value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            itmLog.addLogEntry("warn", "Item " + id + "'s type value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                        }

                        bWarningsOccurred = true;
                    }                    
                    break;
            }

            return rtnVal;
        }

        private int constraintChecking(String iptStr, int caseVal, String data, String id)
        {
            int rtnVal = 0;
            switch (caseVal){
                case 7:
                    if (itemLocale.Contains("re") && iType == 5 && (String.Equals(iptStr, "null", StringComparison.OrdinalIgnoreCase) || iptStr == "" || iptStr == "''")){
                        if (bShowErrorsInApp)
                        {
                            MessageBox.Show(null, "Item " + id + "'s atk:matk value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            itmLog.addLogEntry("warn", "Item " + id + "'s atk:matk value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                        }

                        bWarningsOccurred = true;
                    } else if (!itemLocale.Contains("re") && iType == 5 && (!Int32.TryParse(iptStr, out rtnVal))){
                        if (bShowErrorsInApp)
                        {
                            MessageBox.Show(null, "Item " + id + "'s attack value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            itmLog.addLogEntry("warn", "Item " + id + "'s attack value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                        }

                        bWarningsOccurred = true;
                    }
                    break;

                case 8:
                    if (iType == 4 || iType == 12){
                        if (!Int32.TryParse(iptStr, out rtnVal)){
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s defense value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s defense value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    } else { Int32.TryParse(iptStr, out rtnVal); }
                    break;

                case 9:
                    if (iType == 5){
                        if (!Int32.TryParse(iptStr, out rtnVal)){
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s attack range value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s attack range value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    }
                    else { Int32.TryParse(iptStr, out rtnVal); }
                    break;

                
                case 12:
                    if (iType != 3){
                        if (!Int32.TryParse(iptStr, out rtnVal)){
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s equip upper value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s equip upper value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    } else { Int32.TryParse(iptStr, out rtnVal); }
                    break;

                case 13:
                    if (iType == 4 || iType == 5 || iType == 12){
                        if (!Int32.TryParse(iptStr, out rtnVal)){
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s equip gender value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s equip gender value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    }
                    else  { Int32.TryParse(iptStr, out rtnVal); }
                    break;

                case 15:
                    if (iType == 5) {
                        if (!Int32.TryParse(iptStr, out rtnVal)) {
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s weapon level value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s weapon level range value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    } else { Int32.TryParse(iptStr, out rtnVal); }
                    break;

                case 16:
                    if (iType == 4 || iType == 5 || iType == 12) {
                        if (!Int32.TryParse(iptStr, out rtnVal)) {
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s attack range value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s attack range value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    } else { Int32.TryParse(iptStr, out rtnVal); }
                    break;

                case 18:
                    if (iType == 4 || iType == 5 || iType == 12) {
                        if (!Int32.TryParse(iptStr, out rtnVal)) {
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s view value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s view value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    } else { Int32.TryParse(iptStr, out rtnVal); }
                    break;

                default:
                    break;
            }

            return rtnVal;
        }

        private uint constraintChecking(String iptStr, uint caseVal, String data, String id)
        {
            uint rtnVal = 0;
            switch (caseVal)
            {                
                case 11:
                    String formattedHex = "";
                    bool bInputIsHex = false;
                    if (iptStr.Contains("0x") || iptStr.Contains("0X")){
                        String hexStr = iptStr;
                        formattedHex = hexStr.Substring(2, hexStr.Length - 2);
                        bInputIsHex = true;
                    }

                    if (iType != 3 && iType != 6 && iType != 7 && iType != 8)
                    {
                        if (bInputIsHex)
                        {
                            if (!UInt32.TryParse(formattedHex, System.Globalization.NumberStyles.HexNumber, null, out rtnVal))
                            {
                                if (bShowErrorsInApp)
                                {
                                    MessageBox.Show(null, "Item " + id + "'s equip job value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    itmLog.addLogEntry("warn", "Item " + id + "'s equip job value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                                }

                                bWarningsOccurred = true;
                            }
                        }
                        else
                        {
                            if (!UInt32.TryParse(iptStr, out rtnVal))
                            {
                                if (bShowErrorsInApp)
                                {
                                    MessageBox.Show(null, "Item " + id + "'s equip job value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    itmLog.addLogEntry("warn", "Item " + id + "'s equip job value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                                }

                                bWarningsOccurred = true;
                            }
                        }
                    } else {
                        if (bInputIsHex) { UInt32.TryParse(formattedHex, System.Globalization.NumberStyles.HexNumber, null, out rtnVal); }
                        else { UInt32.TryParse(iptStr, out rtnVal); }
                    }
                    break;

                case 14:
                    if (iType == 4 || iType == 5 || iType == 12)
                    {
                        if (!UInt32.TryParse(iptStr, out rtnVal))
                        {
                            if (bShowErrorsInApp)
                            {
                                MessageBox.Show(null, "Item " + id + "'s equip locations value failed to parse correctly.  Please check your " + itemLocale + " source file.  Invalid row:\r\r " + data, "Integer Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                itmLog.addLogEntry("warn", "Item " + id + "'s equip locations value failed to parse correctly.  Please check your " + itemLocale + " source file.");
                            }

                            bWarningsOccurred = true;
                        }
                    }
                    else { UInt32.TryParse(iptStr, out rtnVal); }
                    break;

                default:
                    break;
            }

            return rtnVal;
        }

        public String generateSQLStatement()
        {
            string rtnStr = "";

            if (bIsNewItem)
            {
                if (itemLocale == "custom_items") { rtnStr = "Insert Into `" + (String)Settings.Default["cust_itm_loc"] + "` Values("; }
                else { rtnStr = "Insert Into `" + itemLocale + "` Values("; }

                for (int i1 = 0; i1 < bChangedCols.Count(); i1++) { rtnStr = formatColData(rtnStr, i1); }

                rtnStr = rtnStr.TrimEnd(',');
                rtnStr += ");\r\n";
            }
            else if (bItemWasUpdated)
            {
                if (itemLocale == "custom_items") { rtnStr = "Update `" + (String)Settings.Default["cust_itm_loc"] + "`\r\nSet"; }
                else { rtnStr = "Update `" + itemLocale + "`\r\nSet"; }

                for (int i1 = 0; i1 < bChangedCols.Count(); i1++)
                {
                    if (bChangedCols[i1])
                    {
                        rtnStr += " " + ConstData.itemColNames[i1] + " = ";
                        rtnStr = formatColData(rtnStr, i1);
                    }
                }

                rtnStr = rtnStr.TrimEnd(',');
                rtnStr += "\r\nwhere id = " + iID.ToString() + ";\r\n\r\n";
            }

            return rtnStr;
        }

        public String generateGenLine()
        {
            string rtnStr = "";

            if (bItemWasUpdated) {
                for (int i1 = 0; i1 < bChangedCols.Count(); i1++) { rtnStr = formatColData(rtnStr, i1); }

                rtnStr = rtnStr.TrimEnd(',');
                rtnStr += "\r\n";
            }

            return rtnStr;

        }

        String formatColData(String rtnStr, int i1)
        {
            switch (i1)
            {
                case 0:
                    rtnStr += iID.ToString() + ",";
                    break;

                case 1:
                    rtnStr += "\"" + iEngName + "\",";
                    break;

                case 2:
                    if (iJpnName.Contains('\\')) { iJpnName.Replace("\\", "\\\\"); } //Handle any \' in the item names

                    rtnStr += "\"" + iJpnName + "\",";
                    break;

                case 3:
                    rtnStr += iType.ToString() + ",";
                    break;

                case 4:
                    rtnStr += iBPrice.ToString() + ",";
                    break;

                case 5:
                    rtnStr += iSPrice.ToString() + ",";
                    break;

                case 6:
                    rtnStr += iWeight.ToString() + ",";
                    break;

                case 7:
                    if (itemLocale.Contains("re")) { rtnStr += "\"" + iAtkMAtk + "\","; }
                    else { rtnStr += iAtkMAtk + ","; }
                    break;

                case 8:
                    rtnStr += iDef.ToString() + ",";
                    break;

                case 9:
                    rtnStr += iRng.ToString() + ",";
                    break;

                case 10:
                    rtnStr += iSlots.ToString() + ",";
                    break;

                case 11:
                    rtnStr += iEqpJobs.ToString() + ",";
                    break;

                case 12:
                    rtnStr += iEqpUpper.ToString() + ",";
                    break;

                case 13:
                    rtnStr += iEqpGen.ToString() + ",";
                    break;

                case 14:
                    rtnStr += iEqpLocals.ToString() + ",";
                    break;

                case 15:
                    rtnStr += iWeapLvl.ToString() + ",";
                    break;

                case 16:
                    rtnStr += iEqpLvl.ToString() + ",";
                    break;

                case 17:
                    rtnStr += iRefinable.ToString() + ",";
                    break;

                case 18:
                    rtnStr += iView.ToString() + ",";
                    break;

                case 19:
                    rtnStr += "\"" + iScript + "\",";
                    break;

                case 20:
                    rtnStr += "\"" + iEqpScript + "\",";
                    break;

                case 21:
                    rtnStr += "\"" + iUneqpScript + "\",";
                    break;
            }

            return rtnStr;
        }


        public void updateItem(item updItem)
        {
            if (iID != updItem.iID) { iID = updItem.iID;}
            if (iEngName != updItem.iEngName) { iEngName = updItem.iEngName; }
            if (iJpnName != updItem.iJpnName) { iJpnName = updItem.iJpnName; }
            if (iType != updItem.iType) { iType = updItem.iType; }
            if (iBPrice != updItem.iBPrice) { iBPrice = updItem.iBPrice; }
            if (iSPrice != updItem.iSPrice) { iSPrice = updItem.iSPrice; }
            if (iWeight != updItem.iWeight) { iWeight = updItem.iWeight; }
            if (iAtkMAtk != updItem.iAtkMAtk) { iAtkMAtk = updItem.iAtkMAtk; }
            if (iDef != updItem.iDef) { iDef = updItem.iDef; }
            if (iRng != updItem.iRng) { iRng = updItem.iRng; }
            if (iSlots != updItem.iSlots) { iSlots = updItem.iSlots; }
            if (iEqpJobs != updItem.iEqpJobs) { iEqpJobs = updItem.iEqpJobs; }
            if (iEqpUpper != updItem.iEqpUpper) { iEqpUpper = updItem.iEqpUpper; }
            if (iEqpGen != updItem.iEqpGen) { iEqpGen = updItem.iEqpGen; }
            if (iEqpLocals != updItem.iEqpLocals) { iEqpLocals = updItem.iEqpLocals; }
            if (iWeapLvl != updItem.iWeapLvl) { iWeapLvl = updItem.iWeapLvl; }
            if (iEqpLvl != updItem.iEqpLvl) { iEqpLvl = updItem.iEqpLvl; }
            if (iRefinable != updItem.iRefinable) { iRefinable = updItem.iRefinable; }
            if (iView != updItem.iView) { iView = updItem.iView; }
            if (iScript != updItem.iScript) { iScript = updItem.iScript; }
            if (iEqpScript != updItem.iEqpScript) { iEqpScript = updItem.iEqpScript; }
            if (iUneqpScript != updItem.iUneqpScript) { iUneqpScript = updItem.iUneqpScript; }

            if (itemLocale != updItem.itemLocale) { itemLocale = updItem.itemLocale; }

            bItemWasUpdated = true;
        }
    }
}
