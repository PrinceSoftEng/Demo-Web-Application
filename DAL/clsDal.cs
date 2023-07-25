using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Application_Registration.BO;

namespace Web_Application_Registration.BEL
{
    public class clsDal
    {
        private int Id;
        private int str_RoleId;
        private string str_UserName;
        private string str_FirstName;
        private string str_MiddleName;
        private string str_LastName;
        private string str_Gender;
        private string str_Mobile;
        private string str_Email;
        private string str_Password;
        private string str_Address;
        private string str_Country;
        private string str_State;
        private string str_City;
        private bool str_IsActive;
        private string str_CreatedBy;
        private string str_ModifiedBy;

        public int id
        {
            get { return Id; } 
            set { Id = value; }  
        }
        public int roleId
        {
            get { return str_RoleId; }
            set { str_RoleId = value; }
        }
        public string userName
        {
            get { return str_UserName; }
            set { str_UserName = value; }
        }
        public string firstName
        {
            get { return str_FirstName; }
            set { str_FirstName = value; }
        }
        public string middleName
        {
            get { return str_MiddleName; }
            set { str_MiddleName = value; }
        }
        public string lastName
        {
            get { return str_LastName; }
            set { str_LastName = value; }
        }
        public string gender
        {
            get { return str_Gender; }
            set { str_Gender = value; }
        }
        public string mobile
        {
            get { return str_Mobile; }
            set { str_Mobile = value; }
        }
        public string email
        {
            get { return str_Email; }
            set { str_Email = value; }
        }
        public string password
        {
            get { return str_Password; }
            set { str_Password = value; }
        }
        public string address
        {
            get { return str_Address; }
            set { str_Address = value; }
        }
        public string country
        {
            get { return str_Country; }
            set { str_Country = value; }
        }
        public string state
        {
            get { return str_State; }
            set { str_State = value; }
        }
        public string city
        {
            get { return str_City; }
            set { str_City = value; }
        }
        public bool isActive
        {
            get { return str_IsActive; }
            set { str_IsActive = value; }
        }
        public string createdBy
        {
            get { return str_CreatedBy; }
            set { str_CreatedBy = value; }
        }
        public string modifiedBy
        {
            get { return str_ModifiedBy; }
            set { str_ModifiedBy = value; }
        }
    }
}