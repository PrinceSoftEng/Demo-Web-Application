using System;
using System.Collections.Generic;
using System.Configuration;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindDropDownList();
                this.BindGetPermission();
            }
        }

        //protected void gvPermissions_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        CheckBox chkAdd = (CheckBox)e.Row.FindControl("chkAdd");
        //        CheckBox chkUpdate = (CheckBox)e.Row.FindControl("chkUpdate");
        //        CheckBox chkRead = (CheckBox)e.Row.FindControl("chkRead");
        //        CheckBox chkDelete = (CheckBox)e.Row.FindControl("chkDelete");
        //        CheckBox chkExport = (CheckBox)e.Row.FindControl("chkExport");

        //        bool add = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "AddPermission").ToString());
        //        bool update = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "UpdatePermission").ToString());
        //        bool read = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "ReadPermission").ToString());
        //        bool delete = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "DeletePermission").ToString());
        //        bool export = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "ExportPermission").ToString());

        //        chkAdd.Checked = add;
        //        chkUpdate.Checked = update;
        //        chkRead.Checked = read;
        //        chkDelete.Checked = delete;
        //        chkExport.Checked = export;
        //    }
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int roleID = int.Parse(ddlRoles.SelectedValue);
            foreach (GridViewRow gvrow in gvRoles.Rows)
            {
                CheckBox chkadd = (CheckBox)gvrow.FindControl("chkAdd");
                CheckBox chkupdate = (CheckBox)gvrow.FindControl("chkUpdate");
                CheckBox chkread = (CheckBox)gvrow.FindControl("chkRead");
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkDelete");
                CheckBox chkexport = (CheckBox)gvrow.FindControl("chkExport");

                bool add =chkadd.Checked;
                bool update =chkupdate.Checked;
                bool read =chkread.Checked;
                bool delete =chkdelete.Checked;
                bool export =chkexport.Checked;

                SavePermissions(roleID,add,update,read,delete,export);
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Permission Save SuccessFully');", true);
            ClearSelection();
        }

        protected void SavePermissions(int roleID, bool add, bool update, bool read, bool delete, bool export)
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;            
            using (SqlConnection Con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UserRolePermissions_spInsertUserRolePermissions", Con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@AddPermission", add);
                    cmd.Parameters.AddWithValue("@UpdatePermission", update);
                    cmd.Parameters.AddWithValue("@ReadPermission", read);
                    cmd.Parameters.AddWithValue("@DeletePermission", delete);
                    cmd.Parameters.AddWithValue("@ExportPermission",export);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                }
            }
        }

        private void ClearSelection() 
        {
            foreach (GridViewRow gvrow in gvRoles.Rows)
            {
                CheckBox chkadd = (CheckBox)gvrow.FindControl("chkAdd");
                CheckBox chkupdate = (CheckBox)gvrow.FindControl("chkUpdate");
                CheckBox chkread = (CheckBox)gvrow.FindControl("chkRead");
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkDelete");
                CheckBox chkexport = (CheckBox)gvrow.FindControl("chkExport");

                chkadd.Checked = false; 
                chkupdate.Checked=false; 
                chkread.Checked = false;
                chkdelete.Checked=false;
                chkexport.Checked = false;
            }
        }

        private void BindGetPermission()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("RolesnPermission_spGetRolesnPermission", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    gvRoles.DataSource = cmd.ExecuteReader();
                    gvRoles.DataBind();
                    btnSave.Visible = true;
                    con.Close();
                }
            }
        }

        private void BindDropDownList()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Roles", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    ddlRoles.DataSource = cmd.ExecuteReader();
                    ddlRoles.DataTextField = "RoleName";
                    ddlRoles.DataValueField = "RoleID";
                    ddlRoles.DataBind();
                    con.Close();
                }
            }
            ddlRoles.Items.Insert(0, new ListItem("---Select Roles---", "0"));
        }
    }
}