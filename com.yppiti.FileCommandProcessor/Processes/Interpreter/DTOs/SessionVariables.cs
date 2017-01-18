using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs
{
    public class SessionVariables
    {
        public static string DirectoryLocation { get; set; }
        public static string Username { get; set; }
        public static string MachineName { get; set; }

        public List<string> commandHistoryList = new List<string>();
        
        public List<string> CommandHistory()
        {
            return commandHistoryList;
        }

        public static string LastCommandDate { get; set; }
        public static bool UserIsAdministrator { get; set; }
    }
}
