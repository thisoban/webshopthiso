using System;
using Models;
using DAO;
using ILogic;
using System.Collections.Generic;

namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        IDAL.IProductDAL product;
        public bool AddProduct()
        {
            throw new NotImplementedException();
        }

        public ProductData GetproductDetail(int id)
        {
           return product.GetProductDetail(id);
        }

        public List<ProductData> GetProducts()
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
