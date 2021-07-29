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
#nullable restore
#line 1 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\Components\LoginSystem\LoginComponent.razor"
using OnlineShop.Models.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\Components\LoginSystem\LoginComponent.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\Components\LoginSystem\LoginComponent.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
    public partial class LoginComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 37 "C:\Users\jarek\Desktop\BlazorProject (Shop)\Project\OnlineShop\OnlineShop\Components\LoginSystem\LoginComponent.razor"
       

    private Login LoginModel { get; set; }
    private string info { get; set; }
    private bool loading { get; set; }

    protected override void OnInitialized()
    {
        info = "";
        LoginModel = new();
    }
    private string GetRightUrl(string fullurl)
    {
        string r = "";
        if (fullurl.Contains("/c/"))
        {

            string x = fullurl.Split("/c/").Last();

            int z = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (i == 0)
                {
                    if (x[i] == '/')
                    {
                        z++;
                    }
                    r += x[i];
                }
                else
                {
                    if (x[i] != '/')
                    {
                        z = 0;
                        r += x[i];
                    }
                    else
                    {
                        if (z == 0)
                        {
                            z++;
                            r += x[i];
                        }
                        else
                        {
                        }
                    }
                }
            }

            if (r[r.Length - 1] == '/')
            {
                r.Remove(r.Length - 1);
            }
            if (r[0] == '/')
            {
                r.Remove(0, 1);
            }
        }

        return r;
    }
    private async void Login()
    {
        //to login with admin permission use admin and password
        if (LoginModel.UserName == "admin" && LoginModel.Password == "password")
        {
            SimpleUserInfo.ID = -1;
            SimpleUserInfo.IsLogged = true;
            SimpleUserInfo.Email = "";
            SimpleUserInfo.UserAddress = "";
            SimpleUserInfo.UserName = "admin";
            SimpleUserInfo.UserRole = "Admin";
            info = "";
            Refresh_Component.topMenuComponent.Refresh();
            await BrowserStorage.SetAsync("login", "True");
            await BrowserStorage.SetAsync("role", "Admin");
            await BrowserStorage.SetAsync("UserName", "Admin");
            StateHasChanged();
            StateHasChanged();
            string x =GetRightUrl(NavigationManager.Uri);

            if (NavigationManager.Uri.Contains("admin-panel"))
            {
                Refresh_Component.adminPanelPage.Refresh();
            }
            if (x.Count(f=>f=='/')==1)
            {
                Refresh_Component.opinionsComponent.Refresh();
            }
            loading = false;
            Refresh_Component.topMenuComponent.closewindow();
            Refresh_Component.topMenuComponent.Refresh();
        }
        else
        {
            if (await Additional_Functions.UserExist(LoginModel.UserName, _config))
            {
                UserSQL userSQL = await Additional_Functions.Get_User_From_SQL(LoginModel.UserName, _config);
                if (DataAccess.PasswordHashing.IsPasswordCorrect(userSQL.Salt, LoginModel.Password, userSQL.Passhash))
                {
                    SimpleUserInfo.ID = userSQL.ID;
                    SimpleUserInfo.IsLogged = true;
                    SimpleUserInfo.Email = userSQL.Email;
                    SimpleUserInfo.UserAddress = userSQL.UserAddres;
                    SimpleUserInfo.UserName = userSQL.UserName;
                    SimpleUserInfo.UserRole = userSQL.UserRole;
                    info = "";
                    Refresh_Component.topMenuComponent.Refresh();
                    loading = false;
                    await BrowserStorage.SetAsync("login", "True");
                    await BrowserStorage.SetAsync("role", SimpleUserInfo.UserRole);
                    await BrowserStorage.SetAsync("Email", SimpleUserInfo.Email);
                    await BrowserStorage.SetAsync("UserAddress", SimpleUserInfo.UserAddress);
                    await BrowserStorage.SetAsync("UserName", SimpleUserInfo.UserName);

                    StateHasChanged();
                    string x = GetRightUrl(NavigationManager.Uri);

                    if (NavigationManager.Uri.Contains("admin-panel"))
                    {
                        Refresh_Component.adminPanelPage.Refresh();
                    }
                    if (x.Count(f => f == '/') == 1)
                    {
                        Refresh_Component.opinionsComponent.Refresh();
                    }
                    Refresh_Component.topMenuComponent.closewindow();
                }
                else
                {
                    info = "Złe hasło";
                    loading = false;
                    StateHasChanged();
                }
            }
            else
            {
                info = "Nie ma takiego użytkownika";
                loading = false;
                StateHasChanged();
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IConfiguration _config { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Services.Refresh_Component Refresh_Component { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SimpleUserInfo SimpleUserInfo { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage BrowserStorage { get; set; }
    }
}
#pragma warning restore 1591