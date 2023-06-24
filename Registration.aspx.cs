using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Web_Application_Registration.BEL;
using Web_Application_Registration.BO;
using Web_Application_Registration.DAL;

namespace Web_Application_Registration
{
    public partial class CS : System.Web.UI.Page
    {
        clsDal objnewuser = new clsDal();
        clsMaster objdal = new clsMaster();
        clsBal objbal = new clsBal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindCountry(); 
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string encryptPass = MixStrings(txtUsername.Text.Trim() , "MAkv2SPBnI99212" + txtPassword.Text.Trim());
            string emailId=string.Empty;
            objnewuser.userName = txtUsername.Text.Trim();
            objnewuser.firstName = txtFirstname.Text.Trim();
            objnewuser.middleName = txtMiddlename.Text.Trim();
            objnewuser.lastName = txtLastname.Text.Trim();
            objnewuser.gender = rblGender.SelectedItem.Text.ToString().Trim();
            objnewuser.mobile= txtMobile.Text.Trim();
            objnewuser.email=txtEmail.Text.Trim();
            objnewuser.password= encryptPass;
            objnewuser.address=txtAddress.Text.Trim();
            objnewuser.country = ddlCountry.SelectedItem.Text;
            objnewuser.state = ddlState.SelectedItem.Text;
            objnewuser.city = ddlCity.SelectedItem.Text;
            objnewuser.isActive = chkIsActive.Checked ? true : false;
            objnewuser.createdBy=txtUsername.Text.Trim();
            objnewuser.modifiedBy = txtUsername.Text.Trim();
            int retVal = objdal.AddEmployees(objnewuser);           
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("guptaprince27012001@gmail.com");
            //mailMessage.To.Add(txtEmail.Text);
            //mailMessage.Subject = "Account Activation Email";
            //string ActivationUrl = Server.HtmlEncode("https://localhost:44369/Login.aspx?ID=" + objbal.FetchId(emailId) + "&EmailId=" + emailId);
            //mailMessage.Body = "Hi " + txtUsername.Text.Trim() + "!\n" +
            //  "Thanks for showing interest and registring in <a href='https://localhost:44369/Home.aspx'> Angel Automobile<a> " +
            //  " Please <a href='" + ActivationUrl + "'>click here to activate</a>  your account and enjoy our services. \nThanks!"; ;
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Port = 587;
            //smtpClient.Host = "smtp.gmail.com";
            //smtpClient.EnableSsl = true;
            ////NetworkCredential NetworkCred = new NetworkCredential("guptaprince27012001@gmail.com", "<Password>");
            //smtpClient.UseDefaultCredentials = true;
            ////smtpClient.Credentials = NetworkCred;
            //smtpClient.Send(mailMessage);                 
            if (retVal > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Registration Successful And Activation Mail Has Send To You');window.location='Home.aspx';", true);
                ClearControls();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('User Not Register');", true);
            }
        }

        protected void txtUserName_TextChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("UserRegTable_UserNameValidation", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                lblStatus.ForeColor = System.Drawing.Color.GhostWhite;
                                lblStatus.Text = "UserName Already Taken";
                            }
                            else 
                            {
                                lblStatus.ForeColor = System.Drawing.Color.IndianRed;
                                lblStatus.Text = "UserName Available";
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        private string MixStrings(string username, string password)
        {
            string keyword1 = "MAkv2SPBnI99212";

            StringBuilder mixedString = new StringBuilder();
            int maxLength = Math.Max(username.Length, password.Length);

            for (int i = 0; i < maxLength; i++)
            {
                if (i < username.Length)
                    mixedString.Append(username[i]);

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

        private void BindCountry()
        {
            DataTable dtCountry = clsMaster.GetCountryList();
            ddlCountry.DataSource = dtCountry;
            ddlCountry.DataTextField = "County";
            ddlCountry.DataValueField = "CountryId";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("---Select Country---"));
        }

        protected void ddlCountry_OnSelectedIndexChanged(object sender, EventArgs e) 
        {
            this.BindState();
        }

        private void BindState()
        {
            int country_id;
            int.TryParse(ddlCountry.SelectedValue, out country_id);
            DataTable dtState = clsMaster.GetStateList(country_id);
            ddlState.DataSource = dtState;
            ddlState.DataTextField = "State";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("---Select State---"));
        }

        protected void ddlState_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindCity();
        }

        private void BindCity()
        {
            int state_Id;
            int.TryParse(ddlState.SelectedValue, out state_Id);
            DataTable dtCity = clsMaster.GetCityList(state_Id);
            ddlCity.DataSource = dtCity;
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("---Select City---"));
        }

        private void ClearControls()
        {
            txtUsername.Text = string.Empty;
            txtFirstname.Text = string.Empty;
            txtMiddlename.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty; 
            txtPassword.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
    }
}