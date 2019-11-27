using System;
using System.Collections.Generic;
using Models;

namespace ILogic
{
    public interface IProductLogic
    {
        bool AddProduct();
        ProductData GetproductDetail(int id);
        bool UpdateProduct();
        List<ProductData> GetProducts();
        bool RemoveProduct();
    }
}
