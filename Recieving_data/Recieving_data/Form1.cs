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
        private List<KeyValuePair<List<int>, DateTime>> allFrames;
        private object queueLock; // объект замок. Если взять этот объект потоком, то только этот поток может записывать

        private StreamReader reader;
        private bool isPaused;
        private bool stopRequested;

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
            stopRequested = false;
            logger.Text = "";

            allFrames = new List<KeyValuePair<List<int>, DateTime>>();
            queueLock = new object();
            txt_name_file.Text = "C:\\work\\Проектирование_алгоритмов_систем_управления\\test.txt";
            txt_freq.Text = "200";
            txt_port.Text = "8080";
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

        private void pause_btn_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pause_btn.Text = "Continue";
                Log("Приём приостановлен.");
            }
            else
            {
                pause_btn.Text = "Pause";
                Log("Приём возобновлён.");
            }
        }

        // -------РАБОТАЮ С UDP---------
        private void StartUdpReceiving()
        {
            try
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
                Log("UDP-приём запущен на порту " + portServer.ToString());
            }
            catch (Exception ex)
            {
                Log("Ошибка запуска UDP: " + ex.Message);
            }
        }

        private void ReceiveMessage()
        {
            try
            {
                while (!stopRequested)
                {
                    IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, portServer);
                    byte[] data = udpServer.Receive(ref remoteIPEndPoint);
                    string text = Encoding.ASCII.GetString(data).Trim();
                    if (text.StartsWith(">"))
                    {
                        text = text.Substring(1).TrimStart(); 
                    }

                    string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 360)
                    {
                        Log("Получен некорректный UDP-фрейм: " + parts.Length.ToString() + " значений (ожидается 360)");
                        Log(text);
                        continue;
                    }
                    if (parts.Length != 360)
                    {
                        Log("Получен некорректный UDP-фрейм: " + parts.Length.ToString() + " значений (ожидается 360)");
                        Log(text);
                        continue;
                    }
                    List<int> distance = new List<int>();
                    for (int i = 0; i < parts.Length; i++)
                    {
                        int value = int.Parse(parts[i]);
                        distance.Add(value);
                    }
                    DateTime timeNow = DateTime.Now;
                    EnqueueFrame(distance, timeNow);

                    if (!isPaused)
                    {
                        this.Invoke(new MethodInvoker(PreparingForDisplay)); //встроенный делегат без параметров и без возврата
                    }
                }
            }
            catch (Exception ex)
            {
                if (!stopRequested)
                {
                    Log("Ошибка приёма UDP: " + ex.Message);
                }
            }
        }


        //-------РАБОТАЮ С ФАЙЛОМ------
        private void StartFileReading()
        {
            string file = txt_name_file.Text;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
               Log("Файл не выбран или не существует!");
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
                stopRequested = false;

                int interval = 100;
                bool parsed = int.TryParse(txt_freq.Text, out int freq);
                if (freq > 0)
                {
                    interval = freq;
                }
                fileTimer.Interval = interval;
                fileTimer.Enabled = true;
                Log("Чтение файла начато. Интервал: " + interval.ToString() + " мс");
            }
            catch (Exception ex)
            {
                Log("Ошибка открытия файла: " + ex.Message);
            }
        }
        private void fileTimer_Tick(object sender, EventArgs e)
        {
            if (isPaused)
            {
                return;
            }
            if (stopRequested)
            {
                return;
            }
            if (reader == null || reader.EndOfStream)
            {
                fileTimer.Enabled = false;
                Log("Достигнут конец файла.");
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
                if (parts.Length < 361)
                {
                    Log("Недостаточно данных в строке: " + parts.Length.ToString() + " элементов (ожидается ≥361)");
                    return;
                }
                DateTime timeNow = DateTime.Today.AddHours(12);
                bool parsed = DateTime.TryParse(parts[0], out DateTime date);
                if (parsed)
                {
                    timeNow = date;
                }
                List<int> distances = new List<int>();

                for (int i = 1; i <= 360; i++)
                {
                    int value = int.Parse(parts[i]);
                    distances.Add(value);
                }
                EnqueueFrame(distances, timeNow);
                redrawRequested = true;
                PreparingForDisplay();
            }
            catch (Exception ex)
            {
                Log("Ошибка обработки строки: " + ex.Message + ". Строка: \"" + line + "\"");
            }
        }

        // --------ОБЩИЕ ФУНКЦИИ-------


        private void EnqueueFrame(List<int> distances, DateTime timeNow)
        {
            lock(queueLock)
            {
                List<int> lst = new List<int>();
                foreach (int d in distances)
                {
                    lst.Add(d);
                }

                allFrames.Add(new KeyValuePair<List<int>, DateTime>(lst, timeNow));
                const int MAX_FRAMES = 10000; 
                if (allFrames.Count > MAX_FRAMES)
                {
                    allFrames.RemoveRange(0, allFrames.Count - MAX_FRAMES);
                }
            }
            Log("Фрейм добавлен. Всего: " + allFrames.Count);
        }

        private void PreparingForDisplay()
        {
            lock (queueLock)
            {
                if (allFrames.Count > 0)
                {
                    KeyValuePair<List<int>, DateTime> pair = allFrames[allFrames.Count - 1];
                    currentFrame = new List<int>(pair.Key); // копируем, чтобы не было гонок
                    currentTimeOfFrame = pair.Value;
                }
            }
            UpdateDisplay();

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

            //currentFrame.Clear();
            //ClearDisplay();
            Log("Все процессы остановлены.");

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

        private void Log(string serverMessage)
        {
            if (logger.InvokeRequired)
            {
                logger.Invoke(new Action< string>(Log), serverMessage); //создаем экземпляр делегата, который указывает на нашу функцию
            }
            else
            {
                logger.Items.Add($"{DateTime.Now:HH:mm:ss} - {serverMessage}");

                logger.SelectedIndex = logger.Items.Count - 1; // опускаемся к последнему сообщению
            }
        }

        private void UpdateDisplay()
        {
            if (checkBox_show.Checked != false)
            {
                lst_data.Items.Add("[" + currentTimeOfFrame.ToString("HH:mm:ss.fff") + "] ");
                const int VALUES_PER_LINE = 15;
                for (int start = 0; start < currentFrame.Count; start+=VALUES_PER_LINE)
                {
                    string line = "  ";
                    for (int i = start; i < start + VALUES_PER_LINE && i < currentFrame.Count; i++)
                    {
                        line += currentFrame[i].ToString().PadLeft(5); // выравнивание
                        if ((i - start + 1) % 5 == 0 && i < start + VALUES_PER_LINE - 1)
                            line += "  "; // дополнительный пробел каждые 5 значений
                    }
                    lst_data.Items.Add(line);
                }
                lst_data.Items.Add("");
                if (lst_data.Items.Count > 0)
                    lst_data.SelectedIndex = lst_data.Items.Count - 1;
            }
            DrawLidar();
        }

        private void DrawLidar()
        {
            if (currentFrame == null)
            {
                return;
            }
            if (currentFrame.Count == 0)
            {
                return;
            }
            const int WIDTH = 800;
            const int HEIGHT = 500;
            const double SCALE = 50.0; // пикселей на метр
            const int CENTER_X = 400;  
            const int CENTER_Y = 250;
            Bitmap bitmap = new Bitmap(WIDTH, HEIGHT); // ратровое изображение в памяти
            Graphics g = Graphics.FromImage(bitmap); // объект для рисования
            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                //границы
                Pen borderPen = new Pen(Color.LightBlue, 1);
                try
                {
                    borderPen.DashStyle = DashStyle.Dot;
                    g.DrawRectangle(borderPen, 0, 0, WIDTH, HEIGHT);
                }
                finally
                {
                    borderPen.Dispose();
                }
                const int R = 2;
                SolidBrush pointBrush = new SolidBrush(Color.Red);
                try
                {
                    for (int angle = 0; angle < currentFrame.Count && angle < 360; angle++)
                    {
                        int distMm = currentFrame[angle];
                        if (distMm <= 0 || distMm > 10000)
                        {
                            continue;
                        }

                        double distM = (double)distMm / 1000.0;
                        double rad = (double)angle * Math.PI / 180.0;

                        double x = distM * Math.Cos(rad);
                        double y = distM * Math.Sin(rad);

                        int px = (int)(CENTER_X + x * SCALE);
                        int py = (int)(CENTER_Y - y * SCALE); // Y вверх — минус

                        if (px >= -R && px < WIDTH + R && py >= -R && py < HEIGHT + R)
                        {
                            g.FillEllipse(pointBrush, px - R, py - R, 2 * R + 1, 2 * R + 1);
                        }
                    }
                }
                finally
                {
                    pointBrush.Dispose();
                }
            }
            finally
            {
                g.Dispose();
            }
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = bitmap;
        }

    }
}
