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
            this.button3 = new System.Windows.Forms.Button();
            this.cbx_choose_mode = new System.Windows.Forms.ComboBox();
            this.txt_freq = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_show = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_selectFile = new System.Windows.Forms.Button();
            this.txt_name_file = new System.Windows.Forms.TextBox();
            this.fileTimer = new System.Windows.Forms.Timer(this.components);
            this.drawingTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(644, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(616, 604);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lst_data
            // 
            this.lst_data.FormattingEnabled = true;
            this.lst_data.ItemHeight = 16;
            this.lst_data.Location = new System.Drawing.Point(31, 44);
            this.lst_data.Name = "lst_data";
            this.lst_data.Size = new System.Drawing.Size(197, 340);
            this.lst_data.TabIndex = 1;
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(255, 44);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(106, 42);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(520, 44);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(109, 45);
            this.stop_btn.TabIndex = 3;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(387, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 45);
            this.button3.TabIndex = 4;
            this.button3.Text = "Pause";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cbx_choose_mode
            // 
            this.cbx_choose_mode.FormattingEnabled = true;
            this.cbx_choose_mode.Items.AddRange(new object[] {
            "считывание из файла",
            "считывание из сети по UDP"});
            this.cbx_choose_mode.Location = new System.Drawing.Point(27, 47);
            this.cbx_choose_mode.Name = "cbx_choose_mode";
            this.cbx_choose_mode.Size = new System.Drawing.Size(273, 24);
            this.cbx_choose_mode.TabIndex = 5;
            // 
            // txt_freq
            // 
            this.txt_freq.Location = new System.Drawing.Point(27, 109);
            this.txt_freq.Name = "txt_freq";
            this.txt_freq.Size = new System.Drawing.Size(145, 22);
            this.txt_freq.TabIndex = 6;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(27, 165);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(97, 22);
            this.txt_port.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Порт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Частота записи:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Режим чтения:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_show);
            this.groupBox1.Controls.Add(this.cbx_choose_mode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_freq);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(264, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 230);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные для отображения";
            // 
            // checkBox_show
            // 
            this.checkBox_show.AutoSize = true;
            this.checkBox_show.Location = new System.Drawing.Point(27, 204);
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
            this.groupBox2.Location = new System.Drawing.Point(31, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 125);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбор файла";
            // 
            // btn_selectFile
            // 
            this.btn_selectFile.Location = new System.Drawing.Point(412, 60);
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
            this.txt_name_file.Size = new System.Drawing.Size(514, 22);
            this.txt_name_file.TabIndex = 0;
            // 
            // fileTimer
            // 
            this.fileTimer.Tick += new System.EventHandler(this.fileTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 658);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.lst_data);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lst_data;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbx_choose_mode;
        private System.Windows.Forms.TextBox txt_freq;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_show;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_selectFile;
        private System.Windows.Forms.TextBox txt_name_file;
        private System.Windows.Forms.Timer fileTimer;
        private System.Windows.Forms.Timer drawingTimer;
    }
}

