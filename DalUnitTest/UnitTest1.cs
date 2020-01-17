using NUnit.Framework;
using DAL;
using Models;


namespace DalUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void GetProductTest()
        {
            int serialnumber = 123546789;
            ProductDAl product = new ProductDAl();
            ProductData product1 = new ProductData()
            {Id = 6,
               Name = "conn",
               Description = "is een persoon die programmeurt en alles voor je maakt",
                Quantity = 12,
               Price = 12,
                Serialnumber = 123546789
            };
            ProductData productdal = product.GetProductDetail(serialnumber);
            Assert.AreEqual(product1.Serialnumber, productdal.Serialnumber);
            Assert.AreEqual(product1.Price, productdal.Price);
            Assert.AreEqual(product1.Quantity, productdal.Quantity);
            Assert.AreEqual(product1.Description, productdal.Description);
            Assert.AreEqual(product1.Id, productdal.Id);
  
         
        }
    }
}