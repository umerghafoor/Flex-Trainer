using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Flex_Trainer
{
    public partial class user_page : KryptonForm
    {
        private signin parent;

        public user_page()
        {
            InitializeComponent();
            parent = null;
        }

        //constructor that take parent form address as parameter
        public user_page(signin parent)
        {
            InitializeComponent();
            this.parent = parent;
        }


        private void user_page_Load(object sender, EventArgs e)
        {
            //add items to chart1
            chart1.Series["Series1"].Points.AddXY("Monday", 10);
            chart1.Series["Series1"].Points.AddXY("Tuesday", 20);
            chart1.Series["Series1"].Points.AddXY("Wednesday", 30);
            chart1.Series["Series1"].Points.AddXY("Thursday", 40);
            chart1.Series["Series1"].Points.AddXY("Friday", 50);
            chart1.Series["Series1"].Points.AddXY("Saturday", 60);
            chart1.Series["Series1"].Points.AddXY("Sunday", 70);

            // hide the legend
            chart1.Legends[0].Enabled = false;

            //enable scroll
            kryptonPanel1.AutoScroll = true;

            // add custom panals to flowLayoutPanel1_Paint flow layout panel using for loop
            for (int i = 0; i < 10; i++)
            {
                //create new panel
                KryptonPanel panel = new KryptonPanel();
                panel.Size = new Size(200, 200);
                panel.BackColor = Color.Red;
                panel.Margin = new Padding(10);
                panel.Dock = DockStyle.Top;

                //name, taget muscle group, equipment list, type of exercise, reps, sets
                panel.Controls.Add(new KryptonLabel() { Text = "Sets : " + "(" + i +"x"+i+1+ ")", Dock = DockStyle.Top });
                panel.Controls.Add(new KryptonLabel() { Text = "Type " + i, Dock = DockStyle.Top });
                //add equipment list
                for (int j = 0; j < 3; j++)
                {
                    panel.Controls.Add(new KryptonLabel() { Text = "   equipment " + j, Dock = DockStyle.Top });
                }
                panel.Controls.Add(new KryptonLabel() { Text = "Equipment : ", Dock = DockStyle.Top });
                panel.Controls.Add(new KryptonLabel() { Text = "Target Muscle Group: " + "muscle group " + i, Dock = DockStyle.Top });
                panel.Controls.Add(new KryptonLabel() { Text = "# 1 Name" + i, Dock = DockStyle.Top, Font = new Font("Arial", 18, FontStyle.Bold) });
                //add button to panel
                KryptonButton button = new KryptonButton();
                button.Text = "Start";
                button.Dock = DockStyle.Bottom;
                panel.Controls.Add(button);


                //add panel to flow layout panel
                flowLayoutPanel1.Controls.Add(panel);
            }

            //integrate scoll bar with it
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel2.AutoScroll = true;

        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (parent != null)
            {
                parent.Show();
            }
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Home_page_user_Click(object sender, EventArgs e)
        {
            // enable scroll
            kryptonPanel1.AutoScroll = true;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }
    }
}