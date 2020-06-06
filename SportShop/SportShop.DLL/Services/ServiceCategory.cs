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
    public class ServiceCategory : IServiceCatogory
    {
        private IUnitOfWork Database;
        public ServiceCategory(IUnitOfWork Database)
        {
            this.Database = Database;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category,CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, IList<CategoryDTO>>(Database.Categories.AllCategories());
        }
        public IEnumerable<string> GetFindByNameItem(string category) 
        {
            if(category == null)
                throw new ValidationException("Don`t found data", "");

            return Database.Categories.FindByNameItem(category);
        }

        public CategoryDTO GetCategory(string category)
        {
            if (category == null)
                throw new ValidationException("Don`t found data","");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category, CategoryDTO>(Database.Categories.GetCategory(category));
        }

        public CategoryDTO GetCategoryFind(int? id)
        {
            if(id == null)
                throw new ValidationException("Don`t found data", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category, CategoryDTO>(Database.Categories.CategoryFind(id.Value));
        }

        
    }
}
