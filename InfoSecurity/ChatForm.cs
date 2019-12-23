using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace InfoSecurity
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
        }

        ChatController controller = new ChatController();
        private void ChatForm_Load(object sender, EventArgs e)
        {
            richTextBox_Chat.ReadOnly = true;
            new Thread(controller.Listener) { IsBackground = true }.Start();
            controller.Notify += UpdateMessages;
        }

        private void UpdateMessages(string message)
        {
            richTextBox_Chat.BeginInvoke((MethodInvoker)(() => this.richTextBox_Chat.AppendText(message + Environment.NewLine)));
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_Message.Text))
            {
                DESData();

                controller.SendMessage(textBox_Message.Text);
                textBox_Message.Text = string.Empty;
            }
        }

        private void DESData()
        {
            using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
            {
                if (File.Exists("key.dat"))
                    ChatData.Key = Convert.FromBase64String(File.ReadAllText("key.dat"));
                else
                {
                    ChatData.Key = des.Key;
                    File.WriteAllText("key.dat", Convert.ToBase64String(ChatData.Key));
                }

                if (File.Exists("iv.dat"))
                    ChatData.Iv = Convert.FromBase64String(File.ReadAllText("iv.dat"));
                else
                {
                    ChatData.Iv = des.IV;
                    File.WriteAllText("iv.dat", Convert.ToBase64String(ChatData.Iv));
                }

            }
        }
    }
}
