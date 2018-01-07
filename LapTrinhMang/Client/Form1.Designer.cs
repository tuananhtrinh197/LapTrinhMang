namespace Client
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.rtbMain = new System.Windows.Forms.TextBox();
            this.rtbTextChat = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbFont = new System.Windows.Forms.LinkLabel();
            this.lbColor = new System.Windows.Forms.LinkLabel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Server";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(103, 12);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(219, 20);
            this.txtIPServer.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(351, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rtbMain
            // 
            this.rtbMain.Location = new System.Drawing.Point(34, 58);
            this.rtbMain.Multiline = true;
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(288, 147);
            this.rtbMain.TabIndex = 3;
            // 
            // rtbTextChat
            // 
            this.rtbTextChat.Location = new System.Drawing.Point(32, 243);
            this.rtbTextChat.Multiline = true;
            this.rtbTextChat.Name = "rtbTextChat";
            this.rtbTextChat.Size = new System.Drawing.Size(290, 37);
            this.rtbTextChat.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(351, 243);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 37);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbFont
            // 
            this.lbFont.AutoSize = true;
            this.lbFont.Location = new System.Drawing.Point(31, 217);
            this.lbFont.Name = "lbFont";
            this.lbFont.Size = new System.Drawing.Size(28, 13);
            this.lbFont.TabIndex = 8;
            this.lbFont.TabStop = true;
            this.lbFont.Text = "Font";
            this.lbFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbFont_LinkClicked);
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(74, 217);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 9;
            this.lbColor.TabStop = true;
            this.lbColor.Text = "Color";
            this.lbColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbColor_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 292);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.lbFont);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbTextChat);
            this.Controls.Add(this.rtbMain);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIPServer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox rtbMain;
        private System.Windows.Forms.TextBox rtbTextChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.LinkLabel lbFont;
        private System.Windows.Forms.LinkLabel lbColor;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

