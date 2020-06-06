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
    public class ManagerTest
    {

        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GerRemoveItem() 
        {
            mock.Setup(x=>x.Manager);
            ServiceManager service = new ServiceManager(mock.Object);
            service.GerRemoveItem(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetItem() 
        {
            mock.Setup(x => x.Manager);
            ServiceManager service = new ServiceManager(mock.Object);
            ItemManager item = service.GetItem(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetCreateItem() 
        {
            mock.Setup(x => x.Manager);
            ServiceManager service = new ServiceManager(mock.Object);
            service.GetCreateItem(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetEditItem() 
        {
            mock.Setup(x => x.Manager);
            ServiceManager service = new ServiceManager(mock.Object);
            service.GetEditItem(null);
        }
    }
}
