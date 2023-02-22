using UserInterfaceManager;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ALGORITHM STUDY PROJECT");
            AlgorithmsDataPrinter ui = new AlgorithmsDataPrinter();

            bool continueWhile = true;
            while(continueWhile)
            {
                var selectedAlgorithm = ui.SelectAlgorithm();
                Console.Clear();

                ui.ExecuteSelectedAlgorithm(selectedAlgorithm);
                continueWhile = ListenForKeyPress();
                Console.Clear();
            }
        }

        private static bool ListenForKeyPress()
        {
            Console.WriteLine("Press ENTER to continue or ESC to leave.");

            while (!Console.KeyAvailable)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter) return true;
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) return false;
            }

            return true;
        }
    }
}