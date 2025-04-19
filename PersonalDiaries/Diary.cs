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
using Personal_Diary_Application;

namespace PersonalDiaries
{
    public partial class Diary : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        
        public Diary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( textBoxOFtitle.Text.Trim(' ').Length == 0 || textBox.Text.Trim(' ').Length == 0)
            {
                MessageBox.Show(" Nigga -___- ");
                return;
            }
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr=null;
            //Get User ID
            //cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select userid from  Users where username =:userName";
            //cmd.Parameters.Add("userName", Login.username);
            //dr = cmd.ExecuteReader();
            //dr.Read();
            //userId = Convert.ToInt32(dr[0]);
            //cmd.Parameters.Clear();

            //Get Tag ID
            int tagId=0;
            cmd.Connection = conn;
            if (comboBoxOFTags.SelectedItem != null)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select tagid from tags where tagname = :name";
                cmd.Parameters.Add("name", comboBoxOFTags.SelectedItem.ToString());
                dr = cmd.ExecuteReader();
                dr.Read();
                tagId = Convert.ToInt32(dr[0]);
                cmd.Parameters.Clear();
            }

            

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
                cmd.Parameters.Add("id", Home.userId);
                cmd.Parameters.Add("diaryid", last_diary_Id);
                cmd.Parameters.Add("title", textBoxOFtitle.Text);
                cmd.Parameters.Add("text", textBox.Text);
                if (tagId == 0)
                    cmd.Parameters.Add("tagid", DBNull.Value);
                else
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
                if (tagId == 0)
                    cmd.Parameters.Add("tagid", DBNull.Value);
                else
                    cmd.Parameters.Add("tagid", tagId);
                cmd.Parameters.Add("id", Home.userId);
                cmd.Parameters.Add("diaryid", Home.diaryId);
                MessageBox.Show("Updated");
            }



            cmd.ExecuteNonQuery();
            if(dr != null)
                dr.Close();
            conn.Dispose();

            Home form = new Home();
            form.Show();
            this.Hide();

        }

        private void Diary_Load(object sender, EventArgs e)
        {
            
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
            statusLabel.Text = "New Diary";

            if (!Home.isNew)
            {
                statusLabel.Text = "Edit Diary";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select title,text ,tagid from diaries where diaryid = :id";
                cmd.Parameters.Add("id",Home.diaryId);
                dr = cmd.ExecuteReader();
                dr.Read();
                textBoxOFtitle.Text = dr[0].ToString();
                textBox.Text = dr[1].ToString();
                if (dr[2] != DBNull.Value)
                    comboBoxOFTags.Text = tags[Convert.ToInt32(dr[2])-1];
                cmd.Parameters.Clear();
            }


            dr.Close();
            conn.Dispose();

            
        }

        private void back_Button_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.Show();
            this.Hide();
        }
    }
}
