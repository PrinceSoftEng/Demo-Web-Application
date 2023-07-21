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
        private byte str_Read;
        private byte str_Add;
        private byte str_Update;
        private byte str_Delete;
        private byte str_Export;
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

        public byte read
        {
            get { return str_Read; }
            set { str_Read = value; }
        }
        public byte add
        {
            get { return str_Add; }
            set { str_Add = value; }
        }
        public byte update
        {
            get { return str_Update; }
            set { str_Update = value; }
        }
        public byte delete
        {
            get { return str_Delete; }
            set { str_Delete = value; }
        }
        public byte export
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