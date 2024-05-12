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
    public partial class page_trainer : Form
    {
        private string id;
        SQL sql = new SQL();
        signin parent;
        public page_trainer(string id,signin s)
        {
            InitializeComponent();
            this.trainer_home1.Visible = true;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = false;
            this.traner_feedback1.Visible = false;
            this.parent = s;
            this.id = id;
            this.trainer_home1.setvalues(id);
            this.trainer_workout1.setUser(id, UserType.Trainer);
            this.traner_diet1.setuser(id, UserType.Trainer);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.trainer_home1.Visible = false;
            this.trainer_workout1.Visible = true;
            this.traner_diet1.Visible = false;
            this.traner_feedback1.Visible = false;


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.trainer_home1.Visible = true;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = false;
            this.traner_feedback1.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.trainer_home1.Visible = false;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = true;
            this.traner_feedback1.Visible = false;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.trainer_home1.Visible = false;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = false;
            this.traner_feedback1.Visible = true;

        }

        private void page_trainer_Load(object sender, EventArgs e)
        {
            

        }

        private void logout_Button_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }
    }
}
