using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PNodeServer
{
    public interface IP2PClient
    {
        public Task ConnectToPeer(string ipAddress, int port, string message);
    }
}
