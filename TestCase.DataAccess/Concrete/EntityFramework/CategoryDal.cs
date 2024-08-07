using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Abstract;
using TestCase.Entities.Concrete;

namespace TestCase.DataAccess.Concrete.EntityFramework
{
    public class CategoryDal: EfEntityRepositoryBase<Category,DemoContext>,ICategoryDal
    {
    }
}
