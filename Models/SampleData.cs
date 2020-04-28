using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EStore_MVC_.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Laptop" },
                new Category { Name = "PC" },
                new Category { Name = "Desctop" },

            };

            var brands = new List<Brand>
            {
                new Brand { Name = "Lenovo" },
                new Brand { Name = "HP" },
                new Brand { Name = "Apple" },
            };

            new List<Product>
            {
                new Product { Title = "", Category = categories.Single(c => c.Name == ""), Price = 8.99M, Brand = brands.Single(b => b.Name == ""), ProductImgUrl = "/Content/Images/placeholder.gif" },
                
            }.ForEach(a => context.Products.Add(a));
        }
    }
}