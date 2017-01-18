using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using com.yppiti.FileCommandProcessor;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class ExecutionPaths
    {
        public static void Command()
        {
            CommandInterpreter.WriteToScreen(Scriptlet_PublicExecutionPath());
        }

        public static string Scriptlet_PublicExecutionPath()
        {
            string _PublicExecutionPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return _PublicExecutionPath;
        }
    }
}
