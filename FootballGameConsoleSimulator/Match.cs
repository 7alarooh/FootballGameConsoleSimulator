using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
    public class Match
    {
        // private attributes
        private Team team1;
        private Team team2;
        private int currentTurn;
        private int currentHalf;
        private bool extraRound;
        private List<RoundDetail> roundDetails;
        private int numberOfRounds;

        //constructor to initialize the match between two teams
        public Match(Team team1, Team team2)
        {

            this.team1 = team1;
            this.team2 = team2;
            this.currentTurn = 0;
            this.extraRound = false;
            this.currentHalf = 1;
            this.roundDetails = new List<RoundDetail>();
        }

        //method foe coin toss to determine which team starts
        public Team coinToss()
        {
            Random rand = new Random();
            int toss = rand.Next(0, 2);
            if (toss == 0)
            {
                Console.WriteLine($"{team1.getTeamName()} wins the coin toss and will start the match.");
                return team1;
            }
            else
            {
                Console.WriteLine($"{team2.getTeamName()} wins the coin toss and will start the match.");
                return team2;
            }
        }
        //method to play a single turn
        public void playTurn(Team attackingTeam, Team defendingTeam)
        {
            List<Player> attackingPlayers = attackingTeam.selectPlayersForAttack();
            List<Player> defendingPlayers = defendingTeam.selectPlayersForDefense();
            Console.WriteLine($"        :... Turn ( {currentTurn + 1} ) ...:               ");
            Console.WriteLine($"\n {attackingTeam.getTeamName()} is attacking, {defendingTeam.getTeamName()} is defending.");

            //to calculate attack and defense power
            int attackPower = attackingTeam.calculateDefensePower();
            int defensePower = defendingTeam.calculateDefensePower();

            Console.WriteLine($"{attackingTeam.getTeamName()} attack: {attackPower}");
            Console.WriteLine($"{defendingTeam.getTeamName()} defense: {defensePower}");

            //determine the outcome (goal or save)
            string outcome;
            if (attackPower > defensePower)
            {
                attackingTeam.AddGoal();
                outcome = "Goal!";
                Console.WriteLine($"{attackingTeam.getTeamName()} scores!");
            }
            else
            {
                outcome = "Save!";
                Console.WriteLine($"{defendingTeam.getTeamName()} successfully defends.");
            }

            //to store round details
            roundDetails.Add(new RoundDetail(attackingTeam.getTeamName(), defendingTeam.getTeamName(), attackingTeam.selectPlayersForAttack(), defendingTeam.selectPlayersForDefense(), attackPower, defensePower, outcome));
            EndTurn(attackingPlayers, defendingPlayers);
            currentTurn++;

        }
        // method to make sure reduced all players after a round is completed
        public void EndTurn(List<Player> attackingPlayers, List<Player> defendingPlayers)
        {
            foreach (var player in attackingPlayers) { DecreaseEnergy(player, 0.10); }
            foreach (var player in defendingPlayers) { DecreaseEnergy(player, 0.05); }
        }
        //method to decrease the plyer's energy level
        public void DecreaseEnergy(Player player, double percentage)
        {
            player.energyLevel -= (int)(player.energyLevel * percentage);

            if (player.energyLevel < 0)
            {
                player.energyLevel = 0; //ensure dose not go below 0 
            }
        }
        //method to simulate one half of the match
        public void simulateHalf(int numberOfRounds)
        {
            Console.WriteLine($"\nStarting Half {currentHalf}...");
            Team staringTeam = coinToss();
            Team otherTeam = (staringTeam == team1) ? team2 : team1;

            //play multiple turn in each half
            for (int i = 0; i < numberOfRounds; i++)
            {
                if (i % 2 == 2)
                    playTurn(otherTeam, staringTeam);
                else
                    playTurn(staringTeam, otherTeam);
                Console.WriteLine("\nPress Enter key to move to the next round...");
                string nextRound=Console.ReadLine();
            }
            currentHalf++;
        }
        //method to simulate an extra round in case of a tie
        public void simulateExtraRound()
        {
            Console.WriteLine("\nThe Match is tied! Playing an extra round...");
            extraRound=true;
            playTurn(team1 , team2);
            if (team1.GetScore() == team2.GetScore())
            {
                playTurn(team2 , team1);
            }
        }
        // method to start and simulate the full match
        public void startMatch()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("- Please, the first enter an even number of rounds for the match:");
            Console.WriteLine("----------------------------------------------------------------");
            
            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                // Try to parse the input to an integer
                if (int.TryParse(input, out int rounds))
                {
                    if (rounds > 0 && rounds % 2 == 0) // Check if it's an even number
                    {
                        numberOfRounds = rounds/2;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("The number of rounds must be an even number greater than 0. Please try again.");
                    }
                }
            }
                    Console.WriteLine("Statring the match...");
            simulateHalf(numberOfRounds);
            simulateHalf(numberOfRounds);

            //to check if needing play extra round
            if (team1.GetScore() == team2.GetScore())
            {
                simulateExtraRound();
            }

            // to display final result
            displayFinalResult();
        }
        //method to display detailed information about each round
        public void displayMatchDetails()
        {
            Console.WriteLine("\nMatch Details:");
            foreach(RoundDetail detail in roundDetails)
            {
                detail.displayMatchDetails();
            }
        }
        //method to display the final result of the match
        private void displayFinalResult()
        {
            Console.WriteLine($"\nFinal Score: {team1.getTeamName()} {team1.GetScore()} - {team2.getTeamName()} {team2.GetScore()}");
            if (team1.GetScore() > team2.GetScore())
            { Console.WriteLine($"{team1.getTeamName()} wins the match!"); }
            else if (team1.GetScore() < team2.GetScore())
            { Console.WriteLine($"{team1.getTeamName()} wins the match!"); }
            else { Console.WriteLine($"The match ends in a draw!"); }
        }




    }
}
