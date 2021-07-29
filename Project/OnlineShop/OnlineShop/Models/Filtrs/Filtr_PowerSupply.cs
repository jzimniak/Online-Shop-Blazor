using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_PowerSupply
    {
        public List<string> Brand { get; set; }
        public decimal Price_min { get; set; }
        public decimal Price_max { get; set; }
        public List<string> Power { get; set; }
        public List<string> Standard { get; set; }
        public List<string> Certificate { get; set; }
        public List<string> Cables_types { get; set; }

    }
}
