using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Functions;
using com.yppiti.FileCommandProcessor.Processes;
using System.Data.SQLite;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Processes.Initialization
{
    class Initialize
    {
        public static  void CommandInitialization()
        {
            // Any dependents that need to run before the rest of the interpreter is started
            // needs to be added to the LoadDependencies function PRIOR to the initialization call.
            LoadDependencies();
            Interpreter.CommandInputListener.TypePrompt();
        }

        private static void LoadDependencies()
        {
            // Class dependencies go here.
            Initialization.Environment.InitializeCommandEnvironmentVariables.InitVariables();

            // Variable dependencies go here.
            SessionVariables.DirectoryLocation = Functions.ExecutionPaths.Scriptlet_PublicExecutionPath();
            SessionVariables.Username = System.Environment.UserName;
            SessionVariables.MachineName = System.Environment.MachineName;

        }

    }
}
