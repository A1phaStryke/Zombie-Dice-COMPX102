using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    /// <summary>
    /// Represents a medium dice used in the Zombie Dice game.
    /// </summary>
    class MediumDice : Dice
    {
        /// <summary>
        /// The possible results of rolling the medium dice.
        /// </summary>
        static string[] mediumDiceResult = new string[]
        {
            "Brains",
            "Brains",
            "Shotgun",
            "Shotgun",
            "Feet",
            "Feet"
        };

        /// <summary>
        /// Initializes a new instance of the MediumDice class.
        /// </summary>
        /// <param name="brush">The brush used for rendering the dice.</param>
        public MediumDice(Brush brush) : base(mediumDiceResult, brush) 
        { 
            // Constructor logic is done in the base class constructor.
        }
    }
}
