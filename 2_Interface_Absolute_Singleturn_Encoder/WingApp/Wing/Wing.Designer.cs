namespace Wing
{
    partial class Wing
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.connectBT = new System.Windows.Forms.Button();
            this.disconnectBT = new System.Windows.Forms.Button();
            this.clearBT = new System.Windows.Forms.Button();
            this.scanBT = new System.Windows.Forms.Button();
            this.PortCB = new System.Windows.Forms.ComboBox();
            this.Baudrate = new System.Windows.Forms.ComboBox();
            this.incomingTB = new System.Windows.Forms.RichTextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tboxOperator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbArticle = new System.Windows.Forms.TextBox();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectBT
            // 
            this.connectBT.Location = new System.Drawing.Point(314, 240);
            this.connectBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectBT.Name = "connectBT";
            this.connectBT.Size = new System.Drawing.Size(86, 32);
            this.connectBT.TabIndex = 0;
            this.connectBT.Text = "START";
            this.connectBT.UseVisualStyleBackColor = true;
            this.connectBT.Click += new System.EventHandler(this.connectBT_Click);
            // 
            // disconnectBT
            // 
            this.disconnectBT.Enabled = false;
            this.disconnectBT.Location = new System.Drawing.Point(428, 240);
            this.disconnectBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.disconnectBT.Name = "disconnectBT";
            this.disconnectBT.Size = new System.Drawing.Size(86, 32);
            this.disconnectBT.TabIndex = 1;
            this.disconnectBT.Text = "STOP";
            this.disconnectBT.UseVisualStyleBackColor = true;
            this.disconnectBT.Click += new System.EventHandler(this.disconnectBT_Click);
            // 
            // clearBT
            // 
            this.clearBT.Location = new System.Drawing.Point(552, 240);
            this.clearBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearBT.Name = "clearBT";
            this.clearBT.Size = new System.Drawing.Size(86, 34);
            this.clearBT.TabIndex = 2;
            this.clearBT.Text = "CLEAR";
            this.clearBT.UseVisualStyleBackColor = true;
            this.clearBT.Click += new System.EventHandler(this.clearBT_Click);
            // 
            // scanBT
            // 
            this.scanBT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.scanBT.Location = new System.Drawing.Point(670, 240);
            this.scanBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scanBT.Name = "scanBT";
            this.scanBT.Size = new System.Drawing.Size(86, 32);
            this.scanBT.TabIndex = 3;
            this.scanBT.Text = "REFRESH";
            this.scanBT.UseVisualStyleBackColor = true;
            this.scanBT.Click += new System.EventHandler(this.scanBT_Click);
            // 
            // PortCB
            // 
            this.PortCB.FormattingEnabled = true;
            this.PortCB.Location = new System.Drawing.Point(58, 247);
            this.PortCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PortCB.Name = "PortCB";
            this.PortCB.Size = new System.Drawing.Size(75, 21);
            this.PortCB.TabIndex = 5;
            // 
            // Baudrate
            // 
            this.Baudrate.FormattingEnabled = true;
            this.Baudrate.Items.AddRange(new object[] {
            "19200 ",
            "9600",
            "115200"});
            this.Baudrate.Location = new System.Drawing.Point(183, 247);
            this.Baudrate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Baudrate.Name = "Baudrate";
            this.Baudrate.Size = new System.Drawing.Size(77, 21);
            this.Baudrate.TabIndex = 6;
            // 
            // incomingTB
            // 
            this.incomingTB.Location = new System.Drawing.Point(49, 291);
            this.incomingTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.incomingTB.Name = "incomingTB";
            this.incomingTB.Size = new System.Drawing.Size(662, 127);
            this.incomingTB.TabIndex = 7;
            this.incomingTB.Text = "";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // tboxOperator
            // 
            this.tboxOperator.Location = new System.Drawing.Point(182, 89);
            this.tboxOperator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tboxOperator.Name = "tboxOperator";
            this.tboxOperator.Size = new System.Drawing.Size(358, 20);
            this.tboxOperator.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(56, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "OPERATOR NAME :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(57, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "ARTICLE NO             :";
            // 
            // tbArcticle
            // 
            this.tbArticle.Location = new System.Drawing.Point(182, 126);
            this.tbArticle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbArticle.Name = "tbArticle";
            this.tbArticle.Size = new System.Drawing.Size(358, 20);
            this.tbArticle.TabIndex = 11;
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(183, 165);
            this.tbFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(358, 20);
            this.tbFolder.TabIndex = 13;
            this.tbFolder.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(299, 15);
            this.Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(168, 28);
            this.Title.TabIndex = 14;
            this.Title.Text = "WING AND FIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(56, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2);
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "FOLDER                    :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(56, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2);
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "FILENAME             :";
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(182, 201);
            this.tbFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(358, 20);
            this.tbFile.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(297, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label5.Size = new System.Drawing.Size(174, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = " Unfolding Time Measurement";
            // 
            // btnOpen
            // 
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOpen.Location = new System.Drawing.Point(555, 164);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(32, 20);
            this.btnOpen.TabIndex = 19;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // Wing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(802, 493);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.tbArticle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxOperator);
            this.Controls.Add(this.incomingTB);
            this.Controls.Add(this.Baudrate);
            this.Controls.Add(this.PortCB);
            this.Controls.Add(this.scanBT);
            this.Controls.Add(this.clearBT);
            this.Controls.Add(this.disconnectBT);
            this.Controls.Add(this.connectBT);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Wing";
            this.Text = "Wing";
            this.Load += new System.EventHandler(this.Wing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectBT;
        private System.Windows.Forms.Button disconnectBT;
        private System.Windows.Forms.Button clearBT;
        private System.Windows.Forms.Button scanBT;
        private System.Windows.Forms.ComboBox PortCB;
        private System.Windows.Forms.ComboBox Baudrate;
        private System.Windows.Forms.RichTextBox incomingTB;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox tboxOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbArticle;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpen;
    }
}

