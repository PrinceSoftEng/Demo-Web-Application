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
                int roleId = Convert.ToInt32(ddlRoles.SelectedValue);
                string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select programId,[Read],[Add],[Update],[Delete],[Export] from [tblPermission] where roleId=@roleId", con))
                    {

                        cmd.Parameters.AddWithValue("@roleId", roleId);
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                int rowIndex = 0;
                                while (sdr.Read())
                                {
                                    string chkRead = Convert.ToString(sdr["Read"]);
                                    string chkAdd = Convert.ToString(sdr["Add"]);
                                    string chkUpdate = Convert.ToString(sdr["Update"]);
                                    string chkDelete = Convert.ToString(sdr["Delete"]);
                                    string chkExport = Convert.ToString(sdr["Export"]);

                                    if (rowIndex < gvPermissions.Rows.Count)
                                    {
                                        GridViewRow gvRow = gvPermissions.Rows[rowIndex];
                                        Label lblprogramList = (Label)gvRow.FindControl("lblProgramList");
                                        CheckBox chkread = (CheckBox)gvRow.FindControl("chkRead");
                                        CheckBox chkadd = (CheckBox)gvRow.FindControl("chkAdd");
                                        CheckBox chkupdate = (CheckBox)gvRow.FindControl("chkUpdate");
                                        CheckBox chkdelete = (CheckBox)gvRow.FindControl("chkDelete");
                                        CheckBox chkexport = (CheckBox)gvRow.FindControl("chkExport");

                                        lblprogramList.Text = sdr["programId"].ToString();
                                        chkread.Checked = chkRead.ToString() == "R";
                                        chkadd.Checked = chkAdd.ToString() == "A";
                                        chkupdate.Checked = chkUpdate.ToString() == "U";
                                        chkdelete.Checked = chkDelete.ToString() == "D";
                                        chkexport.Checked = chkExport.ToString() == "E";
                                        rowIndex++;
                                    }
                                }
                            }
                            else { this.ClearControls(); }
                        }
                    }
                    con.Close();
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
                objBalRole.read = Convert.ToString(chkRead.Checked ? "R" : "");
                objBalRole.add = Convert.ToString(chkAdd.Checked ? "A" : "");
                objBalRole.update = Convert.ToString(chkUpdate.Checked ? "U" : "");
                objBalRole.delete = Convert.ToString(chkDelete.Checked ? "D" : "");
                objBalRole.export = Convert.ToString(chkExport.Checked ? "E" : "");
                objBalRole.accessControl = (chkRead.Checked ? "R" : "") + (chkAdd.Checked ? "A" : "") + (chkUpdate.Checked ? "U" : "") + (chkDelete.Checked ? "D" : "") + (chkExport.Checked ? "E" : "");

                int retValue = objMasterRole.AddorUpdate(objBalRole);
                if (retValue > 0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Pass Successfully')", true);
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