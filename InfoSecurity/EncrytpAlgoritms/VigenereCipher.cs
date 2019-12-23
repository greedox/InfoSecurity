namespace InfoSecurity.EncrytpAlgoritms
{
    class VigenereCipher : IEncryptable
    {
        const string defaultAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        readonly string letters;
        private string key;
        public string Key
        {
            get => key;
            set
            {
                key = value;
            }
        }

        public VigenereCipher(string key, string alphabet = null)
        {
            letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
            Key = key;
        }

        public string Decrypt(string encryptedMessage) => Vigenere(encryptedMessage, key, false);

        public string Encrypt(string plainMessage) => Vigenere(plainMessage, key);

        //генерация повторяющегося пароля
        private string GetRepeatKey(string s, int n)
        {
            var p = s;
            while (p.Length < n)
            {
                p += p;
            }

            return p.Substring(0, n);
        }

        private string Vigenere(string text, string password, bool encrypting = true)
        {
            var gamma = GetRepeatKey(password, text.Length);
            var retValue = "";
            var q = letters.Length;

            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = letters.IndexOf(text[i]);
                var codeIndex = letters.IndexOf(gamma[i]);
                if (letterIndex < 0)
                {
                    //если буква не найдена, добавляем её в исходном виде
                    retValue += text[i].ToString();
                }
                else
                {
                    retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                }
            }

            return retValue;
        }
    }
}
