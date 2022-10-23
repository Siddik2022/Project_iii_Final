using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace login
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-LK9S857\SQLEXPRESS;Initial Catalog=file;Integrated Security=True");

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = textUser.Text;
            user_password = textPass.Text;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from Table_1 where username = '" +textUser.Text+"' AND password = '"+textPass.Text+"';",con);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                username = textUser.Text;
                user_password= textPass.Text;

                TemperatureConverter Form2 = new TemperatureConverter();
                Form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
