using InfoSecurity.EncrytpAlgoritms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.Commands
{
    [Serializable]
    public enum Cipher
    {
        Atbash,
        Ceasar,
        PolybiusSquare,
        Vigenere,
        XOR
    }

    [Serializable]
    public class MessageData
    {
        public Cipher Cipher { get; set; }

        public string Message { get; set; }

        public void EncryptMessage()
        {
            switch (Cipher)
            {
                case Cipher.Atbash:
                    Message = new Atbash().Encrypt(Message);
                    break;
                case Cipher.Ceasar:
                    Message = new CeasarCipher((int)DiffieHellman.Key).Encrypt(Message);
                    break;
                case Cipher.PolybiusSquare:
                    Message = new PolybiusSquare(DiffieHellman.Key.ToString()).Encrypt(Message);
                    break;
                case Cipher.Vigenere:
                    Message = new VigenereCipher(DiffieHellman.Key.ToString()).Encrypt(Message);
                    break;
                case Cipher.XOR:
                    Message = new XORCipher(DiffieHellman.Key.ToString()).Encrypt(Message);
                    break;
                default:
                    break;
            }
        }

        public void DecryptMessage()
        {
            switch (Cipher)
            {
                case Cipher.Atbash:
                    Message = new Atbash().Decrypt(Message);
                    break;
                case Cipher.Ceasar:
                    Message = new CeasarCipher((int)DiffieHellman.Key).Decrypt(Message);
                    break;
                case Cipher.PolybiusSquare:
                    Message = new PolybiusSquare(DiffieHellman.Key.ToString()).Decrypt(Message);
                    break;
                case Cipher.Vigenere:
                    Message = new VigenereCipher(DiffieHellman.Key.ToString()).Decrypt(Message);
                    break;
                case Cipher.XOR:
                    Message = new XORCipher(DiffieHellman.Key.ToString()).Decrypt(Message);
                    break;
                default:
                    break;
            }
        }
    }
}
