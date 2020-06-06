using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportShop.DAL.Interfaces;
using SportShop.DLL.DTO;
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
    public class ItemTest
    {

        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CreateItem() 
        {
            mock.Setup(x=>x.Items);
            ServiceItem target = new ServiceItem(mock.Object);
            target.CreateItem(null); 
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetItem()
        {
            mock.Setup(x => x.Items);
            ServiceItem target = new ServiceItem(mock.Object);
            var res = target.GetItem(null);
        }
    }
}
