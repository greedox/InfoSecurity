using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity
{
    enum CommandType
    {
        Message,
        DiffieHellman
    }
    class ChatCommand<T> where T: class
    {
        public CommandType Type { get; set; }
        public T Data { get; set; }
    }
}
