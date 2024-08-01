using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCase.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? StockQuantity { get; set; }
        public int? CategoryId { get; set; }
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
                    return  (StockQuantity >= minimumStock);
                }
            }
        }
    }
}
