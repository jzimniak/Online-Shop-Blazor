using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_Processor
    {
        public List<string> Brand { get; set; }
        public decimal Price_min { get;set;}
        public decimal Price_max { get; set; }
        public List<string> Family { get; set; }
        public List<string> Socket { get; set; }
        public List<string> Arch { get; set; }
        public List<string> Cores { get; set; }
        public List<string> Unlocked { get; set; }
        public List<string> Cache { get; set; }
        public List<string> Intergrated_graphic { get; set; }

    }
}
