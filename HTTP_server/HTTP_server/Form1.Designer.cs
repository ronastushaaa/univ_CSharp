namespace HTTP_server
{
    partial class Romanovskaia241_324_LAB4_SERVER
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
            this.server_port_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.server_start_btn = new System.Windows.Forms.Button();
            this.server_output_a = new System.Windows.Forms.TextBox();
            this.server_output_b = new System.Windows.Forms.TextBox();
            this.server_output_c = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.server_input_f = new System.Windows.Forms.TextBox();
            this.server_input_e = new System.Windows.Forms.TextBox();
            this.server_input_d = new System.Windows.Forms.TextBox();
            this.server_info_lstbox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // server_port_txt
            // 
            this.server_port_txt.Location = new System.Drawing.Point(95, 22);
            this.server_port_txt.Name = "server_port_txt";
            this.server_port_txt.Size = new System.Drawing.Size(100, 22);
            this.server_port_txt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Порт:";
            // 
            // server_start_btn
            // 
            this.server_start_btn.Location = new System.Drawing.Point(266, 17);
            this.server_start_btn.Name = "server_start_btn";
            this.server_start_btn.Size = new System.Drawing.Size(163, 32);
            this.server_start_btn.TabIndex = 3;
            this.server_start_btn.Text = "Запустить";
            this.server_start_btn.UseVisualStyleBackColor = true;
            this.server_start_btn.Click += new System.EventHandler(this.server_start_btn_Click);
            // 
            // server_output_a
            // 
            this.server_output_a.Location = new System.Drawing.Point(56, 48);
            this.server_output_a.Name = "server_output_a";
            this.server_output_a.Size = new System.Drawing.Size(330, 22);
            this.server_output_a.TabIndex = 4;
            // 
            // server_output_b
            // 
            this.server_output_b.Location = new System.Drawing.Point(56, 76);
            this.server_output_b.Name = "server_output_b";
            this.server_output_b.Size = new System.Drawing.Size(330, 22);
            this.server_output_b.TabIndex = 5;
            // 
            // server_output_c
            // 
            this.server_output_c.Location = new System.Drawing.Point(56, 104);
            this.server_output_c.Name = "server_output_c";
            this.server_output_c.Size = new System.Drawing.Size(330, 22);
            this.server_output_c.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.server_output_a);
            this.groupBox1.Controls.Add(this.server_output_c);
            this.groupBox1.Controls.Add(this.server_output_b);
            this.groupBox1.Location = new System.Drawing.Point(33, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 149);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Полученные данные:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "C:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "A:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.server_input_f);
            this.groupBox2.Controls.Add(this.server_input_e);
            this.groupBox2.Controls.Add(this.server_input_d);
            this.groupBox2.Location = new System.Drawing.Point(33, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 143);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные для отправки:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "F:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "E:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "D:";
            // 
            // server_input_f
            // 
            this.server_input_f.Location = new System.Drawing.Point(56, 99);
            this.server_input_f.Name = "server_input_f";
            this.server_input_f.Size = new System.Drawing.Size(330, 22);
            this.server_input_f.TabIndex = 12;
            // 
            // server_input_e
            // 
            this.server_input_e.Location = new System.Drawing.Point(56, 71);
            this.server_input_e.Name = "server_input_e";
            this.server_input_e.Size = new System.Drawing.Size(330, 22);
            this.server_input_e.TabIndex = 11;
            // 
            // server_input_d
            // 
            this.server_input_d.Location = new System.Drawing.Point(56, 43);
            this.server_input_d.Name = "server_input_d";
            this.server_input_d.Size = new System.Drawing.Size(330, 22);
            this.server_input_d.TabIndex = 10;
            // 
            // server_info_lstbox
            // 
            this.server_info_lstbox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.server_info_lstbox.FormattingEnabled = true;
            this.server_info_lstbox.ItemHeight = 16;
            this.server_info_lstbox.Location = new System.Drawing.Point(0, 417);
            this.server_info_lstbox.Name = "server_info_lstbox";
            this.server_info_lstbox.Size = new System.Drawing.Size(501, 180);
            this.server_info_lstbox.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Системные сообщения:";
            // 
            // Romanovskaia241_324_LAB4_SERVER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 597);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.server_info_lstbox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.server_start_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.server_port_txt);
            this.Name = "Romanovskaia241_324_LAB4_SERVER";
            this.Text = "Сервер";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox server_port_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button server_start_btn;
        private System.Windows.Forms.TextBox server_output_a;
        private System.Windows.Forms.TextBox server_output_b;
        private System.Windows.Forms.TextBox server_output_c;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox server_input_f;
        private System.Windows.Forms.TextBox server_input_e;
        private System.Windows.Forms.TextBox server_input_d;
        private System.Windows.Forms.ListBox server_info_lstbox;
        private System.Windows.Forms.Label label9;
    }
}

