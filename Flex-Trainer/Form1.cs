using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.SqlClient;

namespace Flex_Trainer
{
    public partial class signin : KryptonForm
    {
        private Flex_Trainer.SQL sql = new Flex_Trainer.SQL();
        public signin()
        {
            InitializeComponent();
            user_selecter.Items.Add("Admin");
            user_selecter.Items.Add("User");
            user_selecter.Items.Add("Trainer");
            user_selecter.Items.Add("Gym Owner");

            // TEST DATA BASE CONNECTION
            //sql.connection.ConnectionString = sql.connectionString;

            sql.OpenConnection();
            //TESTING CONNECTION
            if (sql.connection.State != ConnectionState.Open)
                MessageBox.Show("Connection Failed");
            sql.CloseConnection();
        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //close this window
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //minize window
            this.WindowState = FormWindowState.Minimized;
        }

        private void email_text_box(object sender, EventArgs e)
        {

        }

        private void password_text_box(object sender, EventArgs e)
        {

        }


        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            //close this window
            this.Close();
        }

        private void signin_Load(object sender, EventArgs e)
        {

        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            // this.Hide();
            if (user_selecter.Text == "Admin")
            {
                page_admin page_Admin = new page_admin(this);
                page_Admin.Show();
            }
            else if (user_selecter.Text == "User")
            {
                sql.OpenConnection();
                {
                    string query = "SELECT * FROM Member WHERE Gmail='" + gmail_TextBox.Text + "' AND Password ='" + password_TextBox.Text + "';";
                    SqlCommand command = new SqlCommand(query, sql.connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Hide();
                        string id = reader["Member_SSN"].ToString();
                        page_user user = new page_user(this, id);
                        user.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
                sql.CloseConnection();
            }
            else if (user_selecter.Text == "Trainer")
            {
                sql.OpenConnection();
                {
                    string query = "SELECT * FROM Trainer WHERE Gmail='" + gmail_TextBox.Text + "' AND Password ='" + password_TextBox.Text + "';";
                    SqlCommand command = new SqlCommand(query, sql.connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Hide();
                        string id = reader["Trainer_SSN"].ToString();
                        page_trainer admin = new page_trainer(id,this);
                        admin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
                sql.CloseConnection();
                
            }
            else if (user_selecter.Text == "Gym Owner")
            {
                sql.OpenConnection();
                {
                    string query = "SELECT * FROM Gym_Owner WHERE Gmail='" + gmail_TextBox.Text + "' AND Password ='" + password_TextBox.Text + "';";
                    SqlCommand command = new SqlCommand(query, sql.connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Hide();
                        string id = reader["GO_SSN"].ToString();
                        page_gym_owner gym_owner = new page_gym_owner(this,id);
                        gym_owner.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
                sql.CloseConnection();
            }
        }

        private void SignUp_Button_Click(object sender, EventArgs e)
        {
            if (user_selecter.Text == "Admin")
            {
            }
            if (user_selecter.Text == "User")
            {
                this.Hide();
                signup_member signup_page = new signup_member(this);
                signup_page.Show();
            }
            if (user_selecter.Text == "Trainer")
            {
                this.Hide();
                signup_trainer signup_page = new signup_trainer(this);
                signup_page.Show();
            }
            if (user_selecter.Text == "Gym Owner")
            {
                this.Hide();
                signup_owner signup_page = new signup_owner(this);
                signup_page.Show();
            }
        }
    }
}
