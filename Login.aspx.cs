using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application_Registration.BEL;
using Web_Application_Registration.BO;

namespace Web_Application_Registration
{
    public partial class Login : System.Web.UI.Page
    {
        clsDal dal=new clsDal();
        clsBal bal= new clsBal();
        DataTable dt = new DataTable(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnLogin_Click(object sender, EventArgs e)
        { 
            dal.userName=txtUsername.Text;
            dal.password=txtPassword.Text;
            dt = bal.GetLogin(dal);
            if (dt.Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Login Successful');window.location='Home.aspx';", true);
            }
            else
            {
                Response.Write("<script> alert('Not Valid User……') </script>");
            }
        }
    }
}