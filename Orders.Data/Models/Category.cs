using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Data.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
