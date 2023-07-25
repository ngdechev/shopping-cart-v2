using OnlineShop.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands.general
{
    static class Logger1
    {
        public static string filePath = "shopping_cart.log";
        private static string logLvl;

        public static void GetLogLevel(UserRole userRole, string message)
        {
            switch(logLvl.ToLower())
            {
                case "debug":
                    Debug(userRole, message);
                    break;
                case "info":
                    Info(userRole, message);
                    break;
                case "warn":
                    Warn(userRole, message);
                    break;
                case "error":
                    Error(userRole, message);
                    break;
            }
        }

        public static void SetLogLevel(string logLvl)
        {
            logLvl = logLvl;
        }

        private static void Log(UserRole userRole, string message)
        {
            string logType = logLvl.ToString().ToUpper();
            string userRoleStr = userRole.ToString();
            string logMessage = $"[{DateTime.Now}][{logType}][{userRoleStr}]{message}";

            WriteToFile(logMessage);
        }

        public static void Error(UserRole userRole, string message)
        {
            Log(userRole, message);
        }

        public static void Warn(UserRole userRole, string message)
        {
            Log(userRole, message);
        }

        public static void Info(UserRole userRole, string message)
        {
            Log(userRole, message);
        }

        public static void Debug(UserRole userRole, string message)
        {
            Log(userRole, message); 
        }

        private static void WriteToFile(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
