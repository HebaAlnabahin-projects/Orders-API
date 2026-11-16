using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.Dto
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; }
    }
}
