using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountValue { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}

