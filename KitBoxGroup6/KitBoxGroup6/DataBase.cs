using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

public class DataBase
{
    public static void ReadDB()  //Method to read the DB
    {
        try
        {
            OleDbConnection connection;
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=..\..\..\..\Kitbox.accdb;Persist Security Info=False;";
            connection.Open();
            //CheckConnection.Text = "Connection established";
            string queryString = "SELECT * FROM Parts ";
            // declare oleDb command object 
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = queryString;
            // declare data reader object 
            OleDbDataReader dbReader = null;
            dbReader = cmd.ExecuteReader();


            // Show first row 
            dbReader.Read();
            int i;
            for (i = 0; i < 17; i++)
            {
                //textBox1.Text += dbReader[i].ToString();
            }

            dbReader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Connexion to Database failed" + ex.ToString());
        }
    }

}
	            
