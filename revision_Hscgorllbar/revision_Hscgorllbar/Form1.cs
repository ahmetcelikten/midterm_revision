using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revision_Hscgorllbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateColor();

            hScrollBarRed.Scroll += (s, e) => UpdateColor();
            hScrollBarGreen.Scroll += (s, e) => UpdateColor();
            hScrollBarBlue.Scroll += (s, e) => UpdateColor();
            numericUpDown1.ValueChanged += (s, e) => UpdateColor();
            btnReset.Click += (s, e) => ResetColor();
        }

        private void UpdateColor()
        {
            int red = hScrollBarRed.Value;
            int green = hScrollBarGreen.Value;
            int blue = hScrollBarBlue.Value;
            int alpha = decimal.ToInt32(numericUpDown1.Value * 2.55m);

            lblColor.BackColor = Color.FromArgb(alpha, red, green, blue);
        }

        private void ResetColor()
        {
            hScrollBarRed.Value = 0;
            hScrollBarGreen.Value = 0;
            hScrollBarBlue.Value = 0;
            numericUpDown1.Value = 100;
            UpdateColor();
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
