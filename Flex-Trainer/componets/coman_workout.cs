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
    public struct WorkoutInfo
    {
        public string Id;
        public string Name;
        public string targetmuscle;
        public string Time;
        public string category;
        public string[] Exercise;
        public string[] Reps;
        public string[] Sets;
    }
    public partial class coman_workout : UserControl
    {
        SQL sql = new SQL();
        private string userid;
        private UserType userType;
        public coman_workout()
        {
            InitializeComponent();
        }
        public void setUser(string id,UserType u)
        {
            this.userid = id;
            this.userType = u;
        }
        internal void setSender(UserType userType)
        {
            this.userType = userType;
        }

        private void getAllCards(DataTable dt)
        {
            card_workout card;
            // remove all previus cards from 
            this.flowLayoutPanel1.Controls.Clear();

            Dictionary<string, WorkoutInfo> workoutDictionary = new Dictionary<string, WorkoutInfo>();

            foreach (DataRow row in dt.Rows)
            {
                string id = row["Workout_ID"].ToString();
                string name = row["Workout_Name"].ToString();
                string category = row["Workout_Category"].ToString();
                string targetMuscle = row["Target_Muscle"].ToString();
                string time = row["Total_Time"].ToString();
                string[] exercises = row["Equipment_Name"].ToString().Split(',');
                string[] reps = row["Reps"].ToString().Split(',');
                string[] sets = row["Sets"].ToString().Split(',');

                if (!workoutDictionary.ContainsKey(id))
                {
                    WorkoutInfo workout = new WorkoutInfo
                    {
                        Id = id,
                        Name = name,
                        category = category,
                        targetmuscle = targetMuscle,
                        Time = time,
                        Exercise = exercises,
                        Reps = reps,
                        Sets = sets
                    };

                    workoutDictionary.Add(id, workout);
                }
                else
                {
                    WorkoutInfo existingWorkout = workoutDictionary[id];
                    List<string> mergedExercises = new List<string>(existingWorkout.Exercise);
                    mergedExercises.AddRange(exercises);

                    List<string> mergedReps = new List<string>(existingWorkout.Reps);
                    mergedReps.AddRange(reps);

                    List<string> mergedSets = new List<string>(existingWorkout.Sets);
                    mergedSets.AddRange(sets);

                    workoutDictionary[id] = new WorkoutInfo
                    {
                        Id = id,
                        Name = name,
                        category = category,
                        targetmuscle = targetMuscle,
                        Time = time,
                        Exercise = mergedExercises.ToArray(),
                        Reps = mergedReps.ToArray(),
                        Sets = mergedSets.ToArray()
                    };
                }
            }

            foreach (var workout in workoutDictionary.Values)
            {
                card = new card_workout();
                card.setValues(workout.Name, workout.targetmuscle, workout.Time, workout.category, workout.Exercise, workout.Reps, workout.Sets);
                this.flowLayoutPanel1.Controls.Add(card);
            }
        }


        private void workoutcard1_Load(object sender, EventArgs e)
        {

        }

        private void trainer_workout_Load(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('"+ userid +"')");
            // return all muscle types
            DataTable dt2 = sql.GetDataTable("SELECT * FROM GetMuscleTypes()");
            foreach (DataRow row in dt2.Rows)
            {
                this.muscleComboBox2.Items.Add(row["Target_Muscle"].ToString());
            }
            // return all workout categorys
            DataTable dt3 = sql.GetDataTable("SELECT * FROM GetWorkoutCategory()");
            foreach (DataRow row in dt3.Rows)
            {
                this.catagoryComboBox.Items.Add(row["Category"].ToString());
            }
            getAllCards(dt);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // GetWorkoutEquipmentDetailsByName
            DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetailsByName('" + this.searchTextBox1.Text +"','"+ userid+ "')");
            getAllCards(dt);
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.muscleComboBox2.Text == "All")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('" + userid+"')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
            else
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetailsByMuscle('" + this.muscleComboBox2.Text + "','" + userid + "')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
        }
        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.guna2ToggleSwitch1.Checked)
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
            else
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('" + userid+"')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.guna2ComboBox3.Text == "private")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetPrivateWorkoutEquipmentDetails('"+userid+"')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
            if (this.guna2ComboBox3.Text == "public")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
            if (this.guna2ComboBox3.Text == "All")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('" + userid+"')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.catagoryComboBox.Text == "All")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetails('" + userid+"')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
            else
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetailsByCategory('" + this.catagoryComboBox.Text + "','"+userid+"')");
                this.flowLayoutPanel1.Controls.Clear();
                getAllCards(dt);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // GetWorkoutEquipmentDetailsByFilters(1, 'Chest', 'Strength', 'Workout 1')
            if(this.guna2ComboBox3.Text == "private")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetailsByFilters( '" + this.muscleComboBox2.Text + "', '" + this.catagoryComboBox.Text + "', '" + this.searchTextBox1.Text + "','" + userid + "')");
                getAllCards(dt);
            }
            if (this.guna2ComboBox3.Text == "public")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetailsByFilters( '" + this.muscleComboBox2.Text + "', '" + this.catagoryComboBox.Text + "', '" + this.searchTextBox1.Text + "','" + userid + "')");
                getAllCards(dt);
            }
            if (this.guna2ComboBox3.Text == "All")
            {
                DataTable dt1 = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetailsByFilters( '" + this.muscleComboBox2.Text + "', '" + this.catagoryComboBox.Text + "', '" + this.searchTextBox1.Text + "','" + userid + "')");
                DataTable dt2 = sql.GetDataTable("SELECT * FROM GetWorkoutEquipmentDetailsByFilters( '" + this.muscleComboBox2.Text + "', '" + this.catagoryComboBox.Text + "', '" + this.searchTextBox1.Text + "','" + userid + "')");
                DataTable dt = new DataTable();
                dt.Merge(dt1);
                dt.Merge(dt2);
                getAllCards(dt);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            creatworkout createDietPlan = new creatworkout(userid,this.userType);
            createDietPlan.Show();
        }

        
    }
}
