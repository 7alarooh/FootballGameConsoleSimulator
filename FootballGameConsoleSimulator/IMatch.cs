using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
      interface IMatch
    {
        Team coinToss();
        void DecreaseEnergy(Player player, double percentage);
        void simulateHalf(int numberOfRounds);
        void simulateExtraRound();
        void startMatch();
        void displayMatchDetails();
    }
}
