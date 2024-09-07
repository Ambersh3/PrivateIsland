using DotRas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PrivateIsland_Client
{
    internal static class VPNInstance
    {
        internal static void Create(string vpnName, string serverAddress, string username, string password, string presharedKey)
        {
            try
            {
                try
                {
                    if (GetState(vpnName)[0] == "Connected")
                        Abandon(vpnName);
                }
                catch { }

                // Create a new phonebook entry
                RasPhoneBook phoneBook = new RasPhoneBook();
                phoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));

                // Check if the entry already exists
                try
                {
                    if (phoneBook.Entries.Contains(vpnName))
                    {
                        phoneBook.Entries[vpnName].Remove();
                    }
                }
                catch { }

                // Create a new VPN entry
                RasEntry entry = RasEntry.CreateVpnEntry(vpnName, serverAddress, RasVpnStrategy.L2tpOnly, RasDevice.GetDeviceByName("(L2TP)", RasDeviceType.Vpn));
                entry.Options.UsePreSharedKey = true;
                phoneBook.Entries.Add(entry);

                // Set credentials
                entry.UpdateCredentials(RasPreSharedKey.Client, presharedKey);
                entry.Update();
                RasDialer dialer = new RasDialer();
                dialer.EntryName = vpnName;
                dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);
                dialer.Credentials = new System.Net.NetworkCredential(username, password);

                // Connect to the VPN
                dialer.Dial();
            }
            catch(Exception e)
            {
                if (e.Message.Contains("user name and password combination you provided is not recognized"))
                {
                    new Notification("The username or password you provided was not recognized").Show();
                }
                else { new ExceptionFrm(e).Show(); }
            }
        }

        internal static void Abandon(string vpnName)
        {
            // Open the phonebook
            RasPhoneBook phoneBook = new RasPhoneBook();
            phoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));

            // Find the active connection
            RasConnection connection = RasConnection.GetActiveConnectionByName(vpnName, phoneBook.Path);

            if (connection != null)
            {
                // Disconnect the VPN
                connection.HangUp();
                Console.WriteLine("VPN disconnected successfully.");
            }
            else
            {
                Console.WriteLine("VPN connection not found.");
            }
        }

        internal static string[] GetState(string vpnName)
        {
            string[] state = new string[2];
            state[0] = "Null";
            state[1] = "None";

            // Open the phonebook
            RasPhoneBook phoneBook = new RasPhoneBook();
            phoneBook.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));

            // Get the active connection
            RasConnection connection = RasConnection.GetActiveConnectionByName(vpnName, phoneBook.Path);

            if (connection != null)
            {
                // Get the connection status
                RasConnectionStatus status = connection.GetConnectionStatus();
                state[0] = status.ConnectionState.ToString();
                state[1] = status.ErrorCode.ToString();
            }
            else
            {
                Console.WriteLine("VPN connection not found.");
            }

            return state;
        }
    }
}
