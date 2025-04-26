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
    public partial class Tags: Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public Tags()
        {
            InitializeComponent();
        }

        private void Tags_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            if (Home.darkMode == "1")
            {

                this.BackColor = Color.FromArgb(34, 36, 49);
            }
            else
            {
                this.BackColor = Color.White;
            }

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select tagName from Tags where userId =: user_id";
            cmd.Parameters.Add("user_id", Login.user_id);
            cmd.CommandType = CommandType.Text;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());
            }

            reader.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            int newID, maxID;

            string new_tag = textBox1.Text.ToString();

            OracleCommand getIdCmd = new OracleCommand("GetTagID", conn);
            getIdCmd.CommandType = CommandType.StoredProcedure;
            getIdCmd.Parameters.Add("TID", OracleDbType.Int32).Direction = ParameterDirection.Output;

            getIdCmd.ExecuteNonQuery();

            try
            {
                maxID = Convert.ToInt32(getIdCmd.Parameters["TID"].Value.ToString());
                newID = maxID + 1;
            }
            catch
            {
                newID = 1;
            }



            OracleCommand insertCmd = new OracleCommand();
            insertCmd.Connection = conn;

            string username = Login.username;
        


            insertCmd.CommandText = "Insert INTO Tags (tagId, userId, tagName) VALUES (:id, :userid, :new_tag)";
            insertCmd.CommandType = CommandType.Text;

            insertCmd.Parameters.Add("id", OracleDbType.Int32).Value = newID;
            insertCmd.Parameters.Add("userid", OracleDbType.Int32).Value = Login.user_id;
            insertCmd.Parameters.Add("new_tag", OracleDbType.Varchar2).Value = textBox1.Text;

            int rowsInserted = insertCmd.ExecuteNonQuery();

            if (rowsInserted > 0)
            {
                MessageBox.Show("Tag added successfully!");
                
            }
            else
            {
                MessageBox.Show("Insertion failed.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "Delete from Tags where userId =: u_id and tagName =: t_name";
            cmd.Parameters.Add("u_id", Login.user_id);
            cmd.Parameters.Add("t_name", comboBox1.SelectedItem.ToString());
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            MessageBox.Show("Done deletion");
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.Show();
            this.Close();
        }
    }
}
