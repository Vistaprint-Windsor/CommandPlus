using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Functions;
using com.yppiti.FileCommandProcessor.Processes;

namespace com.yppiti.FileCommandProcessor.Processes.Interpreter
{
    class CommandBank
    {
        public static bool TryCommand(string Data)
        {
            string[] FullCommandWithArguments;
            FullCommandWithArguments = Data.Split(null);

            switch (FullCommandWithArguments[0])
            {
                case "about":
                    About.Command();
                    return true;

                case "%execution.path%":
                    ExecutionPaths.Command();
                    return true;

                case "copy":
                    FileCopy.Command(FullCommandWithArguments);
                    return true;

                case "exit":
                    Exit.Command(FullCommandWithArguments);
                    return true;

                case "stacktolog":
                    StackToLog.Command();
                    return true;

                case "vars":
                    Vars.Command(FullCommandWithArguments);
                    return true;

                case "clear":
                    ClearScreen.Command();
                    return true;

                case "lastcommand":
                    LastCommand.Command();
                    return true;

                case "cd":
                    Cd.Command(FullCommandWithArguments);
                    return true;

                case "collectgarbage":
                    Functions.AppOnlyScope.Disposal.RunCleanup();
                    return true;

                case "ls":
                    Ls.Command(FullCommandWithArguments);
                    return true;

                case "ping":
                    Ping.Command(FullCommandWithArguments);
                    return true;

                case "ipinfo":
                    IpInfo.Command(FullCommandWithArguments);
                    return true;

                case "commands":
                    CommandList.Command();
                    return true;

                case "help":
                    CommandList.Command();
                    return true;

                case "download":
                    Download.Command(FullCommandWithArguments);
                    return true;

                default:
                    return false;
            }
        }
    }
}
