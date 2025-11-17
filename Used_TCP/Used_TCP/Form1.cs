using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;

namespace Used_TCP
{
    public partial class Romanovskaia241_324_LAB3 : Form
    {
        private TcpListener Tlistener;
        private Thread listenerThread;
        private bool isServerRunning = false;

        private TcpClient Tclient;
        private NetworkStream clientStream;
        private bool isClientConnected = false;

        private int port_server, port_client;
        private IPAddress ip;

        private Bitmap drawingBitmap; //растровое изоображение - холст для изображения
        private Graphics drawingGraphics;
        private Pen currentPen; //перо для рисования
        private Brush currentBrush; //заливка


        public Romanovskaia241_324_LAB3()
        {
            InitializeComponent();
        }


        private void server_start_btn_Click(object sender, EventArgs e)
        {
            if (!isServerRunning)
            {
                StartServer();
            }
            else
            {
                StopServer();
            }
        }

        private void StartServer()
        {
            try
            {
                port_server = int.Parse(server_port_txt.Text);
                Tlistener = new TcpListener(IPAddress.Any, port_server);
                listenerThread = new Thread(new ThreadStart(ReceiveMessage));
                listenerThread.IsBackground = true;
                listenerThread.Start();
                server_info_lstbox.Text += $"\nСервер запущен на порту: {port_server}";

                isServerRunning = true;
                server_start_btn.Text = "Остановить";
            }

            catch (Exception ex)
            {
                server_info_lstbox.Text += "\nОшибка запуска сервера!";
            }
        }

        private void StopServer()
        {
            isServerRunning = false;
            if (Tlistener != null)
            {
                try
                {
                    Tlistener.Stop();
                }
                catch (Exception ex)
                {
                    server_info_lstbox.Text += "\nОшибка остановки сервера";
                }
            }
            server_start_btn.Text = "Слушать";
            server_info_lstbox.Text += "\nСервер остановлен";
        }

        private void client_conect_btn_Click(object sender, EventArgs e)
        {
            if (!isClientConnected)
            {
                ConnectToServer();
            }
            else
            {
                DisconnectFromServer();
            }
        }

        private void ConnectToServer()
        {
            try
            {
                ip = IPAddress.Parse(client_ip_txt.Text.Trim());
                port_client = int.Parse(client_port_txt.Text);
                Tclient = new TcpClient();
                Tclient.Connect(ip, port_client);
                clientStream = Tclient.GetStream();

                isClientConnected = true;
                client_conect_btn.Text = "Отключиться";
                client_chat_lstbox.Text += "\nКлиент подключился к серверу";
            }
            catch { }
        }

        private void ReceiveMessage()
        {
            try
            {
                server_info_lstbox.Text += "\nСервер начал прослушивание";

                while (isServerRunning)
                {
                    Tclient = Tlistener.AcceptTcpClient(); // Получаем входящие подключение
                    clientStream = Tclient.GetStream(); // получаем сетевой поток для чтения и записи
                    server_info_lstbox.Text += $"\nКлиент подключен {Tclient.Client.RemoteEndPoint}";
                }
            }
            catch (Exception ex)
            {

            }
        }



    }
}
