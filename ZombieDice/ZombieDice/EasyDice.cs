using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    /// <summary>
    /// Represents an easy dice in the Zombie Dice game.
    /// This dice has a higher probability of rolling "Brains".
    /// </summary>
    class EasyDice : Dice
    {
        // Array representing the possible results of rolling an easy dice
        // 3 Brains, 1 Shotgun, and 2 Feet
        static string[] easyDiceResult = new string[]
        {
            "Brains",
            "Brains",
            "Brains",
            "Shotgun",
            "Feet",
            "Feet"
        };

        /// <summary>
        /// Initializes a new instance of the EasyDice class.
        /// </summary>
        /// <param name="brush">The brush used to draw the dice.</param>
        public EasyDice(Brush brush) : base(easyDiceResult, brush) 
        { 
            // Constructor body is empty as all initialization is done in the base constructor
        }

    }
}
