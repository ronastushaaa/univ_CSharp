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


        public void StartServer(int serverPort)
        {
            //Logger.Log("ServerTcp", "Start");

            if (FListener != null)
                return;
            try
            {
                FListener = new TcpListener(IPAddress.Any, serverPort);
                FListenerThread = new Thread(new ThreadStart(ReceiveConnect));
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

        private void ReceiveConnect()
        {
            try
            {
                FListener.Start();
                Logger.Log(LOG_ID, "Сервер начал прослушивание!");
                while (FIsServerRunning)
                {
                    TcpClient client = FListener.AcceptTcpClient(); // Получаем входящие подключение
                    Logger.Log(LOG_ID, $"Клиент подключен {client.Client.RemoteEndPoint}");
                    HandleClientData(client);
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
                req += Encoding.ASCII.GetString(tmp_buf, 0, bytes);
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
                }
                req = "";
            }
            Logger.Log(LOG_ID, "Клиент отключен!");
            client.Close();
        }
    }
}
