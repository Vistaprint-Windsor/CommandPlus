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
    class FileCopy
    {
        public static void Command(string[] FullCommand)
        {
            // Direct to the Backup functionality for files and folders.
            Backup.Command(FullCommand);
        }
    }
}
