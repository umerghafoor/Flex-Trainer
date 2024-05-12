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
    public partial class coman_add_to_week : Form
    {
        SQL sql = new SQL();
        string workout_id = "NULL";
        string deit_id = "NULL";
        string member_id;

        public coman_add_to_week(string member_id,string workout_id, string deit_id)
        {
            InitializeComponent();
            this.member_id = member_id;
            this.workout_id = workout_id;
            this.deit_id = deit_id;
        }

        private void coman_add_to_workout_Load(object sender, EventArgs e)
        {
            // SELECT * FROM GetWorkoutEquipmentDetails('') WHERE Workout_ID = 1
            // guna2DataGridView1
            DataTable dt;
            if (workout_id != "NULL")
            {
                dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('" + member_id + "') WHERE Workout_ID = '" + workout_id + "'");
                foreach (DataRow row in dt.Rows)
                {
                    guna2DataGridView1.Rows.Add(row["Equipment_Name"].ToString(), row["Sets"].ToString(), row["Reps"].ToString());
                }
                this.heading_name.Text = dt.Rows[0]["Workout_Name"].ToString();
            }
            else if(deit_id != "NULL")
            {
                dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + member_id + "') WHERE ID = '" + deit_id + "'");
                foreach (DataRow row in dt.Rows)
                {
                    // clear colums
                    guna2DataGridView1.Columns.Clear();
                    guna2DataGridView1.Columns.Add("DietPlan_Name", "Diet Plan Name");
                    guna2DataGridView1.Columns.Add("total_fats", "Total Fats");
                    guna2DataGridView1.Columns.Add("total_cals", "Total Calories");
                    guna2DataGridView1.Rows.Add(row["DietPlan_Name"].ToString(), row["total_fats"].ToString(), row["total_cals"].ToString());
                }
                this.heading_name.Text = dt.Rows[0]["DietPlan_Name"].ToString();
            }
            
            // select dt row 0 Workout_Name and set it to workout_name.Text
            
        }

        private void workout_name_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // EXEC InsertWeeklyPlan '11111111111', 'wednesday', 5, NULL
            DataTable dt = sql.GetDataTable("EXEC InsertWeeklyPlan '" + member_id + "', '"+ guna2ComboBox3.Text+ "',"+ workout_id+"," + deit_id +"");
            // if dt[0][0] == 1
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Workout Added to Plan");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Adding to Weekly Plan");
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
