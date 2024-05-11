using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Flex_Trainer
{

    internal class SQL
    {
        public const string connectionString = "Data Source=UMERS-LENOVO-X1\\MSSQLSERVER01;Initial Catalog=i22_2328_SecK_Lab12;Integrated Security=True;";
        public SqlConnection connection = new SqlConnection();
        // function for opeing SQL DATABASE
        public void OpenConnection()
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            connection.ChangeDatabase("FlexTrainer2");
        }
        public void CloseConnection()
        {
            connection.Close();
        }

        public SqlConnection getSqlConection()
        {
            return connection;
        }

        internal DataTable GetDataTable(string v)
        {


            // apply try catch on full function
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(v, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                // close the connection
                CloseConnection();
            }

        }

    }
}
