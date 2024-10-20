using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P2PNodeServer
{
    public class P2PClient : IP2PClient
    {
        public async Task ConnectToPeer(string ipAddress, int port, string message)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(IPAddress.Parse(ipAddress), port);
                    NetworkStream stream = client.GetStream();

                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine($"Odpowiedź od serwera: {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas łączenia lub wysyłania: {ex.Message}");
            }
        }
    }
}
