    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Data;
    using System.Diagnostics;
    using static HelpLibrarySharp.Logging.Logger;
using static HelpLibrarySharp.Configuration;
namespace HelpLibrarySharp
{
    /// <summary>
/// Class for make default easier
/// </summary>
    public static class MainHelp
    {/// <summary>
    /// You can just Init() by deafult settings.
    /// </summary>
    /// <param name="usingExtLogger"></param>
    /// <param name="usingLogger"></param>
    /// <param name="showDebugMessages"></param>
    /// <param name="logfileNameS"></param>
    /// <param name="extfileNameS"></param>
        public static void Init(bool usingExtLogger = false, bool usingLogger=false, bool showDebugMessages = false, string logfileNameS = "hls.log",string extfileNameS = "extLog.log")
        {
            int status = 0;
            #region logger
            if (logfileNameS != "hls.log")
            {
                status = status + 1;
               logFileName = logfileNameS;
            }
            if (usingLogger == true)
            {
               is_LoggerOn = true;
                if(showDebugMessages == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteL("Date of latest release: " + date_of_release);
                    WriteL("Logger: enabled");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                status = status + 1;
            }
            else
            {
               is_LoggerOn = false;
                if (showDebugMessages == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteL("Logger: Disabled");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            #endregion
            #region debugmsg
            if (showDebugMessages == true)
            {
                WriteL("Log file name set: " + logfileNameS);
                WriteL("External logging file output set: " + extfileNameS);
                status = status + 1;
            }
            #endregion
            #region extern logger
            if (usingExtLogger == true)
            {
               extFileName = extfileNameS;
               is_extLoggerOn = true;
                status = status + 1;
                if (showDebugMessages == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteL("External Logger: Enabled");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }
            else
            {
                
                if (showDebugMessages == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteL("External Logger: Disabled");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
               
            }
            #endregion
            #region output
            if (status == 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                WriteL("HelpLibrarySharp initialized successfully");
                Console.ForegroundColor = ConsoleColor.Gray;
                WriteL("Starting status: " + status.ToString());
            }
            else
            {
                if (showDebugMessages)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if(usingExtLogger == false || usingLogger == false)
                    {
                        WriteL("HelpLibrarySharp isn't using 100%");
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Gray;
                    WriteL("Staring status: " + status.ToString());
                }
            }
            #endregion
            if (is_LoggerOn == true)
            {
                File.AppendAllText(logFileName, "Date of compilation: " + date_of_release);
                File.AppendAllText(logFileName, "Initialization completed successfully");
            }
        }

        #region reading writing
        /// <summary>
        /// Write a line in console
        /// </summary>
        /// <param name="str"></param>
        public static void WriteL(string str)
        {
            Console.WriteLine(str);
            Log("Method WriteL used\n");
        }
        /// <summary>
        /// Write string in a console
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str)
        {
            Console.Write(str);
         
            Log("Method Write used\n");
        }
        /// <summary>
        /// Read a line
        /// </summary>
        public static void ReadL()
        {
            Console.ReadLine();
            Log("Method ReadL used\n");
        }
        /// <summary>
        /// Simply Console.Read
        /// </summary>
        public static void Read()
        {
            Console.Read();
            Log("Method Read used\n");
        }
        #endregion
        /// <summary>
        /// Deleting a file simply
        /// </summary>
        /// <param name="path"></param>
        public static void DelF(string path)
        {
            try
            {
                File.Delete(path);
                Log("Method DelF used\n");
                Log("File: " + path + " deleted\n");
            }
            catch (Exception ex)
            {
                Log("Exception with file: " + ex.ToString()+ "\n");
                throw new System.ArgumentException("В библиотеке HelpLibrarySharp возникла ошибка! Проблема с удалением файла!!!", "Error");
                
            }
        }
        /// <summary>
        /// Deleting a directory simply
        /// </summary>
        /// <param name="path"></param>
        /// <param name="conf"></param>
        public static void delDir(string path,bool conf)
        {
            try
            {
                Directory.Delete(path, conf);
            }
            catch
            {
                Log("Exception with a directory\n");
                throw new System.ArgumentException("В библиотеке HelpLibrarySharp возникла ошибка! Проблема с удалением директории!!!", "Error");
            }
        }
        /// <summary>
        /// Throwing an exception
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        public static void thrEX(string text, string title)
        {
            Log("Exception throwed: " + text+ "\n");
            throw new System.ArgumentException(text, title);
        }
        /// <summary>
        /// Killing a process
        /// </summary>
        /// <param name="procNamewithoutEXE"></param>
       public static void killPrcs(string procNamewithoutEXE)
        {
            try
            {
                Process[] ps1 = System.Diagnostics.Process.GetProcessesByName(procNamewithoutEXE);
                foreach (Process p1 in ps1)
                {

                    p1.Kill();
                }
            }
            catch
            {
                Log("Exception with killing: "+ procNamewithoutEXE + "\n");
                throw new System.ArgumentException("В библиотеке HelpLibrarySharp возникла ошибка! Проблема с завершением процесса!!!", "Error");
            }
        }
        /// <summary>
        /// Starting process
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="args"></param>
        public static void strProcs(string procName, string args = null)
        {
            try
            {
                Process.Start(procName, args);
            }
            catch
            {
                Log("Exception with a starting file\n");
                throw new System.ArgumentException("В библиотеке HelpLibrarySharp возникла ошибка! Проблема с запуском файла!!!", "Error");
            }
        }     
     }
 }

