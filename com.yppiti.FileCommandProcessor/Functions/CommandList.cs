using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using com.yppiti.FileCommandProcessor;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class CommandList
    {
        public static void Command()
        {
            Scriptlet_CommandList();
        }

        protected static void Scriptlet_CommandList()
        {
            try
            {
                string Commands = System.IO.File.ReadAllText(@Functions.ExecutionPaths.Scriptlet_PublicExecutionPath() + @"\Common\~com32.dat");
                CommandInterpreter.WriteToScreen(Commands.Trim());
                ValidationResponse.CommandReturnedWasSuccessful = true;
            }

            catch (Exception Message)
            {
                ValidationResponse.ResponseFromCommandClass = Message.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        }
    }
}
