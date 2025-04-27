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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tag_Report form = new Tag_Report();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users_Report form = new Users_Report();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home form  = new Home();
            form.Show();
            this.Hide();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (Home.darkMode == "1")
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }
    }
}
