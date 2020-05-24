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

namespace USERTEST
{
    public partial class Form2 : Form
    {
        DataTable dt;
        OleDbConnection connection;
        public Form2()
        {

            InitializeComponent();
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=..\..\..\..\Kitbox.accdb;Persist Security Info=False;";
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            string query = "select * from Parts";
            command.CommandText = query;

            OleDbDataAdapter da = new OleDbDataAdapter(command);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Title"].Visible = false;
            dataGridView1.Columns["Compliance Asset Id"].Visible = false;
            connection.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Parts";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Title"].Visible = false;
                dataGridView1.Columns["Compliance Asset Id"].Visible = false;
                connection.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new Form3();
            f1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "DELETE from Parts where Code='" + textBox1.Text + "';";

                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Data deleted");
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "Code like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "UPDATE Parts SET InStock='" + textBox5.Text + "'Where Code= '" + textBox4.Text + "';";

                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Data update");
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "Code like '%" + textBox4.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new Form1();
            f1 .ShowDialog();
        }
    }
}
