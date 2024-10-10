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
    public class Player: IPlayer
    {
        //private attributes
        public string name { get; private set; }
        public Position position { get; private set; }
        public int skillLevel { get; private set; }
        public int energyLevel;

        //constructor to initialize the player's attributes
        public Player(string name, Position position, int skillLevel) 
        {
            this.name = name;
            this.position = position;   
            this.skillLevel = skillLevel;   
            this.energyLevel= skillLevel;
        }

        ///////////// Methods /////////////////////
        
        //
        public string GetName() { return this.name; }
        public int GetskillLevel() {  return this.skillLevel; }
        public Position GetPosition() { return this.position; }
        //method to display player details
        public void DisplayPlayerInfo() 
        {
            Console.WriteLine($"Player: {name} \t|  Position: {position} \t| Skill Level: {skillLevel} \t| Energy: {energyLevel} ");
        }


    }
}
