using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace com.yppiti.FileCommandProcessor.Functions.AppOnlyScope
{
    class Debug
    {
        public static void Interrupt(string[] Data, string stack, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("*** DEBUG STOP ***");
            Console.WriteLine("------- This code is isolated from the rest of the app! -------");
            Console.WriteLine("Called by: " + memberName);
            Console.WriteLine("Executed: " + DateTime.Now.ToString());
            Console.WriteLine("Arguments (incl base command): " + Data.Count());
            Console.WriteLine("");
            Console.WriteLine("Data:");
            Console.WriteLine("--------------");
            foreach (var data in Data)
            {
                Console.WriteLine("- " + data);
            }

            Console.WriteLine("");
            Console.WriteLine("STACK:");
            Console.WriteLine("-------------");
            if (stack == null)
            {
                Console.WriteLine("No stack to display.");
            }

            else
            {
                Console.WriteLine("" + stack);
            }

            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] key to jump over routine and continue..");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
