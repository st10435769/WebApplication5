using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Orders : System.Web.UI.Page
    {
        private readonly OrderService _orderService;

        public Orders()
        {
            _orderService = new OrderService(@"Data Source=TREVOR-LAPTOP\SQLEXPRESS;Initial Catalog=khumalocraftdb;Integrated Security=True;Encrypt=False;");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    string username = Session["username"].ToString();
                    Page.Title = "My Orders - " + username;
                    OrdersHeading.Text = "My Orders - " + username;

                    List<Order> orders = _orderService.GetOrdersByUsername(username);
                    if (orders.Count > 0)
                    {
                        OrdersGridView.DataSource = orders;
                        OrdersGridView.DataBind();
                    }
                    else
                    {
                        NoOrdersLiteral.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}