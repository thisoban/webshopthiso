using System;
using Models;
using DAL;
using ILogic;
using System.Collections.Generic;
using IDAL;
namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductDAL product = DalFactory.DalFactory.GProductDal();
       
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

        public bool RemoveProduct(ProductData product)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(ProductData upProduct)
        {
            throw new NotImplementedException();
        }
    }
}
