namespace Used_UDP
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
            this.text_SendMsg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Send = new System.Windows.Forms.Button();
            this.text_info = new System.Windows.Forms.TextBox();
            this.Server = new System.Windows.Forms.GroupBox();
            this.btn_listen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label_recieve_msg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_listen_port = new System.Windows.Forms.TextBox();
            this.Client = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_SendName = new System.Windows.Forms.TextBox();
            this.text_SendPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_SendIP = new System.Windows.Forms.TextBox();
            this.Server.SuspendLayout();
            this.Client.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_SendMsg
            // 
            this.text_SendMsg.Location = new System.Drawing.Point(9, 139);
            this.text_SendMsg.Name = "text_SendMsg";
            this.text_SendMsg.Size = new System.Drawing.Size(189, 22);
            this.text_SendMsg.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "User message";
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(290, 139);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(97, 45);
            this.btn_Send.TabIndex = 8;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_send__Click);
            // 
            // text_info
            // 
            this.text_info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.text_info.Location = new System.Drawing.Point(0, 494);
            this.text_info.Multiline = true;
            this.text_info.Name = "text_info";
            this.text_info.ReadOnly = true;
            this.text_info.Size = new System.Drawing.Size(427, 30);
            this.text_info.TabIndex = 9;
            // 
            // Server
            // 
            this.Server.Controls.Add(this.btn_listen);
            this.Server.Controls.Add(this.label6);
            this.Server.Controls.Add(this.label_recieve_msg);
            this.Server.Controls.Add(this.label3);
            this.Server.Controls.Add(this.text_listen_port);
            this.Server.Location = new System.Drawing.Point(12, 12);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(405, 167);
            this.Server.TabIndex = 16;
            this.Server.TabStop = false;
            this.Server.Text = "Server";
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(293, 97);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(97, 45);
            this.btn_listen.TabIndex = 3;
            this.btn_listen.Text = "Listen";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Recieve message";
            // 
            // label_recieve_msg
            // 
            this.label_recieve_msg.Location = new System.Drawing.Point(23, 97);
            this.label_recieve_msg.Multiline = true;
            this.label_recieve_msg.Name = "label_recieve_msg";
            this.label_recieve_msg.ReadOnly = true;
            this.label_recieve_msg.Size = new System.Drawing.Size(261, 45);
            this.label_recieve_msg.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Listen Port";
            // 
            // text_listen_port
            // 
            this.text_listen_port.Location = new System.Drawing.Point(23, 46);
            this.text_listen_port.Name = "text_listen_port";
            this.text_listen_port.ReadOnly = true;
            this.text_listen_port.Size = new System.Drawing.Size(100, 22);
            this.text_listen_port.TabIndex = 1;
            // 
            // Client
            // 
            this.Client.Controls.Add(this.label4);
            this.Client.Controls.Add(this.text_SendName);
            this.Client.Controls.Add(this.text_SendPort);
            this.Client.Controls.Add(this.label2);
            this.Client.Controls.Add(this.btn_Send);
            this.Client.Controls.Add(this.label1);
            this.Client.Controls.Add(this.label5);
            this.Client.Controls.Add(this.text_SendMsg);
            this.Client.Controls.Add(this.text_SendIP);
            this.Client.Location = new System.Drawing.Point(12, 195);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(405, 215);
            this.Client.TabIndex = 17;
            this.Client.TabStop = false;
            this.Client.Text = "Client";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name Client";
            // 
            // text_SendName
            // 
            this.text_SendName.Location = new System.Drawing.Point(9, 95);
            this.text_SendName.Name = "text_SendName";
            this.text_SendName.Size = new System.Drawing.Size(189, 22);
            this.text_SendName.TabIndex = 6;
            // 
            // text_SendPort
            // 
            this.text_SendPort.Location = new System.Drawing.Point(204, 51);
            this.text_SendPort.Name = "text_SendPort";
            this.text_SendPort.Size = new System.Drawing.Size(100, 22);
            this.text_SendPort.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Adress";
            // 
            // text_SendIP
            // 
            this.text_SendIP.Location = new System.Drawing.Point(9, 51);
            this.text_SendIP.Name = "text_SendIP";
            this.text_SendIP.Size = new System.Drawing.Size(189, 22);
            this.text_SendIP.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 524);
            this.Controls.Add(this.Client);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.text_info);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Server.ResumeLayout(false);
            this.Server.PerformLayout();
            this.Client.ResumeLayout(false);
            this.Client.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox text_SendMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox text_info;
        private System.Windows.Forms.GroupBox Server;
        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox label_recieve_msg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_listen_port;
        private System.Windows.Forms.GroupBox Client;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_SendName;
        private System.Windows.Forms.TextBox text_SendPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_SendIP;
    }
}

