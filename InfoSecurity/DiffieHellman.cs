using System;
using InfoSecurity.EncrytpAlgoritms;

namespace InfoSecurity
{
    public static class DiffieHellman
    {
        public static int g, p;

        public static long PrivateKey { get; set; }
        public static long MyPublicKey => (long)Math.Pow(g, PrivateKey) % p;
        public static long TheyPublicKey { get; set; }
        public static long Key => (long)Math.Pow(TheyPublicKey, PrivateKey) % p;
    }
}
