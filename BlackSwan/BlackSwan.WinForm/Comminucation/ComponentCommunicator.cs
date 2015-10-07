﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlackSwan.WinForm
{
    static class ComponentCommunicator
    {
        public static void RegisterArduino(string ip)
        {
            ReadMetaAndRegisterArduino(SendTcpRequest(ip, "getmeta").First(), ip);
        }

        public static void ReadMetaAndRegisterArduino(string meta, string ip)
        {
            var arduino = JsonConvert.DeserializeObject<Arduino>(meta);

            if (Program.Arduinos.Any(a => a.Ip == ip))
                return;

            arduino.Ip = ip;
            Program.Arduinos.Add(arduino);
            Program.ComponentsPanel.Invoke(new Action(() => {
                Program.ComponentsPanel.UpdateComponentsView();
            }));
        }

        public static void UpdateComponentValue(string ip, string componentName, int value)
        {
            var arduino = Program.Arduinos.SingleOrDefault(a => a.Ip == ip);
            var component = arduino.Components?.SingleOrDefault(c => c.Name == componentName);

            if (arduino == null || component == null)
            {
                ComponentCommunicator.RegisterArduino(ip.ToString());
            }

            // TODO: Send request

            Program.ComponentsPanel.Invoke(new Action(() => {
                Program.ComponentsPanel.UpdateComponentsView();
            }));
        }

        private static IEnumerable<string> SendTcpRequest(string ip, string command)
        {
            using (TcpClient tc = new TcpClient())
            {
                tc.Connect(ip, 9090);

                using (NetworkStream ns = tc.GetStream())
                {
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        using (StreamReader sr = new StreamReader(ns))
                        {
                            sw.Write("getmeta");
                            sw.Flush();
                            return sr.ReadToEnd().Split(new[] {"\r\n"} , StringSplitOptions.None);
                        }
                    }
                }
            }
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
