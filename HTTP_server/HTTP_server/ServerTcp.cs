using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP_server
{
    internal class ServerTcp
    {
        static private string LOG_ID = "ServerTcp";
        private TcpListener FListener;
        private Thread FListenerThread;
        private bool FIsServerRunning = false;
        private string FLastJSON = "";
        private int FReqCount = 0;

        private TcpClient FClient;


        public void StartServer(int serverPort)
        {
            //Logger.Log("ServerTcp", "Start");

            if (FListener != null)
                return;
            try
            {
                FLastJSON = "";
                FReqCount = 0;
                FListener = new TcpListener(IPAddress.Any, serverPort);
                FListenerThread = new Thread(new ThreadStart(ReceiveConnection));
                FListenerThread.IsBackground = true;
                FListenerThread.Start();
                FIsServerRunning = true;
                Logger.Log(LOG_ID, $"Сервер запущен на порту: {serverPort}"); 
            }
            catch (Exception)
            {
                Logger.Log(LOG_ID, "Ошибка запуска сервера!");
            }
        }

        public void StopServer()
        {
            FIsServerRunning = false;
            if (FListener != null)
            {
                try
                {
                    FListener.Stop();
                    //FListener = null; <- нужно ли оно?
                }
                catch
                {
                    Logger.Log(LOG_ID, "Ошибка остановки сервера!");
                }
            }
            Logger.Log(LOG_ID, "Сервер остановлен!");
        }

        private void ReceiveConnection()
        {
            try
            {
                FListener.Start();
                Logger.Log(LOG_ID, "Сервер начал прослушивание!");
                while (FIsServerRunning)
                {
                    TcpClient client = FListener.AcceptTcpClient(); // Получаем входящие подключение
                    Logger.Log(LOG_ID, $"Клиент подключен {client.Client.RemoteEndPoint}");
                    Thread clientThread = new Thread(delegate () { HandleClientData(client); });
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LOG_ID, $"Ошибка сервера: {ex.Message}");
            }
        }

        private void HandleClientData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            const int BUF_SIZE = 4096;
            var tmp_buf = new byte[BUF_SIZE];
            string req = "";
            while (FIsServerRunning)
            {
                int bytes = 0;
                try
                {
                    bytes = stream.Read(tmp_buf, 0, tmp_buf.Length);
                }
                catch
                {
                    break;
                }
                if (bytes == 0)
                {
                    break;
                }
                req += Encoding.UTF8.GetString(tmp_buf, 0, bytes);
                Logger.Log(LOG_ID, "RCV: "+ req);
                if (req.IndexOf("\r\n\r\n") >= 0)
                {
                    HttpRequest r = HttpRequest.TryParse(req);
                    Logger.Log(LOG_ID, $"Method: {r.Method}");
                    Logger.Log(LOG_ID, $"Path: {r.Path}");
                    Logger.Log(LOG_ID, $"Ver: {r.Ver}");
                    Logger.Log(LOG_ID, "[HEADERS]");
                    foreach (var item in r.Headers)
                    {
                        string result = $"{item.Key}: {item.Value}";
                        Logger.Log(LOG_ID, result);
                    }
                    Logger.Log(LOG_ID, "[BODY]");
                    Logger.Log(LOG_ID, $"{r.JsonBody}");
                    Logger.Log_2(r.A, r.B, r.C);

                    if(r.Path == "/")
                    {
                        FLastJSON = r.JsonBody;
                        FReqCount += 1;
                        Dictionary<string, string> map = Logger.GetMap();
                        SendMap(client, map);
                    }
                    else if (r.Path == "/stat/")
                    {
                        string html = BuildStatHtml();
                        SendResponse(client, html, "text/html; charset=utf-8", false);
                        FReqCount += 1;
                        break;
                    }
                    else 
                    {
                        Logger.Log(LOG_ID, "Не опознаный запрос!");
                        break;
                    }
                }
                req = "";
            }
            Logger.Log(LOG_ID, "Клиент отключен!");
            client.Close();
        }

        public void SendMap(TcpClient client, Dictionary<string, string> map)
        {
            string json = ConvertToJson(map);
            SendResponse(client, json);
        }
        public void SendResponse(TcpClient client, string data, string ContentType = "application/json", bool encodingBase64 = true)
        {
            string body;
            if (encodingBase64 == true)
            {
                body = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
            }
            else
            {
                body = data;
            }
            string response = "HTTP/1.1 200 OK\r\n"
                + $"Content-Type: {ContentType}\r\n"
                + "Connection: keep-alive\r\n"
                + "\r\n"
                + body;
            byte[] buf = Encoding.UTF8.GetBytes(response);
            client.GetStream().Write(buf, 0, buf.Length);
            Logger.Log(LOG_ID, $"Ответ отправлен: {data}");
        }

        private string ConvertToJson(Dictionary<string, string> map)
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

        private string BuildStatHtml()
        {
            return $@"<!DOCTYPE html>
            <html>
                <body>
                    Запросов: {FReqCount}<br>
                    Последний: {FLastJSON}
                </body>
            </html>";
        }

    }
}
