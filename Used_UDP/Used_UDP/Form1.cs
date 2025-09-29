using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Used_UDP
{
    public partial class Form1 : Form
    {
        public delegate void ShowMessage(string message);
        public ShowMessage myDelegate;
        private int port_server, port_client;
        private IPAddress ip;
        UdpClient udpServer, udpClient;
        Thread thread;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            udpServer = new UdpClient(int.Parse(text_SendPort.Text));

            text_info.Text = "Слушаем порт: " + port_client;

            thread = new Thread(new ThreadStart(ReceiveMessage));
            thread.IsBackground = true;
            thread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            udpClient = new UdpClient();
            myDelegate = new ShowMessage(ShowMessageMethod);
            text_SendIP.Text = "127.0.0.1";
            text_SendPort.Text = "8080";
            text_listen_port.Text = "8080";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                thread.Abort();
                udpServer.Close();
                Close();
            }
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any,  0);
                byte[] content = udpServer.Receive(ref remoteIPEndPoint);

                if (content.Length > 0)
                {
                    string message = Encoding.ASCII.GetString(content);

                    this.Invoke(myDelegate, new object[] { message });
                }
            }
        }

        private void btn_send__Click(object sender, EventArgs e)
        {
            ip = IPAddress.Parse(text_SendIP.Text.Trim());
            port_client = int.Parse(text_SendPort.Text);
            IPEndPoint ipEndPoint = new IPEndPoint(ip, port_client);
            byte[] input = Encoding.ASCII.GetBytes(text_SendMsg.Text);
            try
            {
                int count = udpClient.Send(input, input.Length, ipEndPoint);
                if (count > 0)
                {
                    text_info.Text = "Message has been sent.";
                }
            }
            catch
            {
                text_info.Text = "Error occurs.";
            }
        }

        private void ShowMessageMethod(string message)
        {
            string newMessage = $"[{DateTime.Now.ToString("HH:mm:ss")}] {text_SendName.Text}: {message}";
            if (string.IsNullOrEmpty(label_recieve_msg.Text))
            {
                label_recieve_msg.Text = newMessage;
            }
            else
            {
                label_recieve_msg.Text += $"\n{newMessage}";
            }
            text_listen_port.Text = text_SendPort.Text;
        }
    }
}
