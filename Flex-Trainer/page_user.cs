using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flex_Trainer
{
    public enum UserType
    {
        Trainer,
        Member
    }
    public partial class page_user : Form
    {
        private string id;
        private signin parent;
        SQL sql = new SQL();
        public page_user(signin parent,string id)
        {
            this.id = id;
            this.parent = parent;
            InitializeComponent();
            this.trainer_workout1.setUser(id,UserType.Member);
            this.traner_diet1.setuser(id,UserType.Member);
            this.userControl11.setvalues(id);
            this.traner_feedback1.Visible = false;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = false;
            this.userControl11.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.traner_feedback1.Visible = false;
            this.trainer_workout1.Visible = false;
            this.traner_diet1.Visible = false;
            this.userControl11.Visible = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.userControl11.Visible = false;
            this.trainer_workout1.Visible = true;
            this.traner_diet1.Visible = false;
            this.traner_feedback1.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.userControl11.Visible = false;
            this.traner_feedback1.Visible = false;
            this.traner_diet1.Visible = true;
            this.trainer_workout1.Visible = false;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.userControl11.Visible = false;
            this.traner_feedback1.Visible = true;
            this.traner_diet1.Visible = false;
            this.trainer_workout1.Visible = false;
        }

        private void page_user_Load(object sender, EventArgs e)
        {
            string name,gmail;
            sql.OpenConnection();
            string query = "SELECT * FROM Member WHERE Member_SSN = '" + this.id + "'";
            // exec and get name and gmail
            SqlCommand command = new SqlCommand(query, sql.getSqlConection());
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                name = reader["First_Name"].ToString() + " " + reader["Last_Name"].ToString();
                gmail = reader["Gmail"].ToString();
                this.userControl11.setUserName(name, gmail);
            }
            sql.CloseConnection();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {
            int[] values = { 100, 100, 30, 40, 50, 60, 70 };
            this.userControl11.setChartValue(values);
        }

        private void logout_Button_Click(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();
        }
    }
}
