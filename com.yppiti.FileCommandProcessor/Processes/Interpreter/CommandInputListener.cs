using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;
using com.yppiti.FileCommandProcessor.Functions;

namespace com.yppiti.FileCommandProcessor.Processes.Interpreter
{
    class CommandInputListener
    {
        public static void TypePrompt()
        {
          //  try
         //   {
                // Display the default type prompt.
                Console.Write(SessionVariables.Username + "@" + SessionVariables.MachineName + " " + SessionVariables.DirectoryLocation + ">");
                string Input = Console.ReadLine();
                InputCommand(Input);
           // }

            //catch (Exception TypePromptException)
            //{
             ///   ValidationResponse.ResponseFromCommandClass = TypePromptException.Message;
             //   ValidationResponse.CommandReturnedWasSuccessful = false;
             //   MessageBox.Show(TypePromptException.Message + ".\r\nCommand Plus must exit.", "Command Plus: Fatal Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
           // }

        }

        private static void InputCommand(string Data)
        {
            // Take the data passed to the prompt and pass it to the intepreter.
            CommandInterpreter.PassedCommand(Data);
        }

        private static string ConvertVariables(string Data)
        {
            // Go through variable definitions and replace any defined variables with full value of the key.
            //CommandEnvironmentVariables.Variables.ToList().ForEach(var =>
           // {
           //     Data.Replace(var.Key, var.Value);
           // });

            return Data;
        }
    }
}
