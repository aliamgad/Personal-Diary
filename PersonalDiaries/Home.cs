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
using PersonalDiaries;

namespace Personal_Diary_Application
{
    public partial class Home : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;

        public Login user;

        public Home()
        {
            InitializeComponent();
        }

        private void dark_mode_btn_CheckedChanged(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            

            if (dark_mode_btn.Checked)
            {
                cmd.CommandText = "update Users set darkmode = 1 where username =:userName";
                this.BackColor = Color.FromArgb(34, 36, 49);
                this.ForeColor = Color.White;
            }
            else
            {
                cmd.CommandText = "update Users set darkMode = 0 where username =:userName";
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
            }

            cmd.Parameters.Add("userName", Login.username);
            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select darkmode from  Users where username =:userName";
            cmd.Parameters.Add("userName", Login.username);
            OracleDataReader dr = cmd.ExecuteReader();


            dr.Read();
            
            if (dr[0].ToString() == "1")
            {
                dark_mode_btn.Checked = true;
                this.BackColor = Color.FromArgb(34, 36, 49);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
            }

            dr.Close();
            conn.Dispose();
        }
    }
}