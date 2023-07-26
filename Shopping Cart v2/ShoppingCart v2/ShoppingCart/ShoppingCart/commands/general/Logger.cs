using OnlineShop.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands.general
{
    static class Logger
    {
        private static int logMsgType = 0;
        public static void SetMessageType(string messageType)
        {
            switch (messageType)
            {
                case "error":
                    logMsgType = (int) LogLevel.error;
                    break;
                case "warn":
                    logMsgType = (int)LogLevel.warn;
                    break;
                case "info":
                    logMsgType = (int)LogLevel.info; ;
                    break;
                case "debug":
                    logMsgType = (int)LogLevel.debug;
                    break;
                default:
                    logMsgType = 0;
                    break;
            }

        }
        public static void Log(string messageType, string message)
        {
            int msgType;

            switch (messageType)
            {
                case "error":
                    msgType = 0;
                    break;
                case "warn":
                    msgType = 1;
                    break;
                case "info":
                    msgType = 2;
                    break;
                case "debug":
                    msgType = 3;
                    break;
                default:
                    msgType = 0;
                    break;
            }
            if (msgType <= logMsgType)  
            {
                SaveToFile(messageType, message);
            }
        }

        private static void SaveToFile(string type_msg, string message)
        {
            string logFilePath = "logger.log";
            string logInformation = $"[{DateTime.Now.ToString()}][{UserInputHandler.GetUserRole()}][{type_msg.ToUpper()}] -> {message}\n";
            
            try
            {
                File.AppendAllText(logFilePath, logInformation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}
