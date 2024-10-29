using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    /// <summary>
    /// Represents a Hunk Dice used in the Zombie Dice game.
    /// Inherits from the Dice class and defines specific results for the Hunk Dice.
    /// </summary>
    class HunkDice : Dice
    {
        /// <summary>
        /// The possible results of rolling a Hunk Dice.
        /// </summary>
        static string[] hunkDiceResult = new string[]
        {
            "Double Brains",
            "Double Shotgun",
            "Shotgun",
            "Shotgun",
            "Feet",
            "Feet"
        };

        /// <summary>
        /// Initializes a new instance of the HunkDice class.
        /// </summary>
        /// <param name="brush">The brush used for rendering the dice.</param>
        public HunkDice(Brush brush) : base(hunkDiceResult, brush) 
        { 
            // Constructor logic is done in the base class constructor.
        }
    }
}
