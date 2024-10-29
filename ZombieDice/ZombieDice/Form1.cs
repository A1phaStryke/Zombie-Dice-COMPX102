namespace ZombieDice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the main form of the Zombie Dice game.
    /// </summary>
    public partial class Form1 : Form
    {
        // Lists to manage dice
        private List<Dice> diceList = new List<Dice>();
        private List<Dice> displayedDiceList = new List<Dice>();

        // Player scores
        private static int player1Brains = 0;
        private static int player1Shotgun = 0;
        private static int player2Brains = 0;
        private static int player2Shotgun = 0;
        private int tempBrains = 0;

        // Game state variables
        private bool isPlayer1 = true;
        private bool zombieBrainsV2;
        private bool hunkInHand;
        private bool hottieInHand;

        // Cup to hold dice
        private Cup cup;

        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Set fixed size for the form
            MinimumSize = MaximumSize = Size;

            // Hide the roll button initially
            button1.Hide();
        }

        /// <summary>
        /// Handles the Form1_Load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Ask the user which version of the game they want to play
            if (MessageBox.Show("Welcome to Zombie Dice! Would you like to play Version 1 (Easier Version) of Zombie Dice?", "Welcome to Zombie Dice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                zombieBrainsV2 = false;
            }
            else
            {
                zombieBrainsV2 = true;
            }

            // Initialize the game
            LoadDice();
            cup = new Cup(diceList);
            diceList.Clear();
        }

        /// <summary>
        /// Handles the button1_Click event (Roll Dice).
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // If the cup has enough dice, run the script for the displayed dice
            if (cup.containedDice.Count >= 3)
            {
                // Temp string for the results
                string results = "";

                // Temp list for the dice to remove
                List<Dice> diceToRemove = new List<Dice>();

                foreach (Dice dice in displayedDiceList)
                {
                    dice.Roll(); // Roll the dice
                    results += dice.diceResult + ", "; // Add result to the string

                    // Check for special dice effects in Version 2
                    if (dice is HunkDice && dice.diceResult == "Double Brains" && zombieBrainsV2)
                    {
                        hunkInHand = true;
                    }
                    else if (dice is HottieDice && dice.diceResult == "Brains" && zombieBrainsV2)
                    {
                        hottieInHand = true;
                    }

                    // Calculate points for the current player
                    if (isPlayer1)
                    {
                        PointCalculate(ref player1Brains, ref player1Shotgun, dice, _Player1BrainsPoints, _Player1ShotgunPoints);
                    }
                    else
                    {
                        PointCalculate(ref player2Brains, ref player2Shotgun, dice, _Player2BrainsPoints, _Player2ShotgunPoints);
                    }

                    // If the result isn't "Feet", the dice should be removed from play
                    if (dice.diceResult != "Feet")
                    {
                        diceToRemove.Add(dice);
                    }
                }

                MessageBox.Show(results, "Dice Roll Results");

                // Remove dice that aren't "Feet" from the displayed list
                foreach (Dice dice in diceToRemove)
                {
                    displayedDiceList.Remove(dice);
                }
                pictureBox1.Invalidate(); // Redraw the picture box

                // Check if the current player's turn should end due to too many shotguns
                if (isPlayer1 && player1Shotgun >= 3)
                {
                    isPlayer1 = false;
                    MessageBox.Show("Player 2's Turn");
                    MessageBox.Show("Remainder left in cup: " + cup.containedDice.Count);
                    player1Shotgun = 0;
                    player1Brains -= tempBrains;
                    tempBrains = 0;
                }
                else if (!isPlayer1 && player2Shotgun >= 3)
                {
                    isPlayer1 = true;
                    MessageBox.Show("Player 1's Turn");
                    MessageBox.Show("Remainder left in cup: " + cup.containedDice.Count);
                    player2Shotgun = 0;
                    player2Brains -= tempBrains;
                    tempBrains = 0;
                }

                // Ask if the player wants to stop their turn
                if (MessageBox.Show("Do you wish to stop?", "Stop?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // If the player stops their turn, reset the temp brains.
                    tempBrains = 0;

                    // Then set it to the other players turn, clear the displayed dice, and reset the shotgun values
                    if (isPlayer1)
                    {
                        isPlayer1 = false;
                        displayedDiceList.Clear();
                        player1Shotgun = 0;
                        _Player1ShotgunPoints.Text = "0";
                    }
                    else
                    {
                        isPlayer1 = true;
                        displayedDiceList.Clear();
                        player2Shotgun = 0;
                        _Player2ShotgunPoints.Text = "0";
                    }
                }

                // Redraw the picturebox
                pictureBox1.Invalidate();

                // Hide the roll button
                button1.Hide();

                // Update the labels to display the current scores
                _Player1BrainsPoints.Text = player1Brains.ToString();
                _Player1ShotgunPoints.Text = player1Shotgun.ToString();
                _Player2BrainsPoints.Text = player2Brains.ToString();
                _Player2ShotgunPoints.Text = player2Shotgun.ToString();
            }
            else
            {
                // If there are less than 3 dice in the cup, reload all dice
                LoadDice();
                cup.containedDice.AddRange(diceList);
                diceList.Clear();
            }

            // Check if the game should end (13 or more brains)
            if (player1Brains >= 13 || player2Brains >= 13)
            {
                FinishGame();
            }
        }



        /// <summary>
        /// Draws the objects on the playing field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the cup
            cup.Draw(e.Graphics);

            // Then Draw each dice that is in play
            foreach (Dice dice in displayedDiceList)
            {
                dice.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// Detects when the cup is clicked, before picking the 3 dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (cup.IsMouseOn(e.X, e.Y))
            {
                // Pick 3 dice from the cup
                while (displayedDiceList.Count < 3)
                {
                    Dice newDice = cup.PickDice();
                    displayedDiceList.Add(newDice);
                    cup.containedDice.Remove(newDice);
                }

                // Creates and sets a temporary dice counter to 1
                int diceCounter = 1;

                // Then position the dice to 3 locations per side (3 locations for player 1, 3 locations for player 2)
                foreach (Dice dice in displayedDiceList)
                {
                    // Set dice to position 1
                    if (diceCounter == 1)
                    {
                        dice.xPos = 356;
                    }
                    // Set dice to position 2
                    else if (diceCounter == 2)
                    {
                        dice.xPos = 396;
                    }
                    // Set dice to position 3
                    else if (diceCounter == 3)
                    {
                        dice.xPos = 436;
                    }

                    // Set the dice to the side of the current player
                    if (isPlayer1)
                    {
                        dice.yPos = 329;
                    }
                    else
                    {
                        dice.yPos = 129;
                    }

                    // Increment the dice counter up.
                    diceCounter++;
                }

                // Redraw the picture box 
                pictureBox1.Invalidate();

                // Show the roll button
                button1.Show();
            }
        }


        /// <summary>
        /// Calculates and updates points for the current player based on dice roll results.
        /// </summary>
        private void PointCalculate(ref int playerBrains, ref int playerShotgun, Dice dice, Label playerBrainsPoints, Label playerShotgunPoints)
        {
            // If the result of the dice is Brains, add one to the temp brains, and player brains values
            if (dice.diceResult == "Brains")
            {
                playerBrains++;
                tempBrains++;
            }
            // if the result of the dice is Shotgun, add one to the shotgun score
            else if (dice.diceResult == "Shotgun")
            {
                playerShotgun++;

                // Special rule for Version 2: If hunk is in hand, and hottie rolls shotgun, add Hunk dice back.
                if (zombieBrainsV2 && hunkInHand && dice is HottieDice)
                {
                    cup.containedDice.Add(new HunkDice(Brushes.Black));
                }
            }

            // Additional rules for Version 2
            if (zombieBrainsV2)
            {
                // If the dice result is Double Brains add two to the player brains and temp brains scores
                if (dice.diceResult == "Double Brains")
                {
                    playerBrains += 2;
                    tempBrains += 2;
                }
                // If the result is double shotgun add two to the players shotgun score
                else if (dice.diceResult == "Double Shotgun")
                {
                    playerShotgun += 2;

                    // Special rule for Version 2:  If Hottie is in hand, and Hunk rolls double shotgun, add Hottie dice back.
                    if (hottieInHand && dice is HunkDice)
                    {
                        cup.containedDice.Add(new HottieDice(Brushes.Pink));
                    }
                }
            }

            // Update the labels to display new scores
            playerBrainsPoints.Text = playerBrains.ToString();
            playerShotgunPoints.Text = playerShotgun.ToString();
        }

        /// <summary>
        /// Handles the end of the game, determines the winner, and offers to restart.
        /// </summary>
        public void FinishGame()
        {
            // Bool for checking if the player wants to restart
            bool restart = false;

            // Temporary strings for checking the tie breaker results
            string player1Result = "1";
            string player2Result = "2";

            // If there is a tie at the end of the game, then run a tie breaker with two Red(hard) dice
            // and keep running the tie breaker until a winner is determined
            while (player1Brains == player2Brains && player1Brains == 13)
            {
                if (player1Brains == player2Brains || player1Result.Equals(player2Result))
                {
                    // Roll both the dice and save into the two temp strings
                    player1Result = new HardDice(Brushes.Red).Roll();
                    player2Result = new HardDice(Brushes.Red).Roll();

                    // If player 1 rolls a "Brains" and player 2 does not, then have player 1 win.
                    if (player1Result == "Brains" && player2Result != "Brains")
                    {
                        restart = MessageBox.Show("Player 1 Wins! Restart?", "Player 1 Wins! Restart??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        isPlayer1 = true;
                    }
                    // if player 2 rolls a "Brains" and player 1 does not, then have player 2 win
                    else if (player2Result == "Brains" && player1Result != "Brains")
                    {
                        restart = MessageBox.Show("Player 2 Wins! Restart?", "Player 2 Wins! Restart?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        isPlayer1 = false;
                    }
                }
            }

            // Check if the game has finished
            if (player1Brains == 13 || player2Brains == 13)
            {
                // If the game has finished, and player 2 has more brains than player 1, have player 2 win.
                if (player2Brains > player1Brains)
                {
                    // On finish, display a message box to the players, saying who has won, and asking if they want to restart
                    restart = MessageBox.Show("Player 2 Wins! Restart?", "Player 2 Wins! Restart?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    isPlayer1 = false;
                }
                // If the game has finished, and player 1 has more brains than player 2, have player 1 win
                else if (player1Brains > player2Brains)
                {
                    // On finish, display a message box to the players, saying who has won, and asking if they want to restart
                    restart = MessageBox.Show("Player 1 Wins! Restart?", "Player 1 Wins! Restart??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    isPlayer1 = true;
                }
            }
            
            // If the players decide to restart, reset everything
            if (restart)
            {
                player1Brains = 0;
                player2Brains = 0;
                player1Shotgun = 0;
                player2Shotgun = 0;
                _Player1BrainsPoints.Text = "0";
                _Player1ShotgunPoints.Text = "0";
                _Player2BrainsPoints.Text = "0";
                _Player1ShotgunPoints.Text = "0";
                LoadDice();

            }
        }

        /// <summary>
        /// Loads the appropriate dice into the game based on the selected version.
        /// </summary>
        public void LoadDice()
        {
            if (!zombieBrainsV2)
            {
                // Load dice for Version 1 (Easier Version)
                for (int i = 0; i < 6; i++)
                {
                    diceList.Add(new EasyDice(Brushes.Green));
                }
                for (int i = 0; i < 4; i++)
                {
                    diceList.Add(new MediumDice(Brushes.Yellow));
                }
                for (int i = 0; i < 3; i++)
                {
                    diceList.Add(new HardDice(Brushes.Red));
                }
            }
            else
            {
                // Load dice for Version 2 (Harder Version)
                for (int i = 0; i < 6; i++)
                {
                    diceList.Add(new EasyDice(Brushes.Green));
                }
                for (int i = 0; i < 2; i++)
                {
                    diceList.Add(new MediumDice(Brushes.Yellow));
                }
                for (int i = 0; i < 3; i++)
                {
                    diceList.Add(new HardDice(Brushes.Red));
                }
                diceList.Add(new HunkDice(Brushes.Black));
                diceList.Add(new HottieDice(Brushes.Pink));
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}