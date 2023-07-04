using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web_Application_Registration.BAL;
using Web_Application_Registration.BEL;
using Web_Application_Registration.BO;
using Web_Application_Registration.DAL;

namespace Web_Application_Registration.Model
{
    public class clsCarListMaster
    {
        public int AddCarsData(clsDalCarList objdalCar)
        {
            clsBalCarList objBalCar = new clsBalCarList();
            return objBalCar.AddCarsData(objdalCar);
        }

        public DataSet BindGrid()
        {
            clsBalCarList objBalCar = new clsBalCarList();
            return objBalCar.BindGrid();
        }

        public DataSet SearchGridView(clsDalCarList clsdalCar)
        {
            clsBalCarList objBalCar = new clsBalCarList();
            return objBalCar.SearchGridView(clsdalCar);
        }

        public Int32 UpDateGridView(clsDalCarList objdalCar)
        {
            clsBalCarList objBalCar = new clsBalCarList();
            return objBalCar.UpDateGridView(objdalCar);
        }

        public Int32 DeleteGridView(clsDalCarList objdalCar)
        {
            clsBalCarList objBalCar=new clsBalCarList();
            return objBalCar.DeleteGridView(objdalCar);
        }
    }
}