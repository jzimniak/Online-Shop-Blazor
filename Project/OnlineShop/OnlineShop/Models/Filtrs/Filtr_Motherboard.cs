using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_Motherboard
    {
        public List<string> Brand { get; set; }
        public decimal Price_min { get; set; }
        public decimal Price_max { get; set; }

        public List<string> Socket { get; set; }
        public List<string> Chipset { get; set; }
        public List<string> Multi_cards { get; set; }
        public List<string> Audio { get; set; }
        public List<string> Format { get; set; }
    }
}
