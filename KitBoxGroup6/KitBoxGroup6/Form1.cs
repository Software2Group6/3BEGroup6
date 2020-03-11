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
            comboBox6.Items.Add("Verre");
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
            button1.Visible = false;

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
            string cups = "Yes";

            if (doors==false || comboBox6.SelectedItem == "Verre")
            {
                cups = "None";
            }

            panel2.Visible = true;

            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = A;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                row.Cells[1].Value = comboBox6.SelectedItem;
            }
            else
            {
                row.Cells[1].Value = "None";
            }
            row.Cells[2].Value = cups;
            row.Cells[3].Value = comboBox3.SelectedItem;
            row.Cells[4].Value = comboBox1.SelectedItem;
            dataGridView1.Rows.Add(row);

            Inventory inventory = new Inventory(new List<Part>());  
            Locker Locker = new Locker(dimension, color, inventory);

            A = A + 1;

            if (A > 7)
            {
                button2.Visible = false;
            }

            

        }

        private void CreateTextBoxesP2()
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

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

    }
}
