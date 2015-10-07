using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackSwan.WinForm
{
    class ComponentChangeHandler
    {
        public ComponentChangeHandler()
        {
            Thread TcpServerRunThread = new Thread(new ThreadStart(TcpServerRun));
            TcpServerRunThread.Start();
        }

        private void TcpServerRun()
        {
            TcpListener tcplistener = new TcpListener(IPAddress.Any, 9090);
            tcplistener.Start();
            Program.ComponentsPanel.ComponentChange("Listening");
            while (true)
            {
                TcpClient client = tcplistener.AcceptTcpClient();
                Program.ComponentsPanel.ComponentChange("Connected");
                Thread tcpHandlerThread = new Thread(new ParameterizedThreadStart(tcpHandler));
                tcpHandlerThread.Start(client);
            }
        }

        private void tcpHandler(object client)
        {
            var mclient = (TcpClient) client;
            var stream = mclient.GetStream();
            var message = new byte[1024];
            stream.Read(message, 0, message.Length);

            var request = Encoding.ASCII.GetString(message);
            var ipWithPort = (mclient.Client.RemoteEndPoint as IPEndPoint).ToString();
            var ip = ipWithPort.Split(':')[0];

            var lines = request.Split(new[] { "\r\n" }, StringSplitOptions.None);

            if (lines[0] == "change")
            {
                ComponentCommunicator.UpdateComponentValue(ip, lines[1], int.Parse(lines[2]));
            }
            else if (lines[0] == "register")
            {
                ComponentCommunicator.ReadMetaAndRegisterArduino(lines[1], ip);
            }

            stream.Close();
            mclient.Close();
        }
    }
}
