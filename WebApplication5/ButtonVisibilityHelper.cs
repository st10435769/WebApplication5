using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5
{
    public class ButtonVisibilityHelper
    {
        public static void SetButtonVisibility(System.Web.UI.WebControls.Button button, string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                button.Visible = true;
            }
            else
            {
                button.Visible = false;
            }
        }
    }
}