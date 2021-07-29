using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.Filtrs
{
    public class Filtr_Disc
    {
        public List<string> Brand { get; set; }
        public decimal Price_min { get; set; }
        public decimal Price_max { get; set; }
        public List<string> Type { get; set; }
        public List<string> Format { get; set; }
        public int Read_speed { get; set; }
        public int Write_speed { get; set; }

    }
}
