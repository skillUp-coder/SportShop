using SportShop.DAL.Interfaces;
using SportShop.DLL.DTO;
using SportShop.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SportShop.DAL.Entities;
using SportShop.DLL.Infrastructure;

namespace SportShop.DLL.Services
{
    public class ServiceOrder : IServiceOrder
    {
        private IUnitOfWork Database;
        public ServiceOrder(IUnitOfWork Database)
        {
            this.Database = Database;
        }

        public void CreateOrder(OrderDTO order)
        {
            if (order == null)
                throw new ValidationException("Don`t found data","");

            Order _order = new Order 
            {
                ColorItem = order.ColorItem,
                PhoneNumber = order.PhoneNumber,
                SizeItem = order.SizeItem,
                OrderDate = order.OrderDate,
                Total = order.Total,
                Username = order.Username
            };
            Database.Orders.Create(_order);
            Database.Save();

        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order,OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, IList<OrderDTO>>(Database.Orders.GetAll());
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Not found datas","");
            Order order = Database.Orders.Get(id.Value);
            return new OrderDTO {
                OrderId = order.OrderId,
                ColorItem = order.ColorItem,
                PhoneNumber = order.PhoneNumber,
                SizeItem = order.SizeItem,
                OrderDate = order.OrderDate,
                Total = order.Total,
                Username = order.Username
            };
        }
    }
}
