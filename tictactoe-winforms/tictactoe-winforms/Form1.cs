using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if(button1.Text == "X")
                button1.Text = "O";
            else
                button1.Text = "X";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "X")
                button2.Text = "O";
            else      
                button2.Text = "X";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "X")
                button3.Text = "O";
            else      
                button3.Text = "X";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "X")
                button4.Text = "O";
            else      
                button4.Text = "X";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "X")
                button5.Text = "O";
            else      
                button5.Text = "X";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "X")
                button6.Text = "O";
            else      
                button6.Text = "X";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "X")
                button7.Text = "O";
            else      
                button7.Text = "X";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "X")
                button8.Text = "O";
            else      
                button8.Text = "X";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "X")
                button9.Text = "O";
            else      
                button9.Text = "X";

        }
    }
}
