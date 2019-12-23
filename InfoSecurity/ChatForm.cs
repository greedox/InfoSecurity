using InfoSecurity.Commands;
using System;
using System.IO;
using System.Linq;
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
            comboBox_Cipher.DataSource = Enum.GetValues(typeof(Cipher));
            richTextBox_Chat.ReadOnly = true;
            new Thread(controller.Listener) { IsBackground = true }.Start();
            controller.Notify += UpdateMessages;
            var rnd = new Random();
            var primeGen = new PrimeNumberGenerator();
            DiffieHellman.PrivateKey = (int)primeGen.SieveEratosthenes((uint)rnd.Next(10, 30)).Max();
        }

        private void UpdateMessages(string message)
        {
            richTextBox_Chat.BeginInvoke((MethodInvoker)(() => this.richTextBox_Chat.AppendText(">" + message + Environment.NewLine)));
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_Message.Text))
            {
                //DESData();
                //controller.SendMessage(textBox_Message.Text);
                Cipher cipher;
                Enum.TryParse<Cipher>(comboBox_Cipher.SelectedValue.ToString(), out cipher);
                var msgData = new MessageData
                {
                    Cipher = cipher,
                    Message = textBox_Message.Text
                };
                msgData.EncryptMessage();
                var msgCmd = new ChatCommand
                {
                    Type = CommandType.Message,
                    Data = msgData
                };
                controller.SendCommand(msgCmd);
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

        private void button_Login_Click(object sender, EventArgs e)
        {
            var primeGen = new PrimeNumberGenerator();
            var rnd = new Random();
            int g = (int)primeGen.SieveEratosthenes((uint)rnd.Next(10, 30)).Max();
            int p = (int)primeGen.SieveEratosthenes((uint)rnd.Next(10, 30)).Max();
            DiffieHellman.g = g;
            DiffieHellman.p = p;
            var dhCmd = new ChatCommand
            {
                Type = CommandType.DiffieHellmanInit,
                Data = new DiffieHellmanData 
                {
                    g = g,
                    p = p, 
                    PublicKey = DiffieHellman.MyPublicKey
                }
            };
            richTextBox_Chat.AppendText($"g {DiffieHellman.g}\n");
            richTextBox_Chat.AppendText($"p {DiffieHellman.p}\n");
            richTextBox_Chat.AppendText($"PrivateKey {DiffieHellman.PrivateKey}\n");
            richTextBox_Chat.AppendText($"MyPublicKey {DiffieHellman.MyPublicKey}\n");
            richTextBox_Chat.AppendText($"TheyPublicKey {DiffieHellman.TheyPublicKey}\n");

            controller.SendCommand(dhCmd);
        }
    }
}
