// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace OnlineShop.Components.Product_Management
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
#line 3 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AdminPanelPage.razor"
using DataAccess;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AdminPanelPage.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AdminPanelPage.razor"
using Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AdminPanelPage.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AdminPanelPage.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class AdminPanelPage : ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AdminPanelPage.razor"
       
    private bool login;
    private string username, password;

    protected override void OnInitialized()
    {
        login = false;
    }

    private async void logowanie()
    {

        if (username == "admin" && password == "password")
        {
            //check if tables exists
            login = true;
            await DatabaseValidation.Checktables();

        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Services.Json_distinct json_Distinct { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebHostEnvironment env { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SqlDataAccess _data { get; set; }
    }
}
#pragma warning restore 1591
