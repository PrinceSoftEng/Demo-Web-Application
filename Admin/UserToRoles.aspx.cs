
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
using System.EnterpriseServices;
using System.Net.NetworkInformation;
using System.Web.Configuration;
using Web_Application_Registration.BAL;
using System.Text;
using System.Data.SqlTypes;

namespace Web_Application_Registration.Roles
{
    public partial class UserToRoles : System.Web.UI.Page
    {
        clsMasterUsertoRole objMastUTR = new clsMasterUsertoRole();
        clsDalUsertoRole objDalUTR = new clsDalUsertoRole();
        private string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGridViewUTR();
                this.BindGridViewRoles();
                this.BindUserDropDownList();
                this.BindRolesRadioButtonList();
            }
        }

        //Binding DrodownList Of User
        private void BindUserDropDownList()
        {
            DataTable dt = objMastUTR.BindUserDropdown();
            if (dt.Rows.Count > 0)
            {
                ddlUsers.DataSource = dt;
                ddlUsers.DataBind();
            }
            ddlUsers.Items.Insert(0, new ListItem("--Select User--", "0"));
        }

        //Bind RadioButtonList With Roles
        private void BindRolesRadioButtonList()
        {
            DataTable dt = objMastUTR.BindRolesRadioButtonList();
            if (dt.Rows.Count > 0)
            {
                rblRoles.DataSource = dt;
                rblRoles.DataBind();
            }
        }

        //GridViewData Of User to Role
        private void BindGridViewUTR()
        {
            DataTable dt = objMastUTR.BindGrid();
            if (dt.Rows.Count > 0)
            {
                gvUTR.DataSource = dt;
                gvUTR.DataBind();
            }
        }

        //Check Mapping for User
        private bool CheckIfMappingExists(int userId)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select Count(*) from tblUserToRole where UserId=@UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        //Update Data if already Exists in UserToRole table 
        private void UpdateUserToRoleMapping(int roleId, int userId)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Update tblUserToRole set roleId=@roleId where UserId=@UserId", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        //insert Data in UserToRole table 
        private void InsertUserToRoleMapping(int userId, int roleId)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Insert into tblUserToRole(UserId,roleId) values(@UserId,@roleId) ", con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        //Clieck Event to check for Update and Insert in UserToRoleTable 
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int selectedUserId = Convert.ToInt32(ddlUsers.SelectedValue);
            int selectedRoleId = Convert.ToInt32(rblRoles.SelectedValue);
            bool existingRecord = CheckIfMappingExists(selectedUserId);
            if (existingRecord)
            {
                UpdateUserToRoleMapping(selectedRoleId, selectedUserId);
                ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Updating SuccessFully..!')", true);
            }
            else
            {
                foreach (ListItem roleItem in rblRoles.Items)
                {
                    if (roleItem.Selected)
                    {
                        int roleId = Convert.ToInt32(roleItem.Value);
                        InsertUserToRoleMapping(selectedUserId, roleId);
                        ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Inserted Successfully..!')", true);
                    }
                }
            }
            ddlUsers.ClearSelection();
            rblRoles.ClearSelection();
            this.BindGridViewUTR();
        }

        //Here All Coding is realated for Roles Where Roles Is Inserted,reading,Checking and Deleting...!

        //Check If role already exists
        protected void txtUserName_TextChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                objDalUTR.roleId = Convert.ToInt32(txtId.Text.Trim());
                var sdr = objMastUTR.CheckRoleIdExist(objDalUTR);
                if (sdr.Read())
                {
                    lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
                    lblStatus.Text = "RoleId Already Exists";
                    //ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Role Already Exists');", true);
                }
                else
                {
                    lblStatus.Visible = false;
                }
            }
        }

        //Bind GridView for RoleTable 
        private void BindGridViewRoles()
        {
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

        //Insert Roles In UserRoles table 
        protected void btnSave_click(object sender, EventArgs e)
        {
            objDalUTR.roleId = Convert.ToInt32(txtId.Text.Trim());
            objDalUTR.roleName = txtRoleName.Text.Trim();
            int retValue = objMastUTR.AddRoles(objDalUTR);
            if (retValue > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Role Inserted Successfully');", true);
                this.BindGridViewRoles();
                this.BindRolesRadioButtonList();
                this.ClearData();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Insertion failed');", true);
            }
        }

        //Delete role on the roleTable 
        protected void btnDelete_click(object sender, EventArgs e)
        {
            objDalUTR.roleId = Convert.ToInt32(txtId.Text.Trim());
            int retValue = objMastUTR.DeleteRole(objDalUTR);
            if (retValue > 0)
            {
                this.BindGridViewRoles();
                this.BindRolesRadioButtonList();
                lblStatus.Visible = false;
                this.ClearData();
            }
        }        
               
        //clear data from textbox
        private void ClearData()
        {
            txtId.Text = string.Empty;
            txtRoleName.Text = string.Empty;
        }        
    }
}