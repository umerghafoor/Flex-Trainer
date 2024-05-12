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
    public partial class card_workout_goals : UserControl
    {
        public card_workout_goals()
        {
            InitializeComponent();

        }

        public void setValues(string name, string desciption, string goal_goal,int progress)
        {
            this.name_goal.Text = name;
            this.desciption.Text = desciption;
            this.goal_goal.Text = goal_goal;
            this.guna2CircleProgressBar1.Value = progress;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
