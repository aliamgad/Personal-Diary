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
    public partial class Users_Report : Form
    {
        Report CR;
        public Users_Report()
        {
            InitializeComponent();
        }

        private void Users_Report_Load(object sender, EventArgs e)
        {
            CR = new Report();
        }

        private void generate_tag2_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = CR;
        }

        private void back_Button_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Show();
            this.Hide();
        }
    }
}
