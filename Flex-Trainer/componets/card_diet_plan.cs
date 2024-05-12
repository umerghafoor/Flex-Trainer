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
    public partial class card_diet_plan : UserControl
    {
        string deit_id;
        string user_id;
        public card_diet_plan()
        {
            InitializeComponent();
        }
        public void setValues(string name, string tpye,string daytime ,string fats,string cal,string deitplan_id,string user_id)
        {
            this.deit_id = deitplan_id;
            this.user_id = user_id;
            this.Diet_Name.Text = name;
            this.timofday.Text = daytime;
            this.typeofdiet.Text = tpye;
            this.fats.Text = "Fats : " + fats;
            this.cals.Text = "Cal : " + cal;
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void card_diet_plan_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            coman_add_to_week coman_Add_To_Week = new coman_add_to_week(user_id, "NULL", deit_id);
            coman_Add_To_Week.Show();
        }
    }
}
