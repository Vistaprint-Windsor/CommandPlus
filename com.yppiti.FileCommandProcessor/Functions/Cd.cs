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
    class Cd
    {
        static string Error;
        public static void Command(string[] Location)
        {
            try
            {
                if (Location.Length != 2)
                {
                    Error = "Invalid argument length. 'cd' accepts 'cd <location>'";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                    ValidationResponse.ResponseFromCommandClass = Error;
                }

                else
                {
                    Scriptlet_Cd(Location[1]);
                }
            }

            catch (Exception CommandExecutionException)
            {
                ValidationResponse.CommandReturnedWasSuccessful = false;
                ValidationResponse.ResponseFromCommandClass = CommandExecutionException.Message;
            }
        }

        protected static void Scriptlet_Cd(string Location)
        {
            try
            {
                if (Directory.Exists(Location))
                {
                    CommandInterpreter.WriteToScreenWithNoInterrupt(AppOnlyScope.Status.CommandInformationMessage("Working directory is '" + Location + "'"));
                    SessionVariables.DirectoryLocation = Location;
                    ValidationResponse.CommandReturnedWasSuccessful = true;
                }

                else
                {
                    Error = "The specified directory cannot be found: '"+Location+"'";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                    ValidationResponse.ResponseFromCommandClass = Error;
                }
            }

            catch (Exception CdException)
            {
                ValidationResponse.CommandReturnedWasSuccessful = false;
                ValidationResponse.ResponseFromCommandClass = CdException.Message;
            }
        }
    }
}
