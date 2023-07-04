using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Application_Registration.DAL
{
    public class clsDalCarList
    {
        private int str_CarId;
        private int str_CarCode;
        private string str_CarName;
        private string str_CarColor;
        private string str_CarYear;
        private string str_CarMakerComp;
        private string str_carModel;
        private int Str_CarMileage;
        private string str_CarCondition;
        private Decimal str_CarPrice;


        public int carId { get { return str_CarId; } set { str_CarId = value; } }
        public int carCode { get { return str_CarCode; } set { str_CarCode = value; } }
        public string carName { get { return str_CarName; } set { str_CarName = value; } }
        public string carColor { get { return str_CarColor; } set { str_CarColor = value; } }
        public string carYear { get { return str_CarYear; } set { str_CarYear = value; } }
        public string carMakerComp { get { return str_CarMakerComp; } set { str_CarMakerComp = value; } }
        public string carModel { get { return str_carModel; }set { str_carModel = value; } }
        public int carMileage { get { return Str_CarMileage; } set { Str_CarMileage = value; } }
        public string carCondition { get { return str_CarCondition; } set { str_CarCondition = value; } }
        public Decimal carPrice { get { return str_CarPrice; } set { str_CarPrice = value; } }
    }
}