using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoponBusinessLayer.Contracts;
using ShoponBusinessLayer.Implementation;
using ShoponCommonLayer.Models;
using ShoponDataLayer.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnAppTestProject
{
    [TestClass]
    public class ShoponBusinessLayerUnitTest
    {
        private IProductManager productManager = null;
        private Mock<IProductRepository> productRepoMock = null;

        [TestInitialize]
        public void Init()
        {
            productRepoMock = new Mock<IProductRepository>();
            productManager = new ProductManager(productRepoMock.Object);
        }
        [TestMethod]
        public void GetProductsTest()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    
                    PId=1,
                    ProductName="Apple Iphone Mini",
                    AvailableStatus="yes",
                    Price=23000,
                    ImageUrl="images/apple/1.jpg"
                },
                new Product()
                {
                    PId=2,
                    ProductName="Apple Iphone 4s",
                    AvailableStatus="yes",
                    Price=33000,
                    ImageUrl="images/apple/2.jpg"
                },
                new Product()
                {
                    PId=3,
                    ProductName="Apple Iphone 5s",
                    AvailableStatus="yes",
                    Price=43000,
                    ImageUrl="images/apple/3.jpg"
                },
                new Product()
                {
                    PId=4,
                    ProductName="Apple Iphone 6s",
                    AvailableStatus="yes",
                    Price=53000,
                    ImageUrl="images/apple/4.jpg"
                }

            };
            productRepoMock.Setup(x => x.GetProducts(true)).Returns(products);
            var actual = productManager.GetProducts();
            var actualCount = actual.Count();
            var expectedCount = 4;
            //Check whether the actual count is equal to expected count
            Assert.AreEqual(expectedCount, actualCount);
            //var actual = productManager.GetProducts().FirstOrDefault();
            //var expected = new Product()
            //{
            //    PId = 1,
            //    ProductName = "Apple Iphone Mini",
            //    AvailableStatus = "yes",
            //    Price = 23000,
            //    ImageUrl = "images/apple/1.jpg"
            //};
            ////1.The Actual Shouldnot be null
            //Assert.IsNotNull(actual);
            ////2.The Actuals Id should be equal to Expected's Id
            //Assert.AreEqual(expected.PId, actual.PId);
            ////3.The Actuals Name should be equal to Expected's Name
            //Assert.AreEqual(expected.ProductName, actual.ProductName);
            ////4.The Actuals available status should be equal to expecteds
            //Assert.AreEqual(expected.AvailableStatus, actual.AvailableStatus);
            ////5.the Actuals image url should be equal to expected image url
            //Assert.AreEqual(expected.ImageUrl, actual.ImageUrl);
        }
        [TestMethod]
        public void GetProductByIdTest()
        {
            int id = 2;
            var expected = new Product()
            {
                PId = 2,
                ProductName = "Apple Iphone 4s",
                AvailableStatus = "yes",
                Price = 33000,
                ImageUrl = "images/apple/2.jpg"
            };
            
            productRepoMock.Setup(x => x.GetProductById(id)).Returns(expected);
            var actual = productManager.GetProductById(id);
            //1.The actual should not be null
            Assert.IsNotNull(actual);
            //2.The actual's id should be equal to expected'id
            Assert.AreEqual(expected.PId, actual.PId);
            //3.The actual's productname should be equal to expected' product name
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            //4.The Actuals available status should be equal to expecteds
            Assert.AreEqual(expected.AvailableStatus, actual.AvailableStatus);
            //5.the Actuals image url should be equal to expected image url
            Assert.AreEqual(expected.ImageUrl, actual.ImageUrl);
        }

        [TestMethod]
        public void GetProductByInvalidIdTest()
        {
            int id = 50;
            var actual = productManager.GetProductById(id);
            productRepoMock.Setup(x => x.GetProductById(id)).Returns(actual);  
            //1.The actual should not be null
            Assert.IsNull(actual);

        }
        [TestMethod]
        public void SortByIdTest()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {

                    PId=1,
                    ProductName="Apple Iphone Mini",
                    AvailableStatus="yes",
                    Price=23000,
                    ImageUrl="images/apple/1.jpg"
                },
                new Product()
                {
                    PId=4,
                    ProductName="Apple Iphone 4s",
                    AvailableStatus="yes",
                    Price=33000,
                    ImageUrl="images/apple/2.jpg"
                },
                new Product()
                {
                    PId=2,
                    ProductName="Apple Iphone 5s",
                    AvailableStatus="yes",
                    Price=43000,
                    ImageUrl="images/apple/3.jpg"
                },
                new Product()
                {
                    PId=3,
                    ProductName="Apple Iphone 6s",
                    AvailableStatus="yes",
                    Price=53000,
                    ImageUrl="images/apple/4.jpg"
                }

            };
            productRepoMock.Setup(x => x.GetProducts(true)).Returns(products);
            var expectedId = 1;
            var actual = productManager.SortById().FirstOrDefault();
            //check if the first sorted product'ID is equal to the Expected's Id
            Assert.AreEqual(expectedId, actual.PId);
        }

        [TestMethod]
        public void SortByNameTest()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {

                    PId=1,
                    ProductName="Vivo",
                    AvailableStatus="yes",
                    Price=23000,
                    ImageUrl="images/apple/1.jpg"
                },
                new Product()
                {
                    PId=4,
                    ProductName="Realme 9pro ",
                    AvailableStatus="yes",
                    Price=33000,
                    ImageUrl="images/apple/2.jpg"
                },
                new Product()
                {
                    PId=2,
                    ProductName="Apple Iphone",
                    AvailableStatus="yes",
                    Price=43000,
                    ImageUrl="images/apple/3.jpg"
                },
                new Product()
                {
                    PId=3,
                    ProductName="Oppon F7",
                    AvailableStatus="yes",
                    Price=53000,
                    ImageUrl="images/apple/4.jpg"
                }

            };
            productRepoMock.Setup(x => x.GetProducts(true)).Returns(products);
            var expectedName = "Apple Iphone";
            var actual = productManager.SortByName().FirstOrDefault();
            //check if the first sorted product'ID is equal to the Expected's Id
            Assert.AreEqual(expectedName, actual.ProductName);
        }

        [TestMethod]
        public void SortByPriceTest()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {

                    PId=1,
                    ProductName="Apple Iphone Mini",
                    AvailableStatus="yes",
                    Price=23000,
                    ImageUrl="images/apple/1.jpg"
                },
                new Product()
                {
                    PId=4,
                    ProductName="Apple Iphone 4s",
                    AvailableStatus="yes",
                    Price=33000,
                    ImageUrl="images/apple/2.jpg"
                },
                new Product()
                {
                    PId=2,
                    ProductName="Apple Iphone 5s",
                    AvailableStatus="yes",
                    Price=43000,
                    ImageUrl="images/apple/3.jpg"
                },
                new Product()
                {
                    PId=3,
                    ProductName="Apple Iphone 6s",
                    AvailableStatus="yes",
                    Price=53000,
                    ImageUrl="images/apple/4.jpg"
                }

            };
            productRepoMock.Setup(x => x.GetProducts(true)).Returns(products);
            var expectedPrice = 23000;
            var actual = productManager.SortByPrice().FirstOrDefault();
            //check if the first sorted product'ID is equal to the Expected's Id
            Assert.AreEqual(expectedPrice, actual.Price);
        }
    }
}
