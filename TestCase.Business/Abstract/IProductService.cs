using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Entities.Concrete;

namespace TestCase.Business.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> PostProduct(Product product);
        Task<bool> PutProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);
        Task<List<Product>> FilterProducts(string keyword, int? minStock, int? maxStock);
    }
}
