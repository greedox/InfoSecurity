namespace InfoSecurity
{
    partial class AlgoritmsForm
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
            this.button_Encrypt = new System.Windows.Forms.Button();
            this.button_Decrypt = new System.Windows.Forms.Button();
            this.textBox_DecryptMessage = new System.Windows.Forms.TextBox();
            this.textBox_EncryptMessage = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_KeyGen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Encrypt
            // 
            this.button_Encrypt.Location = new System.Drawing.Point(278, 103);
            this.button_Encrypt.Name = "button_Encrypt";
            this.button_Encrypt.Size = new System.Drawing.Size(96, 23);
            this.button_Encrypt.TabIndex = 2;
            this.button_Encrypt.Text = "Зашифровать";
            this.button_Encrypt.UseVisualStyleBackColor = true;
            this.button_Encrypt.Click += new System.EventHandler(this.button_Encrypt_Click);
            // 
            // button_Decrypt
            // 
            this.button_Decrypt.Location = new System.Drawing.Point(278, 128);
            this.button_Decrypt.Name = "button_Decrypt";
            this.button_Decrypt.Size = new System.Drawing.Size(96, 23);
            this.button_Decrypt.TabIndex = 3;
            this.button_Decrypt.Text = "Расшифровать";
            this.button_Decrypt.UseVisualStyleBackColor = true;
            this.button_Decrypt.Click += new System.EventHandler(this.button_Decrypt_Click);
            // 
            // textBox_DecryptMessage
            // 
            this.textBox_DecryptMessage.Location = new System.Drawing.Point(115, 130);
            this.textBox_DecryptMessage.Name = "textBox_DecryptMessage";
            this.textBox_DecryptMessage.Size = new System.Drawing.Size(157, 20);
            this.textBox_DecryptMessage.TabIndex = 4;
            // 
            // textBox_EncryptMessage
            // 
            this.textBox_EncryptMessage.Location = new System.Drawing.Point(115, 104);
            this.textBox_EncryptMessage.Name = "textBox_EncryptMessage";
            this.textBox_EncryptMessage.Size = new System.Drawing.Size(157, 20);
            this.textBox_EncryptMessage.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(278, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // textBox_Input
            // 
            this.textBox_Input.Location = new System.Drawing.Point(115, 78);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(157, 20);
            this.textBox_Input.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Входная строка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Зашифр. строка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Расшифр. сторка";
            // 
            // button_KeyGen
            // 
            this.button_KeyGen.Location = new System.Drawing.Point(278, 47);
            this.button_KeyGen.Name = "button_KeyGen";
            this.button_KeyGen.Size = new System.Drawing.Size(96, 23);
            this.button_KeyGen.TabIndex = 12;
            this.button_KeyGen.Text = "Сгенерировать ключ";
            this.button_KeyGen.UseVisualStyleBackColor = true;
            this.button_KeyGen.Click += new System.EventHandler(this.button_KeyGen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ключ";
            // 
            // textBox_Key
            // 
            this.textBox_Key.Location = new System.Drawing.Point(115, 50);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(157, 20);
            this.textBox_Key.TabIndex = 14;
            // 
            // AlgoritmsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Key);
            this.Controls.Add(this.button_KeyGen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Input);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox_EncryptMessage);
            this.Controls.Add(this.textBox_DecryptMessage);
            this.Controls.Add(this.button_Decrypt);
            this.Controls.Add(this.button_Encrypt);
            this.Name = "AlgoritmsForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Encrypt;
        private System.Windows.Forms.Button button_Decrypt;
        private System.Windows.Forms.TextBox textBox_DecryptMessage;
        private System.Windows.Forms.TextBox textBox_EncryptMessage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_KeyGen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Key;
    }
}

