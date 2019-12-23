using System;
using InfoSecurity.EncrytpAlgoritms;

namespace InfoSecurity
{
    class DiffieHellman
    {
        public int BobKey { get; set; }
        public int AliceKey { get; set; }
        public int PrivateBobKey { get; set; }
        public int FullKey { get; set; }

        private int GeneratePartialKey()
        {
            int partialKey = (int)Math.Pow(BobKey, AliceKey);
            partialKey = partialKey % AliceKey;
            return partialKey;
        }

        public int GenerateFullKey()
        {
            int partialKey = GeneratePartialKey();
            int fullKey = (int)Math.Pow(partialKey, PrivateBobKey);
            fullKey = fullKey % AliceKey;
            FullKey = fullKey;
            return fullKey;
        }

        public string EncryptMessage(string message)
        {
            string encryptedMessage = "";
            foreach (char item in message)
            {
                encryptedMessage += (char)(item + FullKey);
            }
            return encryptedMessage;
        }

        public string DecryptMessage(string encryptedMessage)
        {
            string decryptedMessage = "";
            foreach (char item in encryptedMessage)
            {
                decryptedMessage += (char)(item - FullKey);
            }
            return decryptedMessage;
        }
    }
}
