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
    public class CategoryTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetFindByNameItem() 
        {
            mock.Setup(x=>x.Categories);
            ServiceCategory service = new ServiceCategory(mock.Object);
            IEnumerable<string> res = service.GetFindByNameItem(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetCategory() 
        {
            mock.Setup(x => x.Categories);
            ServiceCategory service = new ServiceCategory(mock.Object);
            CategoryDTO res = service.GetCategory(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetCategoryFind() 
        {
            mock.Setup(x => x.Categories);
            ServiceCategory service = new ServiceCategory(mock.Object);
            CategoryDTO res = service.GetCategoryFind(null);
        }

        
    }
}
