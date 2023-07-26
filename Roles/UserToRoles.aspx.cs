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
using Web_Application_Registration.Model;
using Web_Application_Registration.DAL;
using System.Web.Services;

namespace Web_Application_Registration.Roles
{
    public partial class UserToRoles : System.Web.UI.Page
    {
        
        clsDalUsertoRole objDalUTR = new clsDalUsertoRole();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindGridViewRoles();
            this.BindRoleForCheckBoxList();
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            objDalUTR.roleId = Convert.ToInt32(txtId.Text.Trim());
            objDalUTR.roleName = txtRoleName.Text.Trim();
            int retValue = objMastUTR.AddRoles(objDalUTR);
            if (retValue > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Inserted Successfully');", true);
                this.BindGridViewRoles();
                this.ClearData();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Insertion failed');", true);
            }
        }

        protected void btnDelete_click(object sender, EventArgs e)
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            objDalUTR.roleId = Convert.ToInt32(txtId.Text.Trim());
            int retValue = objMastUTR.DeleteRole(objDalUTR);
            if (retValue > 0)
            {
                this.BindGridViewRoles();
                lblStatus.Visible = false;
                this.ClearData();
            }
        }

        protected void txtUserName_TextChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
                objDalUTR.roleId = Convert.ToInt32(txtId.Text.Trim());
                var sdr = objMastUTR.CheckRoleIdExist(objDalUTR);
                if (sdr.Read())
                {
                    lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                    lblStatus.Text = "RoleId already Exists";
                }
                else
                {
                    lblStatus.Visible = false;
                }
            }
        }

        [WebMethod]
        public static List<string> GetRoleNameBySearch(string searchTerm)
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            List<string> data = objMastUTR.GetAutoComplete(searchTerm);
            return data;
        }

        //[WebMethod]
        //public static List<string> GetRolesName(string prefixText)
        //{
        //    List<string> roles = new List<string>();
        //    string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Select UserName From UserRegTable where UserName like @SearchText +'%'", con))
        //        {
        //            con.Open();
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.Parameters.AddWithValue("@SearchText", prefixText);
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    roles.Add(sdr["UserName"].ToString());
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return roles;
        //}
        private void BindRoleForCheckBoxList()
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            DataTable dt = objMastUTR.BindRoleForCheckBoxList();
            if (dt.Rows.Count > 0)
            {
                chkRoles.DataSource = dt;
                chkRoles.DataTextField = "roleName";
                chkRoles.DataValueField = "roleId";
                chkRoles.DataBind();
            }
            else 
            {
                chkRoles.DataSource = "No Data Available";
                chkRoles.DataBind();
            }
        }

        private void BindGridViewRoles()
        {
            clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
            DataTable dt = objMastUTR.BindGridViewRoles();
            if (dt.Rows.Count > 0)
            {
                gvRoles.DataSource = dt;
                gvRoles.DataBind();
            }
            else
            {
                gvRoles.DataSource = "No records Found";
                gvRoles.DataBind();
            }
        }

        private void ClearData()
        {
            txtId.Text = string.Empty;
            txtRoleName.Text = string.Empty;
        }
    }
}