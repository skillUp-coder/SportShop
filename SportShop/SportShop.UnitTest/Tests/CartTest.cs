using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportShop.DAL.Interfaces;
using SportShop.DLL.Infrastructure;
using SportShop.DLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.UnitTest.Tests
{
    [TestClass]
    public class CartTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddCart() 
        {
            mock.Setup(x => x.Carts);
            ServiceCart serviceCart = new ServiceCart(mock.Object);
            serviceCart.GetAddToCart(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CreateOrder() 
        {
            mock.Setup(x => x.Carts);
            ServiceCart serviceCart = new ServiceCart(mock.Object);
            int res = serviceCart.GetCreateOrder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetItemName() 
        {
            mock.Setup(x => x.Carts);
            ServiceCart serviceCart = new ServiceCart(mock.Object);
            string res = serviceCart.GetItemName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetMigrateCart() 
        {
            mock.Setup(x => x.Carts);
            ServiceCart serviceCart = new ServiceCart(mock.Object);
            serviceCart.GetMigrateCart(null);
        }



    }
}
