using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP_client
{
    internal class ClientTcp
    {
        private TcpClient FClient;
        private Thread FClientThread;
        private NetworkStream FClientStream;
        private bool FIsClientConnected = false;
        public bool FIsConnected
        {
            get { return FIsClientConnected; }
        }

        public void ConnectToServer(IPAddress ip, int port)
        {
            if (FClient != null)
            {
                FClient = new TcpClient();
                FClient.Connect(ip, port);
                FClientThread = new Thread(new ThreadStart(RecieveMessageFromServer));
                FClientThread.IsBackground = true;
                FClientThread.Start();
                FIsClientConnected = true;

            }
        }

        public void DisconnectFromServer()
        {
            FIsClientConnected = false;
            FClient.Close();
        }

        private void RecieveMessageFromServer() //ответы у сервера
        {
            NetworkStream stream = FClient.GetStream();
            const int BUF_SIZE = 4096;
            byte[] message = new byte[BUF_SIZE];
            while (FIsClientConnected)
            {
                int bytes = 0;
                try
                {
                    bytes = stream.Read(message, 0, message.Length);
                }
                catch
                {
                    break;
                }
                if (bytes == 0)
                {
                    break;
                }

                string receivedMessage = Encoding.ASCII.GetString(message, 0, bytes).Trim();
            }
        }

        public void SendMessage(string clientMessage)
        {
            if (FIsClientConnected && !string.IsNullOrEmpty(clientMessage))
            {
                byte[] messageData = Encoding.ASCII.GetBytes(clientMessage);
                //FClient.GetStream().Write(messageData, 0, messageData.Length);
            }
        }
    }
}
