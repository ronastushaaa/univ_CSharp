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
            Logger.OnLog += ShowLogInfo;
        }

        private void ShowLogInfo(string who, string msg)
        {
            if (server_info_lstbox.InvokeRequired)
            {
                server_info_lstbox.Invoke(new Action<string, string>(ShowLogInfo), who, msg);
            }
            else
            {
                server_info_lstbox.Items.Add($"{who}: {msg}");
                server_info_lstbox.SelectedIndex = server_info_lstbox.Items.Count - 1;
            }
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
                    Logger.Log("ServerTcp", $"Ошибка: {ex.Message}"); // так и оставлять?
                    return;
                }
                tcpServer = new ServerTcp();
                tcpServer.StartServer(serverPort);
                server_start_btn.Text = "Остановить";
            }
            else
            {
                tcpServer.StopServer();
                tcpServer = null;
                server_start_btn.Text = "Запустить";
            }
        }


    }
}
