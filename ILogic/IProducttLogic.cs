using System;
using System.Collections.Generic;
using Models;

namespace ILogic
{
    public interface IProductLogic
    {
        bool AddProduct(ProductData newProduct);
        
        ProductData GetproductDetail(int id);
        bool UpdateProduct(ProductData upProduct);
        List<ProductData> GetProducts();
    }
}
