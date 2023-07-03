using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Web_Application_Registration.DAL;
using System.Web.UI.WebControls;

namespace Web_Application_Registration.BAL
{
    public class clsBalCarList
    {   
        public int AddCarsData(clsDalCarList objdalcar)
        {
            string constr = ConfigurationManager.ConnectionStrings["constrldb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Cars_spInsertCars", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CarCode", objdalcar.carCode);
                    cmd.Parameters.AddWithValue("@CarName", objdalcar.carName);
                    cmd.Parameters.AddWithValue("@CarColor", objdalcar.carColor);
                    cmd.Parameters.AddWithValue("@CarYear", objdalcar.carYear);
                    cmd.Parameters.AddWithValue("@CarMakerComp", objdalcar.carMakerComp);
                    cmd.Parameters.AddWithValue("@CarModel", objdalcar.carModel);
                    cmd.Parameters.AddWithValue("@CarMileage", objdalcar.carMileage);
                    cmd.Parameters.AddWithValue("@CarCondition", objdalcar.carCondition);
                    cmd.Parameters.AddWithValue("@CarPrice", objdalcar.carPrice);
                    con.Open();
                    int getData=cmd.ExecuteNonQuery();
                    con.Close();
                    return getData;
                }
            }
        }

        public DataSet BindGrid()
        {
            string constring = ConfigurationManager.ConnectionStrings["constrldb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Cars", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }

        public Int32 UpDateGridView(clsDalCarList objdalcar)
        {
            string constring = ConfigurationManager.ConnectionStrings["constrldb"].ConnectionString;
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("Cars_spUpdateCars", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CarId", objdalcar.carId);
                        cmd.Parameters.AddWithValue("@CarCode", objdalcar.carCode);
                        cmd.Parameters.AddWithValue("@CarName", objdalcar.carName);
                        cmd.Parameters.AddWithValue("@CarColor", objdalcar.carColor);
                        cmd.Parameters.AddWithValue("@CarYear", objdalcar.carYear);
                        cmd.Parameters.AddWithValue("@CarMakerComp", objdalcar.carMakerComp);
                        cmd.Parameters.AddWithValue("@CarModel", objdalcar.carModel);
                        cmd.Parameters.AddWithValue("@CarMileage", objdalcar.carMileage);
                        cmd.Parameters.AddWithValue("@CarCondition", objdalcar.carCondition);
                        cmd.Parameters.AddWithValue("@CarPrice", objdalcar.carPrice);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        return i;
                    }
                }
            }
        }

        public Int32 DeleteGridView(clsDalCarList objdalcar)
        {
            string constring = ConfigurationManager.ConnectionStrings["constrldb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Cars_spDeleteCars", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CarId", objdalcar.carId);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i;
                }
            }
        }
    }
}