using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Flex_Trainer
{
    public partial class admin_reports : UserControl
    {
        SQL sql = new SQL();
        public admin_reports()
        {
            InitializeComponent();
        }

        private void reportnameComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.para1ComboBox2.Items.Clear();
            this.para2ComboBox1.Items.Clear();
            refresh();
        }

        private void refresh()
        {
            
            this.guna2DataGridView1.DataSource = null;
            this.guna2DataGridView1.Columns.Clear();
            this.guna2DataGridView1.Rows.Clear();
            if (this.reportnameComboBox1.SelectedIndex == 0)
            {
                this.para1ComboBox2.Enabled = true;
                this.para2ComboBox1.Enabled = true;
                report1();
            }
            else if (this.reportnameComboBox1.SelectedIndex == 1)
            {
                this.para1ComboBox2.Enabled = true;
                this.para2ComboBox1.Enabled = true;
                report2();
            }
            else if (this.reportnameComboBox1.SelectedIndex == 2)
            {
                this.para1ComboBox2.Enabled = true;
                this.para2ComboBox1.Enabled = true;
                report3();
            }
            else if (this.reportnameComboBox1.SelectedIndex == 3)
            {
                this.para1ComboBox2.Enabled = true;
                this.para2ComboBox1.Enabled = false;
                report4();
            }
            else if (this.reportnameComboBox1.SelectedIndex == 4)
            {
                this.para1ComboBox2.Enabled = false;
                this.para2ComboBox1.Enabled = false;
                report5();
            }
        }
        private void report1()
        {
            DataTable dt;

            // add all gym ids in para 1
            // SELECT GYM_SSN FROM Gym;
            dt = sql.GetDataTable("SELECT GYM_SSN FROM Gym");
            foreach (DataRow row in dt.Rows)
            {
                //if not already present in the combobox
                if (!this.para1ComboBox2.Items.Contains(row["GYM_SSN"].ToString()))
                    this.para1ComboBox2.Items.Add(row["GYM_SSN"].ToString());
            }
            // SELECT Trainer_SSN FROM Trainer;
            dt = sql.GetDataTable("SELECT Trainer_SSN FROM Trainer");
            foreach (DataRow row in dt.Rows)
            {
                //if not already present in the combobox
                if (!this.para2ComboBox1.Items.Contains(row["Trainer_SSN"].ToString()))
                    this.para2ComboBox1.Items.Add(row["Trainer_SSN"].ToString());
            }
            // SELECT DISTINCT *FROM GetMembersByGymAndTrainer('12345678902', 'T_001'); also columns
            //para1ComboBox2 is not null
            string gym_SSN = string.IsNullOrEmpty(this.para1ComboBox2.Text) ? "null" : this.para1ComboBox2.Text;
            string trainer_SSN = string.IsNullOrEmpty(this.para2ComboBox1.Text) ? "null" : this.para2ComboBox1.Text;
            dt = sql.GetDataTable("SELECT DISTINCT *FROM GetMembersByGymAndTrainer('" + gym_SSN + "', '" + trainer_SSN + "')");
            this.guna2DataGridView1.DataSource = dt;
        }

        private void report2() 
        {
            DataTable dt;

            // add all gym ids in para 1
            dt = sql.GetDataTable("SELECT GYM_SSN FROM Gym");
            foreach (DataRow row in dt.Rows)
            {
                //if not already present in the combobox
                if (!this.para1ComboBox2.Items.Contains(row["GYM_SSN"].ToString()))
                    this.para1ComboBox2.Items.Add(row["GYM_SSN"].ToString());
            }
            dt = sql.GetDataTable("SELECT Diet_Plan_ID FROM Diet_Plan;");
            foreach (DataRow row in dt.Rows)
            {
                //if not already present in the combobox
                if (!this.para2ComboBox1.Items.Contains(row["Diet_Plan_ID"].ToString()))
                    this.para2ComboBox1.Items.Add(row["Diet_Plan_ID"].ToString());
            }
            // SELECT * FROM GetMembersByGymAndDietPlan('11111111111', 1);  
            string gym_SSN = string.IsNullOrEmpty(this.para1ComboBox2.Text) ? "null" : this.para1ComboBox2.Text;
            string diet_Plan_ID = string.IsNullOrEmpty(this.para2ComboBox1.Text) ? "0" : this.para2ComboBox1.Text;
            dt = sql.GetDataTable("SELECT DISTINCT * FROM GetMembersByGymAndDietPlan('" + gym_SSN + "', " + diet_Plan_ID + ");");
            this.guna2DataGridView1.DataSource = dt;
        }

        private void report3()
        {
            DataTable dt;

            // add all gym ids in para 1
            dt = sql.GetDataTable("SELECT Trainer_SSN FROM Trainer;");
            foreach (DataRow row in dt.Rows)
            {
                //if not already present in the combobox
                if (!this.para1ComboBox2.Items.Contains(row["Trainer_SSN"].ToString()))
                    this.para1ComboBox2.Items.Add(row["Trainer_SSN"].ToString());
            }
            dt = sql.GetDataTable("SELECT Diet_Plan_ID FROM Diet_Plan;");
            foreach (DataRow row in dt.Rows)
            {
                //if not already present in the combobox
                if (!this.para2ComboBox1.Items.Contains(row["Diet_Plan_ID"].ToString()))
                    this.para2ComboBox1.Items.Add(row["Diet_Plan_ID"].ToString());
            }
            // SELECT * FROM GetMembersByGymAndDietPlan('11111111111', 1);  
            string gym_SSN = string.IsNullOrEmpty(this.para1ComboBox2.Text) ? "null" : this.para1ComboBox2.Text;
            string diet_Plan_ID = string.IsNullOrEmpty(this.para2ComboBox1.Text) ? "0" : this.para2ComboBox1.Text;
            dt = sql.GetDataTable("SELECT DISTINCT * FROM GetMembersByTrainerAndDietPlan('" + gym_SSN + "', " + diet_Plan_ID + ");");
            this.guna2DataGridView1.DataSource = dt;
        }

        private void report4()
        {
            DataTable dt;
            dt = sql.GetDataTable("SELECT GYM_SSN FROM Gym;");
            foreach (DataRow row in dt.Rows)
            {
                //if not already present in the combobox
                if (!this.para1ComboBox2.Items.Contains(row["GYM_SSN"].ToString()))
                    this.para1ComboBox2.Items.Add(row["GYM_SSN"].ToString());
            }

            // SELECT * FROM GetNewMembershipsByGym('GYM_005');
            string gym_SSN = string.IsNullOrEmpty(this.para1ComboBox2.Text) ? "null" : this.para1ComboBox2.Text;
            dt = sql.GetDataTable("SELECT DISTINCT * FROM GetNewMembershipsByGym('" + gym_SSN + "');");
            this.guna2DataGridView1.DataSource = dt;
        }

        private void report5()
        {
            // SELECT GYM_Name, AVG(TotalMembers) FROM GymLog WHERE LogDate >= DATEADD(MONTH, -3, GETDATE()) GROUP BY GYM_Name;
            DataTable dt = sql.GetDataTable("SELECT GYM_Name, AVG(TotalMembers) FROM GymLog WHERE LogDate >= DATEADD(MONTH, -3, GETDATE()) GROUP BY GYM_Name;");
            this.guna2DataGridView1.DataSource = dt;
        }

        private void para1ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void para2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // donload data in guna2DataGridView1 as CSV open dialog to save
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv";
            saveFileDialog1.Title = "Save a CSV File";
            DialogResult result = saveFileDialog1.ShowDialog(); // Show the dialog and store the result
            if (result == DialogResult.OK) // Check if the user clicked OK
            {
                string name = saveFileDialog1.FileName; // Get the selected file name
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
                {
                    dt.Columns.Add(col.HeaderText);
                }
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dt.Rows.Add(dRow);
                }
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));
                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }
                System.IO.File.WriteAllText(name, sb.ToString());
            }

        }
    }
}
