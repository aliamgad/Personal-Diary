using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PersonalDiaries
{
    public partial class Diary : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public static int userId;
        public Diary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( textBoxOFtitle.Text.Trim(' ').Length == 0 || textBox.Text.Trim(' ').Length == 0 || comboBoxOFTags.Text.Trim(' ').Length == 0)
            {
                MessageBox.Show(" Nigga -___- ");
                return;
            }
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;
            //Get User ID
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select userid from  Users where username =:userName";
            cmd.Parameters.Add("userName", Login.username);
            dr = cmd.ExecuteReader();
            dr.Read();
            userId = Convert.ToInt32(dr[0]);
            cmd.Parameters.Clear();

            //Get Tag ID
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select tagid from tags where tagname = :name";
            cmd.Parameters.Add("name", comboBoxOFTags.SelectedItem.ToString());
            dr = cmd.ExecuteReader();
            dr.Read();
            int tagId = Convert.ToInt32(dr[0]);
            cmd.Parameters.Clear();

            

            cmd.CommandType = CommandType.Text;
            if(Home.isNew)
            {
                //Get Last Diary id + 1
                int maxId, last_diary_Id;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select max(diaryId) from Diaries";

                dr = cmd.ExecuteReader();
                try
                {
                    dr.Read();
                    maxId = Convert.ToInt32(dr[0]);
                    last_diary_Id = maxId + 1;
                }
                catch
                {
                    last_diary_Id = 1;
                }
                cmd.Parameters.Clear();

                cmd.CommandText = "Insert into diaries(userid, diaryid, title, text, tagid) values (:id,:diaryid,:title,:text,:tagid)";
                cmd.Parameters.Add("id", userId);
                cmd.Parameters.Add("diaryid", last_diary_Id);
                cmd.Parameters.Add("title", textBoxOFtitle.Text);
                cmd.Parameters.Add("text", textBox.Text);
                cmd.Parameters.Add("tagid", tagId);
                MessageBox.Show("Added");


            }
            else
            {

                cmd.CommandText = @"update diaries 
                                    set  title= :title , text= :text , tagid= :tagid
                                    where userid =:id and diaryid= :diaryid";

                cmd.Parameters.Add("title", textBoxOFtitle.Text);
                cmd.Parameters.Add("text", textBox.Text);
                cmd.Parameters.Add("tagid", tagId);
                cmd.Parameters.Add("id", userId);
                cmd.Parameters.Add("diaryid", Home.diaryId);
                MessageBox.Show("Updated");
            }

            Home form = new Home();
            form.Show();
            this.Hide();

            cmd.ExecuteNonQuery();
            dr.Close();
            conn.Dispose();
        }

        private void Diary_Load(object sender, EventArgs e)
        {
            //test
            Login.username = "ali";
            Home.isNew = false;
            Home.diaryId = 3;

            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;

            List<String> tags = new List<String>();
            //Get User ID
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select tagname from tags ORDER by tagid";
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBoxOFTags.Items.Add(dr[0]);
                tags.Add(dr[0].ToString());
            }

            if(!Home.isNew)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select title,text ,tagid from diaries where diaryid = :id";
                cmd.Parameters.Add("id",Home.diaryId);
                dr = cmd.ExecuteReader();
                dr.Read();
                textBoxOFtitle.Text = dr[0].ToString();
                textBox.Text = dr[1].ToString();
                comboBoxOFTags.Text = tags[Convert.ToInt32(dr[2])-1];
                cmd.Parameters.Clear();
            }

            dr.Close();
            conn.Dispose();

            //conn = new OracleConnection(ordb);
            //conn.Open();

            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select darkmode from  Users where username =:userName";
            //cmd.Parameters.Add("userName", Login.username);
            //OracleDataReader dr = cmd.ExecuteReader();


            //dr.Read();

            //if (dr[0].ToString() == "1")
            //{
            //    this.BackColor = Color.FromArgb(34, 36, 49);
            //    this.ForeColor = Color.White;
            //}
            //else
            //{
            //    this.BackColor = Color.White;
            //    this.ForeColor = Color.Black;
            //}

            //dr.Close();
            //conn.Dispose();
        }
    }
}
