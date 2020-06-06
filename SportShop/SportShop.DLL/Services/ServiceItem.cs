using AutoMapper;
using SportShop.DAL.Entities;
using SportShop.DAL.Interfaces;
using SportShop.DLL.DTO;
using SportShop.DLL.Infrastructure;
using SportShop.DLL.Interfaces;
using System;
using System.Collections.Generic;


namespace SportShop.DLL.Services
{

    
    public class ServiceItem : IServiceItem
    {
        private IUnitOfWork Database;
        public ServiceItem(IUnitOfWork Database)
        {
            this.Database = Database;
        }

        public int Count(string name,string Category)
        {
            return name == null ? Database.Items.Count(Category) : Database.Items.MatchingCategories(name,Category);
        }

        public void CreateItem(ItemDTO itemDTO)
        {
            if (itemDTO == null)
                throw new ValidationException("Don`t found data", "");
            
            Item item = new Item 
            {
                 ItemCategory = itemDTO.ItemCategory,
                 ItemName = itemDTO.ItemName,
                 Price = itemDTO.Price,
                 
            };
            Database.Items.Create(item);
            Database.Save();
        }

        public IEnumerable<ItemDTO> DatasMatchingCategories(int page, int PageSize, string name, string category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Item, ItemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Item>, IList<ItemDTO>>(Database.Items.GetDatasMatchingCategories(page, PageSize, name, category));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<string> GetByCategoryName()
        {
            return Database.Items.FindByCategoryName();
        }

        public decimal GetByCost()
        {
            return Database.Items.FindByCost();
        }

        public ItemDTO GetItem(int? id)
        {
            if (id == null)
                throw new ValidationException("Don`t found data", "");
            var data = Database.Items.Get(id.Value);
            if (data == null)
                throw new ValidationException("Don`t found data", "");
            return new ItemDTO { ItemCategory = data.ItemCategory, ItemId = data.ItemId, ItemName = data.ItemName, Price = data.Price};
        }

        public IEnumerable<ItemDTO> GetItems()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Item, ItemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Item>, IList<ItemDTO>>(Database.Items.GetAll());
        }

        public IEnumerable<ItemDTO> SortedDatas(string category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Item, ItemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Item>, IList<ItemDTO>>(Database.Items.GetSortedDatas(category));
        }
    }
}
