using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace TestCase.Entities.Concrete
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? StockQuantity { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public bool IsPublished
        {
            get
            {
                if (Category == null)
                {
                    return false;
                }
                else
                {
                    var minimumStock = Category.MinStockQuantity;
                    return (StockQuantity >= minimumStock);
                }
            }
        }
    }
}
