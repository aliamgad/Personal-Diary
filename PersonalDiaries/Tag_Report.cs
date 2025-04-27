using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Personal_Diary_Application;

namespace PersonalDiaries
{
    public partial class Tag_Report : Form
    {
        TagsReport CR;
        
        public Tag_Report()
        {
            InitializeComponent();
        }

        private void generate_tag_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }

        private void Tag_Report_Load(object sender, EventArgs e)
        {
            CR = new TagsReport();

            if (Home.darkMode == "1")
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

        private void back_Button_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.Show();
            this.Hide();
        }
    }
}
