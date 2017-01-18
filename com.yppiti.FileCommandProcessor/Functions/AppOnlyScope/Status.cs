using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions.AppOnlyScope
{
    class Status
    {
        public static string CommandFailureMessage(string Message)
        {
            if (Message == "" || Message == null)
            {
                Message = "An unknown error has occurred.";
            }

            return "[Failed] " + Message;

        }

        public static string CommandInformationMessage(string Message)
        {
            if (Message == "" || Message == null)
            {
                Message = "The operation completed but did not return a response.";
            }

            return "[Info] " + Message;
        }
        
    }
}
