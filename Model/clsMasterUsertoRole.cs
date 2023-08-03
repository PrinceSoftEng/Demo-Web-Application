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

        public IDataReader LoadCheckedData(clsDalUsertoRole objDalUTR)
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.LoadCheckedData(objDalUTR);
        }

        public DataTable BindGrid()
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.BindGrid();
        }
        public DataTable BindUserDropdown()
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.BindUserDropdown();
        }

        public DataTable BindRolesRadioButtonList()
        {
            clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
            return objBalUTR.BindRolesRadioButtonList();
        }

        //public Int32 AddUserToRole(clsDalUsertoRole objDalUTR)
        //{
        //    clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
        //    return objBalUTR.AddUserToRole(objDalUTR);
        //}

        //public List<string> GetAutoComplete(string searchTerm)
        //{
        //    clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
        //    return objBalUTR.GetAutoComplete(searchTerm);
        //}

        //public DataTable BindRoleForCheckBoxList()
        //{
        //    clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
        //    return objBalUTR.BindRoleForCheckBoxList();
        //}

        //public DataTable BindDropDownUserName()
        //{
        //    clsBalUsertoRole objBalUTR = new clsBalUsertoRole();
        //    return objBalUTR.BindDropDownList();
        //}
    }
}