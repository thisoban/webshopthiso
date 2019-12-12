using DAL;
using IDAL;
using System;

namespace DalFactory
{
    public static class ProductDalFactory
    {
        public static IProductDAL GProductDal()
        {
            return new ProductDAl();
        }
    }
}
