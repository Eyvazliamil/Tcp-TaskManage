using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSystem.Processes
{
    public class Proclist
    {
        public static void ProclistMethod()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Press 'Enter' to see all");
                Console.Write("Proclist => ");
                var processes = Process.GetProcessesByName(Console.ReadLine()!);

                if (processes.Length == 0)
                    Console.WriteLine("Empty.");

                foreach (var process in processes)
                {
                    Console.WriteLine(process.MachineName);
                    Console.WriteLine(process.Id);
                    Console.WriteLine(process.ProcessName);
                    process.Dispose();
                }

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.ReadKey();
            }

        }
    }
}
