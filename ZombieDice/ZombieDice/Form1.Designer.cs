namespace ZombieDice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            _Player1BrainsPoints = new Label();
            _Player1ShotgunPoints = new Label();
            _Player2ShotgunPoints = new Label();
            _Player2BrainsPoints = new Label();
            label5 = new Label();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(362, 379);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Roll";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 387);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 7;
            label1.Text = "P1 Brains Dice";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 47);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 8;
            label2.Text = "P2 Brains Dice";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(535, 387);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 9;
            label3.Text = "P1 Shotgun Dice";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(535, 47);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 10;
            label4.Text = "P2 Shotgun Dice";
            // 
            // _Player1BrainsPoints
            // 
            _Player1BrainsPoints.AutoSize = true;
            _Player1BrainsPoints.Location = new Point(162, 412);
            _Player1BrainsPoints.Name = "_Player1BrainsPoints";
            _Player1BrainsPoints.Size = new Size(13, 15);
            _Player1BrainsPoints.TabIndex = 18;
            _Player1BrainsPoints.Text = "0";
            // 
            // _Player1ShotgunPoints
            // 
            _Player1ShotgunPoints.AutoSize = true;
            _Player1ShotgunPoints.Location = new Point(616, 412);
            _Player1ShotgunPoints.Name = "_Player1ShotgunPoints";
            _Player1ShotgunPoints.Size = new Size(13, 15);
            _Player1ShotgunPoints.TabIndex = 19;
            _Player1ShotgunPoints.Text = "0";
            // 
            // _Player2ShotgunPoints
            // 
            _Player2ShotgunPoints.AutoSize = true;
            _Player2ShotgunPoints.Location = new Point(616, 21);
            _Player2ShotgunPoints.Name = "_Player2ShotgunPoints";
            _Player2ShotgunPoints.Size = new Size(13, 15);
            _Player2ShotgunPoints.TabIndex = 20;
            _Player2ShotgunPoints.Text = "0";
            // 
            // _Player2BrainsPoints
            // 
            _Player2BrainsPoints.AutoSize = true;
            _Player2BrainsPoints.Location = new Point(162, 21);
            _Player2BrainsPoints.Name = "_Player2BrainsPoints";
            _Player2BrainsPoints.Size = new Size(13, 15);
            _Player2BrainsPoints.TabIndex = 21;
            _Player2BrainsPoints.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(376, 61);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 22;
            label5.Text = "Player 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(376, 412);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 23;
            label6.Text = "Player 1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-1, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(802, 459);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(12, 61);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(100, 309);
            richTextBox1.TabIndex = 24;
            richTextBox1.Text = "Click on the cup (Blue Circle) to pick 3 dice randomly.\n\nClick the roll button to roll the dice.\n\nDuring your turn, you can choose to continue to get more brains.";
            // 
            // richTextBox2
            // 
            richTextBox2.Enabled = false;
            richTextBox2.Location = new Point(688, 61);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(100, 309);
            richTextBox2.TabIndex = 25;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 43);
            label7.Name = "label7";
            label7.Size = new Size(123, 15);
            label7.TabIndex = 26;
            label7.Text = "Rules and Instructions";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(678, 43);
            label8.Name = "label8";
            label8.Size = new Size(123, 15);
            label8.TabIndex = 27;
            label8.Text = "Rules and Instructions";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(_Player2BrainsPoints);
            Controls.Add(_Player2ShotgunPoints);
            Controls.Add(_Player1ShotgunPoints);
            Controls.Add(_Player1BrainsPoints);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MouseClick += Form1_MouseClick;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label _Player1BrainsPoints;
        private Label _Player1ShotgunPoints;
        private Label _Player2ShotgunPoints;
        private Label _Player2BrainsPoints;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Label label7;
        private Label label8;
    }
}
