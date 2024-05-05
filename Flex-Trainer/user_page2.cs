using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flex_Trainer
{
    public partial class user_page2 : Form
    {
        public user_page2()
        {
            InitializeComponent();
            this.traner_feedback1.Visible = false;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = false;
            this.userControl11.Visible = true;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.traner_feedback1.Visible = false;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = false;
            this.userControl11.Visible = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.userControl11.Visible = false;
            this.trainer_workout1.Visible = true;
            this.traner_diet1.Visible = false;
            this.traner_feedback1.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.userControl11.Visible = false;
            this.traner_feedback1.Visible = false;
            this.traner_diet1.Visible = true;
            this.trainer_workout1.Visible = false;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.userControl11.Visible = false;
            this.traner_feedback1.Visible = true;
            this.traner_diet1.Visible = false;
            this.trainer_workout1.Visible = false;
        }
    }
}
