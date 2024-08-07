using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Abstract;
using TestCase.Entities.Concrete;

namespace TestCase.DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EfEntityRepositoryBase<Product, DemoContext>, IProductDal
    {
        public override Product Get(Expression<Func<Product, bool>> filter= null)
        {
            using (var context = new DemoContext())
            {
                var entity=context.Set<Product>().Include(x=>x.Category).FirstOrDefault(filter);
                return entity;
            }
        }

        public override List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new DemoContext())
            {
                var entity =(filter==null)? context.Set<Product>().Include(x => x.Category).ToList()
                    :context.Set<Product>().Where(filter).Include(x=>x.Category).ToList();
                return entity;
            }
        }

    }
}
