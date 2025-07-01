using System;
using System.Windows.Forms;
using System.IO;

namespace PizzaHut
{
    public partial class Form2 : Form
    {
        int pid = 100;
        public Form2()
        {
            InitializeComponent();
            xGrid.Columns.Add("A","PID");
            xGrid.Columns.Add("B","PizzaName");
            xGrid.Columns.Add("C","Price");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string pizzaname = textBox1.Text;
            string pizzaprice = textBox2.Text;

            if (pizzaname == "" || pizzaprice == "")
            {
                MessageBox.Show("Please Enter Name & Price");
                return;
            }
            else 
            {
                MessageBox.Show("Data Add Sucessfully");
            }
            StreamWriter SW = new StreamWriter("D://Pizza.txt", true);
            SW.WriteLine(pid+","+pizzaname+","+pizzaprice);
            SW.Close();
            xGrid.Rows.Add(pid, pizzaname, pizzaprice);
            textBox1.Text = textBox2.Text = null;
            pid++;
            
           
        }

        private void xGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            StreamReader abc = new StreamReader("D://Pizza.txt");
            string line;
            while (!abc.EndOfStream)
            {
                line = abc.ReadLine();
                string[] data = line.Split(',');

                if (data.Length == 3) 
                {
                    xGrid.Rows.Add(data[0],data[1],data[2]);

                    int savedpid = int.Parse(data[0]);

                    if (savedpid >= pid)
                    {
                      pid =  savedpid + 1;
                    }
                }
            }
            abc.Close();
        
        }
    }
}
