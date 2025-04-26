using Oracle.DataAccess.Client;
using Personal_Diary_Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PersonalDiaries
{
    public partial class Login: Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;

        public static string user_id;
        public static string username;
        public static string password;
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            textBox1.Text = "Enter Username";
            textBox2.Text = "Enter Passowrd";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Username" || textBox2.Text == "Enter Passowrd")
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }
            username = textBox1.Text.ToString();
            password = textBox2.Text.ToString();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT count(*) FROM Users WHERE username = :username AND password = :password";
            cmd.Parameters.Add("username", username);
            cmd.Parameters.Add("password", password);
            cmd.CommandType = CommandType.Text;


            //OracleDataReader reader = cmd.ExecuteReader();

            //if (reader.Read())
            //{
            //    user_id = reader[0].ToString();
            //    MessageBox.Show("Login successful!");
            //    Home f = new Home();
            //    f.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid username or password.");
            //}

            int userExists = Convert.ToInt32(cmd.ExecuteScalar());

            if (userExists > 0)
            {
                MessageBox.Show("Login successful!");
                Home f = new Home();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WelcomeMenu form = new WelcomeMenu();
            form.Show();
            this.Hide();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Passowrd")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Passowrd";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
