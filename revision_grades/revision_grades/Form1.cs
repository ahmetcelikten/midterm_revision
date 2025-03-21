namespace revision_grades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput(textBox1.Text, out double grade1) &&
                ValidateInput(textBox2.Text, out double grade2) &&
                ValidateInput(textBox3.Text, out double grade3))
            {
                double average = (grade1 + grade2 + grade3) / 3;
                label4.Text = $"Average Grade: {average:F2}";
            }
            else
            {
                label4.Text = "Please enter valid grades (0-100).";
            }
        }
        private bool ValidateInput(string input, out double grade)
        {
            if (double.TryParse(input, out grade) && grade >= 0 && grade <= 100)
            {
                return true;
            }
            grade = 0;
            return false;
        }
    }
}
