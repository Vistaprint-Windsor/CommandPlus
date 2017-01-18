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
    class ClearScreen
    {
        public static void Command()
        {
            Scriptlet_ClearScreen();
        }

        protected static void Scriptlet_ClearScreen()
        {
            Console.Clear();
            ValidationResponse.CommandReturnedWasSuccessful = true;
        }
    }
}
