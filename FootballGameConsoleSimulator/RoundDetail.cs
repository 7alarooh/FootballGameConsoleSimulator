using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
    public class RoundDetail
    {
        //private attributes
        public string attackingTeam { get; private set; }
        public string defendingTeam { get; private set; }
        public List<Player> attackingplayers { get; private set; }
        public List<Player> defendingplayers { get; private set; }
        public int attackPower { get; private set; }
        public int defendingPower { get; private set; }
        public string outcome { get; private set; }


        // constructor
        public RoundDetail(string attackingTeam, string defendingTeam, List<Player> attackingplayers, List<Player> defendingplayers, int attackPower, int defendingPower, string outcome)
        {
           this.attackingTeam = attackingTeam;
            this.defendingTeam = defendingTeam;
            this.attackingplayers = attackingplayers;
            this.defendingplayers = defendingplayers;
            this.attackPower=attackPower;
            this.defendingPower=defendingPower;
            this.outcome = outcome;
        }

        //method to diplay the round summary
        public void displayMatchDetails() 
        {
            

            Console.WriteLine("\nRound summary:");
            Console.WriteLine($"Attacking Team:{attackingTeam}");
            Console.WriteLine($"Defending Team:{defendingTeam}");


            Console.WriteLine($"===============================================");
            Console.WriteLine($"Attacking Players:");
            foreach( Player player in attackingplayers )
            {
                Console.WriteLine($"- {player.GetName()} (Skill:{player.GetskillLevel()}, Position: {player.GetPosition()})");
            }
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Defending Players:");
            foreach (Player player in defendingplayers)
            {
                Console.WriteLine($"- {player.GetName()} (Skill:{player.GetskillLevel()}, Position: {player.GetPosition()})");
            }
            Console.WriteLine($"===============================================");
            Console.WriteLine($"Attack Power: {attackPower}");
            Console.WriteLine($"Defense Power: {defendingPower}");
            Console.WriteLine($"Outcome: {outcome}");
        }

    }
}
