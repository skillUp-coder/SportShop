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
    public class DescriptionTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void GetDescriptionCategory() 
        {
            mock.Setup(x=>x.Descriptions);
            ServiceDescription service = new ServiceDescription(mock.Object);
            DescriptionItemDTO itemDTO = service.GetDescriptionCategory(null);
        }
    }
}
