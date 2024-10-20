using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PNodeServer
{
    public static class P2PInit
    {
        public static void InitP2PServer(string ipaddress = "0.0.0.0", int port = 5000)
        {
            P2PServer server = new P2PServer(ipaddress, port);
            server.Start();
        }
    }
}
