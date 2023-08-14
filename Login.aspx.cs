using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application_Registration.BEL;
using Web_Application_Registration.BO;

namespace Web_Application_Registration
{
    public partial class Login : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void OnLogin_Click(object sender, EventArgs e)
        {
            int userid = 0;
            string roles = string.Empty;
            string mixedPassword = MixStrings(txtUsername.Text, "MAkv2SPBnI99212" + txtPassword.Text);
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select u.UserId,u.Password,r.roleName as Roles from UserRegTable u inner join User_tblRole r on r.roleId=u.RoleId WHERE Username=@UserName", con))
                {
                    cmd.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader()) 
                    {
                        sdr.Read();
                        string storePassword = sdr["Password"].ToString();
                        if (storePassword == mixedPassword)
                        {
                            userid = Convert.ToInt32(sdr["UserId"]);
                            roles = sdr["Roles"].ToString();
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUsername.Text.Trim(), DateTime.Now, DateTime.Now.AddMinutes(2880), chkRemember.Checked, roles, FormsAuthentication.FormsCookiePath);
                            string hash = FormsAuthentication.Encrypt(ticket);
                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                            if (ticket.IsPersistent)
                            {
                                cookie.Expires = ticket.Expiration;
                            }
                            Response.Cookies.Add(cookie);
                            Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text.Trim(), chkRemember.Checked));
                            ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Login Successful');window.location='Home.aspx';");
                        }
                        else 
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Invalid Password');", true);
                        }
                        con.Close();                       
                    }
                }                
            }            
        }

        protected void OnForget_Password(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }

        private string MixStrings(string username, string password)
        {
            string keyword1 = "MAkv2SPBnI99212";
            StringBuilder mixedString = new StringBuilder();
            int maxLength = Math.Max(username.Length, password.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (i < username.Length)
                {
                    mixedString.Append(username[i]);
                }
                 
                if (i < password.Length)
                {
                    mixedString.Append(password[i]);
                    mixedString.Append(GetKeywordCharacter(i, keyword1));
                }
            }
            return mixedString.ToString();
        }

        private char GetKeywordCharacter(int index, string keyword)
        {
            int keywordIndex = index % keyword.Length;
            return keyword[keywordIndex];
        }
    }
}