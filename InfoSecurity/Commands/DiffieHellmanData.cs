using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.Commands
{
    [Serializable]
    class DiffieHellmanData
    {
        public int g, p;
        public long PublicKey { get; set; }
    }
}
