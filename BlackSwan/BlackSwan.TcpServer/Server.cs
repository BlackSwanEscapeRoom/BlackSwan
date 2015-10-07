using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackSwan.TcpServer
{
    class Server
    {
        public Server()
        {
            Thread TcpServerRunThread = new Thread(new ThreadStart(TcpServerRun));
            TcpServerRunThread.Start();
        }

        private void TcpServerRun()
        {
            TcpListener tcplistener = new TcpListener(IPAddress.Any, 8080);
            tcplistener.Start();
            Console.WriteLine("Listening");
            while (true)
            {
                TcpClient client = tcplistener.AcceptTcpClient();
                Console.WriteLine("Connected");
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
            Console.WriteLine("Action: " + lines[0]);

            using (var sw = new StreamWriter(stream))
            {

                if (lines[0] == "getmeta")
                {
                    var sample = "{\"components\": [\"led\", \"switch\"]}";
                    sw.WriteLine(sample);
                }
                else if (lines[0] == "register")
                {

                }

            }



            stream.Close();
            mclient.Close();
        }
    }
}