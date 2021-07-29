using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{

    public class TopMenuModel
    {
        public List<Products> Products_List { get; set; }
    }


    public class Products
    {
        public string Product_name { get; set; }
        public string Product_link { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public string Category_name { get; set; }
        public string Category_link { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }

    public class Subcategory
    {
        public string Subcategory_name { get; set; }
        public string Subcategory_link { get; set; }
    }
}
