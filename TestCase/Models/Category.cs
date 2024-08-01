﻿namespace TestCase.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinStockQuantity { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
