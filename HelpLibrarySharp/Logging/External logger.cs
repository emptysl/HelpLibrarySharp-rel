using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static HelpLibrarySharp.Configuration;
namespace HelpLibrarySharp.Logging
{
    /// <summary>
    /// Class of logging methods or errors simply
    /// </summary>
   public static class External_logger
    {
        public static void log(string str,bool using_timestamp = true)
        {
            if(is_extLoggerOn == true)
            {
                if (!using_timestamp)
                {
                    File.AppendAllText(extFileName, str+"\n");
                }
                else
                {
                    File.AppendAllText(extFileName, "[" + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss") + "]" + " " + str+"\n");
                }
              
            }
        }
    }
}
