using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.Properties
{
    public partial class ProductManagement : System.Web.UI.Page
    {
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            double price = Convert.ToDouble(PriceTextBox.Text);
            string description = DescriptionTextBox.Text;

            // Code to update the product in your data source

            // Show notification
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showNotification('Product updated: " + productName + "');", true);
        }
    }
}