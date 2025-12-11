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
        static private string LOG_ID = "ClientTcp";
        private TcpClient FClient;
        private Thread FClientThread;
        private NetworkStream FClientStream;
        private bool FIsClientConnected = false;
        private int FClientPort;
        private IPAddress FClientIp;
        public bool FIsConnected
        {
            get { return FIsClientConnected; }
        }

        public void ConnectToServer(IPAddress ip, int port)
        {
            FClientPort = port;
            FClientIp = ip;
            try
            {
                FClient = new TcpClient();
                FClient.Connect(ip, port);
                FClientThread = new Thread(new ThreadStart(RecieveMessageFromServer));
                FClientThread.IsBackground = true;
                FClientThread.Start();
                FIsClientConnected = true;
                Logger.Log(LOG_ID, $"Клиент подключился к серверу: {port}");
            }
            catch (Exception ex)
            {
                Logger.Log(LOG_ID, $"Ошибка подключения: {ex.Message}");
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
                Logger.Log(LOG_ID, receivedMessage);
            }
            Logger.Log(LOG_ID, "Клиент отключился");
        }

        public void SendRequest(string clientMessage)
        {
            if (FIsClientConnected && !string.IsNullOrEmpty(clientMessage))
            {
                try
                {
                    string httpRequest = HttpRequest(clientMessage);
                    byte[] messageData = Encoding.ASCII.GetBytes(httpRequest);
                    FClient.GetStream().Write(messageData, 0, messageData.Length);
                    Logger.Log(LOG_ID, "Отправлен HTTP-запрос:\n" + httpRequest);
                }
                catch (Exception ex)
                {
                    Logger.Log(LOG_ID, $"Ошибка отправки: {ex.Message}");
                }
            }
        }
        // зафиксируй в гит! ау
        private string HttpRequest (string Body)
        {
            int content = Encoding.ASCII.GetByteCount(Body);
            string request = $"POST / HTTP/1.1\r\n" 
                           + $"Host: {FClientIp}:{FClientPort}\r\n"
                           + $"Content-Length: {content}\r\n"
                           + $"Connection: keep-alive\r\n"
                           + $"\r\n" 
                           +  $"{Body}";
            return request;
        }

        public void SendData(Dictionary<string, string> map)
        {
            if (map == null || map.Count == 0 || !FIsClientConnected)   
            {
                Logger.Log(LOG_ID, "Нет данных для отправки");
                return;
            }
            try
            {
                string json = ConvertToJson(map);
                Logger.Log(LOG_ID, $"JSON: {json}");
                string base64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(json));
                Logger.Log(LOG_ID, $"Base64: {base64}");
                SendRequest(base64);
            }
            catch (Exception ex)
            {
                Logger.Log(LOG_ID, $"Ошибка отправки: {ex.Message}");
            }
        }

        private string ConvertToJson(Dictionary <string, string> map)
        {
            if (map == null || map.Count == 0)
            {
                return "{}";
            }
            string json = "{";
            bool isComma = true;
            foreach (var i in map)
            {
                if (!isComma)
                {
                    json += ",";
                }
                isComma = false;
                json += "\"" + EscapeJson(i.Key) + "\":\"" + EscapeJson(i.Value) + "\"";
            }
            json += "}";
            return json;
        }

        private string EscapeJson(string s)
        {
            if (string.IsNullOrEmpty(s))
            { 
                return "";
            }
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
        }
    }
}
