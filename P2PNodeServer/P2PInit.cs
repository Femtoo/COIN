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
            // Uruchomienie węzła, który będzie serwerem
            P2PServer server = new P2PServer(ipaddress, port);
            server.Start();

            // Uruchomienie klienta, który połączy się do tego samego węzła
            //await Task.Delay(1000); // Czekamy, aż serwer się uruchomi
            //await P2PClient.ConnectToPeer("localhost", port, "Witaj z innego węzła!");
            //await P2PClient.ConnectToPeer("127.0.0.1", port, "Witaj z innego węzła! v2");
            //string environment = Environment.GetEnvironmentVariable("NODE_NAME") ?? "undefined";
            //if (environment == "APP2")
            //{
            //    //Console.WriteLine("IN");
            //    await Task.Delay(1000);
            //    await P2PClient.ConnectToPeer("192.168.0.10", 5000, $"Hejka tu {environment}");
            //}
        }
    }
}
