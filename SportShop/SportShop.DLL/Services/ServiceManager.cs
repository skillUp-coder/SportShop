using SportShop.DAL.Interfaces;
using SportShop.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SportShop.DAL.Entities;
using SportShop.DLL.Infrastructure;
using SportShop.DLL.Interfaces;

namespace SportShop.DLL.Services
{
    public class ServiceManager:IServiceManager
    {
        private IUnitOfWork Database;
        public ServiceManager(IUnitOfWork Database)
        {
            this.Database = Database;
        }

        public void GerRemoveItem(int? id)
        {
            if (id == null)
                throw new ValidationException("Don`t found data","");

            Database.Manager.RemoveItem(id.Value);
            Database.Save();
            
        }
        public IEnumerable<ItemManager> GetAllItems() 
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Item, ItemManager>()).CreateMapper();
            return mapper.Map<IEnumerable<Item>, IList<ItemManager>>(Database.Manager.GetItems());
        
        }

        public ItemManager GetItem(int? id) 
        {
            if (id == null) 
                throw new ValidationException("Don`t found data","");

            Item getItem = Database.Manager.GetItem(id.Value);

            if (getItem == null)
                throw new ValidationException("Don`t found data","");

            return new ItemManager
            { 
                CategoryId = getItem.CategoryId,
                ColorItem = getItem.ColorItem,
                DescriptionItemId = getItem.DescriptionItemId,
                ItemArtUrl1 = getItem.ItemArtUrl1, 
                ItemArtUrl2 = getItem.ItemArtUrl2,
                ItemArtUrl3 = getItem.ItemArtUrl3,
                ItemArtUrl4 = getItem.ItemArtUrl4, 
                ItemArtUrl5 = getItem.ItemArtUrl5,
                ItemCategory = getItem.ItemCategory,
                ItemId = getItem.ItemId,
                ItemName = getItem.ItemName,
                Price = getItem.Price
            };
        }

        public void GetCreateItem(ItemManager item)
        {
            if (item == null)
                throw new ValidationException("Doun`t found data","");

            Item _item = new Item 
            {
                CategoryId =        item.CategoryId,
                ColorItem =         item.ColorItem,
                DescriptionItemId = item.DescriptionItemId,
                ItemArtUrl1 =       item.ItemArtUrl1,
                ItemArtUrl2 =       item.ItemArtUrl2,
                ItemArtUrl3 =       item.ItemArtUrl3,
                ItemArtUrl4 =       item.ItemArtUrl4,
                ItemArtUrl5 =       item.ItemArtUrl5,
                ItemCategory =      item.ItemCategory,
                ItemName =          item.ItemName,
                Price =             item.Price
            };

            Database.Manager.CreateItem(_item);
            Database.Save();
        }

        public void GetEditItem(ItemManager item) 
        {
            if (item == null)
                throw new ValidationException("Don`t found data","");

            Item _item = new Item 
            {
                CategoryId = item.CategoryId,
                ColorItem = item.ColorItem,
                DescriptionItemId = item.DescriptionItemId,
                ItemArtUrl1 = item.ItemArtUrl1,
                ItemArtUrl2 = item.ItemArtUrl2,
                ItemArtUrl3 = item.ItemArtUrl3,
                ItemArtUrl4 = item.ItemArtUrl4,
                ItemArtUrl5 = item.ItemArtUrl5,
                ItemCategory = item.ItemCategory,
                ItemName = item.ItemName,
                Price = item.Price,
                ItemId = item.ItemId
            };

            Database.Manager.EditItem(_item);
            Database.Save();
        }

        

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
