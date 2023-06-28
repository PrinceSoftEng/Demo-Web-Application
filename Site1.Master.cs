using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application_Registration
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnTermsnCondition(object sender, EventArgs e)
        { 
            Response.Redirect("TermsNCondition.aspx");
        }
        protected void OnViewCars(object sender, EventArgs e)
        {
            Response.Redirect("Viewcars.aspx");
        }

        protected void OnContactUs(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");   
        }

        protected void OnAboutUs(object sender, EventArgs e)
        {
            Response.Redirect("AboutUs.aspx");
        }

        protected void OnSignUp(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");    
        }
        protected void OnLogin(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        //public Label labelUsername
        //{
        //    get { return this.labelUsername; }
        //}
        //public LinkButton btnlogin
        //{
        //    get { return this.btnlogin; }
        //}
        
    }
}