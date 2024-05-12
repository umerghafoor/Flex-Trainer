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
    public partial class signup_gym : Form
    {
        SQL sql = new SQL();
        string gym_owner_ssn = "";
        public signup_gym(string gym_owner)
        {
            InitializeComponent();
            gym_owner_ssn = gym_owner;
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            // EXEC CreateGymRegistrationRequest @GymSSN = '12345678903', @Name = 'Gym 3', @Gmail = 'v', @Location = 'v', @OwnerSSN = 'GO_001'
            string ssn = this.ssnTextBox1.Text;
            string name = this.name_TextBox.Text;
            string gmail = this.gmail_TextBox.Text;
            string location = this.locationTextBox1.Text;
            string owner_ssn = gym_owner_ssn;
            //create checks for empty fields
            if (ssn == "" || name == "" || gmail == "" || location == "" || owner_ssn == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            DataTable dt = sql.GetDataTable("EXEC CreateGymRegistrationRequest '" + ssn + "','" + name + "','" + gmail + "','" + location + "', '" + owner_ssn + "'");
            // if row[0][0] == 1 then success
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Gym registration request sent successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Gym Already Present");
            }
            this.Close();
        }
    }
}
