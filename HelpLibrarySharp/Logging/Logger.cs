using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using static HelpLibrarySharp.Configuration;
namespace HelpLibrarySharp.Logging
{
    /// <summary>
    /// Class of loging internal logger of HelpLibrarySharp
    /// </summary>
     public static class Logger
    {
      //  public static bool is_loggerON = false;
       // public static string logfileName = "hls.log";
        public static void Log(string str)
        {
            if (is_LoggerOn)
            {
               if(checklogFile() == false)
               {
                    throw new Exception("Couldn't create log file\n");
               }
                Thread.Sleep(1500);
                File.AppendAllText(logFileName, "[" + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss") + "]" + " " + str);
            }
        }
        private static bool checklogFile()
        {
            if (!File.Exists(logFileName))
            {
                try { File.CreateText(logFileName).Close(); File.AppendAllText(logFileName, "[" + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss") + "]" + " Logger initialized succesfully\n"); return true; } catch { return false; throw new Exception("Couldn't create file"); } 
            }
            else
            {
             return true;
            }
        }
    }
}
