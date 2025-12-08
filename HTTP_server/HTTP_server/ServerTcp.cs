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
                Logger.Log("ServerTcp", $"Сервер запущен на порту: {serverPort}"); 
            }
            catch (Exception)
            {
                Logger.Log("ServerTcp", "Ошибка запуска сервера!");
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
                    Logger.Log("ServerTcp", "Ошибка остановки сервера!");
                }
            }
            Logger.Log("ServerTcp", "Сервер остановлен!");
        }

        private void ReceiveConnect()
        {
            try
            {
                FListener.Start();
                Logger.Log("ServerTcp", "Сервер начал прослушивание!");
                while (FIsServerRunning)
                {
                    TcpClient client = FListener.AcceptTcpClient(); // Получаем входящие подключение
                    Logger.Log("ServerTcp", $"Клиент подключен {client.Client.RemoteEndPoint}");
                    HandleClientData(client);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("ServerTcp", $"Ошибка сервера: {ex.Message}");
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
                Logger.Log("ServerTcp", req);
                lock (Console.Out)
                {
                    Console.WriteLine(req);

                }
                    if (req.IndexOf("\r\n\r\n") >= 0)
                {
                    HttpRequest r = HttpRequest.TryParse(req);
                    Logger.Log("ServerTcp", $"Method: {r.Method}");
                    Logger.Log("ServerTcp", $"Path: {r.Path}");
                    Logger.Log("ServerTcp", $"Ver: {r.Ver}");
                    Logger.Log("ServerTcp", "[HEADERS]");
                    foreach (var item in r.Headers)
                    {
                        string result = $"{item.Key}: {item.Value}";
                        Logger.Log("ServerTcp", result);
                    }
                    Logger.Log("ServerTcp", "[BODY]");
                }
            }
            Logger.Log("ServerTcp", "Клиент отключен!");
            client.Close();
        }
    }
}
