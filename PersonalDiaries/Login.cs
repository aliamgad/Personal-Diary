using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalDiaries
{
    public partial class Login: Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;


        public static String username = "";
        public static String password = "";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE username = :username AND password = :password";
            cmd.Parameters.Add("username", username);
            cmd.Parameters.Add("password", password);
            cmd.CommandType = CommandType.Text;


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
    }
}
