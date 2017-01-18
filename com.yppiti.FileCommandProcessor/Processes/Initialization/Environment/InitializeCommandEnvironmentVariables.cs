using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Processes.Initialization.Environment
{
    class InitializeCommandEnvironmentVariables
    {
        public static void InitVariables()
        {
            /* Initialize list of variables and what they will do here:
            IDictionary<string, string> RegisteredVariables = new Dictionary<string, string>();
            RegisteredVariables["%username%"] = System.Environment.UserName;
            RegisteredVariables["%machine%"] = System.Environment.MachineName;
            RegisteredVariables["%domain%"] = System.Environment.UserDomainName;
            RegisteredVariables["%programfiles%"] = System.Environment.GetEnvironmentVariable(System.Environment.SpecialFolder.ProgramFiles.ToString());
            RegisteredVariables["%programfiles86%"] = System.Environment.GetEnvironmentVariable(System.Environment.SpecialFolder.ProgramFilesX86.ToString());
            RegisteredVariables["%datetime%"] = DateTime.Now.ToString();
            RegisteredVariables["%documents%"] = System.Environment.GetEnvironmentVariable(System.Environment.SpecialFolder.MyDocuments.ToString());
            RegisteredVariables["%pictures%"] = System.Environment.GetEnvironmentVariable(System.Environment.SpecialFolder.MyPictures.ToString());
            RegisteredVariables["%systemdrive%"] =  Path.GetPathRoot(System.Environment.SystemDirectory).ToString();
            RegisteredVariables["%temp%"] = System.Environment.GetEnvironmentVariable(System.Environment.SpecialFolder.Windows.ToString()) + "Temp\\";
            */
            CommandEnvironmentVariables.AssignVariables();
           // RegisteredVariables.ToList().ForEach(var =>
            //{
              //  CommandEnvironmentVariables.Variables.Add(var.Key, var.Value);
            //});
        }

    }
}
