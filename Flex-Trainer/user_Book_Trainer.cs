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
    public partial class user_Book_Trainer : Form
    {
        SQL sql = new SQL();
        private string userid;
        public user_Book_Trainer(string user)
        {
            InitializeComponent();
            this.userid = user;
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // SELECT * FROM GetTrainersAtDate('2024-05-20');
            DataTable dt = sql.GetDataTable(guna2DateTimePicker1.Value.ToString("yyyy-MM-dd"));
            foreach (DataRow row in dt.Rows)
            {
                availablityDataGridView2.Rows.Add(row["trainer_SSN"], row["First_Name"]+" "+ row["Last_Name"], row["start_time"], row["end_time"]);
            }
        }

        private void addavailability2Button3_Click(object sender, EventArgs e)
        {
            

        }
    }
}
