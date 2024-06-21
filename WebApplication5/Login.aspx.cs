using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication5
{
    public partial class Login : System.Web.UI.Page
    {
        // Removed unnecessary local connection string

        protected void Page_Load(object sender, EventArgs e)
        {
            // Connection will be opened/closed within loginButton_Click
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string inputUsername = "ninja";
            string inputPassword = "password";

            string connectionString = @"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;";
            //string connectionString = "Data Source=tcp:st10435769db1.database.windows.net,1433;Initial Catalog=khumalocraftdb;User Id=st10435769@st10435769db1;Password=password";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Open the connection within the using block

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM users WHERE username = @username AND password = @password";

                    cmd.Parameters.AddWithValue("@username", inputUsername);
                    cmd.Parameters.AddWithValue("@password", inputPassword);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        string email = reader["email"].ToString();
                        Session["username"] = username;
                        Response.Redirect("~/Work.aspx");
                    }
                    else
                    {
                        errorLabel.Text = "Invalid username or password.";
                        errorLabel.Visible = true;
                    }
                } // Connection is closed automatically here
            }
            catch (SqlException ex)
            {
                // Handle connection or database errors
                errorLabel.Text = "An error occurred: " + ex.Message;
                errorLabel.Visible = true;
            }
        }
    }
}
