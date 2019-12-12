using System;
using ILogic;
using Logic;
using IProductLogic = ILogic.IProductLogic;

namespace LogicFactory
{
    public static class ProductLogicFactory
    {
        public static IProductLogic GProductLogic()
        {
            return new ProductLogic();
        }
        
    }
}
