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
    class StackToLog
    {
        public static void Command()
        {
            Scriptlet_StackToLog();
        }

        protected static void Scriptlet_StackToLog()
        {
            try
            {
                // Write the stack-trace to a log file.
                string StackData = Environment.StackTrace;
                string LogLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (!File.Exists(LogLocation + "\\StackLog_" + Environment.WorkingSet + ".log"))
                {
                    using (StreamWriter outputFile = new StreamWriter(LogLocation + @"\StackLog_" + Environment.WorkingSet + ".log", true))
                    {
                        outputFile.WriteLine(StackData);
                    }

                    ValidationResponse.CommandReturnedWasSuccessful = true;
                }

                if (File.Exists(LogLocation + "\\StackLog_" + Environment.WorkingSet + ".log"))
                {
                    ValidationResponse.ResponseFromCommandClass = "Cannot create new log file because one already exists in its place. Please delete or rename it.";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                }
   
            }

            catch (Exception Message)
            {
                ValidationResponse.ResponseFromCommandClass = Message.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        }
    }
}
