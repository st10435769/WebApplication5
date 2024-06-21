using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace WebApplication5
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        private void BindCart()
        {
            List<CartItem> cartItems;

            if (Session["CartItems"] == null)
            {
                // Initialize with random details for 5 items
                cartItems = GenerateRandomCartItems(5);

                Session["CartItems"] = cartItems;
            }
            else
            {
                cartItems = (List<CartItem>)Session["CartItems"];
            }

            if (cartItems.Count > 0)
            {
                CartRepeater.DataSource = cartItems;
                CartRepeater.DataBind();
            }
            else
            {
                CartRepeater.Visible = false; // Hide the repeater if there are no items
                NoItemsMessage.Visible = true; // Show message that cart is empty
            }
        }

        private List<CartItem> GenerateRandomCartItems(int itemCount)
        {
            Random rnd = new Random();
            List<CartItem> cartItems = new List<CartItem>();

            // Sample details for each product
            string[] productNames = {
        "Handcrafted Ceramic Vase",
        "Handcrafted Wooden Bowl",
        "Handcrafted Glass Sculpture",
        "Handcrafted Metal Wall Art"
    };
            decimal[] productPrices = { 500.00m, 150.00m, 250.00m, 200.00m };

            for (int i = 1; i <= itemCount; i++)
            {
                int index = rnd.Next(productNames.Length); // Random index for product details

                // Create a new CartItem with randomized details
                CartItem item = new CartItem
                {
                    OrderId = i,
                    Product_Name = productNames[index],
                    Quantity = rnd.Next(1, 5), // Random quantity between 1 and 4
                    TotalAmount = productPrices[index] // Total amount based on selected product price
                };

                cartItems.Add(item);
            }

            return cartItems;
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            // Clear cart session
            Session["CartCounter"] = 0;
            Session["CartItems"] = null;
            Response.Redirect("Work.aspx");
        }

        protected void CheckoutButton1_Click(object sender, EventArgs e)
        {
            string username = (string)Session["username"];
            if (!string.IsNullOrEmpty(username) && Session["CartItems"] == null)
            {
                List<CartItem> cartItems = (List<CartItem>)Session["CartItems"];
                foreach (var item in cartItems)
                {
                    InsertTransaction(username, item.Product_Name, item.Quantity, item.TotalAmount);
                }

                // Clear the cart session
                Session["CartItems"] = null;

                // Redirect to a thank you or order confirmation page
                Response.Redirect("ThankYou.aspx");
            }
            else
            {
                // Handle the case where there are no cart items or user is not logged in
                Response.Redirect("Work.aspx");
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Work.aspx");
        }


        private void InsertTransaction(string username, string productName, int quantity, decimal totalAmount)
        {
            Random rnd = new Random();
            int transactionId = rnd.Next(100000, 999999);

            string query = "INSERT INTO orders (username, transaction_id, product_name, transaction_date, quantity, totalamount) " +
                           "VALUES (@username, @transactionId, @productName, GETDATE(), @quantity, @totalAmount)";

            using (SqlConnection con = new SqlConnection(@"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;"))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@transactionId", transactionId);
                    command.Parameters.AddWithValue("@productName", productName);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@totalAmount", totalAmount);

                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class CartItem
    {
        public int OrderId { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public decimal Product_Price { get; set; }
    }
}
