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
        private List <RoundDetasil> roundDetails;

        //constructor to initialize the match between two teams
        public Match(Team team1, Team team2)
        {

            this.team1 = team1;
            this.team2 = team2;
            this.currentTurn = 0;
            this.extraRound = false;
            this.currentHalf = 1;
            this.roundDetails=new List<RoundDetasil> ();
        }


    }
}
