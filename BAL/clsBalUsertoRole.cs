using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web_Application_Registration.DAL;

namespace Web_Application_Registration.BAL
{
    public class clsBalUsertoRole
    {
        private string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public DataTable BindGridViewRoles()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select roleId,roleName from User_tblRole", con))
                {
                    cmd.CommandType = CommandType.Text;
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

        public DataTable BindDropDownList()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select Id,UserName from UserRegTable", con))
                {
                    cmd.CommandType = CommandType.Text;
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

        public int AddRoles(clsDalUsertoRole objdalUTR)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("tblRole_spInsertRoles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@roleId", objdalUTR.roleId);
                    cmd.Parameters.AddWithValue("@roleName", objdalUTR.roleName);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i;
                }
            }
        }

        public Int32 DeleteRole(clsDalUsertoRole objDalUTR)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("tblRole_spDeleteRoles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@roleId", objDalUTR.roleId);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return i;
                }
            }
        }

        public IDataReader CheckRoleIdExist(clsDalUsertoRole objDalUTR)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("tblRole_spRoleIdValidation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@roleId", objDalUTR.roleId);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(sdr);
                            return dt.CreateDataReader();
                        }
                    }
                }
            }
        }

        //[WebMethod]
        //public List<string> GetAutoComplete(string searchTerm)
        //{
        //    List<string> roles = new List<string>();
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Select UserName as Name From UserRegTable where UserName like @SearchTerm +'%'", con))
        //        {
        //            cmd.Parameters.AddWithValue("@SearchTerm", searchTerm.Trim());
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    roles.Add(sdr["Name"].ToString());
        //                }
        //            }
        //        }
        //    }
        //    return roles;
        //}

        public DataTable BindRoleForCheckBoxList()
        {
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

        public IDataReader LoadCheckedData(clsDalUsertoRole objDalUTR)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select roleId,roleName from User_tblRole where roleId=@roleId", con))
                {
                    cmd.Parameters.AddWithValue("@roleId", objDalUTR.roleId);
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            using (DataTable dt = new DataTable())
                            {
                                dt.Load(sdr);
                                return dt.CreateDataReader();
                            }
                        }
                    }
                }
            }
        }
    }
}