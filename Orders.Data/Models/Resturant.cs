using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Data.Models
{
    public class Resturant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Order> Orders { get; set; }
    }
}
