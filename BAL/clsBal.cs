using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using Web_Application_Registration.BEL;
using Web_Application_Registration.DAL;

namespace Web_Application_Registration.BO
{
    public class clsBal
    {
        clsDal dal;
        string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public Int32 AddEmployees(clsDal newUser)
        {
            int result;
            SqlConnection conn = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand("UserRegTable_InsertUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", newUser.userName);
            cmd.Parameters.AddWithValue("@FirstName", newUser.firstName);
            cmd.Parameters.AddWithValue("@MiddleName", newUser.middleName);
            cmd.Parameters.AddWithValue("@LastName", newUser.lastName);
            cmd.Parameters.AddWithValue("@Gender", newUser.gender);
            cmd.Parameters.AddWithValue("@Mobile", newUser.mobile);
            cmd.Parameters.AddWithValue("@Email", newUser.email);
            cmd.Parameters.AddWithValue("@Password", newUser.password);
            cmd.Parameters.AddWithValue("@Address", newUser.address);
            cmd.Parameters.AddWithValue("@Country", newUser.country);
            cmd.Parameters.AddWithValue("@State", newUser.state);
            cmd.Parameters.AddWithValue("@City", newUser.city);
            cmd.Parameters.AddWithValue("@IsActive", newUser.isActive);
            cmd.Parameters.AddWithValue("@CreatedBy", newUser.createdBy);
            cmd.Parameters.AddWithValue("@ModifiedBy", newUser.modifiedBy);
            cmd.Parameters.AddWithValue("@RoleId", newUser.roleId);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public string FetchId(string emailId)
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UserRegTable_ActivationEmail_WithId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", emailId);
                    con.Open();
                    string id = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();
                    cmd.Dispose();
                    return id;
                }
            }
        }

        public DataTable BindDrowDownRole()
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("tblRole_spGetRoles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public string GetUserName(string UserName)
        {
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UserRegTable_GetUserName", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", UserName );
                    con.Open();
                    string username = cmd.ExecuteScalar().ToString();
                    return username;
                }
            }
        }

        public static DataTable GetCountryList()
        {
            string connString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("Country_GetCountry", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("Country");
            dt.Load(dr);
            con.Close();
            return dt;
        }


        public static DataTable GetStateList(int country_id)
        {
            string connString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("State_GetState", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", country_id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("State");
            dt.Load(dr);
            con.Close();
            return dt;
        }

        public static DataTable GetCityList(int state_Id)
        {
            string connString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("City_GetCity", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", state_Id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("City");
            dt.Load(dr);
            con.Close();
            return dt;
        }

        //public DataTable GetLogin(clsDal dal)
        //{
        //    using (SqlConnection con = new SqlConnection(conString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("UserRegTable_LoginCredintials", con))
        //        {
        //            cmd.CommandType=CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@UserName", dal.userName);
        //            cmd.Parameters.AddWithValue("@Password", dal.password);
        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                using (DataTable dt = new DataTable())
        //                {
        //                    sda.Fill(dt);
        //                    return dt;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}