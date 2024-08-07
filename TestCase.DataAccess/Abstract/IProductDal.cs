using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Entities.Concrete;

namespace TestCase.DataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>
    {

    }
}
