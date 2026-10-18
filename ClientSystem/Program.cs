using ClientSystem.MenuSystem;
using ClientSystem.Processes;
using ServerSystem.Commands; 
using System.Diagnostics;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        var command = new Command();
        var client = new TcpClient("127.0.0.1", 16789);

        string[] menus = { $"{command.PROCLIST.ToUpper()}", $"{command.KILL.ToUpper()}", $"{command.RUN.ToUpper()}" };

        var serverStream = client.GetStream();

        var br = new BinaryReader(serverStream);
        var bw = new BinaryWriter(serverStream);  

        Task.Run(() =>
        {
            while (true)
            {
                Console.WriteLine(br.ReadString());
            }
        });

        while (true)
        {
            short proc = Menu.ShowMenu(menus, "\u001b[36m====================== COMMANDS ======================\u001b[0m");

            if (proc == 0)
            {
                Proclist.ProclistMethod();
            }

            if (proc == 1)
            {
                Kill.KillApp();
            }

            if (proc == 2)
            { 
                Run.RunApp();
            }
             
            bw.Write(proc);
            bw.Flush();
        }
    }
}