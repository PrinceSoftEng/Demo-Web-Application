using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace Web_Application_Registration.Roles
{
    public partial class UserToRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindGridViewRoles();
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            int txtid=Convert.ToInt32(txtId.Text.Trim());
            string txtRole = txtRoleName.Text.Trim();
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("tblRole_spInsertRoles", con))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@roleId", txtid.ToString());
                    cmd.Parameters.AddWithValue("@roleName", txtRole.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGridViewRoles();
        }

        protected void btnDelete_click(object sender, EventArgs e)
        {
            int txtid = Convert.ToInt32(txtId.Text.Trim());
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("tblRole_spDeleteRoles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@roleId", txtid.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGridViewRoles();
            lblStatus.Visible = false;
        }

        protected void txtUserName_TextChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("tblRole_spRoleIdValidation", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@roleId", txtId.Text.Trim());
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                                lblStatus.Text = "RoleId already Exists";
                            }
                            else 
                            {
                                lblStatus.Visible = false;
                            }
                        }
                        con.Close();
                    }
                }
            }            
        }

        private void BindGridViewRoles()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select roleId,roleName from User_tblRole", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    gvRoles.DataSource = cmd.ExecuteReader();
                    gvRoles.DataBind();
                    con.Close();                   
                }
            }
        }
    }
}