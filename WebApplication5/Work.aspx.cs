using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Work : Page
    {
        public string username { get; set; }
        SqlConnection con = new SqlConnection(@"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                // Assuming you store the username in session after login
                string username = Session["Username"] as string;

                SetAllButtonVisibility(username);

            }
        }

        private DataTable GetUserOrders(string username)
        {
            string query = "SELECT * FROM Products WHERE username = @username";

            //using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        private void SetAllButtonVisibility(string username)
        {
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton1, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton2, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton3, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton4, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton5, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton6, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton7, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton8, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton9, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton10, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton11, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton12, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton13, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton14, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton15, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton16, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton17, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton18, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton19, username);
            ButtonVisibilityHelper.SetButtonVisibility(AddToCartButton20, username);
        }

        private bool IsValidUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;"))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            // Increment cart count
            int cartCount = Convert.ToInt32(Session["CartCount"] ?? 0);
            cartCount++;
            Session["CartCount"] = cartCount;

            // Update UI
            CartCounter.Text = $"Items in Cart: {cartCount}";
            CheckoutLink.Visible = true; // Show checkout link once something is added to cart
        }


        private void InsertTransaction(string username, string productName, decimal totalAmount, int quantity, DateTime transactionDate)
        {
            // Implement logic to insert transaction into your database
            // Example:
            // transactionService.InsertTransaction(username, productName, totalAmount, quantity, transactionDate);

            // For demonstration purposes, assuming direct SQL insert (not recommended; use parameterized queries in practice)
            string connectionString = @"YourConnectionString";
            string query = "INSERT INTO transactions (Username, Product_Name, Totalamount, Quantity, Transaction_date) " +
                           "VALUES (@Username, @ProductName, @Totalamount, @Quantity, @TransactionDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Totalamount", totalAmount);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@TransactionDate", transactionDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //20240620
        //protected void AddToCartButton_Click(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    string username = "ninja"; // Replace with actual logged-in username
        //    int productId = Convert.ToInt32(button.Attributes["data-product-id"]);
        //    int quantity = 1;
        //    decimal price = 500.00m;
        //    decimal totalAmount = quantity * price;

        //    Random rnd = new Random();
        //    int transactionId = rnd.Next(100000, 999999);

        //    string query = "INSERT INTO transactions (username, transaction_id, product_id, transaction_date, quantity, totalamount) " +
        //                   "VALUES (@username, @transactionId, @productId, GETDATE(), @quantity, @totalAmount)";

        //    using (SqlCommand command = new SqlCommand(query, con))
        //    {
        //    command.Parameters.AddWithValue("@username", username);
        //    command.Parameters.AddWithValue("@transactionId", transactionId);
        //    command.Parameters.AddWithValue("@productId", productId);
        //    command.Parameters.AddWithValue("@quantity", quantity);
        //    command.Parameters.AddWithValue("@totalAmount", totalAmount);

        //    con.Open();
        //    command.ExecuteNonQuery();
        //    con.Close();
        //    }

        //}


        //protected void AddToCartButton_Click(object sender, EventArgs e)
        //{
        //    string username = "ninja";
        //    int productId = Convert.ToInt32(((Button)sender).CommandArgument); 
        //    int quantity = 1; 
        //    decimal price = 500.00m; 
        //    decimal totalAmount = quantity * price; 

        //    Random rnd = new Random();
        //    int transactionId = rnd.Next(100000, 999999); // Generate random 6-digit transaction ID

        //    string query = "INSERT INTO transactions (username, transaction_id, product_id, transaction_date, quantity, totalamount) " +
        //                   "VALUES (@username, @transactionId, @productId, GETDATE(), @quantity, @totalAmount)";

        //    using (SqlCommand command = new SqlCommand(query, con))
        //    {
        //        command.Parameters.AddWithValue("@username", username);
        //        command.Parameters.AddWithValue("@transactionId", transactionId);
        //        command.Parameters.AddWithValue("@productId", productId);
        //        command.Parameters.AddWithValue("@quantity", quantity);
        //        command.Parameters.AddWithValue("@totalAmount", totalAmount);

        //        con.Open();
        //        command.ExecuteNonQuery();
        //        con.Close();
        //    }



        //    string username = "ninja"; 
        //    int productId = 1; 

        //    string query = "INSERT INTO transactions (username, transaction_id, product_id, transaction_date, quantity, totalamount) " +
        //                   "VALUES (@username, NEWID(), @productId, GETDATE(), 1, 50.00)";

        //        using (SqlCommand command = new SqlCommand(query, con))
        //        {

        //            command.Parameters.AddWithValue("@username", username);
        //            command.Parameters.AddWithValue("@productId", productId);

        //        con.Open();
        //            command.ExecuteNonQuery();
        //        con.Close();
        //        }
        //protected void OrdersButton_Click(object sender, EventArgs e)
        //{
        //    string username = "ninja"; // Replace with actual logged-in username
        //    string query = "SELECT transaction_id AS OrderId, product_id AS ProductId, quantity, totalamount AS TotalAmount FROM transactions WHERE username = @username";

        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    da.SelectCommand.Parameters.AddWithValue("@username", username);

        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    OrdersGridView.DataSource = dt;
        //    OrdersGridView.DataBind();
        //    OrdersGridView.Visible = true;
        //}
    }
  
}