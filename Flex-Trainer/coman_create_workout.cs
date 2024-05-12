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
    public partial class creatworkout : Form
    {
        string userid;
        UserType usertype;
        SQL sql = new SQL();
        public creatworkout(string id, UserType sender)
        {
            InitializeComponent();
            this.userid = id;
            this.usertype = sender;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // put all_equipment_Grid rows into a list 
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in this.workoutGridView.Rows)
            {
                rows.Add(row);
            }
            bool public_flag = !this.guna2ToggleSwitch1.Checked;
            int total_time = (int)this.min.Value;
            // create checks
            if (this.nameTextBox1.Text == "" || this.workouttypeTextbox.Text == "" || this.muscleTextBox2.Text == "" || total_time == 0 || rows.Count == 1)
            {
                MessageBox.Show("Please fill out all fields and add equipment");
                return;
            }
            else 
            {
                int equipment,sets, reps;
                equipment = (int)this.workoutGridView.Rows[0].Cells[0].Value;
                sets = (int)this.workoutGridView.Rows[0].Cells[3].Value;
                reps = (int)this.workoutGridView.Rows[0].Cells[4].Value;
                string query = "";
                if (usertype == UserType.Member)
                {
                    query = "EXEC CreateWorkoutPlan '" + this.nameTextBox1.Text + "','" + public_flag.ToString() + "', '" + this.workouttypeTextbox.Text + "', '" + this.muscleTextBox2.Text + "','" + total_time.ToString() + "', '" + this.userid + "', NULL, '" + equipment.ToString() + "', '" + sets.ToString() + "', '" + reps.ToString() + "'";
                }
                else if(usertype == UserType.Trainer)
                {
                    query = "EXEC CreateWorkoutPlan '" + this.nameTextBox1.Text + "','" + public_flag.ToString() + "', '" + this.workouttypeTextbox.Text + "', '" + this.muscleTextBox2.Text + "','" + total_time.ToString() + "', NULL, '" + this.userid + "', '" + equipment.ToString() + "', '" + sets.ToString() + "', '" + reps.ToString() + "'";
                }
                DataTable dt = sql.GetDataTable(query);
                // if dt status is 1, then the workout is created
                if (dt.Rows[0][0].ToString() == "1")
                {
                    // fill rest of the equipments EXEC AddEquipmentToWorkoutPlan @WorkoutID INT, @EquipmentID INT, @Sets INT, @Reps INT
                    for (int i = 1; i < rows.Count-1; i++)
                    {
                        equipment = (int)rows[i].Cells[0].Value;
                        sets = (int)rows[i].Cells[3].Value;
                        reps = (int)rows[i].Cells[4].Value;
                        sql.GetDataTable("EXEC AddEquipmentToWorkoutPlan " + dt.Rows[0][1].ToString() + "," + equipment.ToString() + "," + sets.ToString() + "," + reps.ToString());
                    }
                    MessageBox.Show("Workout Created");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error creating workout");
                }

            }
        }

        private void CreateWorkout_Load(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM Equipment");
            foreach (DataRow row in dt.Rows)
            {
                this.all_equipment_Grid.Rows.Add(row["Equipment_ID"],row["Name"], row["Category"]);
            }
            // make cloumn 0,1,2 uneditable
            this.workoutGridView.Columns[0].ReadOnly = true;
            this.workoutGridView.Columns[1].ReadOnly = true;
            this.workoutGridView.Columns[2].ReadOnly = true;
            // make column 2 and 3 number only
            this.workoutGridView.Columns[3].ValueType = typeof(int);
            this.workoutGridView.Columns[4].ValueType = typeof(int);

            // workouttype
            DataTable dt2 = sql.GetDataTable("SELECT * FROM GetWorkoutCategory()");
            foreach (DataRow row in dt2.Rows)
            {
                this.workouttype.Items.Add(row["Category"]);
            }
            // muscletype
            DataTable dt3 = sql.GetDataTable("SELECT * FROM GetMuscleTypes()");
            foreach (DataRow row in dt3.Rows)
            {
                this.muscletype.Items.Add(row["Target_Muscle"]);
            }
        }

        private void all_equipment_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // add selected row to the workoutGridView
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.all_equipment_Grid.Rows[e.RowIndex];
                this.workoutGridView.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value,1,1);
            }
        }

        private void workoutGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // remove selected row
            foreach (DataGridViewRow row in this.workoutGridView.SelectedRows)
            {
                if(!row.IsNewRow)
                    this.workoutGridView.Rows.Remove(row);
            }
        }

        private void workouttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.workouttypeTextbox.Text = this.workouttype.Text;
        }

        private void muscletype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.muscleTextBox2.Text = this.muscletype.Text;
        }

        private void nameTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void workouttypeTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void muscleTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
