using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        var clients = new HashSet<TcpClient>();

        var ip = IPAddress.Parse("127.0.0.1");
        var port = 16789;

        TcpListener listener = new TcpListener(ip, port);

        listener.Start(10);

        while (true)
        {
            Console.WriteLine($"{listener.Server.LocalEndPoint} listening.....");
            var client = listener.AcceptTcpClient();

            Console.WriteLine($"{client.Client.RemoteEndPoint} connected server....");
            clients.Add(client);

            Task.Run(() =>
            {
                var clientStream = client.GetStream(); 
                var br = new BinaryReader(clientStream); 
                var readString = string.Empty;  
                var userIpEndPoint = string.Empty;

                var index = 0;
                while (true)
                {
                    readString = br.ReadString();

                    Console.WriteLine($"{clientStream.Socket.RemoteEndPoint} - {readString}");

                    index = readString.IndexOf(' ');

                    userIpEndPoint = readString.Substring(0, index);

                    var destination = clients.FirstOrDefault(x => x.Client.RemoteEndPoint?.ToString() == userIpEndPoint); 

                    var bw = new BinaryWriter(destination!.GetStream());

                    bw.Write($"{clientStream.Socket.RemoteEndPoint} - {readString.Substring(index + 1)}");
                }
            });
        }
    }
}