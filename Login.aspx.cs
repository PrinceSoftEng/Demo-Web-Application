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
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Please enter a value in all fields');", true);
            }

            try
            {
                Session["UserName"] = txtUsername.Text;
                string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    // Retrieve the user record based on the entered username and password
                    string sp = "UserRegTable_LoginCredintials";
                    using (SqlCommand cmd = new SqlCommand(sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                Session["UserName"] = txtUsername.Text;
                                string storedPassword = dr["Password"].ToString();
                                string mixedPassword = MixStrings(txtUsername.Text, "MAkv2SPBnI99212" + txtPassword.Text);

                                if (storedPassword == mixedPassword)
                                {
                                    ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Login Successful');window.location='Home.aspx';", true);
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Invalid Password');", true);
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Invalid UserName');", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
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