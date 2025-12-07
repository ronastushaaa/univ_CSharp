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


namespace HTTP_server
{
    public partial class Romanovskaia241_324_LAB4_SERVER : Form
    {
        private ServerTcp tcpServer;
        public Romanovskaia241_324_LAB4_SERVER()
        {
            InitializeComponent();
            tcpServer = null;
        }

        private void server_start_btn_Click(object sender, EventArgs e)
        {
            if (tcpServer == null)
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
                try
                {
                    tcpServer = new ServerTcp();
                    tcpServer.StartServer(serverPort);
                    AddtoServerINFO("", $"Сервер запущен на порту: {serverPort}");
                    AddtoServerINFO("", "Сервер начал прослушивание");
                    server_start_btn.Text = "Остановить";
                }
                catch (Exception)
                {
                    AddtoServerINFO("", "Ошибка запуска сервера!");
                    tcpServer = null;
                    server_start_btn.Text = "Запустить";
                }
            }
            else
            {
                try
                {
                    tcpServer.StopServer();
                    AddtoServerINFO("", "Сервер остановлен!");
                    server_start_btn.Text = "Запустить";
                }
                catch (Exception)
                {
                    AddtoServerINFO("", "Ошибка остановки сервера!");
                }
            }
        }

        private void AddtoServerINFO(string who, string serverMessage)
        {
            if (server_info_lstbox.InvokeRequired)
            {
                server_info_lstbox.Invoke(new Action<string, string>(AddtoServerINFO), who, serverMessage); 
            }
            else
            {
                server_info_lstbox.Items.Add($"{DateTime.Now:HH:mm:ss} - {who}{serverMessage}");

                server_info_lstbox.SelectedIndex = server_info_lstbox.Items.Count - 1; 
            }
        }


    }
}
