using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_ComputerCase
    {
        public List<string> Brand { get; set; }
        public List<string> Type { get; set; }
        public List<string> Power_supply_type { get; set; }
        public List<string> Motherboardstype { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Heigth { get; set; }
        public decimal Price_min { get; set; }
        public decimal Price_max { get; set; }
    }
}
