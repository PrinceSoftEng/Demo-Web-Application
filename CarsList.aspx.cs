using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application_Registration.BAL;
using Web_Application_Registration.DAL;
using Web_Application_Registration.Model;

namespace Web_Application_Registration
{
    public partial class CarsList : System.Web.UI.Page
    {
        clsDalCarList objdalCarList = new clsDalCarList();
        clsBalCarList objbalCarList = new clsBalCarList();  
        clsCarListMaster objmasterCarList= new clsCarListMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGridView();
            }
        }
        #region Protected Event of GridView
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCars.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string TitleID = GvCars.SelectedValue.ToString();
            BindDetailsView(TitleID);
        }

        protected void GridView_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GvCars.EditIndex=e.NewEditIndex;
            this.BindGridView();
        }
        
        protected void GridView_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)GvCars.Rows[e.RowIndex];
            objdalCarList.carId= Convert.ToInt32(GvCars.DataKeys[e.RowIndex].Values[0]);
            objdalCarList.carCode= Convert.ToInt32(((TextBox)(gvRow.FindControl("txtCarCode"))).Text.Trim());
            objdalCarList.carName= ((TextBox)gvRow.FindControl("txtCarName")).Text.Trim();
            objdalCarList.carColor= ((TextBox)gvRow.FindControl("txtCarColor")).Text.Trim();
            objdalCarList.carYear= ((TextBox)(gvRow.FindControl("txtCarYear"))).Text.Trim();
            objdalCarList.carMakerComp= ((TextBox)gvRow.FindControl("txtCarMakerComp")).Text.Trim();
            objdalCarList.carModel= ((TextBox)gvRow.FindControl("txtCarModel")).Text.Trim();
            objdalCarList.carMileage = Convert.ToInt32(((TextBox)(gvRow.FindControl("txtCarMileage"))).Text.Trim());
            objdalCarList.carCondition= ((TextBox)gvRow.FindControl("txtCarModel")).Text.Trim();
            objdalCarList.carPrice = Convert.ToDecimal(((TextBox)(gvRow.FindControl("txtCarPrice"))).Text.Trim());
            int retValue = objmasterCarList.UpDateGridView(objdalCarList);
            if (retValue > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Updated Successfully');", true);
                GvCars.EditIndex = -1;
                this.BindGridView();
                this.clearStrings();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Updation failed');", true);
            }
            
        }

        protected void GridView_OnRowCancelingEdit(object sender, EventArgs e)
        {
            GvCars.EditIndex = -1;
            this.BindGridView();
        }

        protected void GridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)GvCars.Rows[e.RowIndex];
            objdalCarList.carId = Convert.ToInt32(GvCars.DataKeys[e.RowIndex].Values[0]);
            int retValue = objmasterCarList.DeleteGridView(objdalCarList);
            if (retValue > 0)
            {
                this.BindGridView();
                this.clearStrings();
            }
            else
            {
            }
        }

        protected void GridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GvCars.EditIndex)
            {
                (e.Row.Cells[10].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to Delete?');";
            }
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            objdalCarList.carCode = Convert.ToInt32(txtCarCode.Text.Trim());
            objdalCarList.carName = txtCarName.Text.Trim();
            objdalCarList.carColor = ddlCarColor.SelectedItem.Text;
            objdalCarList.carYear = ddlCarYear.Text.Trim();
            objdalCarList.carMakerComp = txtCarMakerComp.Text.Trim();
            objdalCarList.carModel = txtCarModel.Text.Trim();
            objdalCarList.carMileage = Convert.ToInt32(txtCarMileage.Text.Trim());
            objdalCarList.carCondition = txtCarCondition.Text.Trim();
            objdalCarList.carPrice = Convert.ToDecimal(txtCarPrice.Text.Trim());
            int retValue = objmasterCarList.AddCarsData(objdalCarList);
            if (retValue > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Data Added Successfully');", true);
            }
            this.BindGridView();
            this.clearStrings();
        }

        protected void CarsSearch_OnTextChanged(object sender, EventArgs e)
        {
            objdalCarList.carName = txtSearch.Text.Trim();
            DataSet ds = objmasterCarList.SearchGridView(objdalCarList);
            if (ds.Tables.Count > 0)
            {
                GvCars.DataSource = ds;
                GvCars.DataBind();
            }
            else 
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('No Records Found');", true);
            }

        }
        #endregion


        #region BindGridMethod
        private void BindGridView()
        {
            DataSet ds = objmasterCarList.BindGrid();
            if (ds.Tables.Count > 0)
            {
                GvCars.DataSource = ds;
                GvCars.DataBind();
                GvCars.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                GvCars.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GvCars.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                GvCars.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else 
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('No Records Found');", true);
            }
        }

        private void clearStrings()
        {
            txtCarCode.Text = " ";
            txtCarName.Text = " ";
            ddlCarColor.ClearSelection();
            ddlCarYear.ClearSelection();
            txtCarMakerComp.Text=" ";
            txtCarModel.Text=" ";
            txtCarMileage.Text=" ";
            txtCarCondition.Text= " ";
            txtCarPrice.Text=" ";
        }
        #endregion

        #region detailsview Protected Event
        protected void DetailsView_OnPageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            dvCarsModels.PageIndex = e.NewPageIndex;
            string TitleID = GvCars.SelectedValue.ToString();
            BindDetailsView(TitleID);
        }
        #endregion
        #region bind detailsview method
        private void BindDetailsView(string CarCode)
        {
            string constring = ConfigurationManager.ConnectionStrings["constrldb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select * from CarModels where CarCode = @CarCode", con))
                {
                    cmd.Parameters.AddWithValue("@CarCode", CarCode);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dvCarsModels.DataSource = dt;
                            dvCarsModels.DataBind();
                        }
                    }
                }
            }
        }
        #endregion
    }
}