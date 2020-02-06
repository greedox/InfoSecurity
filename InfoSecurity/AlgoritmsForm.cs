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
            Luciefer
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
                case Cipher.Luciefer:
                    encText = new LucieferChipher(textBox_Key.Text).Encrypt(text);
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
                case Cipher.Luciefer:
                    decrText = new LucieferChipher(textBox_Key.Text).Decrypt(text);
                    break;
                default:
                    break;
            }
            textBox_DecryptMessage.Text = decrText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_KeyGen_Click(object sender, EventArgs e)
        {
            int num_letters = 16;

            // Создаем массив букв, которые мы будем использовать.
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string fullAlphabet = alphabet.ToLower() + alphabet + "1234567890";
            char[] letters = fullAlphabet.ToCharArray();

            // Создаем генератор случайных чисел.
            Random rand = new Random();

            // Сделайте слово.
            string word = "";
            for (int j = 1; j <= num_letters; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }

            textBox_Key.Text = word;
        }
    }
}
