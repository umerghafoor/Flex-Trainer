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
    public partial class page_gym_owner : Form
    {
        SQL sql = new SQL();
        signin parent;
        string userid;
        //list of all gyms
        List<Gym> gyms = new List<Gym>();
        public page_gym_owner(signin parent, string userid)
        {
            InitializeComponent();
            this.gym_member1.Visible = true;
            this.gym_trainer1.Visible = false;
            this.gym_requests1.Visible = false;
            this.userid = userid;
            this.parent = parent;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.gym_requests1.Visible = false;
            this.gym_trainer1.Visible = false;
            this.gym_member1.Visible = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.gym_requests1.Visible = false;
            this.gym_member1.Visible = false;
            this.gym_trainer1.Visible = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.gym_requests1.Visible = true;
            this.gym_member1.Visible = false;
            this.gym_trainer1.Visible = false;
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            signup_gym signup_Gym = new signup_gym(userid);
            signup_Gym.Show();
        }

        private void allgymsComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gym_trainer1.setuserid(gyms[allgymsComboBox1.SelectedIndex].gym_id);
            this.gym_trainer1.refresh();
            this.gym_member1.setuserid(gyms[allgymsComboBox1.SelectedIndex].gym_id);
            this.gym_member1.refresh();
            this.gym_requests1.setuserid(gyms[allgymsComboBox1.SelectedIndex].gym_id);
            this.gym_requests1.refresh();
        }

        private void page_gym_owner_Load(object sender, EventArgs e)
        {
            // SELECT* FROM GetGymsByOwner('GO_001') set allgyms combo box
            DataTable dt = sql.GetDataTable("SELECT* FROM GetGymsByOwner('" + userid + "')");
            // Insert names to the List
            foreach (DataRow row in dt.Rows)
            {
                Gym gym = new Gym(row["gym_ssn"].ToString(), row["gym_name"].ToString());
                gyms.Add(gym);
            }
            // Insert names to the combo box
            foreach (Gym gym in gyms)
            {
                allgymsComboBox1.Items.Add(gym.gym_name);
            }
            // set close event
            this.FormClosing += new FormClosingEventHandler(this.page_gym_owner_FormClosing);
        }

        private void page_gym_owner_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void logout_Button_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }
    }

    internal class Gym
    {
        public string gym_id;
        public string gym_name;

        public Gym(string v1, string v2)
        {
            this.gym_id = v1;
            this.gym_name = v2;
        }
    }
}
