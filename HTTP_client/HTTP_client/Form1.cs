using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace HTTP_client
{
    public partial class Romanovskaia241_324_LAB4_CLIENT : Form
    {
        private ClientTcp tcpClient;
        public Romanovskaia241_324_LAB4_CLIENT()
        {
            InitializeComponent();
            tcpClient = new ClientTcp();
            Logger.OnLog += ShowLogInfo;
            client_txt_port.Text = "8080";
            client_txt_ip.Text = "127.0.0.1";
        }

        private void ShowLogInfo(string who, string msg)
        {
            if (client_info_lstbox.InvokeRequired)
            {
                client_info_lstbox.Invoke(new Action<string, string>(ShowLogInfo), who, msg); //создаем экземпляр делегата, который указывает на нашу функцию
            }
            else
            {
                client_info_lstbox.Items.Add($"{who}: {msg}");
                client_info_lstbox.SelectedIndex = client_info_lstbox.Items.Count - 1; // опускаемся к последнему сообщению
            }
        }
        private void client_conect_btn_Click(object sender, EventArgs e)
        {
            if (!tcpClient.FIsConnected)
            {
                IPAddress ip;
                int clientPort;
                try
                {
                    ip = IPAddress.Parse(client_txt_ip.Text.Trim());
                    clientPort = int.Parse(client_txt_port.Text.Trim()); // нужен ли \n
                }
                catch (Exception)
                {
                    return;
                }
                tcpClient.ConnectToServer(ip, clientPort);
                client_conect_btn.Text = "Отключиться";
            }
            else
            {
                tcpClient.DisconnectFromServer();
                client_conect_btn.Text = "Подключиться";

            }
        }

        private void client_send_btn_Click(object sender, EventArgs e)
        {
            string a = client_input_a.Text;
            string b = client_input_b.Text;
            string c = client_input_c.Text;
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("A", a);
            map.Add("B", b);
            map.Add("C", c);
            tcpClient.SendData(map);
            //string clientMessage = client_message_txt.Text + "\n";
            //SendMessage(clientMessage);
            // client_message_txt.Clear();
        }

    }
}
