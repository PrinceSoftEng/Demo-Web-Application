using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web_Application_Registration.BAL;
using Web_Application_Registration.DAL;

namespace Web_Application_Registration.Model
{
    public class clsMasterRoleMaster
    {
        public DataTable GridLoadPermission()
        {
            clsBalRoleMaster objDalRole = new clsBalRoleMaster();
            return objDalRole.GridLoadPermission();
        }

        public DataTable BindDrowDownRole()
        {
            clsBalRoleMaster objDalRole = new clsBalRoleMaster();
            return objDalRole.BindDrowDownRole();
        }

        public Int32 AddorUpdate(clsDalRoleMaster objbalrole)
        {
            clsBalRoleMaster objDalRole = new clsBalRoleMaster();
            return objDalRole.AddorUpdate(objbalrole);
        }

        public IDataReader LoadCheckedData(clsDalRoleMaster objbalrole)
        {
            clsBalRoleMaster objDalRole = new clsBalRoleMaster();
            return objDalRole.LoadCheckedData(objbalrole);
        }
    }
}