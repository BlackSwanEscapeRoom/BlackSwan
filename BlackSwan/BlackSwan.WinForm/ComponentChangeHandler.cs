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
            TcpListener tcplistener = new TcpListener(IPAddress.Any, 8080);
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
            TcpClient mclient = (TcpClient) client;
            NetworkStream stream = mclient.GetStream();
            byte[] message = new byte[1024];
            stream.Read(message, 0, message.Length);

            var request = Encoding.ASCII.GetString(message);
            var parts = request.Split(' ');

            var partzero = parts[0];
            var partone = parts[1];
            var parttwo = parts[2];
            var partthree = parts[3];
            var partfour = parts[4];
            Program.ComponentsPanel.ComponentChange("New message = " + partzero +
                " " + partone +
                " " + parttwo +
                " " + partthree +
                " " + partfour);

            stream.Close();
            mclient.Close();
        }

        

    }
}
