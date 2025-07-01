using System;
using System.Windows.Forms;
using System.IO;

namespace PizzaHut
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            xGrid.Columns.Add("A","OID");
            xGrid.Columns.Add("B", "OrderDate");
            xGrid.Columns.Add("C", "Customer Name");
            xGrid.Columns.Add("D", "PhoneNo");
            xGrid.Columns.Add("E", "PizzaName");
            xGrid.Columns.Add("F", "ColdDrink");
            xGrid.Columns.Add("G", "Salad");
            xGrid.Columns.Add("H", "Total");
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string line;
            StreamReader sr = new StreamReader("D://OrderHistory.txt");
            while (!sr.EndOfStream) 
            {
                line = sr.ReadLine();
                string[] data = line.Split(',');
                if(data.Length == 8)
                {
                    xGrid.Rows.Add(data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7]);
                }
            }
            sr.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.Hide();                    
            Form6 newForm = new Form6();  
            newForm.Show();                

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string oid = textBox1.Text;
            string line;
            bool found = false;
            xGrid.Rows.Clear();
            StreamReader sr = new  StreamReader("D://OrderHistory.txt");
            while(!sr.EndOfStream)
            {
            line = sr.ReadLine();
            string[] data = line.Split(',');
            if (data[0]== oid)
            {
                xGrid.Rows.Add(data);
                found = true;
                break;
            }
           
            }
            sr.Close();
             if(!found)
            {
                MessageBox.Show("Order Not Found!");
            }

            
        }
    }
}
