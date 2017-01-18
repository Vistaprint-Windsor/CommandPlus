using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class Ls
    {
        public static void Command(string[] Data)
        {
            Scriptlet_Ls(Data);
        }

        protected static void Scriptlet_Ls(string[] Location)
        {
            if (Location.Length > 2)
            {
                string Error = "Too many arguments specified for ls";
                ValidationResponse.ResponseFromCommandClass = Error;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }

            else
            {
                try
                {
                    if (Location.Length == 1)
                    {
                        ObtainDirectoryContents("");
                    }

                    if (Location.Length == 2)
                    {
                        ObtainDirectoryContents(Location[1]);
                    }
                }

                catch (Exception ListFileContentsException)
                {
                    ValidationResponse.ResponseFromCommandClass = ListFileContentsException.Message;
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                }
            }
        }

        public static void ObtainDirectoryContents(string DirectoryName)    
        {
            try
            {
                if (DirectoryName == "" || DirectoryName == null)
                {
                    DirectoryName = SessionVariables.DirectoryLocation;
                }

                string[] DirectoryContents = System.IO.Directory.GetDirectories(DirectoryName, "*").Select(Path.GetFileName).ToArray();
                string[] FileContents = System.IO.Directory.GetFiles(DirectoryName, "*").Select(Path.GetFileName).ToArray();
                CommandInterpreter.WriteToScreenWithNoInterrupt(AppOnlyScope.Status.CommandInformationMessage("Displaying the contents of '" + DirectoryName + "'"));

                foreach (string contents in DirectoryContents)
                {
                    CommandInterpreter.WriteToScreenWithNoInterruptNoSpaces("> [FOLDER] " + contents);
                }

                foreach (string contents in FileContents)
                {
                    CommandInterpreter.WriteToScreenWithNoInterruptNoSpaces("> [FILE] " + contents);
                }

                if (DirectoryContents.Length == 0)
                {
                    CommandInterpreter.WriteToScreenWithNoInterruptNoSpaces("<...>");
                }

                CommandInterpreter.WriteToScreenWithNoInterruptNoSpaces("");
                ValidationResponse.CommandReturnedWasSuccessful = true;
            }

            catch (Exception FileListException)
            {
                ValidationResponse.ResponseFromCommandClass = FileListException.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }

        }
    }
}
