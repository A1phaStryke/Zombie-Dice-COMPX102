using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    /// <summary>
    /// Represents an abstract base class for dice in the Zombie Dice game.
    /// </summary>
    abstract class Dice
    {
        /// <summary>
        /// Array of possible dice results.
        /// </summary>
        public string[] _diceResults;

        /// <summary>
        /// The current result of the dice roll.
        /// </summary>
        public string diceResult;

        /// <summary>
        /// Random number generator for dice rolls.
        /// </summary>
        public Random rand = new Random();

        /// <summary>
        /// The color of the dice.
        /// </summary>
        public Brush diceColour;

        /// <summary>
        /// The X-coordinate position of the dice on the drawing surface.
        /// </summary>
        public int xPos;

        /// <summary>
        /// The Y-coordinate position of the dice on the drawing surface.
        /// </summary>
        public int yPos;

        /// <summary>
        /// Initializes a new instance of the Dice class.
        /// </summary>
        /// <param name="diceResults">Array of possible dice results.</param>
        /// <param name="brush">The brush used to color the dice.</param>
        public Dice(string[] diceResults, Brush brush)
        {
            _diceResults = diceResults;
            diceColour = brush;
        }

        /// <summary>
        /// Draws the dice on the specified graphics surface.
        /// </summary>
        /// <param name="paper">The graphics surface to draw on.</param>
        public virtual void Draw(Graphics paper)
        {
            Rectangle rectangle = new Rectangle(xPos, yPos, 25, 25);

            // Fill the rectangle with the dice color
            paper.FillRectangle(diceColour, rectangle);

            // Draw a black outline around the rectangle
            paper.DrawRectangle(Pens.Black, rectangle);
        }

        /// <summary>
        /// Simulates rolling the dice and returns the result.
        /// </summary>
        /// <returns>A string representing the result of the dice roll.</returns>
        public string Roll()
        {
            diceResult = _diceResults[rand.Next(_diceResults.Length)];
            return diceResult;
        }
    }
}
