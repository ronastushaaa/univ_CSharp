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
using System.Runtime.Remoting.Messaging;
using System.IO.Ports;
using System.Runtime.Remoting.Contexts;

namespace Used_TCP
{
    public partial class Romanovskaia241_324_LAB3 : Form
    {
        private TcpListener Tlistener;
        private Thread listenerThread;
        private bool isServerRunning = false;
        public delegate void ShowMessage(string message);
        public ShowMessage myDelegate;

        private TcpClient Lclient; // FClient
        private NetworkStream clientStream;
        private bool isClientConnected = false;

        private int serverPort, port_client;
        //private IPAddress ip;

        TClientInfo FClient;
        TClientInfo FSClient;

        private Bitmap drawingBitmap; //растровое изоображение - холст для изображения
        private Graphics drawingGraphics;
        private Pen currentPen; //перо для рисования
        private Brush currentBrush; //заливка

        private delegate void AddServerMessageDelegate(string prefix, string message);
        private AddServerMessageDelegate addServerMessageDelegate;


        public Romanovskaia241_324_LAB3()
        {
            InitializeComponent();
            addServerMessageDelegate = new AddServerMessageDelegate(AddtoServerINFO);
        }


        private void server_start_btn_Click(object sender, EventArgs e)
        {
            if (!isServerRunning)
            {
                serverPort = int.Parse(server_port_txt.Text);
                StartServer(serverPort);
            }
            else
            {
                StopServer();
            }
        }

        private void StartServer(int serverPort)
        {
            try
            {
                Tlistener = new TcpListener(IPAddress.Any, serverPort);
                listenerThread = new Thread(new ThreadStart(ReceiveMessage));
                listenerThread.IsBackground = true;
                listenerThread.Start();

                AddtoServerINFO(" ", $"Сервер запущен на порту: {serverPort}");

                isServerRunning = true;
                server_start_btn.Text = "Остановить";
            }

            catch (Exception ex)
            {
                AddtoServerINFO(" ", "Ошибка запуска сервера!");
            }
        }

        private void AddtoServerINFO(string who, string serverMessage)
        {
            if (server_info_lstbox.InvokeRequired)
            {
                server_info_lstbox.Invoke(new Action<string, string>(AddtoServerINFO), who, serverMessage); //создаем экземпляр делегата, который указывает на нашу функцию
            }
            else
            {
                server_info_lstbox.Items.Add($"{DateTime.Now:HH:mm:ss} - {who}{serverMessage}");
                server_info_lstbox.SelectedIndex = server_info_lstbox.Items.Count - 1; // опускаемся к последнему сообщению
            }
        }

        private void AddtoClientINFO(string who, string clientMessage)
        {
            if (client_chat_lstbox.InvokeRequired)
            {
                client_chat_lstbox.Invoke(new Action<string, string>(AddtoServerINFO), who, clientMessage); //создаем экземпляр делегата, который указывает на нашу функцию
            }
            else
            {
                client_chat_lstbox.Items.Add($"{DateTime.Now:HH:mm:ss} - {who}{clientMessage}");
                client_chat_lstbox.SelectedIndex = client_chat_lstbox.Items.Count - 1; // опускаемся к последнему сообщению
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
                    AddtoServerINFO(" ", "Ошибка остановки сервера!");
                }
            }
            server_start_btn.Text = "Слушать";
            AddtoServerINFO(" ", "Сервер остановлен!"); 
        }

        private void client_conect_btn_Click(object sender, EventArgs e)
        {
            if (!isClientConnected)
            {
                IPAddress ip = IPAddress.Parse(client_ip_txt.Text.Trim());
                port_client = int.Parse(client_port_txt.Text);
                ConnectToServer(ip, port_client);
            }
            else
            {
                //DisconnectFromServer();
            }
        }

        private void ConnectToServer(IPAddress ip, int port)
        {
            try
            {
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
                AddtoServerINFO(" ", "Сервер начал прослушивание");

                while (isServerRunning)
                {
                    Lclient = Tlistener.AcceptTcpClient(); // Получаем входящие подключение
                    TClientInfo clientInfo = new TClientInfo(Lclient, ((IPEndPoint)Lclient.Client.RemoteEndPoint).Port)
                    //clientStream = Tclient.GetStream(); // получаем сетевой поток для чтения и записи
                    AddtoServerINFO("", $"Клиент подключен {Lclient.Client.RemoteEndPoint}");

                    //HandleClient(Tclient);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void HandleCLient(TClientInfo clientInfo) // обработка данных клиента
        {
            TcpClient client = clientInfo.GetClient();
            NetworkStream stream = client.GetStream();
            byte[] message = new byte[4096];
            int bytes;

            while (true)
            {
                bytes = 0;
                try
                {
                    bytes = stream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytes == 0)
                {
                    break;
                }

                string rmessage = Encoding.ASCII.GetString(message, 0, bytes).Trim();
                this.Invoke(addServerMessageDelegate, new object[] { "RCV: ",rmessage });

                string response = CommandProcess(rmessage);
                byte[] responses = Encoding.ASCII.GetBytes(response);

                stream.Write(responses, 0, responses.Length);
                this.Invoke(addServerMessageDelegate, new object[] { "SND: ", response });
            }
        }


        private string CommandProcess(string command)
        {
            string[] elements = command.Split(' ');

            string elemntsType = elements[0].ToUpper(); //преобразует в верхний регистр

            try
            {
                switch(elemntsType)
                {
                    case "LINE":
                        if (elements.Length == 5)
                        {
                            int x1 = int.Parse(elements[1]);
                            int y1 = int.Parse(elements[2]);
                            int x2 = int.Parse(elements[3]);
                            int y2 = int.Parse(elements[4]);
                            drawingGraphics.DrawLine(currentPen, x1, y1, x2, y2);
                            sever_pictureBox.Invalidate();
                            return "Ок. Линия нарисована";
                        }
                        return "ERROR";
                    case "RECTANGLE":
                        if (elements.Length ==5)
                        {
                            int x = int.Parse(elements[1]);
                            int y = int.Parse(elements[2]);
                            int width = int.Parse(elements[3]);
                            int height = int.Parse(elements[4]);
                            drawingGraphics.DrawRectangle(currentPen, x, y, width, height);
                            sever_pictureBox.Invalidate();
                            return "OK: Прямоугольник нарисован";
                        }
                        return "ERROR";
                    case "CIRCLE":
                        if (elements.Length == 4)
                        {
                            int x = int.Parse(elements[1]);
                            int y = int.Parse(elements[2]);
                            int radius = int.Parse(elements[3]);
                            drawingGraphics.DrawEllipse(currentPen, x - radius, y - radius, radius * 2, radius * 2);
                            sever_pictureBox.Invalidate();
                            return "OK: Круг нарисован";
                        }
                        return "ERROR";
                    case "TEXT":
                        if (elements.Length >= 4)
                        {
                            int x = int.Parse(elements[1]);
                            int y = int.Parse(elements[2]);
                            string text = string.Join(" ", elements, 3, elements.Length - 3);
                            drawingGraphics.DrawString(text, new Font("Arial", 12), currentBrush, x, y);
                            sever_pictureBox.Invalidate();
                            return "OK: Текст добавлен";
                        }
                        return "ERROR";
                    default:
                        return "ERROR";
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
        }


    }
    public class TClientInfo
    {
        private TcpClient FClient; // FClient
        private int FPort;

        //public TcpClient Port get FPort set FPort;

        public TClientInfo(TcpClient client, int port)
        {
            this.FClient = client;
            this.FPort = port;
        }

        public TcpClient GetClient()
        {
            return FClient;
        }

        public int GetPort()
        {
            return FPort;
        }

        public void SetClient(TcpClient client)
        {
            FClient = client;
        }

        public void SetPort(int port)
        {
            FPort = port;
        }
    }

}
