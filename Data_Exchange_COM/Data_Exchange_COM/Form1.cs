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


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                serialPort.PortName = comboBox1.SelectedItem.ToString();
                serialPort.BaudRate = 9600; //скорость передачи данных
                //serialPort.DataReceived += new SerialDataReceivedEventHandler();
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

        private void PrintControlBoardLog(string s)
        {
            ReportListBox.Items.Add(s);                    // Добавляем строку в ListBox
            while (ReportListBox.Items.Count > CMaxVisibleLogLines)
            {
                ReportListBox.Items.RemoveAt(0);           // Удаляем старые строки
            }
            ReportListBox.SelectedIndex = ReportListBox.Items.Count - 1;
            ReportListBox.SelectedIndex = -1;              // Сбрасываем выделение
        }
        private void ControlBoardSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();                          // Читаем все доступные данные
            ControlBoardComPortDataReciveBuffer += indata;              // Добавляем в буфер
        }
    }
}
