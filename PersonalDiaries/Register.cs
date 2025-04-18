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

namespace PersonalDiaries
{
    public partial class Register: Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int newID, maxID;

            try
            {

                OracleCommand check_existing_username = new OracleCommand();
                check_existing_username.Connection = conn;
                check_existing_username.CommandText = "SELECT COUNT(*) FROM Users WHERE username = :username";
                check_existing_username.CommandType = CommandType.Text;
                check_existing_username.Parameters.Add("username", OracleDbType.Varchar2).Value = textBox1.Text;

                int count = Convert.ToInt32(check_existing_username.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Username already exists. Please choose another one.");
                    return;
                }

                // --- Get max userId using the stored procedure ---
                OracleCommand getIdCmd = new OracleCommand("GetUserID", conn);
                getIdCmd.CommandType = CommandType.StoredProcedure;
                getIdCmd.Parameters.Add("UID", OracleDbType.Int32).Direction = ParameterDirection.Output;

                getIdCmd.ExecuteNonQuery();

                try
                {
                    maxID = Convert.ToInt32(getIdCmd.Parameters["UID"].Value.ToString());
                    newID = maxID + 1;
                }
                catch
                {
                    newID = 1;
                }

                // --- Insert new user ---
                OracleCommand insertCmd = new OracleCommand();
                insertCmd.Connection = conn;
                insertCmd.CommandText = "INSERT INTO Users (userId, username, email, password) VALUES (:userId, :username, :email, :password)";
                insertCmd.CommandType = CommandType.Text;

                insertCmd.Parameters.Add("userId", OracleDbType.Int32).Value = newID;
                insertCmd.Parameters.Add("username", OracleDbType.Varchar2).Value = textBox1.Text;
                insertCmd.Parameters.Add("email", OracleDbType.Varchar2).Value = textBox2.Text;
                insertCmd.Parameters.Add("password", OracleDbType.Varchar2).Value = textBox3.Text;

                int rowsInserted = insertCmd.ExecuteNonQuery();

                if (rowsInserted > 0)
                {
                    MessageBox.Show("User registered successfully!");
                    Home f = new Home();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Registration failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            WelcomeMenu f = new WelcomeMenu();
            f.Show();
            this.Hide();
        }
    }
}
