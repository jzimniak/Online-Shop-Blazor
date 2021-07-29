using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_Ram
    {
        public List<string> Brand { get; set; }
        public decimal Price_min { get; set; }
        public decimal Price_max { get; set; }
        public List<string> Memory_type { get; set; }
        public List<string> Memory_size_full { get; set; }
        public List<string> Items { get; set; }
        public List<string> Cycle_latency { get; set; }
        public List<string> Frequency { get; set; }

    }
}
