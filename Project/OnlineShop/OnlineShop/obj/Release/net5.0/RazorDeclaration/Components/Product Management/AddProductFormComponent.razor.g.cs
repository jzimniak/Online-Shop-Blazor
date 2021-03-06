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
#line 1 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AddProductFormComponent.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AddProductFormComponent.razor"
using DataAccess;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AddProductFormComponent.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AddProductFormComponent.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AddProductFormComponent.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    public partial class AddProductFormComponent : ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 2041 "C:\Users\jarek\source\repos\OnlineShop\OnlineShop\Components\Product Management\AddProductFormComponent.razor"
       
    [Parameter]
    public string Name { get; set; }
    [Parameter]
    public bool edit { get; set; }
    [Parameter]
    public int editindex { get; set; }
    [CascadingParameter] EditProductsFormComponent editProducts { get; set; }
    [CascadingParameter] ProductManagementComponent productManagement { get; set; }

    private Product<Processor> processor = new Product<Processor>();
    private Product<ComputerCase> computercase = new Product<ComputerCase>();
    private Product<Disc> disc = new Product<Disc>();
    private Product<Motherboard> motherboard = new Product<Motherboard>();
    private Product<GraphicCard> graphiccard = new Product<GraphicCard>();
    private Product<PowerSupply> Powersupply = new Product<PowerSupply>();
    private Product<Radiator> Radiator = new Product<Radiator>();
    private Product<Ram> ram = new Product<Ram>();

    private ShortDesc description { get; set; }
    private int amount_of_desc { get; set; }
    private string PhotoSTR { get; set; }
    private List<IBrowserFile> loadedFiles = new();

    protected async override void OnInitialized()
    {
        amount_of_desc = 10;
        description = new ShortDesc();
        description.Text = new string[amount_of_desc];
        description.Title = new string[amount_of_desc];
        description.photos = new IBrowserFile[amount_of_desc];
        using (StreamReader r = new StreamReader(env.WebRootPath+$"\\json\\distinct.json"))
        {
            string json = r.ReadToEnd();
            json_Distinct = JsonConvert.DeserializeObject<OnlineShop.Services.Json_distinct>(json);
        }

        _data = new SqlDataAccess(_config);
        processor.Attributes = new Processor();
        computercase.Attributes = new ComputerCase();
        disc.Attributes = new Disc();
        motherboard.Attributes = new Motherboard();
        graphiccard.Attributes = new GraphicCard();
        Powersupply.Attributes = new PowerSupply();
        Radiator.Attributes = new Radiator();
        ram.Attributes = new Ram();

        if (edit)
        {
            switch (Name)
            {
                case "processors":
                    List<Product<Processor>> processors = await Additional_Functions.Read_Processors_From_JSON(env);
                    processor = processors.Find(x => x.Id == editindex);
                    StateHasChanged();
                    break;

                case "discs":
                    List<Product<Disc>> discs = await Additional_Functions.Read_Discs_From_JSON(env);
                    disc = discs.Find(x => x.Id == editindex);
                    StateHasChanged();
                    break;

                case "computercases":
                    List<Product<ComputerCase>> computercases = await Additional_Functions.Read_Computercases_From_JSON(env);
                    computercase = computercases.Find(x => x.Id == editindex);
                    StateHasChanged();
                    break;

                case "graphiccards":
                    List<Product<GraphicCard>> graphiccards = await Additional_Functions.Read_GraphicCards_From_JSON(env);
                    graphiccard = graphiccards.Find(x => x.Id == editindex);
                    StateHasChanged();
                    break;

                case "motherboards":
                    List<Product<Motherboard>> motherboards = await Additional_Functions.Read_Motherboards_From_JSON(env);
                    motherboard = motherboards.Find(x => x.Id == editindex);
                    StateHasChanged();
                    break;

                case "Powersupply":
                    List<Product<PowerSupply>> powerSupplies = await Additional_Functions.Read_PowerSupplies_From_JSON(env);
                    Powersupply = powerSupplies.Find(x => x.Id == editindex);
                    StateHasChanged();
                    break;

                case "Radiators":
                    List<Product<Radiator>> radiators = await Additional_Functions.Read_Radiators_From_JSON(env);
                    Radiator = radiators.Find(x => x.Id == editindex);
                    StateHasChanged();
                    break;

                case "rams":
                    List<Product<Ram>> rams = await Additional_Functions.Read_Rams_From_JSON(env);
                    ram = rams.Find(x => x.Id == editindex);
                    break;

                default:
                    break;
            }
        }

        PhotoSTR = "";
    }

    private async Task AddProcessor()
    {
        processor = Additional_Functions.Return_checked_product(processor);

        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = processor.Name, @Price = processor.Price, @Brand = processor.Brand, @Warranty = processor.Warranty, @Id = processor.Id });
            string sql2 = "UPDATE Processors SET [photoSTR] = @PhotoSTR ,[family] = @Family ,[processor_number] = @Processor_number ,[socket] = @Socket ,[arch] = @Arch ,[frequency] = @Frequency ,[cores] = @Cores ,[threads] = @Threads ,[unlocked] = @Unlocked ,[cache] = @Cache ,[intergrated_graphic] = @Intergrated_graphic ,[processor_graphic] = @Processor_graphic ,[memory_types] = @Memory_types ,[lithography] = @Lithography ,[tdp] = @Tdp ,[technologiesSTR] = @TechnologiesSTR ,[cooling_in_box] = @Cooling_in_box ,[code] = @Code WHERE productID=@Id ";
            await _data.Update(sql2, new { @PhotoSTR = processor.Attributes.PhotoSTR, @Family = processor.Attributes.Family, @Processor_number = processor.Attributes.Processor_number, @Socket = processor.Attributes.Socket, @Arch = processor.Attributes.Arch, @Frequency = processor.Attributes.Frequency, @Cores = processor.Attributes.Cores, @Threads = processor.Attributes.Threads, @Unlocked = processor.Attributes.Unlocked, @Cache = processor.Attributes.Cache, @Intergrated_graphic = processor.Attributes.Intergrated_graphic, @Processor_graphic = processor.Attributes.Processor_graphic, @Memory_types = processor.Attributes.Memory_types, @Lithography = processor.Attributes.Lithography, @Tdp = processor.Attributes.TDP, @TechnologiesSTR = processor.Attributes.TechnologiesSTR, @Cooling_in_box = processor.Attributes.Cooling_in_box, @Code = processor.Attributes.Code, @Id = editindex });
            Additional_Functions.Add_Product_To_JSON(processor, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, processor.Id, env, _config);
            editProducts.processor = await SearchEngine.Processors_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(processor, _data, loadedFiles);

            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(r.Item1, false, env);
            await Load_photos_on_sever(r.Item1.Id);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);

            processor = new Product<Processor>();
            processor.Attributes = new Processor();
        }

        await json_Distinct.Laoddistinct(_config,env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private async Task AddComputerCase()
    {
        computercase = Additional_Functions.Return_checked_product(computercase);

        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = computercase.Name, @Price = computercase.Price, @Brand = computercase.Brand, @Warranty = computercase.Warranty, @Id = computercase.Id });
            string sql2 = "UPDATE ComputerCases SET [photoSTR] = @PhotoSTR ,[caseType] = @caseType ,[motherboards_typeSTR] = @Motherboards_typeSTR ,[extension_cards] = @Extension_cards ,[max_graphic_card_length] = @Max_graphic_card_length ,[materialsSTR] = @MaterialsSTR ,[additional_informationSTR] = @Additional_informationSTR ,[side_panel] = @Side_panel ,[backlight] = @Backlight ,[power_supply_type] = @Power_supply_type ,[space_for_discsSTR] = @Space_for_discsSTR ,[max_height_of_cooling] = @Max_height_of_cooling ,[max_fans] = @Max_fans ,[fans_typesSTR] = @Fans_typesSTR ,[water_cooling_optionsSTR] = @Water_cooling_optionsSTR ,[fans_installed] = @Fans_installed ,[fans_types_installedSTR] = @Fans_types_installedSTR ,[buttonsSTR] = @ButtonsSTR ,[front_panel_outputsSTR] = @Front_panel_outputsSTR ,[color] = @Color ,[accessoriesSTR] = @AccessoriesSTR ,[width] = @Width ,[heigth] = @Heigth ,[length_] = @Length_ ,[weigth] = @Weigth WHERE productID=@Id ";
            await _data.Update(sql2, new { @PhotoSTR = computercase.Attributes.PhotoSTR, @caseType = computercase.Attributes.Type, @Motherboards_typeSTR = computercase.Attributes.Motherboards_typeSTR, @Extension_cards = computercase.Attributes.Extension_cards, @Max_graphic_card_length = computercase.Attributes.Max_graphic_card_length, @MaterialsSTR = computercase.Attributes.MaterialsSTR, @Additional_informationSTR = computercase.Attributes.Additional_informationSTR, @Side_panel = computercase.Attributes.Side_panel, @Backlight = computercase.Attributes.Backlight, @Power_supply_type = computercase.Attributes.Power_supply_type, @Space_for_discsSTR = computercase.Attributes.Space_for_discsSTR, @Max_height_of_cooling = computercase.Attributes.Max_height_of_cooling, @Max_fans = computercase.Attributes.Max_fans, @Fans_typesSTR = computercase.Attributes.Fans_typesSTR, @Water_cooling_optionsSTR = computercase.Attributes.Water_cooling_optionsSTR, @Fans_installed = computercase.Attributes.Fans_installed, @Fans_types_installedSTR = computercase.Attributes.Fans_types_installedSTR, @ButtonsSTR = computercase.Attributes.ButtonsSTR, @Front_panel_outputsSTR = computercase.Attributes.Front_panel_outputsSTR, @Color = computercase.Attributes.Color, @AccessoriesSTR = computercase.Attributes.AccessoriesSTR, @Width = computercase.Attributes.Width, @Heigth = computercase.Attributes.Heigth, @Length_ = computercase.Attributes.Length, @Weigth = computercase.Attributes.Weigth, @Id = editindex });
            Additional_Functions.Add_Product_To_JSON(computercase, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, computercase.Id, env, _config);
            editProducts.computercase = await SearchEngine.ComputerCases_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(computercase, _data, loadedFiles);
            computercase = r.Item1;
            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(computercase, false, env);
            await Load_photos_on_sever(computercase.Id);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);

            computercase = new Product<ComputerCase>();
            computercase.Attributes = new ComputerCase();
        }

        await json_Distinct.Laoddistinct(_config, env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private async Task AddDisc()
    {
        disc = Additional_Functions.Return_checked_product(disc);

        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = disc.Name, @Price = disc.Price, @Brand = disc.Brand, @Warranty = disc.Warranty, @Id = disc.Id });
            string sql2 = "UPDATE Discs SET [photoSTR] = @PhotoSTR ,[destiny] = @Destiny ,[discType] = @discType ,[capacity] = @Capacity ,[discFormat] = @discFormat ,[interfaces] = @Interfaces ,[read_speed] = @Read_speed ,[write_speed] = @Write_speed ,[random_read_speed] = @Random_read_speed ,[random_write_speed] = @Random_write_speed ,[memory_type] = @Memory_type ,[reliability] = @Reliability ,[radiator] = @Radiator ,[additional_informationSTR] = @Additional_informationSTR ,[accessoriesSTR] = @AccessoriesSTR ,[color] = @Color ,[width] = @Width ,[heigth] = @Heigth ,[length_] = @Length_ ,[code] = @Code WHERE productID=@Id ";
            await _data.Update(sql2, new { @PhotoSTR = disc.Attributes.PhotoSTR, @Destiny = disc.Attributes.Destiny, @discType = disc.Attributes.Type, @Capacity = disc.Attributes.Capacity, @discFormat = disc.Attributes.Format, @Interfaces = disc.Attributes.Interfaces, @Read_speed = disc.Attributes.Read_speed, @Write_speed = disc.Attributes.Write_speed, @Random_read_speed = disc.Attributes.Random_read_speed, @Random_write_speed = disc.Attributes.Random_write_speed, @Memory_type = disc.Attributes.Memory_type, @Reliability = disc.Attributes.Reliability, @Radiator = disc.Attributes.Radiator, @Additional_informationSTR = disc.Attributes.Additional_informationSTR, @AccessoriesSTR = disc.Attributes.AccessoriesSTR, @Color = disc.Attributes.Color, @Width = disc.Attributes.Width, @Heigth = disc.Attributes.Heigth, @Length_ = disc.Attributes.Length, @Code = disc.Attributes.Code, @Id = editindex });
            Additional_Functions.Add_Product_To_JSON(disc, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, disc.Id, env, _config);
            editProducts.disc = await SearchEngine.Discs_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(disc, _data, loadedFiles);
            disc = r.Item1;

            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(disc, false, env);
            await Load_photos_on_sever(disc.Id);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);
            disc = new Product<Disc>();
            disc.Attributes = new Disc();
        }

        await json_Distinct.Laoddistinct(_config, env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private async Task AddGraphicCard()
    {
        graphiccard = Additional_Functions.Return_checked_product(graphiccard);

        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = graphiccard.Name, @Price = graphiccard.Price, @Brand = graphiccard.Brand, @Warranty = graphiccard.Warranty, @Id = graphiccard.Id });
            string sql2 = "UPDATE GraphicCards SET [photoSTR] = @PhotoSTR ,[rtx] = @Rtx ,[core_clock] = @Core_clock ,[graphics_processing] = @Graphics_processing ,[card_bus] = @Card_bus ,[memory_size] = @Memory_size ,[memory_type] = @Memory_type ,[memory_bus] = @Memory_bus ,[cuda_cores] = @Cuda_cores ,[cooling] = @Cooling ,[outputsSTR] = @OutputsSTR ,[graphic_apiSTR] = @Graphic_apiSTR ,[power_connectors] = @Power_connectors ,[recommended_psu] = @Recommended_psu ,[tdp] = @Tdp ,[length_] = @Length_ ,[width] = @Width ,[heigth] = @Heigth ,[accessoriesSTR] = @AccessoriesSTR ,[code] = @Code, [producent]=@Producent WHERE productID=@Id ";
            await _data.Update(sql2, new { @PhotoSTR = graphiccard.Attributes.PhotoSTR, @Rtx = graphiccard.Attributes.Rtx, @Core_clock = graphiccard.Attributes.Core_clock, @Graphics_processing = graphiccard.Attributes.Graphics_processing, @Card_bus = graphiccard.Attributes.Card_bus, @Memory_size = graphiccard.Attributes.Memory_size, @Memory_type = graphiccard.Attributes.Memory_type, @Memory_bus = graphiccard.Attributes.Memory_bus, @Cuda_cores = graphiccard.Attributes.Cuda_cores, @Cooling = graphiccard.Attributes.Cooling, @OutputsSTR = graphiccard.Attributes.OutputsSTR, @Graphic_apiSTR = graphiccard.Attributes.Graphic_apiSTR, @Power_connectors = graphiccard.Attributes.Power_connectors, @Recommended_psu = graphiccard.Attributes.Recommended_psu, @Tdp = graphiccard.Attributes.Tdp, @Length_ = graphiccard.Attributes.Length, @Width = graphiccard.Attributes.Width, @Heigth = graphiccard.Attributes.Heigth, @AccessoriesSTR = graphiccard.Attributes.AccessoriesSTR, @Code = graphiccard.Attributes.Code, @Id = editindex, @Producent = graphiccard.Attributes.Producent });
            Additional_Functions.Add_Product_To_JSON(graphiccard, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, graphiccard.Id, env, _config);
            editProducts.graphiccard = await SearchEngine.GraphicCards_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(graphiccard, _data, loadedFiles);
            graphiccard = r.Item1;

            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(graphiccard, false, env);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);

            await Load_photos_on_sever(graphiccard.Id);
            graphiccard = new Product<GraphicCard>();
            graphiccard.Attributes = new GraphicCard();
        }

        await json_Distinct.Laoddistinct(_config, env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private async Task AddMotherboard()
    {
        motherboard = Additional_Functions.Return_checked_product(motherboard);

        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = motherboard.Name, @Price = motherboard.Price, @Brand = motherboard.Brand, @Warranty = motherboard.Warranty, @Id = motherboard.Id });
            string sql2 = "UPDATE Motherboards SET [photoSTR] = @PhotoSTR ,[socket] = @Socket ,[chipset] = @Chipset ,[arch_processSTR] = @Arch_processSTR ,[memory_typesSTR] = @Memory_typesSTR ,[memory_types_ocSTR] = @Memory_types_ocSTR ,[memory_slots] = @Memory_slots ,[memory_max_size] = @Memory_max_size ,[memory_channel] = @Memory_channel ,[internal_connectionSTR] = @Internal_connectionSTR ,[back_panel_portsSTR] = @Back_panel_portsSTR ,[raidSTR] = @RaidSTR ,[multi_cards] = @Multi_cards ,[can_handle_processor_card] = @Can_handle_processor_card ,[audio] = @Audio ,[wireless_connection] = @Wireless_connection ,[boardformat] = @boardFormat ,[width] = @Width ,[length_] = @Length_ ,[code] = @Code WHERE productID=@Id ";
            await _data.Update(sql2, new { @PhotoSTR = motherboard.Attributes.PhotoSTR, @Socket = motherboard.Attributes.Socket, @Chipset = motherboard.Attributes.Chipset, @Arch_processSTR = motherboard.Attributes.Arch_processSTR, @Memory_typesSTR = motherboard.Attributes.Memory_typesSTR, @Memory_types_ocSTR = motherboard.Attributes.Memory_types_ocSTR, @Memory_slots = motherboard.Attributes.Memory_slots, @Memory_max_size = motherboard.Attributes.Memory_max_size, @Memory_channel = motherboard.Attributes.Memory_channel, @Internal_connectionSTR = motherboard.Attributes.Internal_connectionSTR, @Back_panel_portsSTR = motherboard.Attributes.Back_panel_portsSTR, @RaidSTR = motherboard.Attributes.RaidSTR, @Multi_cards = motherboard.Attributes.Multi_cards, @Can_handle_processor_card = motherboard.Attributes.Can_handle_processor_card, @Audio = motherboard.Attributes.Audio, @Wireless_connection = motherboard.Attributes.Wireless_connection, @boardFormat = motherboard.Attributes.Format, @Width = motherboard.Attributes.Width, @Length_ = motherboard.Attributes.Length, @Code = motherboard.Attributes.Code, @Id = editindex });
            Additional_Functions.Add_Product_To_JSON(motherboard, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, motherboard.Id, env, _config);

            editProducts.motherboard = await SearchEngine.Motherboards_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(motherboard, _data, loadedFiles);
            motherboard = r.Item1;

            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(motherboard, false, env);
            await Load_photos_on_sever(motherboard.Id);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);

            motherboard = new Product<Motherboard>();
            motherboard.Attributes = new Motherboard();
        }

        await json_Distinct.Laoddistinct(_config, env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private async Task AddPowerSupply()
    {
        Powersupply = Additional_Functions.Return_checked_product(Powersupply);

        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = Powersupply.Name, @Price = Powersupply.Price, @Brand = Powersupply.Brand, @Warranty = Powersupply.Warranty, @Id = Powersupply.Id });
            string sql2 = "UPDATE PowerSupply SET [photoSTR] = @PhotoSTR ,[power_] = @Power_ ,[standard_] = @Standard_ ,[efficiency] = @Efficiency ,[certificate_] = @Certificate_ ,[cables_types] = @Cables_types ,[fan] = @Fan ,[pfc] = @Pfc ,[connectorsSTR] = @ConnectorsSTR ,[securitySTR] = @SecuritySTR ,[additional_informationSTR] = @Additional_informationSTR ,[length_] = @Length_ ,[width] = @Width ,[heigth] = @Heigth ,[color] = @Color WHERE productID=@Id ";
            await _data.Update(sql2, new { @PhotoSTR = Powersupply.Attributes.PhotoSTR, @Power_ = Powersupply.Attributes.Power, @Standard_ = Powersupply.Attributes.Standard, @Efficiency = Powersupply.Attributes.Efficiency, @Certificate_ = Powersupply.Attributes.Certificate, @Cables_types = Powersupply.Attributes.Cables_types, @Fan = Powersupply.Attributes.Fan, @Pfc = Powersupply.Attributes.Pfc, @ConnectorsSTR = Powersupply.Attributes.ConnectorsSTR, @SecuritySTR = Powersupply.Attributes.SecuritySTR, @Additional_informationSTR = Powersupply.Attributes.Additional_informationSTR, @Length_ = Powersupply.Attributes.Length, @Width = Powersupply.Attributes.Width, @Heigth = Powersupply.Attributes.Heigth, @Color = Powersupply.Attributes.Color, @Id = editindex });
            Additional_Functions.Add_Product_To_JSON(Powersupply, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, Powersupply.Id, env, _config);

            editProducts.powersupply = await SearchEngine.PowerSupplies_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(Powersupply, _data, loadedFiles);
            Powersupply = r.Item1;

            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(Powersupply, false, env);
            await Load_photos_on_sever(Powersupply.Id);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);

            Powersupply = new Product<PowerSupply>();
            Powersupply.Attributes = new PowerSupply();
        }

        await json_Distinct.Laoddistinct(_config, env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private async Task AddRadiator()
    {
        Radiator = Additional_Functions.Return_checked_product(Radiator);

        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = Radiator.Name, @Price = Radiator.Price, @Brand = Radiator.Brand, @Warranty = Radiator.Warranty, @Id = Radiator.Id });
            string sql2 = "UPDATE Radiators SET [photoSTR] = @PhotoSTR ,[cooling_type] = @Cooling_type ,[socketsSTR] = @SocketsSTR ,[fansSTR] = @FansSTR ,[materials] = @Materials ,[rps] = @Rps ,[bearing] = @Bearing ,[max_dB] = @Max_dB ,[connectors] = @Connectors ,[backlight] = @Backlight ,[service_life] = @Service_life ,[tdp] = @dp ,[additional_informationSTR] = @Additional_informationSTR ,[heigth] = @Heigth ,[width] = @Width ,[length_] = @Length_ ,[weight_] = @Weight_ ,[accessoriesSTR] = @AccessoriesSTR ,[code] = @Code WHERE productID=@Id  ";
            await _data.Update(sql2, new { @PhotoSTR = Radiator.Attributes.PhotoSTR, @Cooling_type = Radiator.Attributes.Cooling_type, @SocketsSTR = Radiator.Attributes.SocketsSTR, @FansSTR = Radiator.Attributes.FansSTR, @Materials = Radiator.Attributes.Materials, @Rps = Radiator.Attributes.Rps, @Bearing = Radiator.Attributes.Bearing, @Max_dB = Radiator.Attributes.Max_dB, @Connectors = Radiator.Attributes.Connectors, @Backlight = Radiator.Attributes.Backlight, @Service_life = Radiator.Attributes.Service_life, @Tdp = Radiator.Attributes.Tdp, @Additional_informationSTR = Radiator.Attributes.Additional_informationSTR, @Heigth = Radiator.Attributes.Heigth, @Width = Radiator.Attributes.Width, @Length_ = Radiator.Attributes.Length, @Weight_ = Radiator.Attributes.Weight, @AccessoriesSTR = Radiator.Attributes.AccessoriesSTR, @Code = Radiator.Attributes.Code, @Id = editindex });
            Additional_Functions.Add_Product_To_JSON(Radiator, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, Radiator.Id, env, _config);

            editProducts.radiator = await SearchEngine.Radiators_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(Radiator, _data, loadedFiles);
            Radiator = r.Item1;

            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(Radiator, false, env);

            await Load_photos_on_sever(Radiator.Id);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);

            Radiator = new Product<Radiator>();
            Radiator.Attributes = new Radiator();
        }

        await json_Distinct.Laoddistinct(_config, env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private async Task AddRam()
    {
        ram = Additional_Functions.Return_checked_product(ram);
        if (edit)
        {
            string sql = "update products set prName = @prName, price = @Price,brand = @Brand,warranty = @Warranty where Id=@Id";
            await _data.Update(sql, new { @prName = ram.Name, @Price = ram.Price, @Brand = ram.Brand, @Warranty = ram.Warranty, @Id = ram.Id });
            string sql2 = "UPDATE Rams SET [photoSTR] = @PhotoSTR ,[series] = @Series ,[memory_type] = @Memory_type ,[memory_size_full] = @Memory_size_full ,[memory_size_single] = @Memory_size_single ,[items] = @Items ,[frequency] = @Frequency ,[cycle_latency] = @Cycle_latency ,[timings] = @Timings ,[tension] = @Tension ,[cooling] = @Cooling ,[memory_ecc] = @Memory_ecc ,[memory_backlight] = @Memory_backlight ,[additional_information] = @Additional_information ,[color] = @Color WHERE productID=@Id  ";
            await _data.Update(sql2, new { @PhotoSTR = ram.Attributes.PhotoSTR, @Series = ram.Attributes.Series, @Memory_type = ram.Attributes.Memory_type, @Memory_size_full = ram.Attributes.Memory_size_full, @Memory_size_single = ram.Attributes.Memory_size_single, @Items = ram.Attributes.Items, @Frequency = ram.Attributes.Frequency, @Cycle_latency = ram.Attributes.Cycle_latency, @Timings = ram.Attributes.Timings, @Tension = ram.Attributes.Tension, @Cooling = ram.Attributes.Cooling, @Memory_ecc = ram.Attributes.Memory_ecc, @Memory_backlight = ram.Attributes.Memory_backlight, @Additional_information = ram.Attributes.Additional_information, @Color = ram.Attributes.Color, @Id = editindex });
            Additional_Functions.Add_Product_To_JSON(ram, true, env);
            await Additional_Functions.Edit_Description_To_DB(description, ram.Id, env, _config);
            editProducts.ram = await SearchEngine.Rams_List_from_SQL(_config);
            editProducts.changevalue();
        }
        else
        {
            var r = await Additional_Functions.Add_Product_To_SQL(ram, _data, loadedFiles);
            ram = r.Item1;

            await Additional_Functions.Add_Opinion_To_JSON(r.Item2[0], env);
            Additional_Functions.Add_Product_To_JSON(ram, false, env);

            await Load_photos_on_sever(ram.Id);
            await Additional_Functions.Add_Description_To_DB(description, r.Item1.Id, env, _config);

            ram = new Product<Ram>();
            ram.Attributes = new Ram();
        }

        await json_Distinct.Laoddistinct(_config, env);
        await Additional_Functions.Create_TopMenu_JSON(_config, env);
        StateHasChanged();
    }

    private string[] getPhotos(int idproduct)
    {
        string[] PhotoSTR = new string[loadedFiles.Count];
        int index = 0;
        foreach (var item in loadedFiles)
        {
            var path = $"\\img\\" + idproduct + "_" + index + "." + item.ContentType.Split('/')[item.ContentType.Split('/').Length - 1];
            PhotoSTR[index] = path;
            index++;
        }
        return PhotoSTR;
    }

    private async Task Load_photos_on_sever(int idproduct)
    {
        int index = 0;
        foreach (var item in loadedFiles)
        {
            Stream stream = item.OpenReadStream(3072000);
            var path = $"\\img\\" + idproduct + "_" + index + "." + item.ContentType.Split('/')[item.ContentType.Split('/').Length - 1];
            FileStream fs = File.Create(env.WebRootPath + path);
            await stream.CopyToAsync(fs);
            stream.Close();
            fs.Close();
            index++;
        }
    }

    private void LoadFiles(InputFileChangeEventArgs e)
    {
        loadedFiles.Clear();

        foreach (var file in e.GetMultipleFiles(5))
        {
            try
            {
                loadedFiles.Add(file);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    private string[] convertInputTextAreaToProjectSyntax(string input)
    {
        return input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Json_distinct json_Distinct { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IConfiguration _config { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebHostEnvironment env { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SqlDataAccess _data { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
