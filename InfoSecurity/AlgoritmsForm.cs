using InfoSecurity.EncrytpAlgoritms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace InfoSecurity
{
    public partial class AlgoritmsForm : Form
    {
        enum Cipher
        {
            Atbash,
            Ceasar,
            PolybiusSquare,
            Vigenere,
            XOR
        }

        private int key = 0;

        public AlgoritmsForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Cipher));
        }

        private void button_Encrypt_Click(object sender, EventArgs e)
        {
            Cipher cipher;
            Enum.TryParse<Cipher>(comboBox1.SelectedValue.ToString(), out cipher);
            string text = textBox_Input.Text;
            string encText = string.Empty;
            switch (cipher)
            {
                case Cipher.Atbash:
                    encText = new Atbash().Encrypt(text);
                    break;
                case Cipher.Ceasar:
                    encText = new CeasarCipher(key).Encrypt(text);
                    break;
                case Cipher.PolybiusSquare:
                    encText = new PolybiusSquare(key.ToString()).Encrypt(text);
                    break;
                case Cipher.Vigenere:
                    encText = new VigenereCipher(key.ToString()).Encrypt(text);
                    break;
                case Cipher.XOR:
                    encText = new XORCipher(key.ToString()).Encrypt(text);
                    break;
                default:
                    break;
            }
            textBox_EncryptMessage.Text = encText;
        }

        private void button_Decrypt_Click(object sender, EventArgs e)
        {
            Cipher cipher;
            Enum.TryParse<Cipher>(comboBox1.SelectedValue.ToString(), out cipher);
            string text = textBox_EncryptMessage.Text;
            string decrText = string.Empty;
            switch (cipher)
            {
                case Cipher.Atbash:
                    decrText = new Atbash().Decrypt(text);
                    break;
                case Cipher.Ceasar:
                    decrText = new CeasarCipher(key).Decrypt(text);
                    break;
                case Cipher.PolybiusSquare:
                    decrText = new PolybiusSquare(key.ToString()).Decrypt(text);
                    break;
                case Cipher.Vigenere:
                    decrText = new VigenereCipher(key.ToString()).Decrypt(text);
                    break;
                case Cipher.XOR:
                    decrText = new XORCipher(key.ToString()).Decrypt(text);
                    break;
                default:
                    break;
            }
            textBox_DecryptMessage.Text = decrText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_Key.Text = $"Key: {key}";
        }

        private void button_KeyGen_Click(object sender, EventArgs e)
        {
            PrimeNumberGenerator generator = new PrimeNumberGenerator();
            Random random = new Random();
            uint n = (uint)random.Next(int.MaxValue / 1000000, int.MaxValue / 100000);
            key = (int)generator.SieveEratosthenes(n).Max();
            label_Key.Text = $"Key: {key}";
        }
    }
}
