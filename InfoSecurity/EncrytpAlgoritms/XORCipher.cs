namespace InfoSecurity.EncrytpAlgoritms
{
    class XORCipher : IEncryptable
    {
        private string key;
        public string Key
        { 
            get => key; 
            set
            {
                key = value;
            }
        }

        public XORCipher(string key)
        {
            this.key = key;
        }
        //генератор повторений пароля
        private string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }

            return r.Substring(0, n);
        }

        //метод шифрования/дешифровки
        private string Cipher(string text, string secretKey)
        {
            var currentKey = GetRepeatKey(secretKey, text.Length);
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                res += ((char)(text[i] ^ currentKey[i])).ToString();
            }

            return res;
        }

        public string Encrypt(string plainMessage) => Cipher(plainMessage, key);

        public string Decrypt(string encryptedMessage) => Cipher(encryptedMessage, key);
    }
}
