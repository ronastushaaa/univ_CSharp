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
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;

namespace Used_TCP
{
    public partial class Romanovskaia241_324_LAB3 : Form
    {
        TClientInfo FServerInfo;
        private TcpListener FListener;
        private Thread FListenerThread;
        private bool FIsServerRunning = false;

        TClientInfo FClientInfo;
        private TcpClient FClient;
        private Thread FClientThread;
        private NetworkStream FClientStream;
        private bool FIsClientConnected = false;

        public ShowMessage myDelegate;
        public delegate void ShowMessage(string message);

        private Bitmap drawingBitmap; //растровое изоображение - холст для изображения
        private Graphics drawingGraphics;
        private Pen currentPen; //перо для рисования
        private Brush currentBrush; //заливка

        private int indexclient;
        //private bool isTelnet = false;

        //private delegate void AddServerMessageDelegate(string prefix, string message);
        //private AddServerMessageDelegate addServerMessageDelegate;


        public Romanovskaia241_324_LAB3()
        {
            InitializeComponent();
            //addServerMessageDelegate = new AddServerMessageDelegate(AddtoServerINFO);
            Drawing();
            client_ip_txt.Text = "127.0.0.1";
            client_port_txt.Text = "2323";
            server_port_txt.Text = "2323";
            clientChoose.SelectedIndex = 0;
            clientChoose.SelectedIndexChanged += clientChoose_SelectedIndexChanged;
    }

        private void clientChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientChoose.SelectedIndex == 1) // Telnet-сервер
            {
                server_port_txt.Text = "2323";
                client_port_txt.Text = "8080";
                indexclient = 2;
                //isTelnet = true;
            }
            else 
            {
                server_port_txt.Text = "2323";
                client_port_txt.Text = "2323";
                indexclient = 1;
                //isTelnet = false;
            }
        }
        private bool IsCommand_2b(byte command)
        {
            switch (command)
            {
                case 0xED: // ABORT
                case 0xEC: // EOF
                case 0xF3: // BRK
                case 0xF6: // AYT
                    return true;
                default:
                    return false;
            }
        }
        private bool IsCommand_3b(byte command)
        {
            switch (command)
            {
                case 0xFB: // WILL
                case 0xFC: // WON'T
                case 0xFD: // DO
                case 0xFE: // DON'T
                    return true;
                default:
                    return false;
            }
        }

        private string FilterOutNVT(ref List<byte> buf)
        {
            List<byte> clientCommand = new List<byte>();
            int index = 0;
            while (index < buf.Count)
            {
                byte ch = buf[index];   
                // Обычный символ (не NVT)
                if (ch != 0xFF)
                {
                    clientCommand.Add(ch);
                    index += 1;
                    continue;
                }

                // приняли только IAC
                if (index + 1 >= buf.Count)
                {
                    buf.RemoveRange(0, index); //или index-1
                    return Encoding.UTF8.GetString(clientCommand.ToArray());
                }

                // приняли только IAC + cmd
                if (index + 2 >= buf.Count)
                {
                    byte cmd = buf[index + 1];
                    if (cmd == 0xFF)
                    {
                        AddtoServerINFO("NVT:", "IAC");
                        clientCommand.Add(0xFF);
                        index += 2;
                        continue;
                    }
                    if (IsCommand_2b(cmd))
                    {
                        string nvt = $"IAC {cmd:X2}";
                        AddtoServerINFO("NVT:", nvt);
                        index += 2;
                        buf.RemoveRange(index, 2);
                        return Encoding.UTF8.GetString(clientCommand.ToArray());
                    }
                    if (IsCommand_3b(cmd))
                    {
                        buf.RemoveRange(index, 3);
                        return Encoding.UTF8.GetString(clientCommand.ToArray());
                    }
                    AddtoServerINFO("NVT:", "unknown NVT command");
                    return "";
                }

                {
                    // приняли IAC + cmd + prm
                    byte cmd = buf[index + 1];
                    byte prm = buf[index + 2];
                    string nvt = $"IAC {cmd:X2} {prm:X2}";
                    AddtoServerINFO("NVT:", nvt);
                    index += 3;
                    continue;
                }
            }
            // не было NVT команд вообще
            buf.Clear();
            return Encoding.UTF8.GetString(clientCommand.ToArray());
        }

        // ----- Сервер -----

        private void server_start_btn_Click(object sender, EventArgs e)
        {
            if (!FIsServerRunning)
            {
                int serverPort;
                try
                {
                    serverPort = int.Parse(server_port_txt.Text);
                }
                catch (Exception ex)
                {
                    AddtoServerINFO("", $"Ошибка: {ex.Message}");
                    return;
                }
                StartServer(serverPort);
                server_start_btn.Text = "Остановить";
            }
            else
            {
                StopServer();
                server_start_btn.Text = "Слушать";
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

        private void StartServer(int serverPort)
        {
            if (FListener != null)
                return;
            try
            {
                FListener = new TcpListener(IPAddress.Any, serverPort);
                FListenerThread = new Thread(new ThreadStart(ReceiveMessage));
                FListenerThread.IsBackground = true;
                FListenerThread.Start();
                AddtoServerINFO("", $"Сервер запущен на порту: {serverPort}");
                FIsServerRunning = true;
            }
            catch (Exception)
            {
                AddtoServerINFO("", "Ошибка запуска сервера!");
            }
        }


        private void StopServer()
        {
            FIsServerRunning = false;
            if (FListener != null)
            {
                try
                {
                    FListener.Stop();
                }
                catch
                {
                    AddtoServerINFO("", "Ошибка остановки сервера!");
                }
            }
            AddtoServerINFO("", "Сервер остановлен!"); 
        }

        private void ReceiveMessage()
        {
            try
            {
                FListener.Start();
                AddtoServerINFO("", "Сервер начал прослушивание");
                while (FIsServerRunning)
                {
                    TcpClient client = FListener.AcceptTcpClient(); // Получаем входящие подключение
                    AddtoServerINFO("", $"Клиент подключен {client.Client.RemoteEndPoint}");
                    HandleClientData(client);
                }
            }
            catch (Exception ex)
            {
                AddtoServerINFO("", $"Ошибка сервера: {ex.Message}");
            }
        }

        private void HandleClientData(TcpClient client) 
        {
            NetworkStream stream = client.GetStream();
            const int BUF_SIZE = 4096;
            var tmp_buf = new byte[BUF_SIZE];
            var rcv_buf = new List<byte>();
            string message = "";

            if (indexclient == 2)
            {
                byte[] a = Encoding.UTF8.GetBytes(">");
                stream.Write(a, 0, a.Length);
            }

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
                AddtoServerINFO("RCV: ", req);

                // только команды
                if (indexclient == 2)
                {
                    rcv_buf.AddRange(tmp_buf.Take(bytes));
                    // Данные nvt и команды
                    message += FilterOutNVT(ref rcv_buf);
                }
                else
                {
                    // message: RECTANGLE 
                    // message: 1 2 2 
                    // message: 3 23\nCIR
                    // command: RECTANGLE 1 2 23 23 [\n]
                    //this.Invoke(addServerMessageDelegate, new object[] { "CMD: ", command });

                    message += req;
                }
                //message = message.Substring(-2);
                int index = message.IndexOf('\n');
                if (index >= 0)
                {
                    string command = message.Substring(0, index).Trim();
                    message = message.Substring(index + 1).Trim();
                    if (!string.IsNullOrEmpty(command))
                    {
                        string ans = CommandProcess(command);
                        byte[] snd_buf = Encoding.UTF8.GetBytes(ans + "\r\n> ");
                        stream.Write(snd_buf, 0, snd_buf.Length);
                        AddtoServerINFO("SND: ", ans);
                        //this.Invoke(addServerMessageDelegate, new object[] { "SND: ", response });
                    }
                }
            }
            //отключение
            AddtoServerINFO("", "Клиент отключен");
            client.Close();
        }


        private string CommandProcess(string command)
        {
            string[] elements = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
                        break;
                    case "RECTANGLE":
                        if (elements.Length == 5)
                        {
                            int x = int.Parse(elements[1]);
                            int y = int.Parse(elements[2]);
                            int width = int.Parse(elements[3]);
                            int height = int.Parse(elements[4]);
                            drawingGraphics.DrawRectangle(currentPen, x, y, width, height);
                            sever_pictureBox.Invalidate();
                            return "OK: Прямоугольник нарисован";
                        }
                        break;
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
                        break;
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
                        break;
                    case "CLEAR":
                        drawingGraphics.Clear(Color.White);
                        sever_pictureBox.Invalidate();
                        return "OK";
                    case "HELP":
                        return "COMMANDS:\nLINE <x1> <y1> <x2> <y2>\n" +
                            "RECTANGLE <x> <y> <width> <height>\n" +
                            "CIRCLE <x> <y> <radius>\n" +
                            "TEXT <x> <y> <text>\n" +
                            "CLEAR";
                    default:
                        break;
                }
                AddtoServerINFO("ERR: ", "Недопустимая команда ("+ command + ")");
                return "ERROR";
            }
            catch (Exception ex)
            {
                AddtoServerINFO("ERR: ", ex.Message);
                return "ERROR";
            }
        }

        private void Drawing()
        {
            drawingBitmap = new Bitmap(sever_pictureBox.Width, sever_pictureBox.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White);
            sever_pictureBox.Image = drawingBitmap;

            currentPen = new Pen(Color.Black, 2);
            currentBrush = Brushes.Black;
        }


        // ----- Клиент -----
        private void AddtoClientINFO(string who, string clientMessage)
        {
            if (client_chat_lstbox.InvokeRequired)
            {
                client_chat_lstbox.Invoke(new Action<string, string>(AddtoClientINFO), who, clientMessage); //создаем экземпляр делегата, который указывает на нашу функцию
            }
            else
            {
                client_chat_lstbox.Items.Add($"{DateTime.Now:HH:mm:ss} - {who}{clientMessage}");
                client_chat_lstbox.SelectedIndex = client_chat_lstbox.Items.Count - 1; // опускаемся к последнему сообщению
            }
        }

        private void client_conect_btn_Click(object sender, EventArgs e)
        {
            if (!FIsClientConnected)
            {
                IPAddress ip;
                int clientPort;
                try
                {
                    ip = IPAddress.Parse(client_ip_txt.Text.Trim());
                    clientPort = int.Parse(client_port_txt.Text + "\n");
                }
                catch (Exception)
                {
                    return;
                }
                ConnectToServer(ip, clientPort);
                client_conect_btn.Text = "Отключить";
            }
            else
            {
                DisconnectFromServer();
                client_conect_btn.Text = "Подключить";
            }
        }

        private void ConnectToServer(IPAddress ip, int port)
        {
            try
            {
                FClient = new TcpClient();
                FClient.Connect(ip, port);
                //FClientStream = FClient.GetStream();

                FClientThread = new Thread(new ThreadStart(RecieveMessageFromServer));
                FClientThread.IsBackground = true;
                FClientThread.Start();
                FIsClientConnected = true;
                AddtoClientINFO("", $"Клиент подключился к серверу: {port}");
            }
            catch (Exception ex)
            {
                AddtoClientINFO("", $"Ошибка подключения: {ex.Message}");
            }
        }

        private void DisconnectFromServer()
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
                AddtoClientINFO("RCV: ", receivedMessage);
            }
            AddtoClientINFO("", "Клиент отключился");
        }

        private void client_send_btn_Click(object sender, EventArgs e)
        {
            string clientMessage = client_message_txt.Text + "\n";
            SendMessage(clientMessage);
            client_message_txt.Clear();
        }

        private void SendMessage(string clientMessage)
        {
            if (FIsClientConnected && !string.IsNullOrEmpty(clientMessage))
            {
                try
                {
                    byte[] messageData = Encoding.ASCII.GetBytes(clientMessage);
                    FClient.GetStream().Write(messageData, 0, messageData.Length);
                    AddtoClientINFO("SND: ", clientMessage);
                }
                catch (Exception ex)
                {
                    AddtoClientINFO("", $"Ошибка отправки: {ex.Message}");
                    //DisconnectFromServer();
                }
            }       
        }

        private void draw_btn_Click(object sender, EventArgs e)
        {
            string command = server_comand_txt.Text.Trim();
            string result = CommandProcess(command);
            if (result.StartsWith("OK") || result.StartsWith("Ок"))
            {
                AddtoServerINFO("Локальная команда: ", $"{command} - {result}");
            }
        }
    }
    public class TClientInfo
    {
        private TcpClient FClient; 
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

        public void SetPort(int port)
        {
            FPort = port;
        }
    }

}

