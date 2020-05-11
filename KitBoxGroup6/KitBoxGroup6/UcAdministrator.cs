using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitBoxGroup6
{
    public partial class UcAdministrator : UserControl
    {
        public UcAdministrator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Storekeeper" && textBox5.Text == "Kimmy90")
            {
                
            }

            else if (textBox4.Text == "Secretary" && textBox5.Text == "Bambou79")
            {
                panel6.Visible = false;
            }

            else if (textBox4.Text == "" )
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

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
