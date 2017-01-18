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
    class Vars
    {
        public static void Command(string[] Data)
        {
            if (Data.Length < 2 || Data.Length > 2)
            {
                ValidationResponse.ResponseFromCommandClass = "Invalid var count.";
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }

            else
            {
                Scriptlet_Vars(Data);
            }
        }

        protected static void Scriptlet_Vars(string[] Data)
        {
            try
            {
                ValidationResponse.CommandReturnedWasSuccessful = true;
                switch (Data[1])
                {
                    case "machine":
                        CommandInterpreter.WriteToScreen(Environment.MachineName);
                        break;

                    case "username":
                        CommandInterpreter.WriteToScreen(Environment.UserName);
                        break;

                    case "winver":
                        CommandInterpreter.WriteToScreen(Environment.OSVersion.ToString());
                        break;

                    case "appver":
                        CommandInterpreter.WriteToScreen(Environment.Version.ToString());
                        break;

                    case "workingset":
                        CommandInterpreter.WriteToScreen(Environment.WorkingSet.ToString());
                        break;

                    case "ticksfromboot":
                        CommandInterpreter.WriteToScreen(Environment.TickCount.ToString());
                        break;

                    case "domain":
                        CommandInterpreter.WriteToScreen(Environment.UserDomainName);
                        break;

                    case "64bitapp":
                        CommandInterpreter.WriteToScreen(Environment.Is64BitProcess.ToString());
                        break;

                    case "64bitos":
                        CommandInterpreter.WriteToScreen(Environment.Is64BitOperatingSystem.ToString());
                        break;

                    default:
                        ValidationResponse.ResponseFromCommandClass = "Invalid variable.";
                        ValidationResponse.CommandReturnedWasSuccessful = false;
                        break;
                }
            }

            catch (Exception VarsException)
            {
                ValidationResponse.ResponseFromCommandClass = VarsException.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        
            return;
        }
    }
}
