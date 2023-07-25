using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands.general
{
    enum Type_MSG
    {
        error,
        warn,
        info,
        debug
    }
    static class Logger
    {
        private static int msgType = 0;
        public static void SetMessageType(string messageType)
        {
            switch (messageType)
            {
                case "error":
                    msgType = (int) Type_MSG.error;
                    break;
                case "warn":
                    msgType = (int)Type_MSG.warn;
                    break;
                case "info":
                    msgType = (int)Type_MSG.info; ;
                    break;
                case "debug":
                    msgType = (int)Type_MSG.debug;
                    break;
                default:
                    msgType = 0;
                    break;
            }

        }
        public static void Log(string type_msg, string message)
        {
            int this_type_msg;

            switch (type_msg)
            {
                case "error":
                    this_type_msg = 0;
                    break;
                case "warn":
                    this_type_msg = 1;
                    break;
                case "info":
                    this_type_msg = 2;
                    break;
                case "debug":
                    this_type_msg = 3;
                    break;
                default:
                    this_type_msg = 0;
                    break;
            }
            if (this_type_msg <= msgType)
            {
                SaveToFile(type_msg, message);
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
