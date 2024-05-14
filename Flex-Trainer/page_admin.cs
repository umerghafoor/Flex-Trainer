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
    public partial class page_admin : Form
    {
        signin sign = new signin();
        public page_admin(signin sign)
        {
            InitializeComponent();
            this.admin_requests1.Visible = true;
            this.admin_home1.Visible = false;
            this.admin_reports1.Visible = false;
            this.sign = sign;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.admin_requests1.Visible = true;
            this.admin_home1.Visible = false;
            this.admin_reports1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.admin_requests1.Visible = false;
            this.admin_home1.Visible = true;
            this.admin_reports1.Visible = false;
        }

        private void page_admin_Load(object sender, EventArgs e)
        {
            // set close event
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sign.Show();
        }

        private void logout_Button_Click(object sender, EventArgs e)
        {
            sign.Show();
            this.Close();
        }

        private void admin_requests1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.admin_reports1.Visible = true;
            this.admin_requests1.Visible = false;
            this.admin_home1.Visible = false;
        }
    }
}
