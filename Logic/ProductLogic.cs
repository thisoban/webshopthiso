using System;
using Models;
using DAO;
using ILogic;
using System.Collections.Generic;

namespace Logic
{
    public class IProductLogic : ILogic.IProductLogic
    {
        
       ProductDAl product = new ProductDAl();
        public bool AddProduct()
        {
            throw new NotImplementedException();
        }

        public ProductData GetproductDetail(int id)
        { 
             id = 1;
           
           return product.GetProductDetail(id);
        }

        public List<ProductData> GetProducts()
        {
            List<ProductData> products = product.GetProducts();
           
            
            return products;
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
