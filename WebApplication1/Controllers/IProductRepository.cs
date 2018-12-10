using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data.Modals;

namespace WebApplication1.Controllers
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductsByCategory(string category);
        Task<Product> GetProductsById(int id);
        void SaveAll();
    }
}