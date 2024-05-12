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
    public partial class coman_create_diet : Form
    {
        string userid;
        UserType usertype;
        SQL sql = new SQL();
        public coman_create_diet(string id, UserType sender)
        {
            InitializeComponent();
            this.userid = id;
            this.usertype = sender;
        }

        private void muscletype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void coman_create_diet_Load(object sender, EventArgs e)
        {
            DataTable dt = sql.GetDataTable("SELECT * FROM Diet");
            foreach (DataRow row in dt.Rows)
            {
                this.all_deit_Grid.Rows.Add(row["Diet_id"], row["Deit_Name"], row["Fats"], row["Carbs"], row["Proteins"], row["Calories"]);
            }
            DataTable dt2 = sql.GetDataTable("SELECT * FROM GetDietType();");
            foreach (DataRow row in dt2.Rows)
            {
                this.DeitType.Items.Add(row["Type_Diet_Plan"]);
            }
            // make deitGridView colum 0,1 readonly
            this.deitGridView.Columns[0].ReadOnly = true;
            this.deitGridView.Columns[1].ReadOnly = true;
            // set deitGridView column 2 int only
            this.deitGridView.Columns[2].ValueType = typeof(int);
        }

        private void all_equipment_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // add selected row to the this diet
            if (e.RowIndex >= 0)
            {
                this.deitGridView.Rows.Add(this.all_deit_Grid.Rows[e.RowIndex].Cells[0].Value, this.all_deit_Grid.Rows[e.RowIndex].Cells[1].Value, 1);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // fix 'Uncommitted new row cannot be deleted.'
            
            //remove selected from deitGridView
            if (this.deitGridView.SelectedRows.Count > 0)
            {
                if (!this.deitGridView.SelectedRows[0].IsNewRow)
                    this.deitGridView.Rows.RemoveAt(this.deitGridView.SelectedRows[0].Index);
            }
        }

        private void DeitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.typeTextbox.Text = this.DeitType.Text;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in this.deitGridView.Rows)
            {
                rows.Add(row);
            }
            // create checks
            if (rows.Count < 2)
            {
                MessageBox.Show("Please Add atleast 1 Diet to the Diet Plan");
                return;
            }
            else if(this.nameTextBox1.Text == "")
            {
                MessageBox.Show("Please Enter Diet Plan Name");
                return;
            }
            else if (this.typeTextbox.Text == "")
            {
                MessageBox.Show("Please Select Diet Plan Type");
                return;
            }
            else if (this.deitTimeType.Text == "")
            {
                MessageBox.Show("Please Select Diet Plan Time");
                return;
            }


            // EXEC CreateDietPlan 1, 'Diet Plan 12', 'Keto', 'Morning', NULL, 'T_001', 1, 1
            string publicflag = this.guna2ToggleSwitch1.Checked? "0" : "1";
            string dietname = this.nameTextBox1.Text;
            string diettype = this.typeTextbox.Text;
            string diettime = this.deitTimeType.Text;
            string deitid = rows[0].Cells[0].Value.ToString();
            string deitqty = rows[0].Cells[2].Value.ToString();
            string query = "";
            if(usertype == UserType.Member)
            {
                query = "EXEC CreateDietPlan " + publicflag + ", '" + dietname + "', '" + diettype + "', '" + diettime + "','" + userid + "', NULL, '" + deitid + "', '" + deitqty+ "';";
            }
            else if(usertype == UserType.Trainer)
            {
                query = "EXEC CreateDietPlan " + publicflag + ", '" + dietname + "', '" + diettype + "', '" + diettime + "', NULL, '" + userid + "', '" + deitid + "', '" + deitqty + "';";
            }
            DataTable dt = sql.GetDataTable(query);
            string deitplan;
            if (dt.Rows[0][0].ToString() == "1")
            {
                deitplan = dt.Rows[0][1].ToString();
                // fill rest EXEC AddDietToDietPlan 12, 2, 3 => DietPlanID, DietID, Quantity
                for (int i = 1; i < rows.Count-1; i++)
                {
                    deitid = rows[i].Cells[0].Value.ToString();
                    deitqty = rows[i].Cells[2].Value.ToString();
                    sql.GetDataTable("EXEC AddDietToDietPlan " + deitplan + "," + deitid + "," + deitqty);
                }
                MessageBox.Show("Diet Plan Created Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Creating Diet Plan");
            }
        }

        private void deitGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
