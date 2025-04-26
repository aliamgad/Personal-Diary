using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Personal_Diary_Application;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                if(textBoxOFtitle.Text == "Title Here...." || textBox.Text == "Entry Here.....")
                {
                    MessageBox.Show("Please enter a title and text for the diary entry.");
                    return;
                }
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
                if (textBoxOFtitle.Text == "Title Here...." || textBox.Text == "Entry Here.....")
                {
                    MessageBox.Show("Please enter a title and text for the diary entry.");
                    return;
                }

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
            if (Home.darkMode == "1")
            {

                this.BackColor = Color.FromArgb(34, 36, 49);
                statusLabel.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                labelOFsearch.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                statusLabel.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                labelOFsearch.ForeColor = Color.Black;
            }



            textBoxOFtitle.Text = "Title Here....";
            textBox.Text = "Entry Here.....";
            textBoxOFtitle.ForeColor = Color.White;
            textBox.ForeColor = Color.White;
            statusLabel.Text = "New Diary";

            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select tagname from tags where userid = :id ORDER by tagid";
            cmd.Parameters.Add("id", Home.userId);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBoxOFTags.Items.Add(dr[0]);
            }
           cmd.Parameters.Clear();

            if (!Home.isNew)
            {
                textBoxOFtitle.ForeColor = Color.Black;
                textBox.ForeColor = Color.Black;
                statusLabel.Text = "Edit Diary";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select title,text ,tagid from diaries where diaryid = :id";
                cmd.Parameters.Add("id",Home.diaryId);
                dr = cmd.ExecuteReader();
                dr.Read();
                textBoxOFtitle.Text = dr[0].ToString();
                textBox.Text = dr[1].ToString();
                int tagId = Convert.ToInt32(dr[2]);
                cmd.Parameters.Clear();

                cmd.CommandText = "select tagname from tags where tagid = :id";
                cmd.Parameters.Add("id", tagId);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0] != DBNull.Value)
                {
                    comboBoxOFTags.Text = dr[0].ToString();
                }

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

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBoxOFtitle.Text.Trim(' ').Length == 0 || textBox.Text.Trim(' ').Length == 0)
            {
                MessageBox.Show(" Nigga -___- ");
                return;
            }

            string exportFolder = @"..\..\Exported Diaries"; // Specify the folder path  
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder); // Create the folder if it doesn't exist  
            }
            string dirParameter = Path.Combine(exportFolder, textBoxOFtitle.Text + ".txt");
            string Msg = textBox.Text;
            FileStream fParameter = new FileStream(dirParameter, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(Msg);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();

            MessageBox.Show("Exported Successfully");
        }

        private void textBoxOFtitle_Enter(object sender, EventArgs e)
        {
            if (textBoxOFtitle.Text == "Title Here....")
            {
                textBoxOFtitle.Text = "";
                textBoxOFtitle.ForeColor = Color.Black;
            }
        }

        private void textBoxOFtitle_Leave(object sender, EventArgs e)
        {
            if (textBoxOFtitle.Text == "")
            {
                textBoxOFtitle.Text = "Title Here....";
                textBoxOFtitle.ForeColor = Color.White;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (textBox.Text == "Entry Here.....")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (textBox.Text == "")
            {
                textBox.Text = "Entry Here.....";
                textBox.ForeColor = Color.White;
            }
        }

        private void textBoxOFsearch_TextChanged(object sender, EventArgs e)
        {
            //Revert the text box to its original color
            textBox.SelectAll();
            textBox.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;

            string[] words = textBoxOFsearch.Text.Split(',');

            foreach (string wordRaw in words)
            {
                string word = wordRaw.Trim();
                if (string.IsNullOrEmpty(word)) continue;

                int startindex = 0;
                while (startindex < textBox.TextLength)
                {
                    // First try to find as a whole word
                    int wordstartIndex = textBox.Find(word, startindex, RichTextBoxFinds.WholeWord);
                    if (wordstartIndex == -1)
                    {
                        // If not found as a whole word, try to find as substring
                        wordstartIndex = textBox.Find(word, startindex, RichTextBoxFinds.None);
                    }

                    if (wordstartIndex != -1)
                    {
                        textBox.SelectionStart = wordstartIndex;
                        textBox.SelectionLength = word.Length;
                        textBox.SelectionBackColor = Color.Yellow;
                        startindex = wordstartIndex + word.Length;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }


}
