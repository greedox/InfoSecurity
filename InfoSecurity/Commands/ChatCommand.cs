using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.Commands
{
    [Serializable]
    enum CommandType
    {
        Message,
        DiffieHellmanInit,
        DiffieHellmanEnd
    }

    [Serializable]
    class ChatCommand
    {
        public CommandType Type { get; set; }
        public object Data { get; set; }
    }
}
