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
    public partial class gym_member : UserControl
    {
        SQL sql = new SQL();
        string userid;
        public gym_member()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            // SELECT * FROM GetMembersByGym('GYM_001')
            DataTable dt = sql.GetDataTable("SELECT * FROM GetMembersByGym('" + userid + "')");
            //delete previus data
            this.allmemberDataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                // 10101010101	Female	member10@gmail.com	Sophia	White	160	60	Silver	Expired	2023-03-31
                string name = row[3].ToString() + " " + row[4].ToString();
                // Add row in it guna2DataGridView1
                this.allmemberDataGridView1.Rows.Add(row[0], name, row[2], row[1], row[5], row[6], row[7], row[8], row[9]);
            }

        }

        internal void setuserid(string gym_id)
        {
            this.userid = gym_id;
        }

        private void gym_member_Load(object sender, EventArgs e)
        {
            // SELECT * FROM GetMembershipTypes()
            DataTable dt = sql.GetDataTable("SELECT * FROM GetMembershipTypes()");
            foreach (DataRow row in dt.Rows)
            {
                membershiptypesComboBox2.Items.Add(row[0]);
            }
            refresh();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // SELECT * FROM GetMembersByGymAndName('GYM_001', 'Sophia White')
            DataTable dt = sql.GetDataTable("SELECT * FROM GetMembersByGymAndName('" + userid + "', '" + guna2TextBox1.Text + "')");
            this.allmemberDataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string name = row[3].ToString() + " " + row[4].ToString();
                this.allmemberDataGridView1.Rows.Add(row[0], name, row[2], row[1], row[5], row[6], row[7], row[8], row[9]);
            }
        }

        private void membershiptypesComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(membershiptypesComboBox2.Text == "All")
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetMembersByGym('" + userid + "')");
                this.allmemberDataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string name = row[3].ToString() + " " + row[4].ToString();
                    this.allmemberDataGridView1.Rows.Add(row[0], name, row[2], row[1], row[5], row[6], row[7], row[8], row[9]);
                }
            }
            else
            {
                DataTable dt = sql.GetDataTable("SELECT * FROM GetMembersByGym('" + userid + "') WHERE type_membership = '" + membershiptypesComboBox2.Text + "'");
                this.allmemberDataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string name = row[3].ToString() + " " + row[4].ToString();
                    this.allmemberDataGridView1.Rows.Add(row[0], name, row[2], row[1], row[5], row[6], row[7], row[8], row[9]);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // remove selecte row in allmemberDataGridView1
            // EXEC RemoveMemberFromGym '99999999999', 'GYM_001'
            // ask for confermation before deleting
            if (allmemberDataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this member?", "Delete Member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string memberid = allmemberDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    sql.GetDataTable("EXEC RemoveMemberFromGym '" + memberid + "', '" + userid + "'");
                    refresh();
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // dialog to save the data in allmemberDataGridView1 as csv
            // use time stamp for name
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.csv";
            saveFileDialog1.Title = "Save a CSV File";
            DialogResult result = saveFileDialog1.ShowDialog(); // Show the dialog and store the result
            if (result == DialogResult.OK) // Check if the user clicked OK
            {
                string name = saveFileDialog1.FileName; // Get the selected file name
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in allmemberDataGridView1.Columns)
                {
                    dt.Columns.Add(col.HeaderText);
                }
                foreach (DataGridViewRow row in allmemberDataGridView1.Rows)
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
