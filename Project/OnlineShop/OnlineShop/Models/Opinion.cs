using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Opinions
    {
        public int Id { get; set; }
        public int productID { get; set; }
        public float rating { get; set; }
        public int opinions { get; set; }
        public int star0 { get; set; }
        public int star1 { get; set; }
        public int star2 { get; set; }
        public int star3 { get; set; }
        public int star4 { get; set; }
        public int star5 { get; set; }

        public List<Opinion> opinions_text { get; set; }
    }
    public class Opinion
    {
        public string Nick { get; set; }
        public string Text { get; set; }
        public int star { get; set; }
        public DateTime Date { get; set; }
    }
}
