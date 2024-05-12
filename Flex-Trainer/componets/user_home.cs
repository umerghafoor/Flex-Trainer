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
        SQL sql = new SQL();
        private string userid;
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

        public void setvalues(string userid)
        {
            this.userid = userid;
        }
        public void setChartValue(int[] values)
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].Points.AddXY("Monday", values[0]);
            chart1.Series["Series1"].Points.AddXY("Tuesday", values[1]);
            chart1.Series["Series1"].Points.AddXY("Wednesday", values[2]);
            chart1.Series["Series1"].Points.AddXY("Thursday", values[3]);
            chart1.Series["Series1"].Points.AddXY("Friday", values[4]);
            chart1.Series["Series1"].Points.AddXY("Saturday", values[5]);
            chart1.Series["Series1"].Points.AddXY("Sunday", values[6]);
        }

        public void setUserName(string name,string gmail)
        {
            this.user_name.Text = name;
            this.user_gmail_Label.Text = gmail;
            this.username_2.Text = name;
            this.user_gmail.Text = gmail;
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

        private void user_home_Load(object sender, EventArgs e)
        {
            // week workout goals
            // SELECT * FROM GetExercisesInWorkoutPlan('11111111111', 'monday')
            string today = DateTime.Now.DayOfWeek.ToString().ToLower();
            DataTable dataTable = sql.GetDataTable("SELECT * FROM GetExercisesInWorkoutPlan('" + userid + "', '" + today + "')");
            foreach (DataRow row in dataTable.Rows)
            {
                card_workout_goals card = new card_workout_goals();
                string total_sets = "Total Reps " + row["Reps"].ToString();
                card.setValues(row["Exercise_Name"].ToString(), total_sets, row["Sets"].ToString(), 0);
                this.weekly_flowLayoutPanel1.Controls.Add(card);
            }

            //weekly diet goals
            // SELECT * FROM GetDietInDietPlan('11111111111', 'monday')
            dataTable = sql.GetDataTable("SELECT * FROM GetDietInDietPlan('" + userid + "', '" + today + "')");
            foreach (DataRow row in dataTable.Rows)
            {
                card_deit card = new card_deit();
                card.setValues(row["Diet_Name"].ToString(), row["Quantity"].ToString(), row["Calories"].ToString(), row["Fats"].ToString(), row["Carbs"].ToString(), row["Proteins"].ToString());
                this.flowLayoutPanel2.Controls.Add(card);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            user_Book_Trainer user_Book_Trainer = new user_Book_Trainer(userid);
            user_Book_Trainer.Show();
        }
    }
}
