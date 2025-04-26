using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using PersonalDiaries;

namespace Personal_Diary_Application
{
    public partial class Home : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;

        public static string darkMode;
        public static bool isNew;
        public static int userId;
        public static int diaryId; 
        public Home()
        {
            InitializeComponent();
            bool isAdmin = Login.username.Equals("admin", StringComparison.OrdinalIgnoreCase) && Login.password.Equals("1", StringComparison.OrdinalIgnoreCase);

            if (isAdmin)
                button1.Visible = true;
            else
                button1.Visible = false;
        }
        
        private void dark_mode_btn_CheckedChanged(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            

            if (dark_mode_btn.Checked)
            {
                darkMode = "1";
                cmd.CommandText = "update Users set darkmode = 1 where username =:userName";
                this.BackColor = Color.FromArgb(34, 36, 49);
                dark_mode_btn.ForeColor = Color.White;
            }
            else
            {
                darkMode = "0";
                cmd.CommandText = "update Users set darkMode = 0 where username =:userName";
                this.BackColor = Color.White;
                dark_mode_btn.ForeColor = Color.Black;
            }

            cmd.Parameters.Add("userName", Login.username);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select userid from  Users where username =:userName";
            cmd2.Parameters.Add("userName", Login.username);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            userId = Convert.ToInt32(dr2[0]);
            dr2.Close();
            conn.Dispose();


            //////////////////////////////////////////////////////////////////////////////
            string cmdstr = @"SELECT 
                            d.diaryid ,d.title, t.tagName,d.createdAt
                            FROM Diaries d
                            LEFT JOIN Tags t ON d.tagId = t.tagId
                            WHERE d.userId =:id";
            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, ordb);
            adapter.SelectCommand.Parameters.Add("id", userId);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            




            //////////////////////////////////////////////////////////////////////////////
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select darkmode from  Users where username =:userName";
            cmd.Parameters.Add("userName", Login.username);
            OracleDataReader dr = cmd.ExecuteReader();

            dr.Read();

            darkMode = dr[0].ToString();

            if (darkMode == "1")
            {
                dark_mode_btn.Checked = true;
                this.BackColor = Color.FromArgb(34, 36, 49);
                dark_mode_btn.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                dark_mode_btn.ForeColor = Color.Black;
            }


            dr.Close();
            conn.Dispose();




            //////////////////////////////////////////////////////////////////////////////
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd3 = new OracleCommand();
            cmd3.Connection = conn;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select tagname from  tags where userid =:id";
            cmd3.Parameters.Add("id", userId);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            comboBox2.Items.Add("All");

            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3[0]);
            }

            dr3.Close();
            conn.Dispose();


            //////////////////////////////////////////////////////////////////////////////
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd5 = new OracleCommand();
            cmd5.Connection = conn;
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "select reminderdate , remindertext from reminders where userid =:id";
            cmd5.Parameters.Add("id", userId);
            OracleDataReader dr5 = cmd5.ExecuteReader();
            bool exist = false;
            if (dr5.Read())
            {
                DateTime reminderDate = Convert.ToDateTime(dr5["reminderdate"]);
                if (reminderDate.Date == DateTime.Now.Date)
                {
                    MessageBox.Show("Your Reminder for today: " + dr5[1]);
                    exist = true;
                }
                else if (reminderDate.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("You missed a reminder!");
                    exist = true;
                }
                
                if(exist == true)
                {
                    OracleCommand cmd4 = new OracleCommand();
                    cmd4.Connection = conn;
                    cmd4.CommandType = CommandType.Text;
                    cmd4.CommandText = "Delete From reminders where userid=:usId";

                    cmd4.Parameters.Add("usId", Home.userId);
                    cmd4.ExecuteNonQuery();
                    exist = false;
                }
            }

            dr5.Close();
            conn.Dispose();


        }

        private void New_Diary_Click(object sender, EventArgs e)
        {
            isNew = true;
            Diary form = new Diary();
            form.Show();
            this.Hide();
        }

        private void manageTags_Click(object sender, EventArgs e)
        {
            Tags form = new Tags();
            form.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmdstr;
            if (comboBox2.SelectedItem.ToString() == "All")
            {
                cmdstr = @"SELECT 
                            d.diaryid,d.title, t.tagName,d.createdAt
                            FROM Diaries d
                            LEFT JOIN Tags t ON d.tagId = t.tagId
                            WHERE d.userId =:id
                            ORDER by d.title";
            }
            else
            {
                cmdstr = @"SELECT 
                            d.diaryid,d.title, t.tagName,d.createdAt
                            FROM Diaries d
                            LEFT JOIN Tags t ON d.tagId = t.tagId
                            WHERE d.userId =:id and t.tagname=:name
                            ORDER by d.title";
            }
            
            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, ordb);
            adapter.SelectCommand.Parameters.Add("id", userId);
            
            if(comboBox2.SelectedItem.ToString() != "All")
            {
                adapter.SelectCommand.Parameters.Add("name", comboBox2.SelectedItem.ToString());
            }
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                diaryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                isNew = false;

                Diary form = new Diary();
                form.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Please select a valid diary entry.");
                return;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WelcomeMenu form = new WelcomeMenu();
            form.Show();
            this.Hide();
        }

        private void reminder_Button_Click(object sender, EventArgs e)
        {
            Reminder form = new Reminder();
            form.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (!Login.username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            //{
            //    MessageBox.Show("Access denied.");
            //    return;
            //}

            AdminForm form = new AdminForm();
            form.Show();
            this.Hide();
        }
    }
}