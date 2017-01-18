using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using com.yppiti.FileCommandProcessor;
using com.yppiti.FileCommandProcessor.Functions;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class Backup
    {
        public static void Command(string[] FullCommand)
        {
            if (FullCommand.Length > 4 || FullCommand.Length < 4)
            {
                string Error = "The command contains an invalid count of arguments. Operation canceled.";
                ValidationResponse.CommandReturnedWasSuccessful = false;
                ValidationResponse.ResponseFromCommandClass = Error;
            }

            else
            {
               switch (FullCommand[1])
                {
                    case "-f":
                        Scriptlet_BackupFile(FullCommand);
                        break;

                    case "-d":
                        Scriptlet_BackupDirectory(FullCommand);
                        break;

                    default:
                        string Error = "No valid arguments for file input received. Use the -f or -d switch before specifying the location.";
                        ValidationResponse.CommandReturnedWasSuccessful = false;
                        ValidationResponse.ResponseFromCommandClass = Error;
                        break;
                }

            
            }
        }

        protected static void Scriptlet_BackupFile(string[] FileBackup)
        {
            string FileSource = FileBackup[1];
            string FileDestination = FileBackup[2];

            try
            {
                // Copy the source file to its destination folder and file.
                File.Copy(FileSource, FileDestination);
                ValidationResponse.CommandReturnedWasSuccessful = true;
            }

            catch (Exception FileBackupException)
            {
                ValidationResponse.CommandReturnedWasSuccessful = false;
                ValidationResponse.ResponseFromCommandClass = FileBackupException.Message;
            }
        }

        protected static void Scriptlet_BackupDirectory(string[] DirectoryBackup)
        {
            string DirectorySource = DirectoryBackup[2];
            string DirectoryDestination = DirectoryBackup[3];
            DirectoryInfo DirectorySourceInfo = new DirectoryInfo(DirectorySource);
            string RootPath = Path.GetPathRoot(Environment.SystemDirectory).ToLower();

            CommandInterpreter.WriteToScreenWithNoInterrupt(AppOnlyScope.Status.CommandInformationMessage("Gathering space requirements for both media devices. This may take serveral minutes to complete.."));
            long DestinationDriveSpace = GetTotalDriveSpace(Path.GetPathRoot(DirectoryDestination));
            long SourceDriveSpace = GetTotalDriveSpace(Path.GetPathRoot(DirectorySource));
            long SourceDirectorySize = DirectorySize(DirectorySourceInfo);

            try
            {
                if (DirectorySource == RootPath && DirectoryDestination.Contains(RootPath))
                {
                    string Error = "Drive entirety cannot be copied to itself. Destination must contain another media.";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                    ValidationResponse.ResponseFromCommandClass = Error;
                    throw new Exception(Error); 
                }

                if (SourceDirectorySize > DestinationDriveSpace)
                {
                    string Error = "There is not enough available space on the destination drive. Source size is '"+SourceDirectorySize+"' bytes, Destination drive size: '"+ DestinationDriveSpace +"' bytes.";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                    ValidationResponse.ResponseFromCommandClass = Error;
                    throw new Exception(Error);
                }

                if (DirectorySource == DirectoryDestination)
                {
                    string Error = "Source and destination paths are identical.";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                    ValidationResponse.ResponseFromCommandClass = Error;
                    throw new Exception(Error);
                }

                // Re-create the directory structure from source to destination.
                foreach (string dirPath in Directory.GetDirectories(DirectorySource, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(DirectorySource, DirectoryDestination));
                }

                // Take files in old directory and copy them to the new.
                foreach (string newPath in Directory.GetFiles(DirectorySource, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(DirectorySource, DirectoryDestination), true);
                }

                AppOnlyScope.Status.CommandInformationMessage("Operation completed successfully. Moved '" + SourceDirectorySize + "' bytes in ");
                ValidationResponse.CommandReturnedWasSuccessful = true;
            }

            catch (Exception FileBackupException)
            {
                ValidationResponse.CommandReturnedWasSuccessful = false;
                ValidationResponse.ResponseFromCommandClass = FileBackupException.Message;
            }
        }

        protected static long GetTotalDriveSpace(string DriveName)
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady && drive.Name == DriveName.ToUpper())
                    {
                        return drive.AvailableFreeSpace;
                    }
                }
            }

            catch (Exception GetAvailableDriveSpaceException)
            {
                ValidationResponse.CommandReturnedWasSuccessful = false;
                ValidationResponse.ResponseFromCommandClass = GetAvailableDriveSpaceException.Message;
            }

            return -1;
        }

        protected static long DirectorySize(DirectoryInfo DirectoryName)
        {
            try
            {
                long size = 0;
                // Add file sizes.
                FileInfo[] fis = DirectoryName.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = DirectoryName.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirectorySize(di);
                }

                return size;
            }

            catch (Exception GetAvailableDirectorySpaceException)
            {
                ValidationResponse.CommandReturnedWasSuccessful = false;
                ValidationResponse.ResponseFromCommandClass = GetAvailableDirectorySpaceException.Message;
            }

            return -1;
        }
    }
}
