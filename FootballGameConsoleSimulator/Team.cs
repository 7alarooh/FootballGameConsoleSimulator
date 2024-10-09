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

    }
}
