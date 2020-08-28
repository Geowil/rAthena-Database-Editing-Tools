using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using rAthena_Database_Editing_Tools.Properties;

namespace rAthena_Database_Editing_Tools
{
    public class Logging
    {
        StreamWriter logger;
        String logPath;
        String logName;
        String infLogName;
        String wrnLogName;
        String errLogName;
        int loggingLvl;

        String logInfSfx;
        String logWrnSfx;
        String logErrSfx;

        bool bLoggingEnabled;
        bool bILoggingEnabled;


        public Logging() {
            logPath = (String)Settings.Default["log_location"];
            logInfSfx = (String)Settings.Default["info_sufx"];
            logWrnSfx = (String)Settings.Default["warn_sufx"];
            logErrSfx = (String)Settings.Default["err_sufx"];
            bLoggingEnabled = (bool)Settings.Default["enable_logging"];
            bILoggingEnabled = (bool)Settings.Default["indy_logging"];
            loggingLvl = (int)Settings.Default["log_level"];

            if (bLoggingEnabled) { createLog(); }
        }

        public void createLog()
        {
            if (!bILoggingEnabled)
            {
                logName = DateTime.Now.ToString("MM-dd-yyyy hh.mm.ss tt");
            }
            else
            {
                String dStr = DateTime.Now.ToString("MM-dd-yyy hh.mm.ss tt");
                infLogName = dStr + logInfSfx;
                wrnLogName = dStr + logWrnSfx;
                errLogName = dStr + logErrSfx;
            }
        }

        public void addLogEntry(string errSevrt, string msg)
        {
            if (bLoggingEnabled)
            {
                String errStr = "[" + errSevrt + "]: " + msg + "\r\n";

                if (!bILoggingEnabled) { writeToFile(logName, errStr); }
                else
                {
                    if (errSevrt == "info" && loggingLvl >= 1) { writeToFile(infLogName, errStr); }
                    else if (errSevrt == "warn" && loggingLvl >= 2) { writeToFile(wrnLogName, errStr); }
                    else if (errSevrt == "err" && loggingLvl == 3) {
                        writeToFile(errLogName, errStr); }
                }
            }
        }

        private void writeToFile(String fname, String errmsg) {
            using (logger = File.AppendText(logPath + "\\" + fname + ".txt")) { logger.WriteLine(errmsg); }
        }
    }
}
