using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    /// <summary>
    /// Represents a specialized dice for the HottieDice game.
    /// Inherits from the base Dice class and defines specific results.
    /// </summary>
    class HottieDice : Dice
    {
        /// <summary>
        /// The possible results of rolling the HottieDice.
        /// </summary>
        static string[] hottieDiceResult = new string[]
        {
            "Brains",
            "Shotgun",
            "Shotgun",
            "Feet",
            "Feet",
            "Feet"
        };

        /// <summary>
        /// Initializes a new instance of the HottieDice class.
        /// </summary>
        /// <param name="brush">The brush used for rendering the dice.</param>
        public HottieDice(Brush brush) : base(hottieDiceResult, brush) 
        { 
            // Constructor logic is done in the base class constructor.
        }
    }
}
