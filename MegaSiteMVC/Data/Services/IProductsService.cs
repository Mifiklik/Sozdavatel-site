using MegaSiteMVC.Models;

namespace MegaSiteMVC.Data.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddAsync(Product product);
        Task<Product> UpdateAsync(int id, Product newProduct);
        Task DeleteAsync(int id);
    }
}
