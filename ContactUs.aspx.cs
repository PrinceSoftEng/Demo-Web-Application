using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application_Registration
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress(txtEmail.Text);
                Msg.To.Add("guptaprince27012001@gmail.com");
                Msg.Subject = txtSubject.Text;
                Msg.Body = "Name:" + txtName.Text + "<br/><br/>Email:" + txtEmail.Text + "<br/>" + txtMessage.Text;
                if (FileUpload1.HasFile)
                {
                    string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    Msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, fileName));
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("guptaprince27012001@gmail.com", "yourpassword");
                smtp.EnableSsl = true;
                smtp.Send(Msg);
                lblMessage.Text = "Thanks for Contact us";
                txtName.Text = "";
                txtSubject.Text = "";
                txtMessage.Text = "";
                txtEmail.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }
    }
}