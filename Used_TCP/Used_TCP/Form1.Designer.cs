namespace Used_TCP
{
    partial class Romanovskaia241_324_LAB3
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
            this.TCP_connect = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.draw_btn = new System.Windows.Forms.Button();
            this.clientChoose = new System.Windows.Forms.ComboBox();
            this.server_comand_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.server_info_lstbox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sever_pictureBox = new System.Windows.Forms.PictureBox();
            this.server_start_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.server_port_txt = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.client_chat_lstbox = new System.Windows.Forms.ListBox();
            this.client_send_btn = new System.Windows.Forms.Button();
            this.client_message_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.client_conect_btn = new System.Windows.Forms.Button();
            this.client_port_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.client_ip_txt = new System.Windows.Forms.TextBox();
            this.TCP_connect.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sever_pictureBox)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCP_connect
            // 
            this.TCP_connect.Controls.Add(this.tabPage1);
            this.TCP_connect.Controls.Add(this.tabPage2);
            this.TCP_connect.Location = new System.Drawing.Point(24, 12);
            this.TCP_connect.Name = "TCP_connect";
            this.TCP_connect.SelectedIndex = 0;
            this.TCP_connect.Size = new System.Drawing.Size(941, 505);
            this.TCP_connect.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.draw_btn);
            this.tabPage1.Controls.Add(this.clientChoose);
            this.tabPage1.Controls.Add(this.server_comand_txt);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.server_info_lstbox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.sever_pictureBox);
            this.tabPage1.Controls.Add(this.server_start_btn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.server_port_txt);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(933, 476);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сервер";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // draw_btn
            // 
            this.draw_btn.Location = new System.Drawing.Point(806, 420);
            this.draw_btn.Name = "draw_btn";
            this.draw_btn.Size = new System.Drawing.Size(106, 31);
            this.draw_btn.TabIndex = 19;
            this.draw_btn.Text = "Нарисовать";
            this.draw_btn.UseVisualStyleBackColor = true;
            this.draw_btn.Click += new System.EventHandler(this.draw_btn_Click);
            // 
            // clientChoose
            // 
            this.clientChoose.FormattingEnabled = true;
            this.clientChoose.Items.AddRange(new object[] {
            "client",
            "Telnet-client"});
            this.clientChoose.Location = new System.Drawing.Point(309, 34);
            this.clientChoose.Name = "clientChoose";
            this.clientChoose.Size = new System.Drawing.Size(121, 24);
            this.clientChoose.TabIndex = 18;
            this.clientChoose.SelectedIndexChanged += new System.EventHandler(this.clientChoose_SelectedIndexChanged);
            // 
            // server_comand_txt
            // 
            this.server_comand_txt.Location = new System.Drawing.Point(479, 424);
            this.server_comand_txt.Name = "server_comand_txt";
            this.server_comand_txt.Size = new System.Drawing.Size(310, 22);
            this.server_comand_txt.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(476, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Команда от Клиента:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Информация:";
            // 
            // server_info_lstbox
            // 
            this.server_info_lstbox.FormattingEnabled = true;
            this.server_info_lstbox.ItemHeight = 16;
            this.server_info_lstbox.Location = new System.Drawing.Point(40, 276);
            this.server_info_lstbox.Name = "server_info_lstbox";
            this.server_info_lstbox.Size = new System.Drawing.Size(858, 116);
            this.server_info_lstbox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Холст:";
            // 
            // sever_pictureBox
            // 
            this.sever_pictureBox.Location = new System.Drawing.Point(474, 34);
            this.sever_pictureBox.Name = "sever_pictureBox";
            this.sever_pictureBox.Size = new System.Drawing.Size(424, 236);
            this.sever_pictureBox.TabIndex = 12;
            this.sever_pictureBox.TabStop = false;
            // 
            // server_start_btn
            // 
            this.server_start_btn.Location = new System.Drawing.Point(146, 32);
            this.server_start_btn.Name = "server_start_btn";
            this.server_start_btn.Size = new System.Drawing.Size(137, 23);
            this.server_start_btn.TabIndex = 11;
            this.server_start_btn.Text = "Слушать";
            this.server_start_btn.UseVisualStyleBackColor = true;
            this.server_start_btn.Click += new System.EventHandler(this.server_start_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Порт:";
            // 
            // server_port_txt
            // 
            this.server_port_txt.Location = new System.Drawing.Point(48, 32);
            this.server_port_txt.Name = "server_port_txt";
            this.server_port_txt.Size = new System.Drawing.Size(92, 22);
            this.server_port_txt.TabIndex = 9;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(106, 32);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(8, 20);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(0, 0);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(0, 0);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.client_chat_lstbox);
            this.tabPage2.Controls.Add(this.client_send_btn);
            this.tabPage2.Controls.Add(this.client_message_txt);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.client_conect_btn);
            this.tabPage2.Controls.Add(this.client_port_txt);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.client_ip_txt);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(933, 476);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Клиент";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Информация:";
            // 
            // client_chat_lstbox
            // 
            this.client_chat_lstbox.FormattingEnabled = true;
            this.client_chat_lstbox.ItemHeight = 16;
            this.client_chat_lstbox.Location = new System.Drawing.Point(56, 300);
            this.client_chat_lstbox.Name = "client_chat_lstbox";
            this.client_chat_lstbox.Size = new System.Drawing.Size(390, 132);
            this.client_chat_lstbox.TabIndex = 18;
            // 
            // client_send_btn
            // 
            this.client_send_btn.Location = new System.Drawing.Point(347, 205);
            this.client_send_btn.Name = "client_send_btn";
            this.client_send_btn.Size = new System.Drawing.Size(116, 31);
            this.client_send_btn.TabIndex = 17;
            this.client_send_btn.Text = "Отправить";
            this.client_send_btn.UseVisualStyleBackColor = true;
            this.client_send_btn.Click += new System.EventHandler(this.client_send_btn_Click);
            // 
            // client_message_txt
            // 
            this.client_message_txt.Location = new System.Drawing.Point(56, 177);
            this.client_message_txt.Name = "client_message_txt";
            this.client_message_txt.Size = new System.Drawing.Size(407, 22);
            this.client_message_txt.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Поле для ввода сообщения:";
            // 
            // client_conect_btn
            // 
            this.client_conect_btn.Location = new System.Drawing.Point(307, 53);
            this.client_conect_btn.Name = "client_conect_btn";
            this.client_conect_btn.Size = new System.Drawing.Size(123, 26);
            this.client_conect_btn.TabIndex = 14;
            this.client_conect_btn.Text = "Подключиться";
            this.client_conect_btn.UseVisualStyleBackColor = true;
            this.client_conect_btn.Click += new System.EventHandler(this.client_conect_btn_Click);
            // 
            // client_port_txt
            // 
            this.client_port_txt.Location = new System.Drawing.Point(246, 55);
            this.client_port_txt.Name = "client_port_txt";
            this.client_port_txt.Size = new System.Drawing.Size(55, 22);
            this.client_port_txt.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Порт Клиента:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP";
            // 
            // client_ip_txt
            // 
            this.client_ip_txt.Location = new System.Drawing.Point(56, 55);
            this.client_ip_txt.Name = "client_ip_txt";
            this.client_ip_txt.Size = new System.Drawing.Size(184, 22);
            this.client_ip_txt.TabIndex = 10;
            // 
            // Romanovskaia241_324_LAB3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 563);
            this.Controls.Add(this.TCP_connect);
            this.Name = "Romanovskaia241_324_LAB3";
            this.Text = " ";
            this.TCP_connect.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sever_pictureBox)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TCP_connect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox server_comand_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox server_info_lstbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox sever_pictureBox;
        private System.Windows.Forms.Button server_start_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox server_port_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox client_chat_lstbox;
        private System.Windows.Forms.Button client_send_btn;
        private System.Windows.Forms.TextBox client_message_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button client_conect_btn;
        private System.Windows.Forms.TextBox client_port_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox client_ip_txt;
        private System.Windows.Forms.ComboBox clientChoose;
        private System.Windows.Forms.Button draw_btn;
    }
}

