using System;
using System.Windows.Forms;
using System.IO;

namespace PizzaHut
{
    public partial class Form4 : Form
    {
        int sid = 100;
        public Form4()
        {
            InitializeComponent();
            xGrid.Columns.Add("A","SID");
            xGrid.Columns.Add("B", "SaladName");
            xGrid.Columns.Add("C", "Price");
        }

        private void xGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string saladname = textBox1.Text;
            string saladprice = textBox2.Text;
            if (saladname == "" || saladprice == "") { MessageBox.Show("Please Enter Name & Price!"); }
            else { MessageBox.Show("Data Added Sucessfully!"); }
            StreamWriter SW = new StreamWriter("D://Salad.txt",true);
            SW.WriteLine(sid+","+saladname+","+saladprice);
            SW.Close();
            xGrid.Rows.Add(sid,saladname,saladprice);
            saladname = saladprice = null;
            sid++;


            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("D://Salad.txt");
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] data = line.Split(',');
                if (data.Length == 3)
                {
                    xGrid.Rows.Add(data[0],data[1],data[2]);
                    int savedsid = int.Parse(data[0]);
                    if (savedsid >= sid) 
                    {
                        sid = savedsid + 1;
                    }


                }
            }
            sr.Close();
        }
    }
}
