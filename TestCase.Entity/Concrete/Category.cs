using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Entities.Concrete
{
    public class Category: Core.Entities.IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }
        //public ICollection<Product> Products { get; set; }
    }
}
