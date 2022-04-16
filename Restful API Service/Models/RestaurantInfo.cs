using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Models
{
    public class RestaurantInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Food { get; set; }
        public int Rating { get; set; }
        public int Price { get; set; }
        public Address address { get; set; }
    }
}
