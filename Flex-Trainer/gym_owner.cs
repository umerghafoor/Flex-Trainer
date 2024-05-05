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
    public partial class gym_owner : Form
    {
        public gym_owner()
        {
            InitializeComponent();
            this.gym_member1.Visible = true;
            this.gym_trainer1.Visible = false;
            this.gym_requests1.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.gym_requests1.Visible = false;
            this.gym_trainer1.Visible = false;
            this.gym_member1.Visible = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.gym_requests1.Visible = false;
            this.gym_member1.Visible = false;
            this.gym_trainer1.Visible = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.gym_requests1.Visible = true;
            this.gym_member1.Visible = false;
            this.gym_trainer1.Visible = false;
        }
    }
}
