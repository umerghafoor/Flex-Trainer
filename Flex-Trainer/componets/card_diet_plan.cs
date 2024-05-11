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
        public card_diet_plan()
        {
            InitializeComponent();
        }
        public void setValues(string name, string tpye,string daytime ,string fats,string cal)
        {
            this.Diet_Name.Text = name;
            this.Type_diet.Text = tpye;
            this.day_time.Text = daytime;
            this.fats.Text = "Fats : " + fats;
            this.cals.Text = "Cal : " + cal;
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void card_diet_plan_Load(object sender, EventArgs e)
        {

        }
    }
}
