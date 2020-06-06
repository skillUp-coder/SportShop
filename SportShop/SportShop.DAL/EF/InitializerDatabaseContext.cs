using SportShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SportShop.DAL.EF
{
    public class InitializerDatabaseContext : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            IList<Category> categories = new List<Category>
            {
                new Category { Name = "Sports Goods" },
                new Category { Name = "Shoes" }
            };
            IList<DescriptionItem> listDescription = new List<DescriptionItem> 
            {
                 new DescriptionItem{ Description = "Sport supplements",  Category = "Sports Goods"},
                 new DescriptionItem{ Description = "Men's shoes", Category = "Shoes" }
            };

            IList<Item> Items = new List<Item>
            {
                new Item{ ItemName = "Ultimate Nutrition BCAA", ItemCategory = "Sports Goods", Price = 99, Category = categories.Single(x=>x.Name=="Sports Goods"), DescriptionItem = listDescription.Single(x=>x.Category == "Sports Goods")},
                new Item{ ItemName="Nike Zoom KD-12", ItemCategory="Shoes", Price=999, Category = categories.Single(x=>x.Name == "Shoes"), ItemArtUrl1 = "/Content/img/shoes/black.png", ItemArtUrl2 = "/Content/img/shoes/blue.png", ItemArtUrl3 = "/Content/img/shoes/green.png", ItemArtUrl4 = "/Content/img/shoes/orange.png", ItemArtUrl5 = "/Content/img/shoes/red.png", DescriptionItem = listDescription.Single(x=>x.Category == "Shoes") },
                new Item{ ItemName="Adidas", ItemCategory="Shoes", Price=1299, Category = categories.Single(x=>x.Name == "Shoes"), ItemArtUrl1 = "/Content/img/shoes/black.png", ItemArtUrl2 = "/Content/img/shoes/adidass.png", ItemArtUrl3 = "/Content/img/shoes/green.png", ItemArtUrl4 = "/Content/img/shoes/orange.png", ItemArtUrl5 = "/Content/img/shoes/red.png", DescriptionItem = listDescription.Single(x=>x.Category == "Shoes") }

            };

            foreach (Item itemList in Items)
            {
                context.Items.Add(itemList);
            }
            context.SaveChanges();

        }
            
    }

        /*
        protected override void Seed(DatabaseContext context)
        {
            foreach (Item itemList in Items) 
            {
                context.Items.Add(itemList);
            }

            foreach (DescriptionItem itemList in DescriptionItems) 
            {
                context.DescriptionItems.Add(itemList);
            }
            foreach (Category item in listCategories) 
            {
                context.Categories.Add(item);
            }
            */
        //context.SaveChanges();
    
        /*
        private IList<Category> listCategories = new List<Category>
        {
                new Category { Name = "Elctronics" },
                new Category { Name = "Accessories" },
                new Category { Name = "Home Appliances" },
                new Category { Name = "Hardware" },
                new Category { Name = "Clothes" },
                new Category { Name = "Children Toys" },
                new Category { Name = "Fitness Equipments" },
                new Category { Name = "Furniture" },
                new Category { Name = "Others" }
        };

        private List<Item> Items = new List<Item>
        {
            new Item{ ItemName = "Ultimate Nutrition BCAA", ItemCategory = "BCAA", Price = 99, DescriptionItemId = 1, Category =  },
            new Item{ ItemName="Anything", ItemCategory="Anything", Price=999 }
        };
        private IList<DescriptionItem> DescriptionItems = new List<DescriptionItem>
        {
            new DescriptionItem{ Description = "BCAA is a powerful complex containing the essential amino acids L-Leucine, L-Valine, L-Isoleucine in a ratio of 2: 1: 1. In addition to the listed components, the composition of this powdery substance does not contain other additives with which unscrupulous manufacturers are accustomed to supplement their products in order to dilute their total weight." }
        };
        */
    }

