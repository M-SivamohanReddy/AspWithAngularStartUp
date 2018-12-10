using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Modals;

namespace WebApplication1.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext ctx;
        private readonly IHostingEnvironment hosting;

        public DutchSeeder(DutchContext ctx, IHostingEnvironment hosting)
        {
            this.ctx = ctx;
            this.hosting = hosting;
        }
        public void Seed()
        {
            // it will check in the database is row existed or not and if exist it will not create everyTime
            ctx.Database.EnsureCreated();
            if (ctx.Products.Any())
            {
                // Need to create sample data

                //hosting.ContentRootPath will give the route path of the application from the solution.
                var filePath = Path.Combine(hosting.ContentRootPath, "Data/art.json");
                var jsonData = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonData);
                ctx.Products.AddRange(products);

                var order = ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price,
                        }
                    };
                }
                ctx.SaveChanges();

            }
        }

    }
}
