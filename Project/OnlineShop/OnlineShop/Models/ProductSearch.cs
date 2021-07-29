using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ProductSearch
    {

        public int Id { get; set; }

        public string Name { get; set; }


        public float Price { get; set; }


        public string Brand { get; set; }

        public string Warranty { get; set; }

        public string producttype { get; set; }
        public string[] Photo { get; set; }
        public List<string> Attributes { get; set; }
    }
}
