#pragma checksum "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12285cd60b48baea9baffb5079305d0990dbd19d"
// <auto-generated/>
#pragma warning disable 1591
namespace OnlineShop.Components.ProductList
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
    public partial class CheckboxListComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 1 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
 if (json_Distinct2 is not null)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "style", "margin-left:5px;");
            __builder.AddAttribute(2, "class", "w-100");
#nullable restore
#line 4 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
     for (int i = 0; i < json_Distinct2.Count; i++)
    {
        bool Checked = false;
        var z = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "form-check");
#nullable restore
#line 9 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
             if (attribute_check is not null && attribute_check.Count != 0)
            {
                Checked = (attribute_check[0] == json_Distinct2[i]) ? true : false;
            }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "input");
            __builder.AddAttribute(6, "class", "form-check-input");
            __builder.AddAttribute(7, "type", "checkbox");
            __builder.AddAttribute(8, "checked", 
#nullable restore
#line 13 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
                                                                      Checked

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(9, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
                                                                                            ()=> {  changecheckbox(z); }

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n            ");
            __builder.OpenElement(11, "label");
            __builder.AddAttribute(12, "class", "form-check-label");
            __builder.AddContent(13, 
#nullable restore
#line 14 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
                                             json_Distinct2[i]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 16 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 18 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductList\CheckboxListComponent.razor"
          

    [Parameter]
    public List<string> json_Distinct2 { get; set; }
    [Parameter]
    public List<string> attribute_check { get; set; }
    [Parameter]
    public EventCallback<List<string>> listChanged { get; set; }
    [Parameter]
    public List<string> list { get; set; }


    public List<string> list2 { get; set; }

    public bool[] b { get; set; }

    protected override void OnInitialized()
    {
        list2 = new List<string>();
        b = new bool[json_Distinct2.Count];

    }

    private async Task changecheckbox(int index)
    {
        b[index] = !b[index];
        if (b[index])
        {
            list2.Add(json_Distinct2[index]);
        }
        else
        {
            list2.Remove(json_Distinct2[index]);
        }
        list = list2;

        await listChanged.InvokeAsync(list);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591