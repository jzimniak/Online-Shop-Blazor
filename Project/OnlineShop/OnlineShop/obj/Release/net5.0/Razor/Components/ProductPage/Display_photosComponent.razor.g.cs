#pragma checksum "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "748ef35350bc850352c75580f5b8a48edd6f79e9"
// <auto-generated/>
#pragma warning disable 1591
namespace OnlineShop.Components.ProductPage
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
    public partial class Display_photosComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "w-100 container");
            __builder.AddAttribute(2, "style", "height:550px;");
            __builder.AddAttribute(3, "b-5tcxu62niq");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "row h-85 justify-content-center m-0");
            __builder.AddAttribute(6, "b-5tcxu62niq");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "shadow_button_photos_letf h-100");
            __builder.AddAttribute(9, "b-5tcxu62niq");
            __builder.OpenElement(10, "button");
            __builder.AddAttribute(11, "type", "button");
            __builder.AddAttribute(12, "class", "icon-change-left d-flex justify-content-center align-items-center w-50 h-50 position-relative cursor-pointer bg-transparent outline-none");
            __builder.AddAttribute(13, "style", "border-radius: 25px; top: 50%; transform: translateY(-50%);border:none");
            __builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                                                                                                                                                                                                                                                            ()=>Odd_Index()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "b-5tcxu62niq");
            __builder.AddMarkupContent(16, "<i class=\"fas fa-chevron-left fa-2x left-i\" b-5tcxu62niq></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n        ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "custom_col-10");
            __builder.AddAttribute(20, "style", "cursor:pointer;");
            __builder.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                                                     (() => zoom = true)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "b-5tcxu62niq");
            __builder.OpenElement(23, "img");
            __builder.AddAttribute(24, "src", 
#nullable restore
#line 10 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                       Paths[Current_Index]

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(25, "class", "max-width-100 h-auto p-0 position-relative");
            __builder.AddAttribute(26, "style", "object-fit: contain;top: 50%; transform: translateY(-50%) translateX(-50%); left: 50%;");
            __builder.AddAttribute(27, "b-5tcxu62niq");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n\r\n        ");
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "shadow_button_photos_right h-100");
            __builder.AddAttribute(31, "b-5tcxu62niq");
            __builder.OpenElement(32, "button");
            __builder.AddAttribute(33, "type", "button");
            __builder.AddAttribute(34, "class", "icon-change-right d-flex justify-content-center align-items-center position-relative cursor-pointer bg-transparent outline-none");
            __builder.AddAttribute(35, "style", "width: 50px; height: 50px; border-radius: 25px;top: 50%; transform: translateY(-50%) translateX(-50%); left: 50%;border: none");
            __builder.AddAttribute(36, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                                                                                                                                                                                                                                                                                                          ()=>Add_Index()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "b-5tcxu62niq");
            __builder.AddMarkupContent(38, "<i class=\"fas fa-chevron-right fa-2x right-i\" b-5tcxu62niq></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n    ");
            __builder.OpenElement(40, "div");
            __builder.AddAttribute(41, "class", "row justify-content-center h-15 w-100 m-0");
            __builder.AddAttribute(42, "b-5tcxu62niq");
#nullable restore
#line 20 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
         foreach (var item in Paths.Select((value, i) => new { i, value }))
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                           ()=>Change_Image(item.i)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(45, "class", 
#nullable restore
#line 22 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                                              (Current_Index==item.i)? "col h-100 photo_border_selected" : "col h-100 photo_border_not_selected"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(46, "b-5tcxu62niq");
            __builder.OpenElement(47, "img");
            __builder.AddAttribute(48, "src", 
#nullable restore
#line 23 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                           item.value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(49, "class", "photo-mini");
            __builder.AddAttribute(50, "b-5tcxu62niq");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 25 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 28 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
 if (zoom)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(51, "div");
            __builder.AddAttribute(52, "class", "position-fixed");
            __builder.AddAttribute(53, "style", "width: 100vw; height: 100vh; background-color: rgb(0, 0, 0, 0.56); z-index: 100; top: 0; left: 0;");
            __builder.AddAttribute(54, "b-5tcxu62niq");
            __builder.OpenElement(55, "div");
            __builder.AddAttribute(56, "class", "mr-auto ml-auto position-relative border-radius50 bg-white");
            __builder.AddAttribute(57, "style", "width: 85vw; height: 85vh;top: 50%; margin-top: -42.5vh; box-shadow: 0 0 20px 0px black; ");
            __builder.AddAttribute(58, "b-5tcxu62niq");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "container-fluid pl-0 pr-0 h-100");
            __builder.AddAttribute(61, "b-5tcxu62niq");
            __builder.OpenElement(62, "div");
            __builder.AddAttribute(63, "class", "row ml-0 mr-0 justify-content-end");
            __builder.AddAttribute(64, "style", "height:50px;");
            __builder.AddAttribute(65, "b-5tcxu62niq");
            __builder.OpenElement(66, "div");
            __builder.AddAttribute(67, "style", "width:10%;height:50px;");
            __builder.AddAttribute(68, "b-5tcxu62niq");
            __builder.OpenElement(69, "button");
            __builder.AddAttribute(70, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                      (() => zoom = false)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(71, "class", "w-100 h-100 icon-change-left outline-none bg-transparent");
            __builder.AddAttribute(72, "style", "border-radius: 0 50px 0 0;border:none;");
            __builder.AddAttribute(73, "b-5tcxu62niq");
            __builder.AddMarkupContent(74, "<i class=\"fas fa-times left-i\" b-5tcxu62niq></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n            ");
            __builder.OpenElement(76, "div");
            __builder.AddAttribute(77, "class", "row ml-0 mr-0 justify-content-center");
            __builder.AddAttribute(78, "style", "height: calc((100% - 100px))");
            __builder.AddAttribute(79, "b-5tcxu62niq");
            __builder.OpenElement(80, "div");
            __builder.AddAttribute(81, "style", "width: 2.5vw;");
            __builder.AddAttribute(82, "class", "icon-change-left d-flex justify-content-center align-items-center m-auto h-50 cursor-pointer");
            __builder.AddAttribute(83, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                                                                                                                                          ()=>Odd_Index()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(84, "b-5tcxu62niq");
            __builder.AddMarkupContent(85, "<i class=\"fas fa-chevron-left left-i\" b-5tcxu62niq></i>");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                ");
            __builder.OpenElement(87, "div");
            __builder.AddAttribute(88, "style", "width:80vw;");
            __builder.AddAttribute(89, "b-5tcxu62niq");
            __builder.OpenElement(90, "img");
            __builder.AddAttribute(91, "src", 
#nullable restore
#line 45 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                               Paths[Current_Index]

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(92, "style", "height:75vh;");
            __builder.AddAttribute(93, "class", "opacity d-block m-auto");
            __builder.AddAttribute(94, "b-5tcxu62niq");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "             \r\n                ");
            __builder.OpenElement(96, "div");
            __builder.AddAttribute(97, "style", "width: 2.5vw;");
            __builder.AddAttribute(98, "class", "icon-change-right d-flex justify-content-center align-items-center m-auto h-50 cursor-pointer");
            __builder.AddAttribute(99, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 47 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                                                                                                                                           ()=>Add_Index()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(100, "b-5tcxu62niq");
            __builder.AddMarkupContent(101, "<i class=\"fas fa-chevron-right right-i\" b-5tcxu62niq></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n            ");
            __builder.OpenElement(103, "div");
            __builder.AddAttribute(104, "class", "row ml-0 mr-0 w-100 justify-content-center pb-1");
            __builder.AddAttribute(105, "style", "height: 50px;");
            __builder.AddAttribute(106, "b-5tcxu62niq");
#nullable restore
#line 52 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                 foreach (var item in Paths.Select((value, i) => new { i, value }))
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(107, "div");
            __builder.AddAttribute(108, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 54 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                   ()=>Change_Image(item.i)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(109, "class", (
#nullable restore
#line 54 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                                                      (Current_Index==item.i)? "col photo_border_selected-2" : "col photo_border_not_selected-2"

#line default
#line hidden
#nullable disable
            ) + " h-100");
            __builder.AddAttribute(110, "b-5tcxu62niq");
            __builder.OpenElement(111, "img");
            __builder.AddAttribute(112, "src", 
#nullable restore
#line 55 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                                   item.value

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(113, "class", "photo-mini-2");
            __builder.AddAttribute(114, "style", "left:0;right:0;");
            __builder.AddAttribute(115, "b-5tcxu62niq");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 57 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 62 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 64 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\ProductPage\Display_photosComponent.razor"
       

    [Parameter]
    public string[] Paths { get; set; }

    private int Current_Index { get; set; }
    private bool zoom { get; set; }

    protected override void OnInitialized()
    {
        zoom = false;
        Current_Index = 0;
    }

    private void Change_Image(int index)
    {
        Current_Index = index;
    }
    private void Add_Index()
    {
        if (Current_Index == Paths.Length - 1)
        {
            Current_Index = 0;
        }
        else
        {
            Current_Index++;
        }
    }
    private void Odd_Index()
    {
        if (Current_Index == 0)
        {
            Current_Index = Paths.Length - 1;
        }
        else
        {
            Current_Index--;
        }
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
