using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameConsoleSimulator
{
    public enum Position 
    {
        Forward,
        Midfielder,
        Defender,
        Goalkeeper
    }
    public class Player
    {
        //private attributes
        private string name;
        private Position position;
        private int skillLevel;
        private int energyLevel;

        //constructor to initialize the player's attributes
        public Player(string name, Position position, int skillLevel) 
        {
            this.name = name;
            this.position = position;   
            this.skillLevel = skillLevel;   
            this.energyLevel=skillLevel;
        }
    }
}
