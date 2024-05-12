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
    public partial class card_workout : UserControl
    {
        string workout_id;
        string user_id;
        public card_workout()
        {
            InitializeComponent();
        }

        public void setValues(string name, string targetmuscle, string time, string category, string[] execise, string[] reps,string[] sets,string workoutid,string userid)
        {
            this.workout_id = workoutid;
            this.user_id = userid;
            this.workouname.Text = name;
            this.target_muscle.Text = targetmuscle;
            this.time.Text = time;
            this.catgory.Text = category;
            try
            {
                this.ex1.Text = execise[0] +"\t"+ sets[0] + "x" + reps[0];
            }
            catch (Exception)
            {
                this.ex1.Text = " ";
            }
            try
            {
                this.ex2.Text = execise[1] + "\t" + sets[1] + "x" + reps[1];
            }
            catch (Exception)
            {
                this.ex2.Text = " ";
            }
            try
            {
                this.ex3.Text = execise[2] + "\t" + sets[2] + "x" + reps[2];
            }
            catch (Exception)
            {
                this.ex3.Text = " ";
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void card_workout_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            coman_add_to_week coman = new coman_add_to_week(user_id, workout_id, "NULL");
            coman.Show();
        }
    }
}
