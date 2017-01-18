using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Processes.Initialization;

namespace com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs
{
    class CommandEnvironmentVariables
    {
       // public static IDictionary<string, string> Variables { get; set; }
        public static void AssignVariables()
        {
            SessionVariables.Username = Environment.UserName;
            SessionVariables.MachineName = Environment.MachineName;
        }
        
    }
}
