using System;

namespace LispLint.Helpers
{
    public class Log
    {
        public enum LogType
        {
            Info,
            Success,
            Fail
        }

        /// <summary>
        /// This is to make our console window look spicy.
        /// </summary>
        public static void LogMsg(string logMsg, LogType logType = LogType.Info)
        {
            //Remove existing formatting in case another method didn't reset after doing formatting.
            Console.ResetColor();

            //Do not specify anything for LogType.Info so that it retains custom command prompt styles that the user may have configured.
            if (logType == LogType.Success)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (logType == LogType.Fail)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
            }

            //Write the string to the console
            Console.WriteLine(logMsg);

            //Reset formatting once we're done.
            Console.ResetColor();
        }
    }
}
