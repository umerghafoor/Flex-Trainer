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
    public partial class signup_member : Form
    {
        signin parent;
        private SQL sql = new SQL();
        public signup_member(signin parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            //create checks
            if (ssnTextBox1.Text.Length != 11)
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


            if (password1_TextBox.Text == password2_TextBox.Text)
            {
                // EXEC CreateMemberRegistrationRequest '11111111111', 'M', 'test@gmail.com', 'John', 'Doe', 5, 70, 'password123'
                string query = "EXEC CreateMemberRegistrationRequest '" + ssnTextBox1.Text + "', '" + GenderComboBox.Text + "', '" + gmail_TextBox.Text + "', '" + Fname_TextBox.Text + "', '" + Lname_TextBox.Text + "', " + height.Value + ", " + weight.Value + ", '" + password1_TextBox.Text + "'";
                DataTable dt = sql.GetDataTable(query);
                // if dt[0][0] == 1
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Account Request Created");
                }
                else
                {
                    MessageBox.Show("Account already Present");
                }
            }
            else
            {
                MessageBox.Show("Password does not match");
            }
        }

        

    

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void signup_Load(object sender, EventArgs e)
        {
            // set close event
            this.FormClosing += new FormClosingEventHandler(signup_FormClosing);
        }

        private void signup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.Show();
        }
    }
}
