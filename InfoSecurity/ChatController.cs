using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace InfoSecurity
{
    static class ChatData
    {
        public static byte[] Key;
        public static byte[] Iv;
    }

    class ChatController
    {
        private UdpClient _udpClient;
        private readonly IPAddress _multicastAddress;
        private readonly IPEndPoint _endPoint;
        public delegate void MessageHandler(string message);
        public event MessageHandler Notify;

        public ChatController()
        {
            _multicastAddress = IPAddress.Parse("239.0.0.222");
            _udpClient = new UdpClient();
            _udpClient.JoinMulticastGroup(_multicastAddress);
            _endPoint = new IPEndPoint(_multicastAddress, 1408);
        }

        public void SendMessage(string msg)
        {
            //byte[] buff = Encoding.UTF8.GetBytes(msg);
            byte[] buff = Encrypt(msg, ChatData.Key, ChatData.Iv);
            _udpClient.Send(buff, buff.Length, _endPoint);
        }

        public void Listener()
        {
            UdpClient listener = new UdpClient();
            listener.ExclusiveAddressUse = false;
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 1408);
            listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            listener.Client.Bind(localEndPoint);
            listener.JoinMulticastGroup(_multicastAddress);

            while (true)
            {
                //byte[] data = listener.Receive(ref localEndPoint);
                byte[] data = Decrypt(listener.Receive(ref localEndPoint), ChatData.Key, ChatData.Iv);
                string text = Encoding.UTF8.GetString(data);
                Notify?.Invoke(text);
            }
        }

        private byte[] Encrypt(string text, byte[] key, byte[] iv)
        {
            byte[] result;
            using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
            {
                des.IV = iv;
                des.Key = key;

                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);
                using (var stream = new MemoryStream())
                using (var cstream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(cstream))
                    {
                        sw.Write(text);
                    }
                    result = stream.ToArray();
                }
            }

            return result;
        }

        private byte[] Decrypt(byte[] chiper, byte[] key, byte[] iv)
        {
            string text;
            using (TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);

                using (var stream = new MemoryStream(chiper))
                {
                    using (var cstream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cstream))
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                }
            }
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
