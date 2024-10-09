﻿using System;
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
            this.energyLevel=100;
        }

        ///////////// Methods /////////////////////
        //method to decrease the plyer's energy level
        public void DecreaseEnergy(int amount)
        {
            energyLevel -= amount;
            if (energyLevel < 0)
            {  
                energyLevel = 0; //ensure dose not go below 0 
            }
        }
        //method to calculate the player's effective skill, witch is based on their energy level
        public int GetEffectiveSkill()
        {
            return (skillLevel + energyLevel)/100;
        
        }
        //method to display player details
        public void DisplayPlayerInfo() 
        {
            Console.WriteLine($"Player: {name} \t|  Position: {position} \t| Skill Level: {skillLevel} \t| Energy: {energyLevel} ");
        }


    }
}
