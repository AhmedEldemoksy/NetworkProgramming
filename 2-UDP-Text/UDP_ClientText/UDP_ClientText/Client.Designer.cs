namespace UDP_ClientText
{
    partial class client
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
            this.userMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userMessage
            // 
            this.userMessage.Location = new System.Drawing.Point(16, 68);
            this.userMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userMessage.Multiline = true;
            this.userMessage.Name = "userMessage";
            this.userMessage.Size = new System.Drawing.Size(279, 105);
            this.userMessage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Write Message To Server";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(103, 197);
            this.send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(100, 28);
            this.send.TabIndex = 2;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 306);
            this.Controls.Add(this.send);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userMessage);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button send;
    }
}

