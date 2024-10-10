using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
    public interface ITeam
    {
        string teamName { get; }
        List<Player> players { get; }
        string formation { get; }
        int score { get;}
        void chooseFormation();
        int GetScore();
        public void AddGoal();
        int calculateAttackPower();
        int calculateDefensePower();
        string getTeamName();
    }
}
