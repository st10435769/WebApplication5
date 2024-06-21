using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Register : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(@"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        SqlConnection con = new SqlConnection(@"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

        }
        protected void registerButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO users (username, password, email, address, contact_no) VALUES (@username, @password, @email, @address, @contact_no)";

            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@address", address.Text);
            cmd.Parameters.AddWithValue("@contact_no", contact_no.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Response.Redirect("~/UserCreated.aspx");
            }
            else
            {

            }
        }
    }
}