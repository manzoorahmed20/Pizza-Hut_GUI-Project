using System;
using System.Windows.Forms;
using System.IO;

namespace PizzaHut
{
    public partial class Form3 : Form
    {
        int cid = 100;
        public Form3()
        {
            InitializeComponent();
            xGrid.Columns.Add("A","CID");
            xGrid.Columns.Add("B", "DrinkName");
            xGrid.Columns.Add("C", "Price");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string drinkname = textBox1.Text;
            string drinkprice = textBox2.Text;
            if (drinkname == "" || drinkprice == "")
            {
                MessageBox.Show("Please Enter Name & Price! ");
                return;
            }
            else 
            {
                MessageBox.Show("Data Added Successfully!");
            }
            StreamWriter sw = new StreamWriter("D://Drink.txt", true);
            sw.WriteLine(cid+","+drinkname+","+drinkprice);
            sw.Close();
            xGrid.Rows.Add(cid,drinkname,drinkprice);
            drinkname = drinkprice = null;
            cid++;


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("D://Drink.txt",true);
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] data = line.Split(',');
                if (data.Length == 3) 
                {
                    xGrid.Rows.Add(data[0],data[1],data[2]);
                    int savedcid = int.Parse(data[0]);
                    if (savedcid >= cid) 
                    {

                        cid = savedcid + 1;
                    }

                }
                
            }
            sr.Close();
        }
    }
}
