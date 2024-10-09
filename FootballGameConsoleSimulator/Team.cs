using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
    public class Team
    {
        //private attributes
        private string teamName;
        private List<Player> players;
        private string formation;
        private int score;

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
            var attackers=players.Where(p => p.position == Position.Forward || p.position == Position.Midfielder)
                .OrderByDescending(p=> p.GetEffectiveSkill())
                .Take(3).ToList();
            return attackers; 
        }
        // method to select 3 players for defense (must include a goalkeeper and defender/midfielder)
        public List<Player> selectPlayersForDefense()
        {
            var defense = players.Where(p => p.position == Position.Goalkeeper || p.position == Position.Defender || p.position == Position.Midfielder)
                .OrderByDescending(p => p.GetEffectiveSkill())
                .Take(3).ToList();
            return defense;
        }
        //method to calculate total attack power
        public int calculateAttackPower() 
        {
            var selectedAttackers = selectPlayersForAttack();
            int attackPower=selectedAttackers.Sum(p=>p.GetEffectiveSkill());
            return attackPower;
        }
        //method to calculate total defense power
        public int calculateDefensePower()
        {
            var selectedDefense = selectPlayersForAttack();
            int defensePower = selectedDefense.Sum(p => p.GetEffectiveSkill());
            return defensePower;
        }
        //method to increase team score
        public void AddGoal()
        { score++; }
        //method to get the current score
        public int GetScore() 
        { return score; }
        //method to display team information
        public void DisplayTeamInfo() 
        {
            Console.WriteLine($"| Team: {teamName} ---- formation:{formation} ---- Score: {score} |");
            Console.WriteLine("| Player:-----------------------------------------------------------");
            foreach (var player in players)
            {
                player.DisplayPlayerInfo();
            }
        }

    }
}
