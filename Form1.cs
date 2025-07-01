using System;

using System.Windows.Forms;

namespace PizzaHut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form7().Show();
        }

        private void addDrinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Are You Sure To Exit!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addPizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void addSaladToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void takeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }
    }
}
