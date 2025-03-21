namespace revision_calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PerformCalculation(char operation)
        {

            label3.Text = "";

            if (double.TryParse(textBox1.Text, out double num1) && double.TryParse(textBox2.Text, out double num2))
            {
                double result = 0;

                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                        {
                            label3.Text = "Cannot divide by zero!";
                            return;
                        }
                        break;
                }

                label3.Text = $"Result: {result:F2}";
            }
            else
            {
                label3.Text = "Please enter valid numbers.";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            PerformCalculation('+');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformCalculation('-');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PerformCalculation('*');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PerformCalculation('/');
        }
    }
}
