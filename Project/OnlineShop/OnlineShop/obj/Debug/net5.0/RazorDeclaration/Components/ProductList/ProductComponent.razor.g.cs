// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace OnlineShop.Components.ProductList
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Functions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\_Imports.razor"
using Services;

#line default
#line hidden
#nullable disable
    public partial class ProductComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\Components\ProductList\ProductComponent.razor"
       
    [Parameter]
    public float Price { get; set; }
    [Parameter]
    public string Name { get; set; }
    [Parameter]
    public string Photo { get; set; }
    [Parameter]
    public int ID { get; set; }
    [Parameter]
    public List<string> Attributes { get; set; }
    [Parameter]
    public float rating { get; set; }
    [Parameter]
    public int amount_of_opinions { get; set; }
    [Parameter]
    public string link { get; set; }


    private void Add_Product_To_Cart()
    {
        if (Cart.items is null)
        {
            Cart.items = new List<Items>();
        }

        if (Cart.items.Any(x => x.name == this.Name))
        {
            int index = Cart.items.IndexOf(Cart.items.First(x => x.name == this.Name));

            if (Cart.items[index].amount ==10)
            {

            }
            else
            {
                Cart.items[index].amount = Cart.items[index].amount + 1;
                Refresh_Component.topMenuComponent.Refresh();
            }
        }
        else
        {
            Cart.items.Add(new Items() { amount = 1, id = this.ID, name = this.Name, photo = this.Photo, price = (decimal)this.Price });
            Refresh_Component.topMenuComponent.Refresh();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Refresh_Component Refresh_Component { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Cart Cart { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
