using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application_Registration
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRolesDropDown();
                BindPermissionsGridView();
            }
        }

        protected void gvPermissions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbAdd = (CheckBox)e.Row.FindControl("cbAdd");
                CheckBox cbUpdate = (CheckBox)e.Row.FindControl("cbUpdate");
                CheckBox cbDelete = (CheckBox)e.Row.FindControl("cbDelete");
                CheckBox cbRead = (CheckBox)e.Row.FindControl("cbRead");
                CheckBox cbExport = (CheckBox)e.Row.FindControl("cbExport");

                // Set the null values to unchecked checkboxes
                cbAdd.Checked = cbAdd.Checked??false;
                cbUpdate.Checked = cbUpdate.Checked?? false;
                cbDelete.Checked = cbDelete.Checked??false;
                cbRead.Checked = cbRead.Checked??false;
                cbExport.Checked = cbExport.Checked??false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int roleId = Convert.ToInt32(ddlRoles.SelectedValue);

            foreach (GridViewRow row in gvPermissions.Rows)
            {
                //int id = Convert.ToInt32(gvPermissions.DataKeys[row.RowIndex].Value);
                CheckBox cbAdd = (CheckBox)row.FindControl("cbAdd");
                CheckBox cbUpdate = (CheckBox)row.FindControl("cbUpdate");
                CheckBox cbDelete = (CheckBox)row.FindControl("cbDelete");
                CheckBox cbRead = (CheckBox)row.FindControl("cbRead");
                CheckBox cbExport = (CheckBox)row.FindControl("cbExport");

                string addPermission = cbAdd.Checked ?  null:"A" ;
                string updatePermission = cbUpdate.Checked ?  null: "U";
                string deletePermission = cbDelete.Checked ? null : "D";
                string readPermission = cbRead.Checked ? null : "R";
                string exportPermission = cbExport.Checked ? null:"E";

                UpdatePermissions(roleId, addPermission, updatePermission, deletePermission, readPermission, exportPermission);
            }

            BindPermissionsGridView();
        }        

        private void BindRolesDropDown()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT RoleID, RoleName FROM Roles";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ddlRoles.DataSource = dt;
                ddlRoles.DataTextField = "RoleName";
                ddlRoles.DataValueField = "RoleID";
                ddlRoles.DataBind();
            }
            ddlRoles.Items.Insert(0, new ListItem("---Select roles---", "0"));
        }

        private void BindPermissionsGridView()
        {
            int roleId = Convert.ToInt32(ddlRoles.SelectedValue);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select RP.ID,RP.RoleID,P.PageName,RP.AddPermission,RP.UpdatePermission,RP.DeletePermission,RP.ReadPermission,\r\n\t   RP.ExportPermission from RolePermissions RP Inner Join Pages P on RP.ID = P.PageID";
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@RoleId", roleId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gvPermissions.DataSource = dt;
                gvPermissions.DataBind();
            }
        }

        private void UpdatePermissions(int roleId, string addPermission, string updatePermission, string deletePermission,
            string readPermission, string exportPermission)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE RolePermissions SET AddPermission = @AddPermission, UpdatePermission = @UpdatePermission, " +
                               "DeletePermission = @DeletePermission, ReadPermission = @ReadPermission, ExportPermission = @ExportPermission " +
                               "WHERE RoleID = @RoleID";
                SqlCommand command = new SqlCommand(query, connection);

                if (String.IsNullOrEmpty(addPermission))
                {
                    command.Parameters.AddWithValue("@AddPermission", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@AddPermission", addPermission); 
                }

                if (String.IsNullOrEmpty(updatePermission))
                {
                    command.Parameters.AddWithValue("@UpdatePermission", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@UpdatePermission", updatePermission);
                }

                if (String.IsNullOrEmpty(deletePermission))
                {
                    command.Parameters.AddWithValue("@DeletePermission", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DeletePermission", deletePermission);
                }
                if (String.IsNullOrEmpty(readPermission))
                {
                    command.Parameters.AddWithValue("@ReadPermission", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@ReadPermission", readPermission);
                }
                if (String.IsNullOrEmpty(exportPermission))
                {
                    command.Parameters.AddWithValue("@ExportPermission", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@ExportPermission", exportPermission);
                }
                command.Parameters.AddWithValue("@RoleID", roleId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}