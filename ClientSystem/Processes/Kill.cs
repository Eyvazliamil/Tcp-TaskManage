using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSystem.Processes
{
    public class Kill
    {
        public static void KillApp()
        {
            try
            {
                Console.Clear();
                Console.Write("Kill => ");
                var processes = Process.GetProcessesByName(Console.ReadLine()!);

                if (processes.Length == 0){
                    Console.WriteLine("This application is not running currently."); 
                    Console.ReadKey();
                }

                foreach (var process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                    process.Dispose();
                }
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
