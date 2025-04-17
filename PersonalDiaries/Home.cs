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
    public partial class Home: Form
    {
        public static bool isNew;
        public static int userId;
        public static int diaryId;
        public Home()
        {
            InitializeComponent();
        }
    }
}
