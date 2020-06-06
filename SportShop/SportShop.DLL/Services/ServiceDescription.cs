using SportShop.DAL.Interfaces;
using SportShop.DLL.DTO;
using AutoMapper;
using SportShop.DAL.Entities;
using SportShop.DLL.Interfaces;
using System.Collections.Generic;
using SportShop.DLL.Infrastructure;

namespace SportShop.DLL.Services
{
    public class ServiceDescription: IServiceDescription
    {
        private IUnitOfWork Database;
        public ServiceDescription(IUnitOfWork Database)
        {
            this.Database = Database;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<DescriptionItemDTO> GetAllDescription() 
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DescriptionItem, DescriptionItemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<DescriptionItem>,IList<DescriptionItemDTO>>(Database.Descriptions.GetDescriptions());
        }
        public DescriptionItemDTO GetDescriptionCategory(string category) 
        {
            if(category == null)
                throw new ValidationException("Don`t found data", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DescriptionItem, DescriptionItemDTO>()).CreateMapper();
            var res = mapper.Map<DescriptionItem, DescriptionItemDTO>(Database.Descriptions.GetDescription(category));
            return res;
        }

    }
}
