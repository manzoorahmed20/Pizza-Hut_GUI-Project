using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PizzaHut
{
    public partial class Form5 : Form
    {
        int OID = 100;

        List<string> pizzaList = new List<string>();
        List<string> drinkList = new List<string>();
        List<string> saladList = new List<string>();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.Clear();
            pizzaList.Clear();  

            StreamReader sr = new StreamReader("D://Pizza.txt");
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] data = line.Split(',');
                if (data.Length == 3)
                {
                    comboBox1.Text = "Pizza Not Included";
                    comboBox1.Items.Add(data[1]);
                    pizzaList.Add(line);

                }
            }
            sr.Close();
            
            

            comboBox2.Items.Clear();
            drinkList.Clear();

            StreamReader sr2 = new StreamReader("D://Drink.txt");
            
                string line2;
                while (!sr2.EndOfStream)
                {
                    line2 = sr2.ReadLine();
                    string[] data = line2.Split(',');
                    if (data.Length == 3)
                    {
                        comboBox2.Text = "Drink Not Included";
                        comboBox2.Items.Add(data[1]); 
                        drinkList.Add(line2);      
                    }
                }
                sr2.Close();

                comboBox3.Items.Clear();
                saladList.Clear();

                StreamReader sr3 = new StreamReader("D://Salad.txt");
                string line3;
                while (!sr3.EndOfStream)
                {
                    line3 = sr3.ReadLine();
                    string[] data = line3.Split(',');
                    if (data.Length == 3)
                    {
                        comboBox3.Text = "Salad Not Included";
                        comboBox3.Items.Add(data[1]);
                        saladList.Add(line3);

                    }
                }
                sr3.Close();




                if (File.Exists("D://OrderHistory.txt"))
                {
                    OID = File.ReadAllLines("D://OrderHistory.txt").Length + 100;
                }
            }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (string line in pizzaList)
            {
                var parts = line.Split(',');
                if (parts[1] == comboBox1.Text)
                {
                    textBox3.Text = parts[2];
                    break;
                }
                
            }
            CalculateTotal();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string line2 in drinkList)
            {
                var parts = line2.Split(',');
                if (parts[1] == comboBox2.Text)
                {
                    textBox4.Text = parts[2];
                    break;
                }

            }
            CalculateTotal();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string line3 in saladList)
            {
                var parts = line3.Split(',');
                if (parts[1] == comboBox3.Text)
                {
                    
                    textBox5.Text = parts[2];
                    break;
                }


            }
            CalculateTotal();
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

         
      
    


        }
        private void CalculateTotal()
        {
            int p = 0, d = 0, s = 0;

            if (textBox3.Text != "") p = int.Parse(textBox3.Text);
            if (textBox4.Text != "") d = int.Parse(textBox4.Text);
            if (textBox5.Text != "") s = int.Parse(textBox5.Text);

            textBox6.Text = (p + d + s).ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            string name = textBox1.Text;
            string phone = textBox2.Text;
            int subtotal = int.Parse(textBox6.Text);
            string pizza = comboBox1.Text;
            string drink = comboBox2.Text;
            string salad = comboBox3.Text;
            string orderDate = DateTime.Now.ToString("yyyy-MM-dd");
            StreamWriter sr = new StreamWriter("D://OrderHistory.txt",true);
            sr.WriteLine(OID+","+orderDate+","+name+","+phone+","+pizza+","+drink+","+salad+","+subtotal);
            sr.Close();
            OID++;
            
                           
            textBox1.Clear();
            textBox2.Clear(); 
            textBox3.Clear(); 
            textBox4.Clear(); 
            textBox5.Clear(); 
            textBox6.Clear(); 

            
            comboBox1.Text = "Pizza Not Included";
            comboBox2.Text = "Drink Not Included";
            comboBox3.Text = "Salad Not Included";

          

            MessageBox.Show("Order Confirmed Successfully!");
        }

    }
}
