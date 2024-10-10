using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
    public  interface IPlayer
    {
        string name { get; }
        Position position { get; }
        int skillLevel { get;}
        int GetskillLevel();
        Position GetPosition();
        string GetName();
    }
}
