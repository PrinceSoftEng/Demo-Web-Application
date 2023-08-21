using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application_Registration
{
    public partial class UserProfile : System.Web.UI.Page
    {
        private string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadUserData();
            }
        }

        private void LoadUserData()
        { 
            string username=HttpContext.Current.User.Identity.Name;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select UserId,UserName,FirstName,MiddleName,LastName,Mobile,Email,Address,Country,State,City  from UserRegTable where UserName=@UserName", con))
                {
                    cmd.CommandType=System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserName", username);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        txtFirstName.Text = sdr["FirstName"].ToString();
                        txtMiddeName.Text = sdr["MiddleName"].ToString();
                        txtLastName.Text = sdr["LastName"].ToString();
                        txtMobile.Text = sdr["Mobile"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        txtCountry.Text = sdr["Country"].ToString();
                        txtState.Text = sdr["State"].ToString();
                        txtCity.Text = sdr["City"].ToString();
                        lblUserHead.Text = username;
                    }
                    con.Close();
                }
            }            
        }

        protected void Update_UserData(object sender, EventArgs e)
        {
            string username = HttpContext.Current.User.Identity.Name;
            string Fname = txtFirstName.Text.Trim();
            string MName=txtMiddeName.Text.Trim();
            string LName=txtLastName.Text.Trim();
            string mobile=txtMobile.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address= txtAddress.Text.Trim();
            string country = txtCountry.Text.Trim();    
            string state = txtState.Text.Trim();    
            string city = txtCity.Text.Trim();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UserRegTable_spUpdateUserRegTable", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", Fname.ToString());
                    cmd.Parameters.AddWithValue("@MiddleName", MName.ToString());
                    cmd.Parameters.AddWithValue("@LastName", LName.ToString());
                    cmd.Parameters.AddWithValue("@Mobile", mobile.ToString());
                    cmd.Parameters.AddWithValue("@Email", email.ToString());
                    cmd.Parameters.AddWithValue("@Address", address.ToString());
                    cmd.Parameters.AddWithValue("@Country", country.ToString());
                    cmd.Parameters.AddWithValue("@State", state.ToString());
                    cmd.Parameters.AddWithValue("@City", city.ToString());
                    cmd.Parameters.AddWithValue("@UserName", username.ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Updated Successfully..!')", true);
        }
    }
}