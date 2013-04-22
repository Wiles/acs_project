namespace Blowfish
{
    partial class BlowChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_server = new System.Windows.Forms.Button();
            this.btn_client = new System.Windows.Forms.Button();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.tb_messages = new System.Windows.Forms.TextBox();
            this.tb_console = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_key);
            this.groupBox1.Controls.Add(this.tb_name);
            this.groupBox1.Controls.Add(this.tb_port);
            this.groupBox1.Controls.Add(this.tb_ip);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_server);
            this.groupBox1.Controls.Add(this.btn_client);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure";
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(192, 40);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(100, 20);
            this.tb_key.TabIndex = 9;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(192, 17);
            this.tb_name.MaxLength = 16;
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(100, 20);
            this.tb_name.TabIndex = 8;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(42, 41);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 20);
            this.tb_port.TabIndex = 7;
            this.tb_port.Text = "8888";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(42, 17);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 20);
            this.tb_ip.TabIndex = 6;
            this.tb_ip.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Key:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ip:";
            // 
            // btn_server
            // 
            this.btn_server.Location = new System.Drawing.Point(89, 70);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(75, 23);
            this.btn_server.TabIndex = 1;
            this.btn_server.Text = "Server";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // btn_client
            // 
            this.btn_client.Location = new System.Drawing.Point(7, 71);
            this.btn_client.Name = "btn_client";
            this.btn_client.Size = new System.Drawing.Size(75, 23);
            this.btn_client.TabIndex = 0;
            this.btn_client.Text = "Client";
            this.btn_client.UseVisualStyleBackColor = true;
            this.btn_client.Click += new System.EventHandler(this.btn_client_Click);
            // 
            // tb_message
            // 
            this.tb_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_message.Location = new System.Drawing.Point(13, 558);
            this.tb_message.MaxLength = 140;
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(582, 20);
            this.tb_message.TabIndex = 1;
            this.tb_message.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_message_KeyPress);
            // 
            // tb_messages
            // 
            this.tb_messages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_messages.Location = new System.Drawing.Point(230, 120);
            this.tb_messages.Multiline = true;
            this.tb_messages.Name = "tb_messages";
            this.tb_messages.Size = new System.Drawing.Size(365, 432);
            this.tb_messages.TabIndex = 3;
            // 
            // tb_console
            // 
            this.tb_console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_console.Location = new System.Drawing.Point(13, 120);
            this.tb_console.Multiline = true;
            this.tb_console.Name = "tb_console";
            this.tb_console.Size = new System.Drawing.Size(211, 432);
            this.tb_console.TabIndex = 4;
            // 
            // BlowChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 590);
            this.Controls.Add(this.tb_console);
            this.Controls.Add(this.tb_messages);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.groupBox1);
            this.Name = "BlowChat";
            this.Text = "BlowChat";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_server;
        private System.Windows.Forms.Button btn_client;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.TextBox tb_messages;
        private System.Windows.Forms.TextBox tb_console;
    }
}

