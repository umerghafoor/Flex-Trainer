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
    public partial class gym_requests : UserControl
    {
        SQL sql = new SQL();
        string userid;
        public gym_requests()
        {
            InitializeComponent();
        }

        public void setuserid(string id)
        {
            userid = id;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(guna2DataGridView1.SelectedRows.Count > 0)
            {
                string id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string type = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                if (type == "Member")
                {
                    //SELECT * FROM ApproveMemberRegistrationRequest @MemberSSN,  @GymSSN
                    sql.ExecuteQuery("EXEC ApproveMemberRegistrationRequest '" + id + "','"+ userid + "'");
                    
                }
                else if (type == "Trainer")
                {
                    //SELECT * FROM ApproveTrainerRegistrationRequest @TrainerSSN,  @GymSSN
                    sql.ExecuteQuery("EXEC ApproveTrainerRegistrationRequest '" + id + "','" + userid + "'");

                }
                refresh();
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(guna2ComboBox1.SelectedIndex == 0)
            {
                refresh();
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                guna2DataGridView1.Rows.Clear();
                DataTable dt = sql.GetDataTable("SELECT* FROM GetMemberRegistrationRequestsByGym('" + userid + "')");
                foreach (DataRow row in dt.Rows)
                {
                    string name = row[3].ToString() + " " + row[4].ToString();
                    guna2DataGridView1.Rows.Add(row[0].ToString(), name, row[2].ToString(), row[1].ToString(), "Member");
                }
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                guna2DataGridView1.Rows.Clear();
                DataTable dt = sql.GetDataTable("SELECT* FROM GetTrainerRegistrationRequestsByGym('" + userid + "')");
                foreach (DataRow row in dt.Rows)
                {
                    string name = row[3].ToString() + " " + row[4].ToString();
                    guna2DataGridView1.Rows.Add(row[0].ToString(), name, row[2].ToString(), row[1].ToString(), "Trainer");
                }
            }
        }

        public void refresh()
        {
            guna2DataGridView1.Rows.Clear();
            // SELECT* FROM GetMemberRegistrationRequestsByGym('12345678902')
            DataTable dt = sql.GetDataTable("SELECT* FROM GetMemberRegistrationRequestsByGym('" + userid + "')");
            foreach (DataRow row in dt.Rows)
            {
                string name = row[3].ToString() + " " + row[4].ToString();
                guna2DataGridView1.Rows.Add(row[0].ToString(), name, row[2].ToString(), row[1].ToString(), "Member");
            }
            DataTable dt2 = sql.GetDataTable("SELECT* FROM GetTrainerRegistrationRequestsByGym('" + userid + "')");
            foreach (DataRow row in dt2.Rows)
            {
                string name = row[3].ToString() + " " + row[4].ToString();
                guna2DataGridView1.Rows.Add(row[0].ToString(), name, row[2].ToString(), row[1].ToString(), "Trainer");
            }
        }
        private void gym_requests_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string type = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                if (type == "Member")
                {
                    //SELECT * FROM ApproveMemberRegistrationRequest @MemberSSN,  @GymSSN
                    sql.ExecuteQuery("EXEC RejectMemberRegistrationRequest '" + id + "','" + userid + "'");

                }
                else if (type == "Trainer")
                {
                    //SELECT * FROM ApproveTrainerRegistrationRequest @TrainerSSN,  @GymSSN
                    sql.ExecuteQuery("EXEC RejectTrainerRegistrationRequest '" + id + "','" + userid + "'");

                }
                refresh();
            }
        }
    }
}
