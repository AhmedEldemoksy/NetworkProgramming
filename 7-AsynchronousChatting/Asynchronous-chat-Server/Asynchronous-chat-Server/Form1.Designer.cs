namespace Asynchronous_chat_Server
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
            this.results = new System.Windows.Forms.ListBox();
            this.status = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // results
            // 
            this.results.FormattingEnabled = true;
            this.results.Location = new System.Drawing.Point(12, 12);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(120, 238);
            this.results.TabIndex = 0;
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.Location = new System.Drawing.Point(198, 12);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(120, 251);
            this.status.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 317);
            this.Controls.Add(this.status);
            this.Controls.Add(this.results);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox results;
        private System.Windows.Forms.ListBox status;
    }
}

