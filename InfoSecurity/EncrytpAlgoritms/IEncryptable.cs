namespace InfoSecurity.EncrytpAlgoritms
{
    interface IEncryptable
    {
        string Encrypt(string plainMessage);
        string Decrypt(string encryptedMessage);
    }
}
