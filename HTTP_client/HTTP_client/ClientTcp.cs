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
            try
            {
                FClient = new TcpClient();
                FClient.Connect(ip, port);
                FClientThread = new Thread(new ThreadStart(RecieveMessageFromServer));
                FClientThread.IsBackground = true;
                FClientThread.Start();
                FIsClientConnected = true;
                Logger.Log("ClientTcp", $"Клиент подключился к серверу: {port}");
            }
            catch (Exception ex)
            {
                Logger.Log("ClientTcp", $"Ошибка подключения: {ex.Message}");
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
                Logger.Log("ClientTcp", receivedMessage);
            }
            Logger.Log("ClientTcp", "Клиент отключился");
        }

        public void SendRequest(int port, string clientMessage)
        {
            if (FIsClientConnected && !string.IsNullOrEmpty(clientMessage))
            {
                try
                {
                    string httpRequest = HttpRequest(port, clientMessage);
                    byte[] messageData = Encoding.ASCII.GetBytes(clientMessage);
                    FClient.GetStream().Write(messageData, 0, messageData.Length);
                    Logger.Log("ClientTcp", clientMessage);
                }
                catch (Exception ex)
                {
                    Logger.Log("ClientTcp", $"Ошибка отправки: {ex.Message}");
                }
            }
        }

        private string HttpRequest (int port, string Body)
        {
            // Вычисляем Content-Length (байты в UTF-8)
            //int content = Encoding.UTF8.GetByteCount(Body);

            // Просто собираем строку без StringBuilder
            string request = $"POST / HTTP/1.1\r\n" + $"Host: localhost:{port}\r\n" + $"Connection: keep-alive\r\n" + $"\r\n" +  $"{Body}";

            return request;
        }

        public void SendData (int port, string a, string b, string c, string command)
        {
            string data = $"A: {a}, B: {b}, C: {c}, Command: {command}";
            SendRequest(port, data);
        }
    }
}
