using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Entities.Concrete;

namespace TestCase.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> PostCategory(Category category);
        Task<bool> PutCategory(int id, Category category);
        Task<bool> DeleteCategory(int id);
    }
}
