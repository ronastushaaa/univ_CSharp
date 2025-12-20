using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        //коллекция очередь "1 пришёл - 1 вышел" : ключ значение
        private Queue<KeyValuePair<List<int>, DateTime>> frameQueue; //буфер, хранит пару (список расстояний и время получения) При паузе накапливаем и показываем последний
        private object queueLock; // объект замок. Если взять этот объект потоком, то только этот поток может записывать

        private StreamReader reader;
        private bool isPaused;

        //Хранение фрейма
        private List<int> currentFrame;
        private DateTime currentTimeOfFrame;
        private bool redrawRequested;   //обновились ли данные

        public Form1()
        {
            InitializeComponent();

            currentFrame = new List<int>();
            isPaused = false;
            redrawRequested = false;

            frameQueue = new Queue<KeyValuePair<List<int>, DateTime>>();
            queueLock = new object();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (cbx_choose_mode.SelectedIndex == 0)
            {
                StartFileReading();
            }
            else
            {
                StartUdpReceiving();
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            StopAll();
        }

        private void StopAll()
        {
            isPaused = false;

            fileTimer.Enabled = false;

            if (reader != null)
            {
                reader.Close();
                reader = null;
            }

            if (udpServer != null)
            {
                udpServer.Close();
                udpServer = null;
            }

            if (thread != null && thread.IsAlive)
            {
                thread.Abort();
                thread = null;
            }

            currentFrame.Clear();
            ClearDisplay();

        }

        private void ClearDisplay()
        {
            lst_data.Items.Clear();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }
        // -------РАБОТАЮ С UDP---------
        private void StartUdpReceiving()
        {
            portServer = int.Parse(txt_port.Text);
            if (udpServer != null)
            {
                udpServer.Close();
            }
            udpServer = new UdpClient(portServer);

            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(new ThreadStart(ReceiveMessage));
            thread.IsBackground = true;
            thread.Start();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, portServer);
                byte[] data = udpServer.Receive(ref remoteIPEndPoint);
                //this.Invoke(myDelegate, new object[] { data });
                string text = Encoding.ASCII.GetString(data).Trim();

                string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> distance = new List<int>();
                for (int i = 0; i < parts.Length; i++)
                {
                    int value = int.Parse(parts[i]);
                    distance.Add(value);
                }
                DateTime timeNow = DateTime.Now;

                lock(queueLock)
                {
                    frameQueue.Enqueue(new KeyValuePair<List<int>, DateTime>(distance, timeNow));
                    if (frameQueue.Count > 1)
                    {
                        frameQueue.Dequeue(); // удаляем старый фрейм
                    }
                }
                if (!isPaused)
                {
                    this.Invoke(new MethodInvoker(PreparingForDisplay)); //встроенный делегат без параметров и без возврата
                }
            }
        }

        private void PreparingForDisplay()
        {
            lock (queueLock)
            {
                if (frameQueue.Count > 0)
                {
                    KeyValuePair<List<int>, DateTime> pair = frameQueue.Dequeue();
                    currentFrame = pair.Key;
                    currentTimeOfFrame = pair.Value;
                    redrawRequested = true;
                }
            }

        }


        //-------РАБОТАЮ С ФАЙЛОМ------
        private void StartFileReading()
        {
            string file = txt_name_file.Text;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                MessageBox.Show("Файл не выбран или не существует!");
                return;
            }
            try
            {
                if (reader != null)
                {
                    reader.Close();
                }
                reader = new StreamReader(file);
                isPaused = false;

                int freq = 100;
                bool parsed = int.TryParse(txt_freq.Text, out freq);
                if (freq <= 0)
                {
                    freq = 100;
                }
                fileTimer.Interval = freq;
                fileTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия файла:" + ex.Message);
            }
        }
        private void fileTimer_Tick(object sender, EventArgs e)
        {
            if (isPaused)
            {
                return;
            }
            if (reader == null || reader.EndOfStream)
            {
                fileTimer.Enabled = false;
                MessageBox.Show("Конец файла!");
                return;
            }

            string line = reader.ReadLine();
            if (string.IsNullOrEmpty(line))
            {
                return;
            }

            try
            {
                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                currentFrame.Clear();
                for (int i = 0; i < parts.Length; i++)
                {
                    int value = int.Parse(parts[i]);
                    currentFrame.Add(value);
                }
                currentTimeOfFrame = DateTime.Now;
                redrawRequested = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка разбора строки:" + ex.Message);
            }
        }
    }
}
