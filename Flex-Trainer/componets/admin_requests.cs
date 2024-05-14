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
    public partial class admin_requests : UserControl
    {
        SQL sql = new SQL();
        public admin_requests()
        {
            InitializeComponent();
        }

        private void admin_requests_Load(object sender, EventArgs e)
        {
            // SELECT * FROM GetGymRegistrationRequests()
            DataTable dt = sql.GetDataTable(" SELECT * FROM GetGymRegistrationRequests()");
            guna2DataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                guna2DataGridView1.Rows.Add(row.ItemArray);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // EXEC ApproveGymRegistrationRequest '12445678906'
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sql.ExecuteQuery("EXEC ApproveGymRegistrationRequest '" + id + "'");
                admin_requests_Load(sender, e);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // EXEC RejectGymRegistrationRequest '12445678907'
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string id = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                sql.ExecuteQuery("EXEC RejectGymRegistrationRequest '" + id + "'");
                admin_requests_Load(sender, e);
            }
        }
    }
}
