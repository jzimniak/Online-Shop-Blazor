using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_GraphicCard
    {
        public List<string> Brand { get; set; }
        public decimal Price_min { get; set; }
        public decimal Price_max { get; set; }
        public List<string> Graphics_processing { get; set; }
        public List<string> Rtx { get; set; }
        public List<string> Memory_size { get; set; }
        public List<string> Producent { get; set; }
        public int Length { get; set; }
    }
}
