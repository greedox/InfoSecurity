namespace InfoSecurity.EncrytpAlgoritms
{
    class Atbash : IEncryptable
    {
        //алфавит языка
        private const string alphabet = "абвгдеёжзиклмнопрстуфхцчщьъыэюяabcdefghijklmnopqrstuvwxyz ";

        //метод для переворачивания строки
        private string Reverse(string inputText)
        {
            //переменная для хранения результата
            var reversedText = string.Empty;
            foreach (var s in inputText)
            {
                //добавляем символ в начало строки
                reversedText = s + reversedText;
            }

            return reversedText;
        }

        //метод шифрования/дешифрования
        private string EncryptDecrypt(string text, string symbols, string cipher)
        {
            //переводим текст в нижний регистр
            text = text.ToLower();

            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                //поиск позиции символа в строке алфавита
                var index = symbols.IndexOf(text[i]);
                if (index >= 0)
                {
                    //замена символа на шифр
                    outputText += cipher[index].ToString();
                }
            }

            return outputText;
        }

        public string Encrypt(string plainMessage)
        {
            return EncryptDecrypt(plainMessage, alphabet, Reverse(alphabet));
        }

        public string Decrypt(string encryptedMessage)
        {
            return EncryptDecrypt(encryptedMessage, alphabet, Reverse(alphabet));
        }
    }
}
