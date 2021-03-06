// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace OnlineShop.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop.Pages.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\TopMenu.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\TopMenu.razor"
using Models;

#line default
#line hidden
#nullable disable
    public partial class TopMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 177 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\TopMenu.razor"
       

    private TopMenuModel menu_content;
    private bool Is_mouse_over_category, Is_mouse_over_category_List;
    private Data categories = new Data();
    private int x = 0, y = 0;

    private void outx()
    {
        x++;
    }
    private void outy()
    {
        y++;
    }

    protected override Task OnInitializedAsync()
    {
        using (StreamReader r = new StreamReader("./Data/topmenu.json"))
        {
            string json = r.ReadToEnd();
            menu_content = JsonConvert.DeserializeObject<TopMenuModel>(json);
        }
        Is_mouse_over_category = false;
        Is_mouse_over_category_List = false;

        return base.OnInitializedAsync();
    }

    private void lista(string name)
    {

        categories = menu_content.TopMenuTable.Find(x => x.Name == name);
        if (categories is not null)
        {
            Is_mouse_over_category = true;
        }
    }

    private void navigate(string link)
    {
        NavigationManager.NavigateTo(link);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsrunTime { get; set; }
    }
}
#pragma warning restore 1591
