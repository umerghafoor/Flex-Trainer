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
    public partial class user_home : UserControl
    {
        public user_home()
        {
            InitializeComponent();
            //add items to chart1
            chart1.Legends[0].Enabled = false;
            chart1.Series["Series1"].Points.AddXY("Monday", 10);
            chart1.Series["Series1"].Points.AddXY("Tuesday", 100);
            chart1.Series["Series1"].Points.AddXY("Wednesday", 30);
            chart1.Series["Series1"].Points.AddXY("Thursday", 40);
            chart1.Series["Series1"].Points.AddXY("Friday", 50);
            chart1.Series["Series1"].Points.AddXY("Saturday", 60);
            chart1.Series["Series1"].Points.AddXY("Sunday", 70);


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void card_workout_goals1_Load(object sender, EventArgs e)
        {

        }

        private void card_workout_goals3_Load(object sender, EventArgs e)
        {
            
        }
    }
}
