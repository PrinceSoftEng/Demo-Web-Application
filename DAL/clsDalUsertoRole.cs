using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application_Registration.DAL
{
    public class clsDalUsertoRole
    {
        private int str_RoleId;
        private string str_RoleName;

        public int roleId 
        {
            get { return this.str_RoleId; }
            set { str_RoleId = value; }
        }

        public string roleName 
        {
            get { return this.str_RoleName;}
            set { str_RoleName = value; }
        }
    }
}