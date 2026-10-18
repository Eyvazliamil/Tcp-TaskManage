using System.Diagnostics;

namespace ClientSystem.Processes
{
    public class Run
    { 
        public static void RunApp()
        {
            try
            {
                Console.Clear();
                Console.Write("Run => ");
                string input = Console.ReadLine()!.Trim();
                Process.Start(new ProcessStartInfo
                {
                    FileName = string.IsNullOrWhiteSpace(input) ? "Please make sure you enter a valid file name." : input,
                    UseShellExecute = true
                });
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
