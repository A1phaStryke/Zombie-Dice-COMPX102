using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice
{
    /// <summary>
    /// Represents a cup that holds and manages dice in the Zombie Dice game.
    /// </summary>
    class Cup
    {
        // Constants for cup dimensions and position
        public const int width = 100;
        public const int left = 358;
        public const int top = 175;

        // Rectangle representing the cup's body
        public Rectangle cupBody = new Rectangle(left, top, width, width);
        
        // List to store the dice contained in the cup
        public List<Dice> containedDice = new List<Dice>();

        // Random number generator for picking dice
        public Random random = new Random();
        
        /// <summary>
        /// Initializes a new instance of the Cup class.
        /// </summary>
        /// <param name="diceList">The initial list of dice to be added to the cup.</param>
        public Cup(List<Dice> diceList) 
        { 
            containedDice.AddRange(diceList);
        }

        /// <summary>
        /// Checks if the mouse is over the cup.
        /// </summary>
        /// <param name="x">The x-coordinate of the mouse position.</param>
        /// <param name="y">The y-coordinate of the mouse position.</param>
        /// <returns>True if the mouse is over the cup, false otherwise.</returns>
        public bool IsMouseOn(int x, int y)
        {
            if (cupBody.Contains(new Point(x, y)))
            {
                MessageBox.Show("Mouse on cup");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Draws the cup on the specified graphics surface
        public void Draw(Graphics paper)
        {
            paper.FillEllipse(Brushes.LightBlue, cupBody);
            paper.DrawEllipse(Pens.Black, cupBody);
            //paper.DrawRectangle(Pens.Black, cupBody);
        }

        public Dice PickDice()
        {
            Dice pickedDice = containedDice.ElementAt(random.Next(containedDice.Count));
            containedDice.Remove(pickedDice);
            return pickedDice;
        }
    }
}
