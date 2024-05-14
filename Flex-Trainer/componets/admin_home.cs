using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Flex_Trainer
{
    public partial class admin_home : UserControl
    {
        SQL sql = new SQL();
        public admin_home()
        {
            InitializeComponent();
        }

        private void admin_home_Load(object sender, EventArgs e)
        {
            // guna2DataGridView1
            // SELECT * FROM GetGymsWithMemberships()
            DataTable dt = sql.GetDataTable("SELECT * FROM GetGymsWithMemberships()");
            foreach (DataRow row in dt.Rows)
            {
                guna2DataGridView1.Rows.Add(row.ItemArray);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            string status = statusComboBox1.Text == "All" ? "" : statusComboBox1.Text;
            string packageFilter = guna2ComboBox2.Text == "All" ? "" : " AND Package LIKE '%" + guna2ComboBox2.Text + "%'";
            string searchFilter = searchTextBox1.Text.Trim() != "" ? " AND (GYM_SSN LIKE '%" + searchTextBox1.Text.Trim() + "%' OR GYM_Name LIKE '%" + searchTextBox1.Text.Trim() + "%')" : "";

            string query = "";

            if (guna2ToggleSwitch1.Checked)
            {
                query = "SELECT * FROM GetGymsWithLatestMembership() WHERE Membership_Status LIKE '%" + status + "%'" + packageFilter + searchFilter;
            }
            else
            {
                query = "SELECT * FROM GetGymsWithMemberships() WHERE Membership_Status LIKE '%" + status + "%'" + packageFilter + searchFilter;
            }

            DataTable dt = sql.GetDataTable(query);
            guna2DataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                guna2DataGridView1.Rows.Add(row.ItemArray);
            }
        }

        private void searchTextBox1_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            // EXEC RevokeGymMembershipByAdmin '12345678902', 'Silver'
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string ssn = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string package =guna2ComboBox1.Text;
                // open dialog to asl for confermation
                if (guna2ComboBox1.SelectedIndex != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to revoke membership?", "Revoke Membership", MessageBoxButtons.YesNo);

                    this.guna2ComboBox1.SelectedIndex = 0;
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        DataTable dt = sql.GetDataTable("EXEC RevokeGymMembershipByAdmin '" + ssn + "', '" + package + "'");
                        // if dt[0][0] == "1" then success
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            MessageBox.Show("Membership revoked successfully");
                            update();
                        }
                        else
                        {
                            MessageBox.Show("Failed to revoke membership");
                        }
                        update();
                    }
                }
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // EXEC DeleteGymByAdmin '12345678902'
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string ssn = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                // open dialog to asl for confermation
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete gym?", "Delete Gym", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    DataTable dt = sql.GetDataTable("EXEC DeleteGymByAdmin '" + ssn + "'");
                    // if dt[0][0] == "1" then success
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Gym deleted successfully");
                        update();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete gym");
                    }
                    update();
                }
            }
        }
    }
}
