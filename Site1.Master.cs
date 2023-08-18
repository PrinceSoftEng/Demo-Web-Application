using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application_Registration.Roles;

namespace Web_Application_Registration
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string userRole = GetUserRole();
                Menu1.Items.Clear();
                SiteMapDataSource1.SiteMapProvider = "SiteMap";
                Menu1.DataSource = SiteMapDataSource1;
                Menu1.DataBind();

                foreach (MenuItem menuItem in Menu1.Items)
                {   
                    if (HttpContext.Current.User.IsInRole(userRole))
                    {
                        menuItem.Enabled = true;
                    }
                    else 
                    {
                        menuItem.Enabled = false;
                    }
                }
            }
        }
       
        private string GetUserRole()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                lblUserName.Text = HttpContext.Current.User.Identity.Name;
                lblUserName.Visible = true;
                lblMessage.Visible = true;
                lnkUserName.Visible = true;
                Menu1.Visible = true;
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    return "Admin";
                }
                else
                {
                    return "User";
                }
            }
            return " ";
        }

        protected void OnTermsnCondition(object sender, EventArgs e)
        {
            Response.Redirect("TermsNCondition.aspx");
        }

        protected void OnContactUs(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void lblUserName_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}