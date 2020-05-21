using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace USERTEST
{
    public partial class Form1 : Form
    {
        public Form1()
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
            dtDim = DataBase.ReadDB(6);
            //DataTable dtDimDoorColor = dtDim.AsEnumerable().Distinct().CopyToDataTable();
            view = new DataView(dtDim);
            view.Sort = "Color ASC";
            DataTable distinctDTCorColor = view.ToTable(true, "Color");

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
            comboBox5.DisplayMember = "Color";
            comboBox5.ValueMember = "Color";
            comboBox5.DataSource = distinctDTCorColor;

            

        }



        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        int A=1;
        double boxHeight = 0;
        kitBox kitBox = new kitBox(new List<Box>());
        double width, depth;
        string boxColor;
        string angleColor;
        string cups;

        private void button1_Click_1(object sender, EventArgs e)
        {

            panel2.Visible = true;
            List<string> colors = kitBox.getAllColors();
            List<string> cups = kitBox.getAllCups();
            List<string> doorcolors = kitBox.getAllDoorColors();
            List<double> heights = kitBox.getAllHeights();
            //List<int> ab = new List<int>() { 32, 42, 52, 42 };
            //int[] a = { 32, 42, 52 };
            string aa = "(" + string.Join(", ", heights) + ")";
            string color = "( '" + string.Join("', '", colors) + "' )";
            string doorcolor = "( '" + string.Join("', '", doorcolors) + "' )";
            string angColor = "'" + angleColor + "'";
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

            foreach (string element in cups)
            {
                if (element == "Yes")
                {
                    queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
                    "FROM Parts WHERE  Ref='Coupelles' ";
                    cmd.CommandText = queryString;
                    da.Fill(dt);
                    break;
                }
            }
          
            queryString = "SELECT ID, Ref, Code, Height, Depth, Width, Color, InStock, Client_Price " +
            "FROM Parts WHERE Color = " + angColor + "AND  Ref='Cornières' ";
            cmd.CommandText = queryString;
            da.Fill(dt);

            dataGridView2.DataSource = dt;
            connection.Close();
            button1.Visible = false;
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

        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            double Height = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells[4].Value);
            dataGridView1.Rows.RemoveAt(rowIndex);
            kitBox.RemoveAt(rowIndex);
            for (int i = rowIndex; rowIndex < A - 1 && i < A - 2; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
            A--;
            button4.Visible = true;
            textBox4.Text = A.ToString();
            boxHeight = boxHeight - Height  - 4;
            textBox1.Text = boxHeight.ToString();
            if (A < 2)
            {
                button6.Visible = false;
            }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            boxHeight = 0;
            //dataGridView1.Refresh();
            kitBox.Clear();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            boxColor = (comboBox3.SelectedItem as DataRowView)["Color"].ToString();
            angleColor = (comboBox5.SelectedItem as DataRowView)["Color"].ToString();
            string doorColor = (comboBox6.SelectedItem as DataRowView)["Color"].ToString();
            double height = Convert.ToDouble((comboBox1.SelectedItem as DataRowView)["Height"]);
            width = Convert.ToDouble((comboBox2.SelectedItem as DataRowView)["Width"]);
            depth = Convert.ToDouble((comboBox4.SelectedItem as DataRowView)["Depth"]);
            double[] dimension = { height, width, depth };
            bool doors = checkBox1.Checked;
            cups = "Yes";
                         
            if ((boxHeight + 4 + height) > 375)
            {
                MessageBox.Show("You have exceeded the maximum KitBox height capability ! Choice a smaller height or make a new configuration ");

            }
            else
            {
                
                boxHeight = boxHeight + 4 + height;
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
                    label3.Visible = false;
                    comboBox6.Visible = false;
                }
                row.Cells[2].Value = cups;
                row.Cells[3].Value = boxColor;
                row.Cells[4].Value = height;
                dataGridView1.Rows.Add(row);
                row.Cells[0].Value = A;
                Inventory inventory = new Inventory(new List<Part>());
                kitBox.Add(new Box(A, doorColor, dimension, boxColor, inventory, cups));
                A++;

                if (A > 7)
                {
                    button4.Visible = false;
                }
                if (A > 0)
                {
                    button6.Visible = true;
                }
            }

        }
    }
}
