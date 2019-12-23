namespace InfoSecurity
{
    partial class ChatForm
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
            this.richTextBox_Chat = new System.Windows.Forms.RichTextBox();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_Chat
            // 
            this.richTextBox_Chat.Location = new System.Drawing.Point(13, 13);
            this.richTextBox_Chat.Name = "richTextBox_Chat";
            this.richTextBox_Chat.Size = new System.Drawing.Size(775, 360);
            this.richTextBox_Chat.TabIndex = 0;
            this.richTextBox_Chat.Text = "";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(13, 380);
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(694, 20);
            this.textBox_Message.TabIndex = 1;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(713, 378);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 2;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.richTextBox_Chat);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Chat;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_Send;
    }
}