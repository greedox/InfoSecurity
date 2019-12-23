namespace InfoSecurity.EncrytpAlgoritms
{
    class ScytaleCipher : IEncryptable
    {
        private int key;
        public int Key
        {
            get => key;
            set
            {
                key = value;
            }
        }

        public ScytaleCipher(int key)
        {
            this.key = key;
        }

        public string Decrypt(string encryptedMessage)
        {
            var column = encryptedMessage.Length / key;
            var symbols = new char[encryptedMessage.Length];
            int index = 0;
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    symbols[i + column * j] = encryptedMessage[index];
                    index++;
                }
            }

            return string.Join("", symbols);
        }

        public string Encrypt(string plainMessage)
        {
            var k = plainMessage.Length % key;
            if (k > 0)
            {
                //дополняем строку пробелами
                plainMessage += new string(' ', key - k);
            }

            var column = plainMessage.Length / key;
            var result = "";

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    result += plainMessage[i + column * j].ToString();
                }
            }

            return result;
        }
    }
}
