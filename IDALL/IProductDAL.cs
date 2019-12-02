﻿using System;
using System.Collections.Generic;
using DataModel;
using Models;

namespace IDAL
{
    public interface IProductDAL
    {
        bool InsertProduct();
        bool UpdateProduct();
        List<ProductData> GetProducts();
        ProductData GetProductDetail(int id);
    }
}