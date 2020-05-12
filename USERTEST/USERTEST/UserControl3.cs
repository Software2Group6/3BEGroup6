using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USERTEST
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Storekeeper" && textBox5.Text == "Kimmy90")
            {
                panel1.Visible = true;
            }

            else if (textBox4.Text == "Secretary" && textBox5.Text == "Bambou79")
            {
                panel1.Visible = true;
            }

            else if (textBox4.Text == "")
            {
                MessageBox.Show("Login cannot be empty");
            }

            else if (textBox5.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }

            else
            {
                MessageBox.Show("Incorrect login or password ");
            }
        }
    
    }
}
