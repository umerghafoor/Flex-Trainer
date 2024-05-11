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
    public partial class signup_trainer : Form
    {
        private Flex_Trainer.SQL sql = new Flex_Trainer.SQL();
        signin parent;
        public signup_trainer(signin parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            //create checks
            if (SSN_TextBox.Text.Length != 11)
            {
                MessageBox.Show("SSN must be 11 characters long");
                return;
            }
            if (gmail_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Email must be filled out");
                return;
            }
            if (Fname_TextBox.Text.Length == 0)
            {
                MessageBox.Show("First Name must be filled out");
                return;
            }
            if (Lname_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Last Name must be filled out");
                return;
            }
            if (password1_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Password must be filled out");
                return;
            }
            if (password2_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Password must be filled out");
                return;
            }



            if (this.password1_TextBox.Text == password2_TextBox.Text)
            {
                // EXEC CreateTrainerRegistrationRequest 'T_002', 'M', 'trainer@gmail.com', 'Trainer', 'Trainer', 2, 'password456'
                string query = "EXEC CreateTrainerRegistrationRequest '" + SSN_TextBox.Text + "', '" + GenderComboBox.Text + "', '" + gmail_TextBox.Text + "', '" + Fname_TextBox.Text + "', '" + Lname_TextBox.Text + "', " + YoE_NumericUpDown.Value.ToString() + ", '" + password1_TextBox.Text + "'";
                DataTable dt = sql.GetDataTable(query);
                // if dt[0][0] == 1
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Account Request Created");
                }
                else
                {
                    MessageBox.Show("Account Already Present");
                }
            }
            else
            {
                MessageBox.Show("Password does not match");
            }
        }
           
        

        private void signup_trainer_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(signup_FormClosing);
        }

        private void signup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.Show();
        }
    }
}
