using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class About
    {
        public static void Command()
        {
            CommandInterpreter.WriteToScreen(Scriptlet_About());
        }

        public static string Scriptlet_About()
        {
            try
            {
                ValidationResponse.CommandReturnedWasSuccessful = true;
                return "Initial Code Copyright (C) 2016 Devin Pavao. www.pavao.ca.";
            }

            catch (Exception AboutException)
            {
                ValidationResponse.ResponseFromCommandClass = AboutException.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
                return null;
            }
        }
    }
}
