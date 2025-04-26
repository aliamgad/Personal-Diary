using Oracle.DataAccess.Client;
using Personal_Diary_Application;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PersonalDiaries
{
    public partial class Reminder : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        int cnt = 0;
        OracleConnection conn;
        public Reminder()
        {
            InitializeComponent();
        }

        private void Reminder_Load(object sender, EventArgs e)
        {
            if (Home.darkMode == "1")
            {
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(34, 36, 49);
            }
            else
            {
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                this.BackColor = Color.White;
            }
            textBox1.Text = "Enter Reminder Text";
            textBox1.ForeColor = Color.Gray;

            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select userid from  reminders where userid =:id";
            cmd.Parameters.Add("id", Home.userId);
            OracleDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
                label3.Text = "Yes";
            else
                label3.Text = "No";
            dr.Close();
            conn.Dispose();

        }

        private void clear_Reminder_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd4 = new OracleCommand();
            cmd4.Connection = conn;
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "Delete From reminders where userid=:usId";

            cmd4.Parameters.Add("usId", Home.userId);
            cmd4.ExecuteNonQuery();
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = "Enter Reminder Text";
            textBox1.ForeColor = Color.Gray;
            label3.Text = "No";

            cnt++;
            if (cnt == 5)
            {
                MessageBox.Show("برااااااحه علي الزرار");
                cnt = 0;
            }
            else
            {
                MessageBox.Show("Reminder deleted successful!");
            }
                
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("Pick Date From the FUTURE MORTY");
                return;
            }
            if (textBox1.Text == "Enter Reminder Text" || textBox1.Text == null)
            {
                MessageBox.Show("Write Something nice to yourself ;)");
                return;
            }

            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select userid from  reminders where userid =:id";
            cmd.Parameters.Add("id", Home.userId);
            OracleDataReader dr;
            dr = cmd.ExecuteReader();


            if (!dr.Read())
            {
                int maxId, last_reminder_Id;
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.CommandText = "getreminderid";
                cmd2.Parameters.Add("RID", OracleDbType.Int32, ParameterDirection.Output);
                cmd2.ExecuteNonQuery();
                try
                {
                    maxId = Convert.ToInt32(cmd2.Parameters["RID"].Value.ToString());
                    last_reminder_Id = maxId + 1;
                }
                catch
                {
                    last_reminder_Id = 1;
                }
                dr.Close();
                conn.Dispose();

                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "insert into reminders(reminderId, userId, reminderText, reminderDate) values (:remiId, :useId, :remiText, :remiDate)";
                cmd3.Parameters.Add("remiId", last_reminder_Id);
                cmd3.Parameters.Add("useId", Home.userId);
                cmd3.Parameters.Add("remiText", textBox1.Text.ToString());

                cmd3.Parameters.Add("remiDate", dateTimePicker1.Value);
                cmd3.ExecuteNonQuery();
                
                MessageBox.Show("Reminder inserted successful!");

            }
            else
            {
                OracleCommand cmd4 = new OracleCommand();
                cmd4.Connection = conn;
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update reminders set remindertext=:remidText , reminderdate=:remidDate where userid=:usId";
                cmd4.Parameters.Add("remidText", textBox1.Text);
                cmd4.Parameters.Add("remidDate", dateTimePicker1.Value);
                cmd4.Parameters.Add("usId", Home.userId);
                cmd4.ExecuteNonQuery();
                
                MessageBox.Show("Reminder updated successful!");
            }
            label3.Text = "Yes";
            dr.Close();
            conn.Dispose();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Reminder Text")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }


        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Reminder Text";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.Show();
            this.Hide();
        }
    }
}
