using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class LastCommand
    {
        public static void Command()
        {
            Scriptlet_LastCommand();
        }

        protected static void Scriptlet_LastCommand()
        {
            try
            {
                SessionVariables _SessionVariables = new SessionVariables();
                List<string> LastCommands = _SessionVariables.CommandHistory();
                long CommandCount = 0;
                if (LastCommands.Count == 0)
                {
                    string Error = "No last successful commands recorded.";
                    ValidationResponse.ResponseFromCommandClass = Error;
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                }

                CommandInterpreter.WriteToScreenWithNoInterrupt(AppOnlyScope.Status.CommandInformationMessage("Displaying " + CommandCount + " successful commands.."));

                foreach (object command in LastCommands)
                {
                    CommandCount += 1;
                    CommandInterpreter.WriteToScreenWithNoInterruptNoSpaces(CommandCount + ". " + command);
                }

                var Commands = string.Join(Environment.NewLine, LastCommands);
                CommandInterpreter.WriteToScreenWithNoInterrupt(CommandCount + ". " + Commands);

                ValidationResponse.CommandReturnedWasSuccessful = true;
            }

            catch (Exception FileListException)
            {
                ValidationResponse.ResponseFromCommandClass = FileListException.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }

        }
    }
}
