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

namespace HTTP_client
{
    public partial class Romanovskaia241_324_LAB4_CLIENT : Form
    {
        private ClientTcp tcpClient;
        public Romanovskaia241_324_LAB4_CLIENT()
        {
            InitializeComponent();
            tcpClient = new ClientTcp();
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
                    clientPort = int.Parse(client_txt_port.Text + "\n"); // нужен ли \n
                }
                catch (Exception)
                {
                    return;
                }
                try
                {
                    tcpClient.ConnectToServer(ip, clientPort);
                    client_conect_btn.Text = "Отключиться";
                    AddtoClientINFO("", $"Подключено к {ip}:{clientPort}");
                }
                catch (Exception)
                {
                    AddtoClientINFO("", $"Ошибка подключения");
                }
            }
            else
            {
                try
                {
                    tcpClient.DisconnectFromServer();
                    client_conect_btn.Text = "Подключиться";
                    AddtoClientINFO("", "Отключено от сервера");
                }
                catch (Exception)
                {
                    AddtoClientINFO("", $"Ошибка отключения");
                }

            }
        }

        private void client_send_btn_Click(object sender, EventArgs e)
        {
            //string clientMessage = client_message_txt.Text + "\n";
           // SendMessage(clientMessage);
           // client_message_txt.Clear();
        }


        private void AddtoClientINFO(string who, string clientMessage)
        {
            if (client_info_lstbox.InvokeRequired)
            {
                client_info_lstbox.Invoke(new Action<string, string>(AddtoClientINFO), who, clientMessage); //создаем экземпляр делегата, который указывает на нашу функцию
            }
            else
            {
                client_info_lstbox.Items.Add($"{DateTime.Now:HH:mm:ss} - {who}{clientMessage}");
                client_info_lstbox.SelectedIndex = client_info_lstbox.Items.Count - 1; // опускаемся к последнему сообщению
            }
        }

    }
}
