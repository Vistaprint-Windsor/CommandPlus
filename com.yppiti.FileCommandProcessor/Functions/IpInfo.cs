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
    class IpInfo
    {
        public static string Error;
        public static void Command(string[] Switch)
        {
            if (Switch.Count() != 2)
            {
                Error = "Invalid argument count.";
                ValidationResponse.ResponseFromCommandClass = Error;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }

            else
            {
                Scriptlet_IpInfo(Switch[1]);
            }
        }

        public static string GetLocalIPAddress()
        {
            string ipAddress = "";
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            ipAddress = Convert.ToString(ipHostInfo.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork));
            return ipAddress;
        }

        protected static void Scriptlet_IpInfo (string Switch)
        {
            try
            {
                if (Switch.ToLower() == "-r")
                {
                    System.Threading.Thread.Sleep(0500);
                    string IPAddressURL = "https://api.ipify.org/?format=txt";
                    using (WebClient client = new WebClient())
                    {
                        string Result = client.DownloadString(IPAddressURL);
                        CommandInterpreter.WriteToScreen(AppOnlyScope.Status.CommandInformationMessage(Result));

                    }
                }

                else if (Switch.ToLower() == "-l")
                {
                    CommandInterpreter.WriteToScreen(AppOnlyScope.Status.CommandInformationMessage(GetLocalIPAddress()));
                }

                else
                {
                    Error = "Invalid switch supplied. Use -r or -l.";
                    ValidationResponse.ResponseFromCommandClass = Error;
                    ValidationResponse.CommandReturnedWasSuccessful = false;
                }
            }

            catch (Exception IpAddressException)
            {
                ValidationResponse.ResponseFromCommandClass = IpAddressException.Message;
                ValidationResponse.CommandReturnedWasSuccessful = false;
            }
        }
    }
}
