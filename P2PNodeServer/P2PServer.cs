using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P2PNodeServer
{
    public class P2PServer
    {
        private TcpListener _server;
        private bool _isRunning = false;

        public P2PServer(string ipAddress, int port)
        {
            _server = new TcpListener(IPAddress.Parse(ipAddress), port);
        }

        public void Start()
        {
            _server.Start();
            _isRunning = true;
            Console.WriteLine("Serwer nasłuchuje...");

            Task.Run(async () => await ListenForClients());
        }

        private async Task ListenForClients()
        {
            while (_isRunning)
            {
                TcpClient client = await _server.AcceptTcpClientAsync();
                Task.Run(async () => HandleClient(client));
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Otrzymano wiadomość: {message}");

                byte[] response = Encoding.UTF8.GetBytes("Wiadomość odebrana.");
                await stream.WriteAsync(response, 0, response.Length);
            }
        }

        public void Stop()
        {
            _isRunning = false;
            _server.Stop();
        }
    }
}
