using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class RandomProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Path { get; set; }
        public decimal Price { get; set; }
    }
}
