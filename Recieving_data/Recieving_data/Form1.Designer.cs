namespace Recieving_data
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lst_data = new System.Windows.Forms.ListBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.pause_btn = new System.Windows.Forms.Button();
            this.cbx_choose_mode = new System.Windows.Forms.ComboBox();
            this.txt_freq = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_show = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_selectFile = new System.Windows.Forms.Button();
            this.txt_name_file = new System.Windows.Forms.TextBox();
            this.fileTimer = new System.Windows.Forms.Timer(this.components);
            this.drawingTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.logger = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(641, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 501);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lst_data
            // 
            this.lst_data.FormattingEnabled = true;
            this.lst_data.ItemHeight = 16;
            this.lst_data.Location = new System.Drawing.Point(12, 41);
            this.lst_data.Name = "lst_data";
            this.lst_data.Size = new System.Drawing.Size(623, 324);
            this.lst_data.TabIndex = 1;
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(509, 491);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(106, 42);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(509, 539);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(106, 42);
            this.stop_btn.TabIndex = 3;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // pause_btn
            // 
            this.pause_btn.Location = new System.Drawing.Point(382, 421);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(106, 45);
            this.pause_btn.TabIndex = 4;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = true;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // cbx_choose_mode
            // 
            this.cbx_choose_mode.FormattingEnabled = true;
            this.cbx_choose_mode.Items.AddRange(new object[] {
            "считывание из файла",
            "считывание из сети по UDP"});
            this.cbx_choose_mode.Location = new System.Drawing.Point(43, 412);
            this.cbx_choose_mode.Name = "cbx_choose_mode";
            this.cbx_choose_mode.Size = new System.Drawing.Size(273, 24);
            this.cbx_choose_mode.TabIndex = 5;
            // 
            // txt_freq
            // 
            this.txt_freq.Location = new System.Drawing.Point(19, 97);
            this.txt_freq.Name = "txt_freq";
            this.txt_freq.Size = new System.Drawing.Size(145, 22);
            this.txt_freq.TabIndex = 6;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(16, 51);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(97, 22);
            this.txt_port.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Порт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Интервал чтения (мс):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Режим чтения:";
            // 
            // checkBox_show
            // 
            this.checkBox_show.AutoSize = true;
            this.checkBox_show.Location = new System.Drawing.Point(382, 383);
            this.checkBox_show.Name = "checkBox_show";
            this.checkBox_show.Size = new System.Drawing.Size(220, 20);
            this.checkBox_show.TabIndex = 11;
            this.checkBox_show.Text = "Показывать данные таблицы";
            this.checkBox_show.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Таблица данных:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(644, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Представление данных:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_selectFile);
            this.groupBox2.Controls.Add(this.txt_name_file);
            this.groupBox2.Controls.Add(this.txt_freq);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(24, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 139);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с файлом";
            // 
            // btn_selectFile
            // 
            this.btn_selectFile.Location = new System.Drawing.Point(192, 90);
            this.btn_selectFile.Name = "btn_selectFile";
            this.btn_selectFile.Size = new System.Drawing.Size(112, 37);
            this.btn_selectFile.TabIndex = 1;
            this.btn_selectFile.Text = "Select File";
            this.btn_selectFile.UseVisualStyleBackColor = true;
            // 
            // txt_name_file
            // 
            this.txt_name_file.Location = new System.Drawing.Point(19, 32);
            this.txt_name_file.Name = "txt_name_file";
            this.txt_name_file.Size = new System.Drawing.Size(285, 22);
            this.txt_name_file.TabIndex = 0;
            // 
            // fileTimer
            // 
            this.fileTimer.Tick += new System.EventHandler(this.fileTimer_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_port);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(358, 485);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 96);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Работа с UDP";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(268, 1061);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(569, 116);
            this.listBox1.TabIndex = 16;
            // 
            // logger
            // 
            this.logger.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.logger.FormattingEnabled = true;
            this.logger.ItemHeight = 16;
            this.logger.Location = new System.Drawing.Point(24, 602);
            this.logger.Name = "logger";
            this.logger.Size = new System.Drawing.Size(1438, 244);
            this.logger.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 583);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Служебная информация:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 849);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.logger);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx_choose_mode);
            this.Controls.Add(this.checkBox_show);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.lst_data);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lst_data;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button pause_btn;
        private System.Windows.Forms.ComboBox cbx_choose_mode;
        private System.Windows.Forms.TextBox txt_freq;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_show;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_selectFile;
        private System.Windows.Forms.TextBox txt_name_file;
        private System.Windows.Forms.Timer fileTimer;
        private System.Windows.Forms.Timer drawingTimer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox logger;
        private System.Windows.Forms.Label label6;
    }
}

