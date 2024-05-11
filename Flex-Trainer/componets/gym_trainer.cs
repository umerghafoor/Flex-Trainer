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
    public partial class gym_trainer : UserControl
    {
        SQL sql = new SQL();
        string userid;
        public gym_trainer()
        {
            InitializeComponent();
        }
        public void setuserid(string userid)
        {
            this.userid = userid;
        }
        public void refresh()
        {
            // SELECT * FROM GetTrainersByGym('GYM_001')
            DataTable dt = sql.GetDataTable("SELECT * FROM GetTrainersByGym('" + userid + "')");
            //delete previus data
            alltrainerGridView.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string name = row[3].ToString() + " " + row[4].ToString();

                // Add row in it guna2DataGridView1
                alltrainerGridView.Rows.Add(row[0], name, row[2], row[1], row[5]);
            }
        }
        private void gym_trainer_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void _CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // remove selecte row in alltrainerGridView
            //  EXEC RemoveTrainerFromGym 'T_002', 'GYM_001'
            // ask for confermation before deleting
            if (alltrainerGridView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this trainer?", "Delete Trainer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string trainerid = alltrainerGridView.SelectedRows[0].Cells[0].Value.ToString();
                    sql.GetDataTable("EXEC RemoveTrainerFromGym '" + trainerid + "', '" + userid + "'");
                    refresh();
                }
            }
        }

        private void min_ValueChanged(object sender, EventArgs e)
        {
            // SELECT * FROM GetTrainersByGymAndYoE('GYM_001','5')
            DataTable dt = sql.GetDataTable("SELECT * FROM GetTrainersByGymAndYoE('" + userid + "', '" + min.Value + "')");
            alltrainerGridView.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string name = row[3].ToString() + " " + row[4].ToString();

                // Add row in it guna2DataGridView1
                alltrainerGridView.Rows.Add(row[0], name, row[2], row[1], row[5]);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            //SELECT * FROM GetTrainersByGymAndName('GYM_001', 'One')
            DataTable dt = sql.GetDataTable("SELECT * FROM GetTrainersByGymAndName('" + userid + "', '" + guna2TextBox1.Text + "')");
            alltrainerGridView.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string name = row[3].ToString() + " " + row[4].ToString();

                // Add row in it guna2DataGridView1
                alltrainerGridView.Rows.Add(row[0], name, row[2], row[1], row[5]);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // save alltrainerGridView data to csv file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            saveFileDialog.FileName = "Trainers.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                // get headers
                for (int i = 0; i < alltrainerGridView.Columns.Count; i++)
                {
                    sb.Append(alltrainerGridView.Columns[i].HeaderText + ",");
                }
                sb.AppendLine();
                // get rows
                for (int i = 0; i < alltrainerGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < alltrainerGridView.Columns.Count; j++)
                    {
                        sb.Append(alltrainerGridView.Rows[i].Cells[j].Value + ",");
                    }
                    sb.AppendLine();
                }
                System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }

        }
    }
}
