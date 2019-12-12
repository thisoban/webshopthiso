using System;
using System.Collections.Generic;
using DataModel;
using Models;

namespace IDAL
{
    public interface IProductDAL
    {
        bool InsertProduct(ProductData product);
        bool UpdateProduct(ProductData upProduct);
        List<ProductData> GetProducts();
        ProductData GetProductDetail(int id);
    }
}
