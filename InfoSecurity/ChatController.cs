using InfoSecurity.Commands;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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
        bool isInit = false;

        public ChatController()
        {
            _multicastAddress = IPAddress.Parse("239.0.0.222");
            _udpClient = new UdpClient();
            _udpClient.JoinMulticastGroup(_multicastAddress);
            _endPoint = new IPEndPoint(_multicastAddress, 1408);
        }

        public void SendCommand(ChatCommand command)
        {
            switch (command.Type)
            {
                case CommandType.Message:
                    var data = command.Data as MessageData;
                    data.EncryptMessage();
                    break;
                case CommandType.DiffieHellmanInit:
                    isInit = true;
                    break;
                case CommandType.DiffieHellmanEnd:
                    break;
                default:
                    break;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, command);
            var buff = stream.ToArray();
            _udpClient.Send(buff, buff.Length, _endPoint);
        }

        public void SendMessage(string msg)
        {
            byte[] buff = Encoding.UTF8.GetBytes(msg);
            //byte[] buff = Encrypt(msg, ChatData.Key, ChatData.Iv);
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
            BinaryFormatter formatter = new BinaryFormatter();

            while (true)
            {
                byte[] data = listener.Receive(ref localEndPoint);
                //byte[] data = Decrypt(listener.Receive(ref localEndPoint), ChatData.Key, ChatData.Iv);
                var stream = new MemoryStream(data);
                var cmd = (ChatCommand)formatter.Deserialize(stream);
                switch (cmd.Type)
                {
                    case CommandType.Message:
                        var msgData = (MessageData)cmd.Data;
                        Notify?.Invoke(msgData.Message);
                        msgData.DecryptMessage();
                        string text = msgData.Message;
                        Notify?.Invoke(text);
                        break;
                    case CommandType.DiffieHellmanInit:
                        if (isInit) continue;
                        var dhData = (DiffieHellmanData)cmd.Data;
                        DiffieHellman.p = dhData.p;
                        DiffieHellman.g = dhData.g;
                        DiffieHellman.TheyPublicKey = dhData.PublicKey;
                        Notify?.Invoke($"Получены данные: p {DiffieHellman.p}, g {DiffieHellman.g}, TheyPublicKey {DiffieHellman.TheyPublicKey}");
                        Notify?.Invoke($"Ключ создан: {DiffieHellman.Key}");
                        this.SendCommand(new ChatCommand
                        {
                            Type = CommandType.DiffieHellmanEnd,
                            Data = DiffieHellman.MyPublicKey
                        });
                        break;
                    case CommandType.DiffieHellmanEnd:
                        if (!isInit) continue;
                        DiffieHellman.TheyPublicKey = (long)cmd.Data;
                        Notify?.Invoke($"Ключ создан: {DiffieHellman.Key}");
                        isInit = false;
                        break;
                    default:
                        break;
                }
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
                using (var cstream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cstream))
                {
                    text = sr.ReadToEnd();
                }
            }
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
