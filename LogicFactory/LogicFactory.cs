using System;
using ILogic;
using Logic;

namespace LogicFactory
{
    public static class LogicFactory
    {
        public static IProductLogic GProductLogic()
        {
            return new ProductLogic();
        }
        public static IOrderLogic GOrderLogic()
        {
            return new OrderLogic();
        }
        public static IUserLogic GUserLogic()
        {
            return new UserLogic();
        }

        public static ICartLogic GCartLogic()
        {
            return new CartLogic();
        }

    }
}
