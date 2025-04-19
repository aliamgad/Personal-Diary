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
    public partial class Reminder: Form
    {
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


        }
    }
}
