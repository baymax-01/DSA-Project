using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_Clouring
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btncourse_Click(object sender, EventArgs e)
        {
            CourseDetails courseDetails = new CourseDetails();
            courseDetails.Show();
            
        }

        private void btntimetable_Click(object sender, EventArgs e)
        {

        }
    }
}
