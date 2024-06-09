using MiniBooker.Utility;

namespace MiniBooker
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = Configuration.GetConfiguration();
            var services = Configuration.CreateServices(configuration);
            Console.WriteLine("Welcome to the MiniBooker!");
            ConsoleHelper.MainMenu(services);
        }

    }
}




