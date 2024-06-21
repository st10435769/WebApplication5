using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication5
{
    public class OrderService
    {
        private readonly string _connectionString;

        public OrderService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetOrdersByUsername(string username)
        {
            var orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT t.Transaction_ID, p.Product_Name, t.Totalamount, t.Quantity, t.Transaction_date ,t.Status
            FROM transactions t
            JOIN Products p ON t.Product_ID = p.Product_ID
            WHERE t.Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();

                        // Check for DBNull and handle accordingly
                        order.Transaction_ID = reader.IsDBNull(reader.GetOrdinal("Transaction_ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("Transaction_ID"));
                        order.Product_Name = reader.IsDBNull(reader.GetOrdinal("Product_Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Product_Name"));
                        order.Totalamount = reader.IsDBNull(reader.GetOrdinal("Totalamount")) ? 0 : reader.GetInt32(reader.GetOrdinal("Totalamount"));
                        order.Quantity = reader.IsDBNull(reader.GetOrdinal("Quantity")) ? 0 : reader.GetInt32(reader.GetOrdinal("Quantity"));
                        order.Transaction_date = reader.IsDBNull(reader.GetOrdinal("Transaction_date")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Transaction_date"));
                        order.Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader.GetString(reader.GetOrdinal("Status"));

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
    }

    public class Order
    {
        public int Transaction_ID { get; set; }
        public string Product_Name { get; set; }
        public int Totalamount { get; set; }
        public int Quantity { get; set; }
        public DateTime Transaction_date { get; set; }
        public decimal PricePerItem
        {
            get
            {
                return Quantity > 0 ? Math.Round((decimal)Totalamount / Quantity, 2) : 0;
            }
        }
        public string Status { get; set; }
    }
}