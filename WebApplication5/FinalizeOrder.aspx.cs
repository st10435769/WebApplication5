using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class FinalizeOrder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null && Session["CartItems"] != null)
                {
                    UsernameHiddenField.Value = Session["Username"].ToString();
                    BindOrderSummary();
                }
                else
                {
                    // Redirect to the previous page if session is null
                    Response.Redirect("Checkout.aspx");
                }
            }
        }

        private void BindOrderSummary()
        {
            List<CartItemFinal> cartItems = (List<CartItemFinal>)Session["CartItems"];
            if (cartItems.Count > 0)
            {
                var orders = cartItems.Select(item => new
                {
                    item.Product_Name,
                    item.Quantity,
                    PricePerItem = item.Totalamount / item.Quantity,
                    item.Totalamount
                }).ToList();

                OrderSummaryGridView.DataSource = orders;
                OrderSummaryGridView.DataBind();
                CartItemsHiddenField.Value = string.Join(",", orders.Select(o => $"{o.Product_Name}|{o.Quantity}|{o.PricePerItem}|{o.Totalamount}"));
            }
        }

        protected void TermsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SubmitOrderButton.Enabled = TermsCheckBox.Checked;
        }

        protected void SubmitOrderButton_Click(object sender, EventArgs e)
        {
            if (TermsCheckBox.Checked)
            {
                List<CartItemFinal> cartItems = (List<CartItemFinal>)Session["CartItems"];
                SaveOrderToDatabase(cartItems, UsernameHiddenField.Value);
                Session["CartItems"] = null;
                Response.Redirect("ThankYou.aspx"); // Redirect to a thank you or order confirmation page
            }
        }

        private void SaveOrderToDatabase(List<CartItemFinal> cartItems, string username)
        {
            using (SqlCommand command = new SqlCommand("", con))
            {
                con.Open();
                foreach (var item in cartItems)
                {
                    Random rnd = new Random();
                    int transactionId = rnd.Next(100000, 999999);

                    string query = "INSERT INTO transactions (username, transaction_id, product_id, transaction_date, quantity, totalamount) " +
                                   "VALUES (@username, @transactionId, @productId, GETDATE(), @quantity, @totalAmount)";

                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@transactionId", transactionId);
                    command.Parameters.AddWithValue("@productId", item.Product_Id);
                    command.Parameters.AddWithValue("@quantity", item.Quantity);
                    command.Parameters.AddWithValue("@totalAmount", item.Totalamount);
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }

    public class CartItemFinal
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public decimal Totalamount { get; set; }
    }

    public class Transaction
    {
        public int Transaction_Id { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
