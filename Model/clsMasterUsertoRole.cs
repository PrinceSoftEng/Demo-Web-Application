using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using Web_Application_Registration.BAL;
using Web_Application_Registration.DAL;

namespace Web_Application_Registration.Model
{
    public class clsMasterUsertoRole
    {
        public DataTable BindGridViewRoles()
        {
            clsBalUsertoRole objUser = new clsBalUsertoRole();
            return objUser.BindGridViewRoles();
        }

        public int AddRoles(clsDalUsertoRole objDalUTR)
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.AddRoles(objDalUTR);
        }

        public Int32 DeleteRole(clsDalUsertoRole objDalUTR)
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.DeleteRole(objDalUTR);
        }

        public IDataReader CheckRoleIdExist(clsDalUsertoRole objDalUTR)
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return  objBalUTR.CheckRoleIdExist(objDalUTR);
        }

        public DataTable BindRoleForCheckBoxList()
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.BindRoleForCheckBoxList();
        }

        [WebMethod]
        public List<string> GetAutoComplete(string searchTerm)
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.GetAutoComplete(searchTerm);
        }
    }
}