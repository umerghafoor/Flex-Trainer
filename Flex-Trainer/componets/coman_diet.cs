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
    public struct DietPlanInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DayTime { get; set; }
        public string TotalFats { get; set; }
        public string TotalCals { get; set; }
    }

    public partial class coman_diet : UserControl
    {
        SQL sql = new SQL();
        private string userid;
        UserType usertype;
        public coman_diet()
        {
            InitializeComponent();
        }

        private void GetAllDietPlans(DataTable dt)
        {
            card_diet_plan dietPlanCard;
            // Remove all previous cards
            this.flowLayoutPanel1.Controls.Clear();

            Dictionary<string, DietPlanInfo> dietPlanDictionary = new Dictionary<string, DietPlanInfo>();

            foreach (DataRow row in dt.Rows)
            {
                string id = row["ID"].ToString();
                string name = row["DietPlan_Name"].ToString();
                string type = row["Type_diet_plan"].ToString();
                string dayTime = row["day_time"].ToString();
                string totalFats = row["total_fats"].ToString();
                string totalCals = row["total_cals"].ToString();

                if (!dietPlanDictionary.ContainsKey(id))
                {
                    DietPlanInfo dietPlan = new DietPlanInfo
                    {
                        Id = id,
                        Name = name,
                        Type = type,
                        DayTime = dayTime,
                        TotalFats = totalFats,
                        TotalCals = totalCals
                    };

                    dietPlanDictionary.Add(id, dietPlan);
                }
                else
                {
                    DietPlanInfo existingDietPlan = dietPlanDictionary[id];
                    // Merge duplicate diet plan info (if any)

                    dietPlanDictionary[id] = new DietPlanInfo
                    {
                        Id = id,
                        Name = name,
                        Type = type,
                        DayTime = dayTime,
                        TotalFats = totalFats,
                        TotalCals = totalCals
                    };
                }
            }

            foreach (var dietPlan in dietPlanDictionary.Values)
            {
                dietPlanCard = new card_diet_plan();
                dietPlanCard.setValues(dietPlan.Name, dietPlan.Type, dietPlan.DayTime, dietPlan.TotalFats, dietPlan.TotalCals);
                this.flowLayoutPanel1.Controls.Add(dietPlanCard);
            }
        }


        public void setuser(string id,UserType u)
        {
            userid = id;
            this.usertype = u;
        }   

        private void coman_diet_Load(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "')");
            GetAllDietPlans(dt);
            // set types
            DataTable dt2 = sql.GetDataTable("SELECT * FROM GetDietType()");
            foreach (DataRow row in dt2.Rows)
            {
                filterType.Items.Add(row["Type_Diet_Plan"].ToString());
            }
            // filterTime SELECT * FROM GetDayTime();
            DataTable dt3 = sql.GetDataTable("SELECT * FROM GetDayTime()");
            foreach (DataRow row in dt3.Rows)
            {
                filterTime.Items.Add(row["Time_Of_Day"].ToString());
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // SELECT * FROM GetDietPlanDetailsByName('Diet Plan ', '');
            DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetailsByName('"+ this.searchTextBox1.Text +"', '" + userid + "')");
            GetAllDietPlans(dt);
        }

        private void filterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.filterType.Text == "All")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "')");
                GetAllDietPlans(dt);
            }
            else
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "') WHERE Type_Diet_Plan = '" + this.filterType.Text + "'");
                GetAllDietPlans(dt);
            }
        }

        private void filterTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.filterTime.Text == "All")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "')");
                GetAllDietPlans(dt);
            }
            else
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "') WHERE Day_Time = '" + this.filterTime.Text + "'");
                GetAllDietPlans(dt);
            }
        }

        private void privicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.privicy.Text == "All")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "')");
                GetAllDietPlans(dt);
            }
            if(this.privicy.Text == "Private")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "') WHERE Public_flag = '0'");
                GetAllDietPlans(dt);
            }
            if (this.privicy.Text == "Public")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('')");
                GetAllDietPlans(dt);
            }
        }

        private void fats_less_than_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "') WHERE Total_Fats < '" + this.fats_less_than.Value + "'");
            GetAllDietPlans(dt);
        }

        private void cals_less_than_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM GetDietPlanDetails('" + userid + "') WHERE Total_Cals < '" + this.cals_less_than.Value + "'");
            GetAllDietPlans(dt);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            coman_create_diet Create_Diet = new coman_create_diet(userid, usertype);
            Create_Diet.Show();
        }
    }
}
