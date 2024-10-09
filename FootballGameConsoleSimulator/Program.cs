namespace FootballGameConsoleSimulator
{
    public class Program
    {
        private Match match;
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                DisplayMainMenu();
                Console.Write("\nPlease select an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        StartNewMatch();
                        break;
                    case "2":
                        DisplayMatchDetails();
                        break;
                    case "3":
                        Console.WriteLine("\nThank you for playing! Exiting...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        break;
                }
                // Pause before returning to the menu
                if (running)
                {
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                }
            }

            
        }


    }
}
