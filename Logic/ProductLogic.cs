using System;
using Models;
using DAL;
using ILogic;
using System.Collections.Generic;
using IDAL;
namespace Logic
{
    public class IProductLogic : ILogic.IProductLogic
    {
        
      readonly IProductDAL product = new ProductDAl();
        public bool AddProduct(ProductData newProduct)
        {
            //product added
            if (product.InsertProduct(newProduct).Equals(1)) return true;

            //product not added
            return false;
            
        }

        public ProductData GetproductDetail(int id)
        {
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
