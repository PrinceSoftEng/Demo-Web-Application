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

        public DataTable BindUserDropdown()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select UserId,UserName from UserRegTable", con))
                {
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

        public DataTable BindRolesRadioButtonList()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select roleId,roleName from User_tblRole", con))
                {
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

        public DataTable BindGrid()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select urt.UserName,utr.ID,utr.UserId,utr.roleId,tr.roleName from UserRegTable urt Join tblUserToRole utr on urt.UserId =utr.UserId Join User_tblRole tr on tr.roleId=utr.roleId", con))
                {
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
    }
}