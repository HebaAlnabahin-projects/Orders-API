using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Data.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public User Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
    }
}
