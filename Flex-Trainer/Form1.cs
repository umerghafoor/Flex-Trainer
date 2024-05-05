using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Flex_Trainer
{
    public partial class signin : KryptonForm
    {
        public signin()
        {
            InitializeComponent();
            user_selecter.Items.Add("Admin");
            user_selecter.Items.Add("User");
            user_selecter.Items.Add("Trainer");
            user_selecter.Items.Add("Gym Admin");

        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //close this window
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //minize window
            this.WindowState = FormWindowState.Minimized;
        }

        private void email_text_box(object sender, EventArgs e)
        {

        }

        private void password_text_box(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (user_selecter.Text == "Admin"   )
            {
                //trainer_page2 admin = new trainer_page2();
                //admin.Show();
            }
            else if (user_selecter.Text == "User")
            {
                user_page2 user = new user_page2();
                user.Show();
            }
            else if (user_selecter.Text == "Trainer")
            {
                trainer_page2 admin = new trainer_page2();
                admin.Show();
            }
            else if (user_selecter.Text == "Gym Admin")
            {
                gym_owner admin = new gym_owner();
                admin.Show();
            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            //close this window
            this.Close();
        }

        private void signin_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.Show();
        }
    }
}
