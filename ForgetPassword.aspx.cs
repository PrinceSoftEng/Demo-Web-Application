using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application_Registration
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void OnSendEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                string username = string.Empty;
                string password = string.Empty;
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UserRegTable_spSendPasswordThroughEmail", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                username = sdr["UserName"].ToString();
                                password = sdr["Password"].ToString();
                            }
                        }
                        con.Close();
                    }
                }
                if (!string.IsNullOrEmpty(password))
                {
                    MailMessage mm = new MailMessage("princegupta.0627@gmail.com", txtEmail.Text.Trim());
                    mm.Subject = "Password Recovery";
                    mm.Body = string.Format("Hi {0},<br/><br/>Your Password is {1}.<br/><br/>Thank You.", username, password);
                    mm.IsBodyHtml = true;
                    NetworkCredential networkCredential = new NetworkCredential("princegupta.0627@gmail.com", "Mamydady@092701");
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = networkCredential;
                    smtpClient.Port = 465;
                    smtpClient.Send(mm);
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(Password has been sent to your email address.)", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(This email address does not match our records.)", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Please Enter Your EmailId');", true);
            }
        }
    }
}