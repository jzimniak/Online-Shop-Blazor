using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Components;
using OnlineShop.Components.ProductPage;
using OnlineShop.Pages;

namespace OnlineShop.Services
{
    public class Refresh_Component
    {
        public TopMenuComponent topMenuComponent { get; set; }
        public ProductPage productPage { get; set; }
        public OpinionsComponent opinionsComponent { get; set; }
        public AdminPanelPage adminPanelPage { get; set; }
    }
}
