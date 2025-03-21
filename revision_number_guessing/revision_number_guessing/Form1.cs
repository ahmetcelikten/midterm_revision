using System;

namespace revision_number_guessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }
        private Random random = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int userGuess))
            {
                if (userGuess < randomNumber)
                {
                    label1.Text = "Too low! Try again.";
                }
                else if (userGuess > randomNumber)
                {
                    label1.Text = "Too high! Try again.";
                }
                else
                {
                    label1.Text = "Correct! You guessed it!";
                }
            }
            else
            {
                label1.Text = "Please enter a valid number!";
            }
        }
        
        private int randomNumber;
        private void StartNewGame()
        {
            randomNumber = random.Next(1, 101); 
            label1.Text = "Enter a number between 1 and 100.";
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}
