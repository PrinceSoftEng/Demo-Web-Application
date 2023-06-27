using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Web_Application_Registration.BO;

namespace Web_Application_Registration
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        clsBal bal = new clsBal();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnBackbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void OnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Session["Email"] = txtEmail.Text;
                string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlDataAdapter sdr = new SqlDataAdapter("Select * from UserRegTable where Email=@Email",con))
                    {
                        con.Open();
                        sdr.SelectCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                        sdr.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            SqlCommand cmd = new SqlCommand("Update UserRegTable set Password_Change_Status=1 where Email='" + txtEmail.Text + "'", con);
                            cmd.ExecuteNonQuery();
                            SendMail();
                            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(Successfully sent Password reset link on your mail ,please check once! Thank you.)", true);
                            con.Close();
                            txtEmail.Text = "";
                        }
                        else 
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(Please enter Valid Email )", true);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void SendMail()
        {
            try
            {
                StringBuilder stringBuilder= new StringBuilder();
                stringBuilder.Append("Hi,<br/> Click on below link to reset your password<br/>");
                stringBuilder.Append("<a href=https://localhost:44369/ResetPasswordLink.aspx?UserName="+bal.GetUserName(txtEmail.Text.Trim())+"<br/>");
                stringBuilder.Append("Email =" + txtEmail.Text + ">Click Here To Change Password</a><br/>");
                stringBuilder.Append("<b>Thanks & Regards</b>,<br>Prince Gupta<br/>");
                SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                MailMessage mm = new MailMessage("princegupta.0627@gmail.com", txtEmail.Text.Trim(), "Reset Your Password", stringBuilder.ToString());
                mm.IsBodyHtml = true;
                SmtpClient smtp= new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("princegupta.0627@gmail.com", "Mamydady@092701");
                smtp.Send(mm);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}