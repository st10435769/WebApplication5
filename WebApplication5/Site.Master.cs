using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                UsernameLabel.Text = "Welcome, " + Session["Username"].ToString();
                loginLink.Visible = false;
                registerLink.Visible = false;
                logoutLink.Visible = true;
                searchLink.Visible = true;
                ordersLink.Visible = true;
            }
            else
            {
                UsernameLabel.Text = "Welcome, Guest";
                loginLink.Visible = true;
                registerLink.Visible = true;
                logoutLink.Visible = false;
                searchLink.Visible = false;
                ordersLink.Visible = false;
            }
        }
    }
}