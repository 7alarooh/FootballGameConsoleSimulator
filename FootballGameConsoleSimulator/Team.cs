using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
    public class Team: IDisplayInfo, ITeam
    {
        // attributes
        public string teamName{get; private set;}
        public List<Player> players { get; private set; }
        public string formation { get; private set; }
        public int score { get; private set; }

        //constructor to initialize 
        public Team(string teamName)
        {
            this.teamName = teamName;
            this.score = 0;
            chooseFormation();
            this.players = GeneratePlayers();
        }
        /////////Methods//////////
        //method to allow the user to choose a formation
       public void chooseFormation()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine($"        :::: {this.teamName} Team::::     ");
            Console.WriteLine("=========================================");
            Console.WriteLine("Choose a formation: [1] 4-4-2, [2] 4-3-3 [3] 3-5-2");
            string choice=Console.ReadLine();
            switch (choice) 
            {
                case "1":
                    formation = "4-4-2";
                    break;
                case "2":
                    formation = "4-3-3";
                    break;
                case "3":
                    formation = "3-5-2";
                    break;
                default:
                    Console.WriteLine("Invalid choice, defaulting to 4-4-2.");
                    formation = "4-4-2";
                    break;
            }
            Console.WriteLine($"{teamName} selected formation: {formation}");
        }
        //private method to generate 11 players with random skill level
        private List<Player> GeneratePlayers() 
        {
            List<Player> teamPlayers = new List<Player>();
            Random rand = new Random();

            string[] formationSplit = formation.Split('-');
            int numDefenders=int.Parse(formationSplit[0]);
            int numMidfielders=int.Parse(formationSplit[1]);
            int numForwards=int.Parse(formationSplit[2]);
            Console.WriteLine("Enter the Goal Keeper Name: ");
            string GKName=Console.ReadLine();
            teamPlayers.Add(new Player(GKName, Position.Goalkeeper, rand.Next(1, 101)));

            for (int i = 0; i < numDefenders; i++)
            {
                Console.WriteLine($"Enter the Defender Name: [{i+1}] ");
                string DeName = Console.ReadLine();
                teamPlayers.Add(new Player(DeName, Position.Defender, rand.Next(1, 101)));
            }
            for (int i = 0; i < numMidfielders; i++)
            {
                Console.WriteLine($"Enter the Midfielder Name: [{i + 1}] ");
                string MidfName = Console.ReadLine();
                teamPlayers.Add(new Player(MidfName, Position.Midfielder, rand.Next(1, 101)));
            }
            for (int i = 0; i < numForwards; i++)
            {
                Console.WriteLine($"Enter the Forward Name: [{i + 1}] ");
                string ForName = Console.ReadLine();
                teamPlayers.Add(new Player(ForName, Position.Forward, rand.Next(1, 101)));
            }
            return teamPlayers;
        }
        //method to select 3 players for attack (must include at least 1 attacker/ midfielder)
        public List<Player> selectPlayersForAttack()
        {
            Random rand = new Random();
            // Get lists of forwards and midfielders
            var forwards = players.Where(p => p.position == Position.Forward).ToList();
            var midfielders = players.Where(p => p.position == Position.Midfielder).ToList();
            List<Player> selectedPlayers = new List<Player>();

            // Ensure at least 1 forward is selected (if available)
            if (forwards.Count > 0)
            {
                Player forward = forwards[rand.Next(forwards.Count)];
                selectedPlayers.Add(forward);
                forwards.Remove(forward); // Remove selected player to avoid duplicates
            }

            // Ensure at least 1 midfielder is selected (if available)
            if (midfielders.Count > 0)
            {
                Player midfielder = midfielders[rand.Next(midfielders.Count)];
                selectedPlayers.Add(midfielder);
                midfielders.Remove(midfielder); // Remove selected player to avoid duplicates
            }

            // Fill remaining slots (if any) from forwards and midfielders
            while (selectedPlayers.Count < 3)
            {
                var availablePlayers = forwards.Concat(midfielders).ToList();
                if (availablePlayers.Count == 0) break; // No more players to select
                Player randomPlayer = availablePlayers[rand.Next(availablePlayers.Count)];
                selectedPlayers.Add(randomPlayer);
                // Remove the player from their respective list
                if (randomPlayer.position == Position.Forward)
                    forwards.Remove(randomPlayer);
                else if (randomPlayer.position == Position.Midfielder)
                    midfielders.Remove(randomPlayer);
            }
            return selectedPlayers;
        }
        // method to select 3 players for defense (must include a goalkeeper and defender/midfielder)
        public List<Player> selectPlayersForDefense()
        {
            Random rand = new Random();
            // Get lists of goalkeeper,defender and midfielders
            var goalkeeper = players.Where(p => p.position == Position.Goalkeeper).FirstOrDefault();
            var midfielders = players.Where(p => p.position == Position.Midfielder ).ToList();
            var defenders = players.Where( p=> p.position == Position.Defender).ToList();

            List<Player> selectedPlayers = new List<Player>();
            if (goalkeeper != null)
            {
                selectedPlayers.Add(goalkeeper);
            }
            // Ensure at least 1 defender is selected
            if (defenders.Count > 0)
            {
                Player defender = defenders[rand.Next(defenders.Count)];
                selectedPlayers.Add(defender);
                defenders.Remove(defender); // Remove selected defender to avoid duplicates
            }
            // Fill remaining slot (if any) from defenders or midfielders
            while (selectedPlayers.Count >3)
            {
                var availablePlayers = defenders.Concat(midfielders).ToList();
                if (availablePlayers.Count == 0) break; // No more players to select
                Player randomPlayer = availablePlayers[rand.Next(availablePlayers.Count)];
                selectedPlayers.Add(randomPlayer);
                // Remove the player from their respective list
                if (randomPlayer.position == Position.Defender)
                    defenders.Remove(randomPlayer);
                else if (randomPlayer.position == Position.Midfielder)
                    midfielders.Remove(randomPlayer);
            }
            return selectedPlayers;
        }
        //method to calculate total attack power
        public int calculateAttackPower() 
        {
            var selectedAttackers = selectPlayersForAttack();
            int attackPower=selectedAttackers.Sum(p=>p.GetskillLevel());
            return attackPower;
        }
        //method to calculate total defense power
        public int calculateDefensePower()
        {
            var selectedDefense = selectPlayersForDefense();
            int defensePower = selectedDefense.Sum(p => p.GetskillLevel());
            return defensePower;
        }
        //method to increase team score
        public void AddGoal()
        { score++; }
        //method to get the current score
        public int GetScore() 
        { return score; }
        // method to get the name of team
        public string getTeamName() { return this.teamName; }
        //method to display team information
        public void DisplayInfo() 
        {
            Console.WriteLine($"| Team: {teamName} ---- formation:{formation} ---- Score: {score} |");
            Console.WriteLine("| Player:-----------------------------------------------------------");
            foreach (var player in players)
            {
                player.DisplayInfo();
            }
        }

    }
}
