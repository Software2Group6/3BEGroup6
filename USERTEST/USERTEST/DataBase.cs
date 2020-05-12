using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace USERTEST
{

    public class DataBase
    {
        public static DataTable ReadDB(int choice)  //Method to read the DB
        {
            try
            {
                OleDbConnection connection;
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=..\..\..\..\Kitbox.accdb;Persist Security Info=False;";
                connection.Open();
                string queryString;

                //CheckConnection.Text = "Connection established";
                switch (choice)
                {
                    case 1:
                        queryString = "SELECT Height FROM Parts WHERE Ref='Tasseau' ";
                        break;
                    case 2:
                        queryString = "SELECT Width FROM Parts WHERE Ref='Traverse Ar' ";
                        break;
                    case 3:
                        queryString = "SELECT Depth FROM Parts WHERE Ref='Traverse GD' ";
                        break;
                    case 4:
                        queryString = "SELECT Color FROM Parts WHERE Ref='Panneau GD' ";
                        break;
                    case 5:
                        queryString = "SELECT Color FROM Parts WHERE Ref='Porte' ";
                        break;
                    case 6:
                        queryString = "SELECT Color FROM Parts WHERE Ref='Cornières' ";
                        break;
                    default:
                        queryString = null;
                        break;
                }
                //string queryString = "SELECT * FROM Parts ";
                // declare oleDb command object 
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText = queryString;
                // declare data reader object 
                OleDbDataReader dbReader = null;
                dbReader = cmd.ExecuteReader();
                DataTable rep = new DataTable();

                rep = GetData(dbReader);

                dbReader.Close();
                connection.Close();
                return rep;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion to Database failed :" + ex.ToString());
                return null;
            }
        }

        public static DataTable GetData(OleDbDataReader dbReader)
        {

            DataTable dtDim = new DataTable();
            dtDim.Load(dbReader);
            return dtDim;
        }

    }
}

