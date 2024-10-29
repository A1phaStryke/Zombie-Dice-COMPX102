using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    /// <summary>
    /// Represents a hard dice used in the Zombie Dice game.
    /// </summary>
    class HardDice : Dice
    {
        /// <summary>
        /// The possible results of rolling a hard dice.
        /// </summary>
        static string[] hardDiceResult = new string[]
        {
            "Brains",
            "Shotgun",
            "Shotgun",
            "Shotgun",
            "Feet",
            "Feet"
        };

        /// <summary>
        /// Initializes a new instance of the HardDice class.
        /// </summary>
        /// <param name="brush">The brush used for rendering the dice.</param>
        public HardDice(Brush brush) : base(hardDiceResult, brush) 
        { 
            // Constructor logic is done in the base class constructor.
        }
    }
}
