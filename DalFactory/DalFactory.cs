using DAL;
using IDAL;
using System;
using DataModel;

namespace DalFactory
{
    public static class DalFactory
    {
        public static IProductDAL GProductDal()
        {
            return new ProductDAl();
        }
        public static IDalUser GUserDAl()
        {
            return new UserDal();
        }
        public static IDALOrder GOrderDal()
        {
            return new OrdorDAL();
        }
    }
}
