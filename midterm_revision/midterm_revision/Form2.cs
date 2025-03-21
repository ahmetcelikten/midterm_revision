using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace midterm_revision
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            progressBar1.Value = 0;
            label1.Text = "Progress: %0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;
                label1.Text = $"Progress: %{progressBar1.Value}";
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Task Completed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            }
        }
    }
}
