using SportShop.DAL.EF;
using SportShop.DAL.Entities;
using SportShop.DAL.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportShop.DAL.Repositories
{
    public class RepostoryDescription: IRepositoryDescription<DescriptionItem>
    {
        private DatabaseContext context;
        public RepostoryDescription(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<DescriptionItem> GetDescriptions() 
        {
            return context.DescriptionItems.ToList();
        }
        public DescriptionItem GetDescription(string category) 
        {
            var res = context.DescriptionItems.Include(x => x.Items).Single(x => x.Category == category);
            return res;
        }
    }
}
