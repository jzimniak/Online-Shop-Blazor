using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_Radiator
    {
        public List<string> Brand { get; set; }
        public decimal Price_min { get; set; }
        public decimal Price_max { get; set; }
        public List<string> Cooling_type { get; set; }
        public List<string> Socket { get; set; }
        public List<string> Bearing { get; set; }
        public List<string> Connectors { get; set; }
        public List<string> Rps { get; set; }
    }
}
