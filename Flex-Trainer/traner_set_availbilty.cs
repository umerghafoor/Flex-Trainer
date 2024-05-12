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
    public partial class traner_set_availbilty : Form
    {
        SQL sql = new SQL();
        private string userid;
        public traner_set_availbilty(string userid)
        {
            InitializeComponent();
            this.userid = userid;
        }

        private void traner_set_availbilty_Load(object sender, EventArgs e)
        {
            

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addavailability2Button3_Click(object sender, EventArgs e)
        {
            // EXEC AddTrainerAvailability '2024-05-20', '09:00:00', '12:00:00', 'T_001';
            string start_time = this.startH.Value.ToString() + ":" + this.startM.Value.ToString() + ":00";
            string end_time = this.endH.Value.ToString() + ":" + this.endM.Value.ToString() + ":00";
      
            string date = this.guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
            // create checks for date it must be of future
            if (DateTime.Parse(date) < DateTime.Now)
            {
                MessageBox.Show("Date must be of future");
                return;
            }
            if (DateTime.Parse(start_time) > DateTime.Parse(end_time))
            {
                MessageBox.Show("Start time must be less than end time");
                return;
            }
            sql.ExecuteQuery("EXEC AddTrainerAvailability '" + date + "', '" + start_time + "', '" + end_time + "', '" + userid + "'");
            this.Close();
        }
    }
}
