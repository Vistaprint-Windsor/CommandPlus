using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class Startup
    {
        public static void Command()
        {
            Scriptlet_Startup();
        }

        protected static void Scriptlet_Startup()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            string OpenStream = ("\nCommand+ File Processor\nCreated by Devin Pavao\nVersion 1.4\nGithub: https://github.com/Yppiti/CommandPlus\n=============================================");
            CommandInterpreter.WriteToScreen(OpenStream);
        }
    }
}
