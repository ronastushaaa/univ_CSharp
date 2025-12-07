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
            if (FListener != null)
                return;

            FListener = new TcpListener(IPAddress.Any, serverPort);
            FListenerThread = new Thread(new ThreadStart(ReceiveConnect));
            FListenerThread.IsBackground = true;
            FListenerThread.Start();
            FIsServerRunning = true;
        }

        public void StopServer()
        {
            if (FListener != null)
            {
                FListener.Stop();
                FListener = null;
            }
        }

        private void ReceiveConnect()
        {
            FListener.Start();
            while (FIsServerRunning)
            {
                    TcpClient client = FListener.AcceptTcpClient(); // Получаем входящие подключение
                    HandleClientData(client);
            }
        }

        private void HandleClientData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            const int BUF_SIZE = 4096;
            var tmp_buf = new byte[BUF_SIZE];

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

                string req = Encoding.UTF8.GetString(tmp_buf, 0, bytes);
            }
            client.Close();
        }
    }
}
