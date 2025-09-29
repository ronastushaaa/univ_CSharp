using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Exchange_COM
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort();

        }

        private void EnterPorts()
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames()); //добавляет послледовательность из имён портов.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                serialPort.PortName = comboBox1.SelectedItem.ToString();
                serialPort.BaudRate = 9600; //скорость передачи данных
                serialPort.DataReceived += new SerialDataReceivedEventHandler();
                try
                {
                    serialPort.Open();
                    MessageBox.Show("Connect to " + serialPort.PortName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection error");
                }
            }
        }
    }
}
