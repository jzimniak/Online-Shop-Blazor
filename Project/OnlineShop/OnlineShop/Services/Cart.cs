using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public class Cart
    {
        public List<Items> items { get; set; }
    }

    public class Items
    {
        public int id { get; set; }
        public decimal price { get; set; }
        public int amount { get; set; }
        public string photo { get; set; }
        public string name { get; set; }
    }
}
