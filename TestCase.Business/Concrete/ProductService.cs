using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Business.Abstract;
using TestCase.DataAccess.Abstract;
using TestCase.Entities.Concrete;

namespace TestCase.Business.Concrete
{
    public class ProductService: IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;
        public ProductService(IProductDal productDal, ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {

            return  _productDal.GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            return _productDal.Get(x=>x.Id==id);
        }

        public async Task<Product> PostProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Title) || product.Title.Length > 200)
            {
                throw new ArgumentException("Invalid title.");
            }

            _productDal.Add(product);

            return product;
        }

        public async Task<bool> PutProduct(int id, Product product)
        {
            if (id != product.Id || string.IsNullOrWhiteSpace(product.Title) || product.Title.Length > 200)
            {
                return false;
            }

            var category = _categoryDal.Get(x => x.Id == product.CategoryId); 
            if (category == null || product.StockQuantity < category.MinStockQuantity)
            {
                return false;
            }

            _productDal.Update(product);

            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product =_productDal.Get(x=>x.Id==id);
            
            if (product == null)
            {
                return false;
            }
            _productDal.Delete(product);
            return true;
        }

        public async Task<List<Product>> FilterProducts(string keyword, int? minStock, int? maxStock)
        {
            var query = _productDal.GetAll();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.FindAll(p => p.Title.Contains(keyword) || p.Description.Contains(keyword) || p.Category.Name.Contains(keyword));
            }

            if (minStock.HasValue)
            {
                query = query.FindAll(p => p.StockQuantity >= minStock.Value);
            }

            if (maxStock.HasValue)
            {
                query = query.FindAll(p => p.StockQuantity <= maxStock.Value);
            }
            return  query.ToList();
        }
    }
}
