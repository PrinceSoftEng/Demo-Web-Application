using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application_Registration.DAL;
using Web_Application_Registration.Model;

namespace Web_Application_Registration
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        clsMasterRoleMaster objMasterRole = new clsMasterRoleMaster();
        clsDalRoleMaster objBalRole = new clsDalRoleMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRoles();
                this.GridLoadPermission();
            }
        }

        private void BindRoles()
        {
            DataTable dt = objMasterRole.BindDrowDownRole();
            if (dt.Rows.Count > 0)
            {
                ddlRoles.DataSource = dt;
                ddlRoles.DataTextField = "roleName";
                ddlRoles.DataValueField = "roleId";
                ddlRoles.DataBind();
            }
            ddlRoles.Items.Insert(0, new ListItem("-- Select Role --", ""));
        }

        private void GridLoadPermission()
        {
            DataTable dt = objMasterRole.GridLoadPermission();
            if (dt.Rows.Count > 0)
            {
                gvPermissions.DataSource = dt;
                gvPermissions.DataBind();
            }
        }

        protected void ddlRole_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoles.SelectedIndex > 0)
            {
                objBalRole.roleId = Convert.ToInt32(ddlRoles.SelectedValue);
                var sdr = objMasterRole.LoadCheckedData(objBalRole);
                foreach (GridViewRow gvRow in gvPermissions.Rows)
                {
                    if (sdr.Read())
                    {
                        Label lblprogramList = (Label)gvRow.FindControl("lblProgramList");
                        CheckBox chkRead = (CheckBox)gvRow.FindControl("chkRead");
                        CheckBox chkAdd = (CheckBox)gvRow.FindControl("chkAdd");
                        CheckBox chkUpdate = (CheckBox)gvRow.FindControl("chkUpdate");
                        CheckBox chkDelete = (CheckBox)gvRow.FindControl("chkDelete");
                        CheckBox chkExport = (CheckBox)gvRow.FindControl("chkExport");

                        lblprogramList.Text = sdr["programId"].ToString();
                        chkRead.Checked = Convert.ToBoolean(sdr["Read"]);
                        chkAdd.Checked = Convert.ToBoolean(sdr["Add"]);
                        chkUpdate.Checked = Convert.ToBoolean(sdr["Update"]);
                        chkDelete.Checked = Convert.ToBoolean(sdr["Delete"]);
                        chkExport.Checked = Convert.ToBoolean(sdr["Export"]);
                    }
                    else
                    {
                        this.ClearControls();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int roleId = Convert.ToInt32(ddlRoles.SelectedValue);
            foreach (GridViewRow gvRow in gvPermissions.Rows)
            {
                Label lblprogramList = (Label)gvRow.FindControl("lblProgramList");
                CheckBox chkRead = (CheckBox)gvRow.FindControl("chkRead");
                CheckBox chkAdd = (CheckBox)gvRow.FindControl("chkAdd");
                CheckBox chkUpdate = (CheckBox)gvRow.FindControl("chkUpdate");
                CheckBox chkDelete = (CheckBox)gvRow.FindControl("chkDelete");
                CheckBox chkExport = (CheckBox)gvRow.FindControl("chkExport");

                objBalRole.programId = Convert.ToInt32(lblprogramList.Text.Trim());
                objBalRole.roleId = Convert.ToInt32(roleId);
                objBalRole.read = Convert.ToByte(chkRead.Checked ? 1 : 0);
                objBalRole.add = Convert.ToByte(chkAdd.Checked ? 1 : 0);
                objBalRole.update = Convert.ToByte(chkUpdate.Checked ? 1 : 0);
                objBalRole.delete = Convert.ToByte(chkDelete.Checked ? 1 : 0);
                objBalRole.export = Convert.ToByte(chkExport.Checked ? 1 : 0);
                objBalRole.accessControl = chkRead + "" + chkAdd + "" + chkUpdate + "" + chkDelete + "" + chkExport;
                int retValue = objMasterRole.AddorUpdate(objBalRole);
                if (retValue > 0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Pass Successful')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Pass failed');", true);
                }
            }
            this.ClearControls();
            ddlRoles.ClearSelection();
        }

        private void ClearControls()
        {
            foreach (GridViewRow gvrow in gvPermissions.Rows)
            {
                CheckBox chkRead = (CheckBox)gvrow.FindControl("chkRead");
                CheckBox chkAdd = (CheckBox)gvrow.FindControl("chkAdd");
                CheckBox chkUpdate = (CheckBox)gvrow.FindControl("chkUpdate");
                CheckBox chkDelete = (CheckBox)gvrow.FindControl("chkDelete");
                CheckBox chkExport = (CheckBox)gvrow.FindControl("chkExport");

                chkRead.Checked = false;
                chkAdd.Checked = false;
                chkUpdate.Checked = false;
                chkDelete.Checked = false;
                chkExport.Checked = false;
            }
        }
    }
}