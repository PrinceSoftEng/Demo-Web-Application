using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Web_Application_Registration.BAL;
using Web_Application_Registration.BEL;
using Web_Application_Registration.BO;

namespace Web_Application_Registration.DAL
{
    public class clsMaster
    {
        public Int32 AddEmployees(clsDal newUser)
        {
            clsBal objDal = new clsBal();
            return objDal.AddEmployees(newUser);
        }

        public static DataTable GetCountryList()
        {
            return clsBal.GetCountryList();
        }

        public static DataTable GetStateList(int country_id)
        {
            return clsBal.GetStateList(country_id);
        }

        public static DataTable GetCityList(int state_Id)
        {
            return clsBal.GetCityList(state_Id);
        }

        public DataTable BindDrowDownRole()
        {
            clsBal objbalRole = new clsBal();
            return objbalRole.BindDrowDownRole();
        }
    }
}