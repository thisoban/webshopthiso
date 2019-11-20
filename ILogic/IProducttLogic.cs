using System;
using Models;

namespace ILogic
{
    public interface IProductLogic
    {
        bool AddProduct();
        DataProduct  Getproduct();
        bool UpdateProduct();
        DataProduct GetProducts();
        bool RemoveProduct();
    }
}
