using System;
using System.IO;
using System.Windows.Forms;

namespace PizzaHut
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadItems("D://Pizza.txt", comboBox1, "Pizza Not Included");
            LoadItems("D://Drink.txt", comboBox2, "Drink Not Included");
            LoadItems("D://Salad.txt", comboBox3, "Salad Not Included");

            
        }

        private void LoadItems(string filePath, ComboBox comboBox, string defaultOption)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(defaultOption);

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                    comboBox.Items.Add(parts[1]);
            }

            comboBox.SelectedIndex = 0;
        }

        private void UpdateTotal()
        {
            int pizza = GetPrice("D://Pizza.txt", comboBox1.Text);
            int drink = GetPrice("D://Drink.txt", comboBox2.Text);
            int salad = GetPrice("D://Salad.txt", comboBox3.Text);

            int total = pizza + drink + salad;
            textBox4.Text = total.ToString();
        }

        private int GetPrice(string filePath, string name)
        {
            if (string.IsNullOrEmpty(name) || name.Contains("Not Included"))
                return 0;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && parts[1] == name)
                {
                    int price;
                    if (int.TryParse(parts[2], out price))
                        return price;
                }
            }
            return 0;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string orderID = textBox1.Text.Trim();
            UpdateTotal();

            string[] newLine = {
                orderID,
                DateTime.Now.ToShortDateString(),
                textBox2.Text,
                textBox3.Text,
                comboBox1.Text,
                comboBox2.Text,
                comboBox3.Text,
                textBox4.Text
            };

            string[] allLines = File.ReadAllLines("D://OrderHistory.txt");
            bool updated = false;

            for (int i = 0; i < allLines.Length; i++)
            {
                var parts = allLines[i].Split(',');
                if (parts.Length == 8 && parts[0] == orderID)
                {
                    allLines[i] = string.Join(",", newLine);
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                File.WriteAllLines("D://OrderHistory.txt", allLines);
                MessageBox.Show("Order updated successfully!");
            }
            else
            {
                MessageBox.Show("Order ID not found.");
            }
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {
            string orderID = textBox1.Text.Trim();
            bool found = false;

            foreach (var line in File.ReadAllLines("D://OrderHistory.txt"))
            {
                var parts = line.Split(',');
                if (parts.Length == 8 && parts[0] == orderID)
                {
                    textBox2.Text = parts[2];
                    textBox3.Text = parts[3];
                    comboBox1.Text = parts[4];
                    comboBox2.Text = parts[5];
                    comboBox3.Text = parts[6];
                    textBox4.Text = parts[7];
                    found = true;
                    break;
                }
            }

            if (!found)
                MessageBox.Show("Order ID not found.");
        }

        private void button2_Click(object sender, EventArgs e)  // Clear
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)  
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }
    }
}
