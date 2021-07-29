// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace OnlineShop.Components.LoginSystem
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
using OnlineShop.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using OnlineShop.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Functions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\_Imports.razor"
using Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\LoginSystem\RegisterComponent.razor"
using Models.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\LoginSystem\RegisterComponent.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\LoginSystem\RegisterComponent.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
    public partial class RegisterComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\LoginSystem\RegisterComponent.razor"
       

    private Register RegisterModel { get; set; }

    private bool loading { get; set; }
    private string info { get; set; }

    protected override void OnInitialized()
    {
        RegisterModel = new();
    }

    private async void Register()
    {
        loading = true;
        if (await Additional_Functions.UserExist(RegisterModel.UserName, _config))
        {
            RegisterModel.UserName = null;
            info = "Użytkownik o podanej nazwie istnieje";
        }
        else
        {
            await Additional_Functions.Create_User(RegisterModel, _config);

            SimpleUserInfo.IsLogged = true;
            SimpleUserInfo.Email = RegisterModel.Email;
            SimpleUserInfo.UserName = RegisterModel.UserName;
            SimpleUserInfo.UserRole = "User";
            await BrowserStorage.SetAsync("login", "True");
            await BrowserStorage.SetAsync("role", SimpleUserInfo.UserRole);
            await BrowserStorage.SetAsync("Email", SimpleUserInfo.Email);
            await BrowserStorage.SetAsync("UserAddress", SimpleUserInfo.UserAddress);
            await BrowserStorage.SetAsync("UserName", SimpleUserInfo.UserName);

            Refresh_Component.topMenuComponent.Refresh();
            Refresh_Component.topMenuComponent.closewindow();
        }
        loading = false;
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Services.Refresh_Component Refresh_Component { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SimpleUserInfo SimpleUserInfo { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IConfiguration _config { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage BrowserStorage { get; set; }
    }
}
#pragma warning restore 1591
