using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;
namespace com.yppiti.FileCommandProcessor.Processes.Interpreter
{
    class CommandInterpreter
    {
        public static string PassedCommand (string Data)
        {
            SessionVariables _SessionVariables = new SessionVariables(); // initialize the class.
            List<string> commandList = _SessionVariables.commandHistoryList;
            Functions.AppOnlyScope.Disposal.RunCleanup();
            bool Command = Interpret(Data);

            if (ValidationResponse.CommandReturnedWasSuccessful && Command)
            {
                commandList.Add(Data); // Add recent command (successful) to list.
                SessionVariables.LastCommandDate = DateTime.Now.ToString(); // set date and time of last successful command
                CommandInputListener.TypePrompt();
                ValidationResponse.ResetValidationResponse();

                // Reset the Validation Response class objects.
                return ValidationResponse.CommandReturnedWasSuccessful.ToString();
            }

            if (!ValidationResponse.CommandReturnedWasSuccessful && Command)
            {
                WriteToScreen(Functions.AppOnlyScope.Status.CommandFailureMessage(ValidationResponse.ResponseFromCommandClass));

                // Reset the Validation Response class objects.
                ValidationResponse.ResetValidationResponse();
                return ValidationResponse.CommandReturnedWasSuccessful.ToString();
            }

            if (!Command)
            {
                ValidationResponse.ResponseFromCommandClass = "Command '"+Data+"' not recognized.";
                WriteToScreen(Functions.AppOnlyScope.Status.CommandFailureMessage(ValidationResponse.ResponseFromCommandClass));
                
                // Reset the Validation Response class objects.
                ValidationResponse.ResetValidationResponse();
                return ValidationResponse.CommandReturnedWasSuccessful.ToString();
            }

            else
            {
                commandList.Add(Data);
                SessionVariables.LastCommandDate = DateTime.Now.ToString(); // set date and time of last successful command
                Interpreter.CommandInputListener.TypePrompt();
                Functions.AppOnlyScope.Disposal.RunCleanup();
                return null;
            }

        }

        public static bool Interpret (string Data)
        {
            if (CommandBank.TryCommand(Data))
            {
                return true;
            }

            if (!CommandBank.TryCommand(Data))
            {
                return false;
            }

            else { return false; }

        }

        public static void WriteToScreenWithNoInterrupt(string Context)
        {
            Console.WriteLine();
            Console.WriteLine("   " + Context);
            Console.WriteLine();
        }

        public static void WriteToScreenWithNoInterruptNoSpaces(string Context)
        {
            Console.WriteLine("   " + Context);
        }

        public static void WriteToScreen(string Context)
        {
            Console.WriteLine();
            Console.WriteLine("   " + Context);
            Console.WriteLine();

            // Back to the type prompt..
            CommandInputListener.TypePrompt();

        }
        
    }
}
