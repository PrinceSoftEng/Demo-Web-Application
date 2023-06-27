using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application_Registration
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            string username = Session["UserName"].ToString();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            string username = Session["UserName"].ToString();
            string encryptPass = MixStrings(username , "MAkv2SPBnI99212" + txtNewPass.Text.Trim());
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UserRegTable_spUpdatePassword", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Password", encryptPass);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClientScript.RegisterStartupScript(Page.GetType(),"alert", "alert(your password has been successfully updated)",true);
                    txtNewPass.Text = "";
                    txtConfirmPass.Text = "";
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