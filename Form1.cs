using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hostel_manzi
{
    public partial class Form1 : Form
    {
        private string connectionstring;
        private MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionstring = "server= localhost; database= hosteldb; Uid= root; Pwd=;";
            connection = new MySqlConnection(connectionstring);
            connection.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usenametext = textBox1.Text;
            var passwordtext = textBox2.Text;

            var selectcommand = new MySqlCommand();

            selectcommand.CommandText = ("select * from users where username=@username AND password=@password");
            selectcommand.Parameters.AddWithValue ("@username" , textBox1);
            selectcommand.Parameters.AddWithValue("@password", textBox2);

            selectcommand.Connection = connection;

            MySqlDataReader dataReader = selectcommand.ExecuteReader();

            if(dataReader.Read())
            {
                MessageBox.Show("Log in successfully");
            }

            else
            {
                MessageBox.Show("invalid username or password");
            }
        }
    }
}
