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
    public partial class trainer_home : UserControl
    {
        SQL sql = new SQL();
        private string userid;
        public trainer_home()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++) 
            guna2DataGridView1.Rows.Add("1", "Umer", "umerghaforr@gmail.com", "pushups", "cebcie");

        }

        public void setvalues(string userid)
        {
            this.userid = userid;
        }   

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM TrainerAvailability WHERE Trainer_SSN = '" + userid+"'");
            foreach (DataRow row in dt.Rows)
            {
                string totaltime = (DateTime.Parse(row["end_time"].ToString()) - DateTime.Parse(row["start_time"].ToString())).ToString();
                this.availablityDataGridView2.Rows.Add(row["date"].ToString(), row["start_time"].ToString(), row["end_time"].ToString(), totaltime);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addavailability2Button3_Click(object sender, EventArgs e)
        {
            traner_set_availbilty traner_Set_Availbilty = new traner_set_availbilty(userid);
            traner_Set_Availbilty.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM TrainerAvailability WHERE Trainer_SSN = '" + userid + "'");
            this.availablityDataGridView2.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string totaltime = (DateTime.Parse(row["end_time"].ToString()) - DateTime.Parse(row["start_time"].ToString())).ToString();
                this.availablityDataGridView2.Rows.Add(row["date"].ToString(), row["start_time"].ToString(), row["end_time"].ToString(), totaltime);
            }
        }
    }
}
