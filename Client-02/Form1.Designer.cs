namespace Client_02
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label4 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new System.Windows.Forms.Label();
            this.txtKey02 = new System.Windows.Forms.TextBox();
            this.txtKey01 = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSendNoise = new System.Windows.Forms.Button();
            this.richMessage = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Perpetua Titling MT", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 32);
            this.label4.TabIndex = 22;
            this.label4.Text = "CLIENT-02";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(382, 72);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(135, 48);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(139, 221);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(216, 20);
            this.txtKey.TabIndex = 20;
            // 
            // txtEncrypted
            // 
            this.txtEncrypted.Location = new System.Drawing.Point(139, 153);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Name = "txtEncrypted";
            this.txtEncrypted.ReadOnly = true;
            this.txtEncrypted.Size = new System.Drawing.Size(216, 40);
            this.txtEncrypted.TabIndex = 19;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(139, 84);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(216, 36);
            this.txtText.TabIndex = 18;
            this.txtText.Text = "Exchange Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Encrypted";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Text";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(250, 265);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(44, 18);
            this.lbTime.TabIndex = 24;
            this.lbTime.Text = "Time";
            this.lbTime.Visible = false;
            // 
            // txtKey02
            // 
            this.txtKey02.Location = new System.Drawing.Point(40, 520);
            this.txtKey02.Multiline = true;
            this.txtKey02.Name = "txtKey02";
            this.txtKey02.Size = new System.Drawing.Size(412, 52);
            this.txtKey02.TabIndex = 26;
            this.txtKey02.Text = "Key Client-02";
            this.txtKey02.Visible = false;
            // 
            // txtKey01
            // 
            this.txtKey01.Location = new System.Drawing.Point(40, 440);
            this.txtKey01.Multiline = true;
            this.txtKey01.Name = "txtKey01";
            this.txtKey01.Size = new System.Drawing.Size(412, 74);
            this.txtKey01.TabIndex = 27;
            this.txtKey01.Text = "Key Client-01";
            this.txtKey01.Visible = false;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCount.Location = new System.Drawing.Point(408, 265);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(51, 18);
            this.lbCount.TabIndex = 28;
            this.lbCount.Text = "Count";
            this.lbCount.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 501);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(457, 23);
            this.progressBar1.TabIndex = 29;
            // 
            // btnSendNoise
            // 
            this.btnSendNoise.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSendNoise.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendNoise.Location = new System.Drawing.Point(382, 136);
            this.btnSendNoise.Name = "btnSendNoise";
            this.btnSendNoise.Size = new System.Drawing.Size(135, 48);
            this.btnSendNoise.TabIndex = 32;
            this.btnSendNoise.Text = "Send + Noise";
            this.btnSendNoise.UseVisualStyleBackColor = false;
            this.btnSendNoise.Click += new System.EventHandler(this.btnSend02_Click);
            // 
            // richMessage
            // 
            this.richMessage.Location = new System.Drawing.Point(40, 286);
            this.richMessage.Name = "richMessage";
            this.richMessage.Size = new System.Drawing.Size(468, 148);
            this.richMessage.TabIndex = 33;
            this.richMessage.Text = "";
            this.richMessage.TextChanged += new System.EventHandler(this.richMessage_TextChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(549, 625);
            this.Controls.Add(this.richMessage);
            this.Controls.Add(this.btnSendNoise);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.txtKey01);
            this.Controls.Add(this.txtKey02);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtEncrypted);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Client-02";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TextBox txtKey02;
        private System.Windows.Forms.TextBox txtKey01;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSendNoise;
        private System.Windows.Forms.RichTextBox richMessage;
    }
}

