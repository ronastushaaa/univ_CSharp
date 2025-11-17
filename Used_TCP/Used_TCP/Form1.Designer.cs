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
            this.Server = new System.Windows.Forms.GroupBox();
            this.server_comand_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.server_info_lstbox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sever_pictureBox = new System.Windows.Forms.PictureBox();
            this.server_start_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.server_port_txt = new System.Windows.Forms.TextBox();
            this.Client = new System.Windows.Forms.GroupBox();
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
            this.Server.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sever_pictureBox)).BeginInit();
            this.Client.SuspendLayout();
            this.SuspendLayout();
            // 
            // Server
            // 
            this.Server.Controls.Add(this.server_comand_txt);
            this.Server.Controls.Add(this.label8);
            this.Server.Controls.Add(this.label7);
            this.Server.Controls.Add(this.server_info_lstbox);
            this.Server.Controls.Add(this.label4);
            this.Server.Controls.Add(this.sever_pictureBox);
            this.Server.Controls.Add(this.server_start_btn);
            this.Server.Controls.Add(this.label1);
            this.Server.Controls.Add(this.server_port_txt);
            this.Server.Location = new System.Drawing.Point(30, 25);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(456, 496);
            this.Server.TabIndex = 0;
            this.Server.TabStop = false;
            this.Server.Text = "Сервер";
            // 
            // server_comand_txt
            // 
            this.server_comand_txt.Location = new System.Drawing.Point(20, 442);
            this.server_comand_txt.Name = "server_comand_txt";
            this.server_comand_txt.ReadOnly = true;
            this.server_comand_txt.Size = new System.Drawing.Size(373, 22);
            this.server_comand_txt.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 413);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Команда от Клиента:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Информация:";
            // 
            // server_info_lstbox
            // 
            this.server_info_lstbox.FormattingEnabled = true;
            this.server_info_lstbox.ItemHeight = 16;
            this.server_info_lstbox.Location = new System.Drawing.Point(293, 131);
            this.server_info_lstbox.Name = "server_info_lstbox";
            this.server_info_lstbox.Size = new System.Drawing.Size(120, 260);
            this.server_info_lstbox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Холст:";
            // 
            // sever_pictureBox
            // 
            this.sever_pictureBox.Location = new System.Drawing.Point(17, 131);
            this.sever_pictureBox.Name = "sever_pictureBox";
            this.sever_pictureBox.Size = new System.Drawing.Size(248, 261);
            this.sever_pictureBox.TabIndex = 3;
            this.sever_pictureBox.TabStop = false;
            // 
            // server_start_btn
            // 
            this.server_start_btn.Location = new System.Drawing.Point(313, 62);
            this.server_start_btn.Name = "server_start_btn";
            this.server_start_btn.Size = new System.Drawing.Size(75, 23);
            this.server_start_btn.TabIndex = 2;
            this.server_start_btn.Text = "Слушать";
            this.server_start_btn.UseVisualStyleBackColor = true;
            this.server_start_btn.Click += new System.EventHandler(this.server_start_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Порт Сервера:";
            // 
            // server_port_txt
            // 
            this.server_port_txt.Location = new System.Drawing.Point(17, 63);
            this.server_port_txt.Name = "server_port_txt";
            this.server_port_txt.Size = new System.Drawing.Size(248, 22);
            this.server_port_txt.TabIndex = 0;
            // 
            // Client
            // 
            this.Client.Controls.Add(this.label6);
            this.Client.Controls.Add(this.client_chat_lstbox);
            this.Client.Controls.Add(this.client_send_btn);
            this.Client.Controls.Add(this.client_message_txt);
            this.Client.Controls.Add(this.label5);
            this.Client.Controls.Add(this.client_conect_btn);
            this.Client.Controls.Add(this.client_port_txt);
            this.Client.Controls.Add(this.label3);
            this.Client.Controls.Add(this.label2);
            this.Client.Controls.Add(this.client_ip_txt);
            this.Client.Location = new System.Drawing.Point(543, 25);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(463, 496);
            this.Client.TabIndex = 1;
            this.Client.TabStop = false;
            this.Client.Text = "Клиент";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Информация:";
            // 
            // client_chat_lstbox
            // 
            this.client_chat_lstbox.FormattingEnabled = true;
            this.client_chat_lstbox.ItemHeight = 16;
            this.client_chat_lstbox.Location = new System.Drawing.Point(35, 285);
            this.client_chat_lstbox.Name = "client_chat_lstbox";
            this.client_chat_lstbox.Size = new System.Drawing.Size(390, 132);
            this.client_chat_lstbox.TabIndex = 8;
            // 
            // client_send_btn
            // 
            this.client_send_btn.Location = new System.Drawing.Point(317, 202);
            this.client_send_btn.Name = "client_send_btn";
            this.client_send_btn.Size = new System.Drawing.Size(116, 31);
            this.client_send_btn.TabIndex = 7;
            this.client_send_btn.Text = "Отправить";
            this.client_send_btn.UseVisualStyleBackColor = true;
            // 
            // client_message_txt
            // 
            this.client_message_txt.Location = new System.Drawing.Point(26, 174);
            this.client_message_txt.Name = "client_message_txt";
            this.client_message_txt.Size = new System.Drawing.Size(407, 22);
            this.client_message_txt.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Поле для ввода сообщения:";
            // 
            // client_conect_btn
            // 
            this.client_conect_btn.Location = new System.Drawing.Point(302, 63);
            this.client_conect_btn.Name = "client_conect_btn";
            this.client_conect_btn.Size = new System.Drawing.Size(123, 41);
            this.client_conect_btn.TabIndex = 4;
            this.client_conect_btn.Text = "Подключиться";
            this.client_conect_btn.UseVisualStyleBackColor = true;
            this.client_conect_btn.Click += new System.EventHandler(this.client_conect_btn_Click);
            // 
            // client_port_txt
            // 
            this.client_port_txt.Location = new System.Drawing.Point(26, 106);
            this.client_port_txt.Name = "client_port_txt";
            this.client_port_txt.Size = new System.Drawing.Size(188, 22);
            this.client_port_txt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Порт Клиента:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP";
            // 
            // client_ip_txt
            // 
            this.client_ip_txt.Location = new System.Drawing.Point(26, 52);
            this.client_ip_txt.Name = "client_ip_txt";
            this.client_ip_txt.Size = new System.Drawing.Size(188, 22);
            this.client_ip_txt.TabIndex = 0;
            // 
            // Romanovskaia241_324_LAB3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 563);
            this.Controls.Add(this.Client);
            this.Controls.Add(this.Server);
            this.Name = "Romanovskaia241_324_LAB3";
            this.Text = " ";
            this.Server.ResumeLayout(false);
            this.Server.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sever_pictureBox)).EndInit();
            this.Client.ResumeLayout(false);
            this.Client.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Server;
        private System.Windows.Forms.TextBox server_port_txt;
        private System.Windows.Forms.GroupBox Client;
        private System.Windows.Forms.Button server_start_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button client_conect_btn;
        private System.Windows.Forms.TextBox client_port_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox client_ip_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox sever_pictureBox;
        private System.Windows.Forms.TextBox client_message_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox client_chat_lstbox;
        private System.Windows.Forms.Button client_send_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox server_info_lstbox;
        private System.Windows.Forms.TextBox server_comand_txt;
        private System.Windows.Forms.Label label8;
    }
}

