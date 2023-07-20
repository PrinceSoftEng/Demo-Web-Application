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

namespace Web_Application_Registration
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRoles();
                this.GridLoadPermission();
            }
        }

        protected void BindRoles()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SELECT roleId, roleName FROM User_tblRole order by roleName", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlRoles.DataSource = dt;
                ddlRoles.DataTextField = "roleName";
                ddlRoles.DataValueField = "roleId";
                ddlRoles.DataBind();

                // Add a default option
                ddlRoles.Items.Insert(0, new ListItem("-- Select Role --", ""));
            }
        }

        private void GridLoadPermission()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select PM.programId,PM.programList,P.[Read],P.[Add],P.[Update],P.[Delete],P.[Export] from tblPermission P Right outer join Program_tblMaster PM on PM.programId=P.permissionId order by programList", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvPermissions.DataSource = dt;
                            gvPermissions.DataBind();
                        }
                    }
                }
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
                    using (SqlCommand cmd = new SqlCommand("select programId,[Read],[Add],[Update],[Delete],[Export] from [tblPermission] where roleId=@roleId", con))
                    {
                        cmd.Parameters.AddWithValue("@roleId", roleId);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            foreach (GridViewRow gvrow in gvPermissions.Rows)
                            {
                                if (sdr.Read())
                                {
                                    Label lblprogramList = (Label)gvrow.FindControl("lblProgramList");
                                    CheckBox chkRead = (CheckBox)gvrow.FindControl("chkRead");
                                    CheckBox chkAdd = (CheckBox)gvrow.FindControl("chkAdd");
                                    CheckBox chkUpdate = (CheckBox)gvrow.FindControl("chkUpdate");
                                    CheckBox chkDelete = (CheckBox)gvrow.FindControl("chkDelete");
                                    CheckBox chkExport = (CheckBox)gvrow.FindControl("chkExport");

                                    lblprogramList.Text = sdr["programId"].ToString();
                                    chkRead.Checked = Convert.ToBoolean(sdr["Read"]);
                                    chkAdd.Checked = Convert.ToBoolean(sdr["Add"]);
                                    chkUpdate.Checked = Convert.ToBoolean(sdr["Update"]);
                                     chkDelete.Checked = Convert.ToBoolean(sdr["Delete"]);
                                    chkExport.Checked = Convert.ToBoolean(sdr["Export"]);
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int roleId = Convert.ToInt32(ddlRoles.SelectedValue);
            foreach (GridViewRow gvrow in gvPermissions.Rows)
            {
                Label lblprogramList = (Label)gvrow.FindControl("lblProgramList");
                CheckBox chkRead = (CheckBox)gvrow.FindControl("chkRead");
                CheckBox chkAdd = (CheckBox)gvrow.FindControl("chkAdd");
                CheckBox chkUpdate = (CheckBox)gvrow.FindControl("chkUpdate");
                CheckBox chkDelete = (CheckBox)gvrow.FindControl("chkDelete");
                CheckBox chkExport = (CheckBox)gvrow.FindControl("chkExport");
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("tblPermission_spInsertorUpdatetblPermission", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@programId", lblprogramList.Text.Trim());
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    cmd.Parameters.AddWithValue("@Read", chkRead.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Add", chkAdd.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Update", chkUpdate.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Delete", chkDelete.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Export", chkExport.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@AccessControl", Convert.ToByte(chkRead.Checked) + "" + Convert.ToByte(chkAdd.Checked) + "" + Convert.ToByte(chkUpdate.Checked) + "" + Convert.ToByte(chkDelete.Checked) + "" + Convert.ToByte(chkExport.Checked));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Data Pass Successful')", true);
            this.ClearControls();
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