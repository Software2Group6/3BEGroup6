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

            DataTable dtDim = new DataTable();
            DataView view;

            dtDim = DataBase.ReadDB(1);
            //DataTable dtDimHeight = dtDim.AsEnumerable().Distinct().CopyToDataTable();
            view = new DataView(dtDim);
            view.Sort = "Height ASC";
            DataTable distinctDTHeight = view.ToTable(true, "Height");
            dtDim = DataBase.ReadDB(2);
            //DataTable dtDimWidth = dtDim.AsEnumerable().Distinct().CopyToDataTable();
            view = new DataView(dtDim);
            view.Sort = "Width ASC";
            DataTable distinctDTWidth = view.ToTable(true, "Width");
            dtDim = DataBase.ReadDB(3);
            //DataTable dtDimDepth = dtDim.AsEnumerable().Distinct().CopyToDataTable();
            view = new DataView(dtDim);
            view.Sort = "Depth ASC";
            DataTable distinctDTDepth = view.ToTable(true, "Depth");
            dtDim = DataBase.ReadDB(4);
            //DataTable dtDimBoxColor = dtDim.AsEnumerable().Distinct().CopyToDataTable();
            view = new DataView(dtDim);
            view.Sort = "Color ASC";
            DataTable distinctDTBoxColor = view.ToTable(true, "Color");
            dtDim = DataBase.ReadDB(5);
            //DataTable dtDimDoorColor = dtDim.AsEnumerable().Distinct().CopyToDataTable();
            view = new DataView(dtDim);
            view.Sort = "Color ASC";
            DataTable distinctDTDoorColor = view.ToTable(true, "Color");

            comboBox1.DisplayMember = "Height";
            comboBox1.ValueMember = "Height";
            comboBox1.DataSource = distinctDTHeight;
            comboBox2.DisplayMember = "Width";
            comboBox2.ValueMember = "Width";
            comboBox2.DataSource = distinctDTWidth;
            comboBox4.DisplayMember = "Depth";
            comboBox4.ValueMember = "Depth";
            comboBox4.DataSource = distinctDTDepth;
            comboBox3.DisplayMember = "Color";
            comboBox3.ValueMember = "Color";
            comboBox3.DataSource = distinctDTBoxColor;
            comboBox6.DisplayMember = "Color";
            comboBox6.ValueMember = "Color";
            comboBox6.DataSource = distinctDTDoorColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Box kitBox = new Box(new List<Locker>());
            //MessageBox.Show("kitBox created !");
            panel1.Visible = true;
            button3.Visible = false;
            button1.Visible = false;

        }
        int A = 1;
        double boxHeight = 0;


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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label5.Visible = false;
            comboBox2.Visible = false;
            comboBox4.Visible = false;

            string boxColor = (comboBox3.SelectedItem as DataRowView)["Color"].ToString();
            string doorColor = (comboBox6.SelectedItem as DataRowView)["Color"].ToString();
            double height = Convert.ToDouble((comboBox1.SelectedItem as DataRowView)["Height"]);
            double width = Convert.ToDouble((comboBox2.SelectedItem as DataRowView)["Width"]);
            double depth = Convert.ToDouble((comboBox4.SelectedItem as DataRowView)["Depth"]);
            double[] dimension = { height, width, depth };
            bool doors = checkBox1.Checked;
            string cups = "Yes";
            boxHeight += height;

            if (doors == false || doorColor == "Verre")
            {
                cups = "None";
            }

            panel2.Visible = true;
            tableLayoutPanel1.Visible = true;
            label10.Visible = true;
            textBox1.Text = boxHeight.ToString();
            textBox2.Text = width.ToString();
            textBox3.Text = depth.ToString();

            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = A;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                row.Cells[1].Value = doorColor;
            }
            else
            {
                row.Cells[1].Value = "None";
            }
            row.Cells[2].Value = cups;
            row.Cells[3].Value = boxColor;
            row.Cells[4].Value = height;
            dataGridView1.Rows.Add(row);

            Inventory inventory = new Inventory(new List<Part>());
            Locker Locker = new Locker(dimension, boxColor, inventory);

            A++;

            if (A > 7)
            {
                button4.Visible = false;
            }



        }
    }
}
