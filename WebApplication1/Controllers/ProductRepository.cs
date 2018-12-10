using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Data.Modals;

namespace WebApplication1.Controllers
{
    public class ProductRepository : IProductRepository
    {
        private DutchContext db;

        public ProductRepository(DutchContext dbContext)
        {
            db = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
           return await db.Products.OrderBy(s=>s.Id).ToListAsync();
        }

        public async Task<Product> GetProductsById(int id)
        {
            var product = await db.Products.Where(s => s.Id == id).FirstOrDefaultAsync();
            return product;
        }
        public async Task<Product> GetProductsByCategory(string category)
        {
            var product = await db.Products.Where(s => s.Category == category).FirstOrDefaultAsync();
            return product;
        }

        public async void SaveAll() => await db.SaveChangesAsync();
    }
}
