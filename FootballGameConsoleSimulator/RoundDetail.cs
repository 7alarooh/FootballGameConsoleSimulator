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
        private string attackingTeam;
        private string defendingTeam;
        private List<Player> attackingplayers;
        private List<Player> defendingplayers;
        private int attackPower;
        private int defendingPower;
        private string outcome;


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

    }
}
