namespace FootballGameConsoleSimulator
{
    public class Program
    {
        static private Match match;
        Team team1;
        Team team2;
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
                        Console.Clear();
                        StartNewMatch();
                        break;
                    case "2":
                        Console.Clear();
                        DisplayMatchDetails();
                        break;
                    case "0":
                        Console.Clear();
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
                    Console.WriteLine("\nPress Enter key to return to the main menu...");
                    Console.ReadKey();
                }
            }

            
        }

        // Method to display the main menu
        static private void DisplayMainMenu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("        :.:.: Soccer Game Simulator :.:.:        ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Start a New Match");
            Console.WriteLine("2. Display Match Details");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=========================================");
        }
        // Method to start a new match
        static private void StartNewMatch()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("        :::: Start a New Soccer Match ::::     ");
            Console.WriteLine("=========================================");
            // Get team names
            Console.Write("\nEnter the name of Team 1: ");
            string team1Name = Console.ReadLine();
            
            Console.Write("Enter the name of Team 2: ");
            string team2Name = Console.ReadLine();
            Team team1 = new Team(team1Name);
            Team team2 = new Team(team2Name);
            match = new Match(team1, team2);
            match.startMatch();
            Console.WriteLine("\nMatch completed! You can now view the details in the menu.");
        }
        // Method to display match details
        static private void DisplayMatchDetails()
        {
            Console.Clear();
            if (match == null)
            {
                Console.WriteLine("No match has been played yet! Start a new match first.");
            }
            else
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("        :... Match Details ...:               ");
                Console.WriteLine("=========================================");
                match.displayMatchDetails();
            }
        }
      

    }
}
