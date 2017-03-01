using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class Exit
    {
        public static void Command(String[] Arguments)
        {
            if (Arguments.Count() == 1 || Arguments.Count() > 2)
            {
                ValidationResponse.CommandReturnedWasSuccessful = true;
                Environment.Exit(0);
            }

            if (Arguments[1] == "-1")
            {
                Environment.FailFast("User indicated application needed to be force closed 0x0");
            }
        }
    }
}
