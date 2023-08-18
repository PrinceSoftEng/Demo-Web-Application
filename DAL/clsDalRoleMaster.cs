using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application_Registration.DAL
{
    public class clsDalRoleMaster
    {
        private int str_ProgramId;
        private int str_RoleId;
        private string str_Read;
        private string str_Add;
        private string str_Update;
        private string str_Delete;
        private string str_Export;
        private string str_AccessControl;

        public int programId
        {
            get { return str_ProgramId; }
            set { str_ProgramId = value; }
        }

        public int roleId
        {
            get { return str_RoleId; }
            set { str_RoleId = value; }
        }

        public string read
        {
            get { return str_Read; }
            set { str_Read = value; }
        }
        public string add
        {
            get { return str_Add; }
            set { str_Add = value; }
        }
        public string update
        {
            get { return str_Update; }
            set { str_Update = value; }
        }
        public string delete
        {
            get { return str_Delete; }
            set { str_Delete = value; }
        }
        public string export
        {
            get { return str_Export; }
            set { str_Export = value; }
        }

        public string accessControl
        {
            get { return str_AccessControl; }
            set { str_AccessControl = value; }
        }
    }
}