using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace USERTEST
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            

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

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        int A = 1;
        double boxHeight = 0;
        kitBox kitBox = new kitBox(new List<Box>());
        double width, depth;
        string boxColor;

        private void button4_Click(object sender, EventArgs e)
        {
            boxColor = (comboBox3.SelectedItem as DataRowView)["Color"].ToString();
            string doorColor = (comboBox6.SelectedItem as DataRowView)["Color"].ToString();
            double height = Convert.ToDouble((comboBox1.SelectedItem as DataRowView)["Height"]);
            width = Convert.ToDouble((comboBox2.SelectedItem as DataRowView)["Width"]);
            depth = Convert.ToDouble((comboBox4.SelectedItem as DataRowView)["Depth"]);
            double[] dimension = { height, width, depth }; 
            bool doors = checkBox1.Checked;
            string cups = "Yes";
            boxHeight += height;

            if (doors == false || doorColor == "Verre")
            {
                cups = "None";
            }

            dataGridView1.Visible = true;

            tableLayoutPanel1.Visible = true;
            label10.Visible = true;
            textBox1.Text = boxHeight.ToString();
            textBox2.Text = width.ToString();
            textBox3.Text = depth.ToString();
            textBox4.Text = A.ToString();

            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = A;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                row.Cells[1].Value = doorColor;
                label6.Visible = true;
                comboBox6.Visible = true;
            }
            else
            {
                row.Cells[1].Value = "None";
                doorColor = "None";
                label6.Visible = false;
                comboBox6.Visible = false;
            }
            row.Cells[2].Value = cups;
            row.Cells[3].Value = boxColor;
            row.Cells[4].Value = height;
            dataGridView1.Rows.Add(row);

            Inventory inventory = new Inventory(new List<Part>());            
            kitBox.Add(new Box(A, doorColor, dimension, boxColor, inventory, cups));


            A++;

            if (A > 7)
            {
                button4.Visible = false;
            }

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                label3.Visible = true;
                comboBox6.Visible = true;
            }
            else
            {
                label3.Visible = false;
                comboBox6.Visible = false;
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            //string boxColor2 = "'" + boxColor + "'";
            List<string> colors = kitBox.getAllColors();
            List<string> doorcolors = kitBox.getAllDoorColors();
            List<double> heights = kitBox.getAllHeights();
            //List<int> ab = new List<int>() { 32, 42, 52, 42 };
            //int[] a = { 32, 42, 52 };
            string aa = "(" + string.Join(", ", heights) + ")";
            string color = "( '" + string.Join("', '", colors) + "' )";
            string doorcolor = "( '" + string.Join("', '", doorcolors) + "' )";
            OleDbConnection connection;
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=..\..\..\..\Kitbox.accdb;Persist Security Info=False;";
            connection.Open();
            string queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
                            "FROM Parts WHERE Height IN " + aa + " AND  Ref='Tasseau' ";            

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = queryString;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);

            queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
    "FROM Parts WHERE Color IN " + color + " AND Depth = " + depth + " AND Height IN " + aa + "AND Ref='Panneau GD' ";
            cmd.CommandText = queryString;
            da.Fill(dt);

            queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
            "FROM Parts WHERE Color IN " + color + " AND Width = " + width + "AND Height IN " + aa + " AND  Ref='Panneau Ar' ";
            cmd.CommandText = queryString;
            da.Fill(dt);

            queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
                "FROM Parts WHERE Width = " + width + "AND  (Ref='Traverse Av' OR Ref='Traverse Ar') ";
            cmd.CommandText = queryString;
            da.Fill(dt);

            queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
                "FROM Parts WHERE Depth = " + depth + "AND  Ref='Traverse GD' ";
            cmd.CommandText = queryString;
            da.Fill(dt);

            queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
                "FROM Parts WHERE Color IN " + color + "AND Depth = " + depth + "AND Width= " + width + "AND  Ref='Panneau HB' ";
            cmd.CommandText = queryString;
            da.Fill(dt);


            queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
            "FROM Parts WHERE Width = " + width + "AND Color IN " + doorcolor + " AND Height IN " + aa + "AND  Ref='Porte' ";
            cmd.CommandText = queryString;
            da.Fill(dt);

            dataGridView2.DataSource = dt;
            connection.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
