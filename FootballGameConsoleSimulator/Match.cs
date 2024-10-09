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
        private List<RoundDetasil> roundDetails;

        //constructor to initialize the match between two teams
        public Match(Team team1, Team team2)
        {

            this.team1 = team1;
            this.team2 = team2;
            this.currentTurn = 0;
            this.extraRound = false;
            this.currentHalf = 1;
            this.roundDetails = new List<RoundDetasil>();
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
            Console.WriteLine($"\nTurn {currentTurn + 1}:{attackingTeam.getTeamName()} is attacking, {defendingTeam.getTeamName()} is defending.");

            //to calculate attack and defense power
            int attackPower = attackingTeam.calculateDefensePower();
            int defensePower = defendingTeam.calculateDefensePower();

            Console.WriteLine($"{attackingTeam.getTeamName()} attack: {attackPower}");
            Console.WriteLine($"{defendingTeam.getTeamName()} attack: {attackPower}");

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
            roundDetails.Add(new RoundDetasil(attackingTeam.getTeamName(), defendingTeam.getTeamName(), attackingTeam.selectPlayersForAttack(), defendingTeam.selectPlayersForDefense
                , attackPower, defensePower, outcome));
            currentTurn++;

        }
        //method to simulate one half of the match
        public void simulateHalf()
        {
            Console.WriteLine($"\nStarting Half {currentHalf}...");
            Team staringTeam = coinToss();
            Team otherTeam = (staringTeam == team1) ? team2 : team1;

            //play multiple turn in each half
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 2)
                    playTurn(staringTeam, otherTeam);
                else
                    playTurn(otherTeam, staringTeam);
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
    }
}
