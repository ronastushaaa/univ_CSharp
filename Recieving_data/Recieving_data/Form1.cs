using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recieving_data
{
    public partial class Form1 : Form
    {
        public delegate void ShowMessage(string message);
        public ShowMessage myDelegate;
        private int portServer;
        UdpClient udpServer;
        Thread thread;

        private StreamReader reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (cbx_choose_mode.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(txt_name_file.Text))
                {
                    //файл не выбран
                }
                try
                {
                    reader = new StreamReader()
                }
            }
            else
            {
                portServer = int.Parse(txt_port.Text);
                udpServer = new UdpClient(portServer);

                thread = new Thread(new ThreadStart(ReceiveMessage));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, portServer);
                byte[] content = udpServer.Receive(ref remoteIPEndPoint);
                this.Invoke(myDelegate, new object[] { content });
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            if (cbx_choose_mode.SelectedIndex == 0)
            {

            }
            else
            {
                udpServer.Close();
            }
        }

        private string ParseFrame(byte[] data)
        {
            string text = Encoding.ASCII.GetString(data);

            return text;
        }
    }
}
