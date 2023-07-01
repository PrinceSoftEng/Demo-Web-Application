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

namespace Web_Application_Registration
{
    public partial class CarsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.bindGridView();
            }
        }

        private void bindGridView()
        {
            string constring = ConfigurationManager.ConnectionStrings["constrldb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Cars", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GvCars.DataSource = dt;
                            GvCars.DataBind();
                        }
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCars.PageIndex = e.NewPageIndex;
            bindGridView();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string TitleID = GvCars.SelectedValue.ToString();
            BindDetailsView(TitleID);
        }

        

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
        protected void DetailsView_OnPageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            dvCarsModels.PageIndex = e.NewPageIndex;
            string TitleID = GvCars.SelectedValue.ToString();
            BindDetailsView(TitleID);
        }

    }
}