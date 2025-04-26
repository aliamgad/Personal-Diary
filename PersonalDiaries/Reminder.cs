using Oracle.DataAccess.Client;
using Personal_Diary_Application;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalDiaries
{
    public partial class Reminder : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public Reminder()
        {
            InitializeComponent();
        }

        private void Reminder_Load(object sender, EventArgs e)
        {
            if (Home.darkMode == "1")
            {

                this.BackColor = Color.FromArgb(34, 36, 49);
            }
            else
            {
                this.BackColor = Color.White;
            }
            textBox1.Text = "Enter Reminder Text ";
            textBox1.ForeColor = Color.Gray;

            dateTimePicker1.Format = DateTimePickerFormat.Custom; // Use custom format
            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= DateTime.Now)
            {
                MessageBox.Show("Pick Date From the FUTURE MORTY");
                return;
            }
            if (textBox1.Text == null)
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

                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "insert into reminders values (:rId,:uId,:rText,:rDate)";
                cmd3.Parameters.Add("rId", last_reminder_Id);
                cmd3.Parameters.Add("uId", Home.userId);
                cmd3.Parameters.Add("rText", textBox1.Text);

                cmd3.Parameters.Add("rDate", OracleDbType.Varchar2).Value = "19-APR-2025";
                label3.Text = dateTimePicker1.Value.ToString("dd-MMM-yy").ToUpper();

                System.Diagnostics.Debug.WriteLine("SQL Query: " + cmd3.CommandText);
                foreach (OracleParameter param in cmd3.Parameters)
                {
                    System.Diagnostics.Debug.WriteLine($"Parameter: {param.ParameterName}, Value: {param.Value}, Type: {param.OracleDbType}");
                }
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Reminder inserted successful!");
            }
            else
            {
                OracleCommand cmd4 = new OracleCommand();
                cmd4.Connection = conn;
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update reminders set remindertext=:rText , reminderdate=:rDate where userid=:uId";
                cmd4.Parameters.Add("rText", textBox1.Text);
                cmd4.Parameters.Add("rDate", OracleDbType.Varchar2).Value = dateTimePicker1.Value.ToString("dd-MMM-yyyy").ToUpper();


                cmd4.Parameters.Add("uId", Home.userId);
                cmd4.ExecuteNonQuery();

                MessageBox.Show("Reminder updated successful!");
            }

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
            cmd4.CommandText = "Delete From reminders where userid=:uId";

            cmd4.Parameters.Add("uId", Home.userId);
            cmd4.ExecuteNonQuery();
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = "";
            MessageBox.Show("Reminder deleted successful!");
            conn.Dispose();
        }
    }
}
