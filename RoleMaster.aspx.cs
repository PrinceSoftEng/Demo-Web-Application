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
                SqlCommand cmd = new SqlCommand("SELECT roleId, roleName FROM User_tblRole", con);
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
                using (SqlCommand cmd = new SqlCommand("select [programList],[Add],[Update],[Delete],[Read],[Export] from [tblPermission] right outer Join [Program_tblMaster] on programId=permissionId", con))
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int roleId = Convert.ToInt32(ddlRoles.SelectedValue);
            foreach (GridViewRow gvrow in gvPermissions.Rows)
            {
                CheckBox chkRead = (CheckBox)gvrow.FindControl("chkRead");
                CheckBox chkAdd = (CheckBox)gvrow.FindControl("chkAdd");
                CheckBox chkUpdate = (CheckBox)gvrow.FindControl("chkUpdate");
                CheckBox chkDelete = (CheckBox)gvrow.FindControl("chkDelete");
                CheckBox chkExport = (CheckBox)gvrow.FindControl("chkExport");
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO  tblPermission (roleId,[Read],[Add],[Update],[Delete],[Export],[createdBy],[createdDate],[updatedBy],[updatedDate]) Values(@roleId,@Read,@Add,@Update,@Delete,@Export,'Admin','2023-07-19','Admin','2023-07-19')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    cmd.Parameters.AddWithValue("@Read", chkRead.Checked ? true : false);
                    cmd.Parameters.AddWithValue("@Add", chkAdd.Checked ? true : false);
                    cmd.Parameters.AddWithValue("@Update", chkUpdate.Checked ? true : false);
                    cmd.Parameters.AddWithValue("@Delete", chkDelete.Checked ? true : false);
                    cmd.Parameters.AddWithValue("@Export", chkExport.Checked ? true : false);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Successful')", true);
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