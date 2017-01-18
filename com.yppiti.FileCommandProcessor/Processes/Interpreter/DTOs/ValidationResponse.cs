using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Processes;
using com.yppiti.FileCommandProcessor.Functions;

namespace com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs
{
    public class ValidationResponse
    {
        public static bool CommandReturnedWasSuccessful { get; set; }
        public static string ResponseFromCommandClass { get; set; }

        public static void ResetValidationResponse()
        {
            CommandReturnedWasSuccessful = true;
            ResponseFromCommandClass = "";
        }
    }
}
