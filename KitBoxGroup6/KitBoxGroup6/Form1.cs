using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KitBoxGroup6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            comboBox1.Items.Add(32);
            comboBox2.Items.Add(42);
            comboBox3.Items.Add("red");
            comboBox4.Items.Add(52);
            comboBox6.Items.Add("Green");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Box kitBox = new Box(new List<Locker>());
            //MessageBox.Show("kitBox created !");
            panel1.Visible = true;
            button4.Visible = false;

        }
        int A = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            string color = comboBox3.SelectedText;
            double height = Convert.ToDouble(comboBox1.SelectedItem);
            double width = Convert.ToDouble(comboBox2.SelectedItem);
            double depth = Convert.ToDouble(comboBox4.SelectedItem);
            double[] dimension = {height, width, depth};
            bool doors = checkBox1.Checked;

            panel2.Visible = true;

            CreateTextBoxes();


            Inventory inventory = new Inventory(new List<Part>());  
            Locker Locker = new Locker(dimension, color, inventory);

            //listBox1.Items.Add("Color : " + comboBox3.SelectedText);
            //listBox1.Items.Add("Height  : " + comboBox1.SelectedText);
            //listBox1.Items.Add("Width : " + comboBox2.SelectedText);
            //listBox1.Items.Add("Depth : " + comboBox4.SelectedText);

            if (A > 7)
            {
                button2.Visible = false;
            }



        }

        private void CreateTextBoxes()
        {
            TextBox tb = null;            
            tb = new TextBox();
            tb.Width = 400;
            this.panel2.Controls.Add(tb);
            tb.Top = A * 32;
            tb.Left = 15;
            string check = " : without ";
            if (checkBox1.CheckState == CheckState.Checked)
            {
                check = " : with ";
            }
            tb.Text = "Locker " + this.A.ToString() + check + comboBox6.SelectedItem + " doors" + " : " + " Color : " + comboBox3.SelectedItem
                + " Height : " + comboBox1.SelectedItem
                + " Width : " + comboBox2.SelectedItem
                + " Depth : " + comboBox4.SelectedItem;            
            A = A + 1;            
        }

  


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                label3.Visible = true;
                comboBox6.Visible = true;
            }
        }
    }
}
