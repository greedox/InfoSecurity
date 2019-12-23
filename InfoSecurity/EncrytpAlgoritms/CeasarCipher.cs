namespace InfoSecurity.EncrytpAlgoritms
{
    class CeasarCipher : IEncryptable
    {
        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private int key;
        public int Key 
        { 
            get => key;
            set
            {
                key = value;
            }
        }

        public CeasarCipher(int key)
        {
            this.key = key;
        }

        public string Decrypt(string encryptedMessage) => CodeEncode(encryptedMessage, -key);

        public string Encrypt(string plainMessage) => CodeEncode(plainMessage, key);

        private string CodeEncode(string text, int k)
        {
            //добавляем в алфавит маленькие буквы
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (((letterQty + index + k) % letterQty) + letterQty) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

    }
}
