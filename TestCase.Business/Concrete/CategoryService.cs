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
    public class CategoryService : ICategoryService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return _categoryDal.GetAll();
        }

        public async Task<Category> GetCategory(int id)
        {
            return _categoryDal.Get(x => x.Id == id);
        }

        public async Task<Category> PostCategory(Category category)
        {
            if (category == null)
            {
                return null;
            }

            _categoryDal.Add(category);

            return category;
        }
        public async Task<bool> PutCategory(int id, Category category)
        {
            try
            {
                if (id != category.Id)
                {
                    return false;
                }

                _categoryDal.Update(category);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var category = _categoryDal.Get(x => x.Id == id);

            if (category == null)
            {
                return false;
            }
            _categoryDal.Delete(category);
            return true;
        }
    }
}
