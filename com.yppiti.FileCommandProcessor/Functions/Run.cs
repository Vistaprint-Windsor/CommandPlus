using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using com.yppiti.FileCommandProcessor;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class Run
    {
        public static string Error;
        public static void Command(string[] Arguments)
        {
            if (Arguments.Count() == 2)
            {
                Scriptlet_Run(Arguments[1]);
            }

            else
            {
                ValidationResponse.ResponseFromCommandClass = "Invalid arguments. Accepts FILE_LOCATION";
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        }

        private static void Scriptlet_Run(string File)
        {
            try
            {
                Process.Start(File);
                ValidationResponse.CommandReturnedWasSuccessful = true;
            }

            catch (Exception FileExecutionError)
            {
                ValidationResponse.ResponseFromCommandClass = FileExecutionError.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        }
    }
}
