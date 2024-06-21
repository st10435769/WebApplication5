using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication5.Services;

namespace WebApplication5
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                string searchTerm = Request.QueryString["searchTerm"];
                DataTable dt = GetSearchResultsFromDatabase(searchTerm);

                if (dt.Rows.Count == 0)
                {
                    SearchResultsRepeater.Visible = false; // Hide the repeater if no products found
                    noResultsMessage.Visible = true; // Show the no results message
                }
                else
                {
                    SearchResultsRepeater.Visible = true; // Show the repeater if products found
                    noResultsMessage.Visible = false; // Hide the no results message

                    SearchResultsRepeater.DataSource = dt;
                    SearchResultsRepeater.DataBind();
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchTextBox.Text.Trim();

            DataTable searchResults = GetSearchResultsFromDatabase(searchTerm);

            SearchResultsRepeater.DataSource = searchResults;
            SearchResultsRepeater.DataBind();
        }

        private DataTable GetSearchResultsFromDatabase(string searchTerm)
        {
            string connectionString = @"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;";
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Product_Name, Product_Price, Product_Description FROM Products WHERE Product_Name LIKE @searchTerm";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}