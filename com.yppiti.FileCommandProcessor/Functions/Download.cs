using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using com.yppiti.FileCommandProcessor.Processes.Interpreter;
using com.yppiti.FileCommandProcessor.Processes.Interpreter.DTOs;
using System.Net.Sockets;

namespace com.yppiti.FileCommandProcessor.Functions
{
    class Download
    {
        public static void Command (string[] Arguments)
        {
            if (Arguments.Count() == 4)
            {
                Scriptlet_Download(Arguments[1], Arguments[2], Arguments[3]);
            }

            else
            {
                ValidationResponse.ResponseFromCommandClass = "Expecting 3 arguments. Usage: 'download REMOTE_HOST LOCAL_DIRECTORY EXTENSION_TYPE'";
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        }

        protected static void Scriptlet_Download(string Location, string SaveFileLocation, string Extension)
        {
            CheckDirectoryExists(SaveFileLocation);
            try
            {
                if (Extension == "exe" || Extension == "bat" || Extension == "scr" || Extension == "reg" || Extension == "vbs" || Extension == "vbe" || Extension == "cmd")
                {
                    ValidationResponse.ResponseFromCommandClass = "Extension type not supported. Extension may be unsafe.";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                    return;
                }

                if (Location.Contains("://"))
                {
                    Uri DownloadURI = new Uri(Location);
                    string SuccessMessage = "Successfully downloaded contents of '"+DownloadURI+"'.";
                    System.Threading.Thread.Sleep(0500);
                    string WebsiteLocation = Location;
                    using (WebClient client = new WebClient())
                    {
                        string Result = client.DownloadString(WebsiteLocation);
                        StreamWriter DownloadFile = new StreamWriter(@SaveFileLocation + "_" + DownloadURI.Host + "." + Extension);
                        DownloadFile.Write(Result);
                        DownloadFile.Close();
                        CommandInterpreter.WriteToScreen(AppOnlyScope.Status.CommandInformationMessage(SuccessMessage));
                        ValidationResponse.ResponseFromCommandClass = SuccessMessage;
                        ValidationResponse.CommandReturnedWasSuccessful = true;
                    }
                }

                else
                {
                    ValidationResponse.ResponseFromCommandClass = "Location specified invalid. Please use http://, https:// or ftp:// to download a file.";
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                }
            }

            catch (Exception DownloadStreamException)
            {
                ValidationResponse.ResponseFromCommandClass = DownloadStreamException.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        }

        protected static void CheckDirectoryExists(string DirectoryLocation)
        {
            // Quickly check to see if the directory specified exists. If it does not, execute this method.
            if (!Directory.Exists(DirectoryLocation))
            {
                Directory.CreateDirectory(DirectoryLocation);
            }
        }
    }
}
