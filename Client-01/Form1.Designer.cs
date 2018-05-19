namespace Client_01
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtKey01 = new System.Windows.Forms.TextBox();
            this.txtKey02 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSend02 = new System.Windows.Forms.Button();
            this.richMessage = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(379, 87);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(139, 48);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(148, 229);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(213, 20);
            this.txtKey.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Encrypted";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Perpetua Titling MT", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(173, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "CLIENT-01";
            // 
            // txtEncrypted
            // 
            this.txtEncrypted.Location = new System.Drawing.Point(145, 156);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Name = "txtEncrypted";
            this.txtEncrypted.ReadOnly = true;
            this.txtEncrypted.Size = new System.Drawing.Size(216, 40);
            this.txtEncrypted.TabIndex = 21;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(145, 87);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(216, 36);
            this.txtText.TabIndex = 20;
            this.txtText.Text = "Exchange Key";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(259, 271);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(44, 18);
            this.lbTime.TabIndex = 23;
            this.lbTime.Text = "Time";
            this.lbTime.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtKey01
            // 
            this.txtKey01.Location = new System.Drawing.Point(49, 440);
            this.txtKey01.Multiline = true;
            this.txtKey01.Name = "txtKey01";
            this.txtKey01.Size = new System.Drawing.Size(387, 73);
            this.txtKey01.TabIndex = 29;
            this.txtKey01.Text = "Key Client-01";
            this.txtKey01.Visible = false;
            // 
            // txtKey02
            // 
            this.txtKey02.Location = new System.Drawing.Point(49, 519);
            this.txtKey02.Multiline = true;
            this.txtKey02.Name = "txtKey02";
            this.txtKey02.Size = new System.Drawing.Size(387, 46);
            this.txtKey02.TabIndex = 28;
            this.txtKey02.Text = "Key Client-02";
            this.txtKey02.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(39, 490);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(445, 23);
            this.progressBar1.TabIndex = 30;
            // 
            // btnSend02
            // 
            this.btnSend02.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSend02.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend02.Location = new System.Drawing.Point(379, 145);
            this.btnSend02.Name = "btnSend02";
            this.btnSend02.Size = new System.Drawing.Size(139, 48);
            this.btnSend02.TabIndex = 31;
            this.btnSend02.Text = "Send + Noise";
            this.btnSend02.UseVisualStyleBackColor = false;
            this.btnSend02.Click += new System.EventHandler(this.btnSend02_Click);
            // 
            // richMessage
            // 
            this.richMessage.Location = new System.Drawing.Point(30, 292);
            this.richMessage.Name = "richMessage";
            this.richMessage.Size = new System.Drawing.Size(464, 129);
            this.richMessage.TabIndex = 32;
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
            this.Controls.Add(this.btnSend02);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtKey01);
            this.Controls.Add(this.txtKey02);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.txtEncrypted);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Client-01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtKey01;
        private System.Windows.Forms.TextBox txtKey02;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSend02;
        private System.Windows.Forms.RichTextBox richMessage;
    }
}

