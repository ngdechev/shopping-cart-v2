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
    static class Logger
    {
        public static string filePath = "shopping_cart.log";

        public static void GetLogLevel(LogLevel logLevel, UserRole userRole, string message)
        {
            switch(logLevel.ToString())
            {
                case "Debug":
                    Debug(userRole, message);
                    break;
                case "Info":
                    Info(userRole, message);
                    break;
                case "Warn":
                    Warn(userRole, message);
                    break;
                case "Error":
                    Error(userRole, message);
                    break;
            }
        }

        private static void Log(LogLevel logLevel, UserRole userRole, string message)
        {
            string logType = logLevel.ToString().ToUpper();
            string userRoleStr = userRole.ToString();
            string logMessage = $"[{DateTime.Now}][{logType}][{userRoleStr}]{message}";

            WriteToFile(logMessage);
        }

        public static void Error(UserRole userRole, string message)
        {
            Log(LogLevel.Error, userRole, message);
        }

        public static void Warn(UserRole userRole, string message)
        {
            Log(LogLevel.Warn, userRole, message);
        }

        public static void Info(UserRole userRole, string message)
        {
            Log(LogLevel.Info, userRole, message);
        }

        public static void Debug(UserRole userRole, string message)
        {
            Log(LogLevel.Debug, userRole, message);
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
