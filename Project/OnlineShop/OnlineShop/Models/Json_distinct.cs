using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace OnlineShop.Services
{
    public class Json_distinct
    {
        public JSON_ComputerCase JSONComputerCase { get; set; }
        public JSON_Motherboard JSONMotherboard { get; set; }
        public JSON_GraphicCard JSONGraphicCard { get; set; }
        public JSON_PowerSupply JSONPowerSupply { get; set; }
        public JSON_Processor JSONProcessor { get; set; }
        public JSON_Product JSONProduct { get; set; }
        public JSON_Radiator JSONRadiator { get; set; }
        public JSON_Ram JSONRam { get; set; }
        public JSON_Disc JSONDisc { get; set; }

        //create distinct.json (distinct values from products attributes)
        public async Task Laoddistinct(IConfiguration _config, IWebHostEnvironment env)
        {
            SqlDataAccess _data = new (_config);
            Json_distinct file = new ();
            file.JSONComputerCase = new ();
            file.JSONDisc = new ();
            file.JSONMotherboard = new ();
            file.JSONGraphicCard = new ();
            file.JSONPowerSupply = new ();
            file.JSONProcessor = new ();
            file.JSONProduct = new ();
            file.JSONRadiator = new ();
            file.JSONRam = new ();

            //product
            file.JSONProduct.Warranty = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='warranty' , @table ='Products'", new { });

            //procesor
            file.JSONProcessor.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='Processors'", new { });
            file.JSONProcessor.Arch = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='arch' , @table ='Processors'", new { });
            file.JSONProcessor.Cores = await _data.LoadData<int, dynamic>("EXEC distinctvalues @column ='cores' , @table ='Processors'", new { });
            file.JSONProcessor.Cache = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='cache' , @table ='Processors'", new { });
            file.JSONProcessor.Family = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='family' , @table ='Processors'", new { });
            file.JSONProcessor.Lithography = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='lithography' , @table ='Processors'", new { });
            file.JSONProcessor.Memory_types = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='memory_types' , @table ='Processors'", new { });
            file.JSONProcessor.Processor_graphic = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='processor_graphic' , @table ='Processors'", new { });
            file.JSONProcessor.Socket = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='socket' , @table ='Processors'", new { });

            //disc
            file.JSONDisc.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='Discs'", new { });
            file.JSONDisc.Destiny = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='destiny' , @table ='Discs'", new { });
            file.JSONDisc.Format = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='discformat' , @table ='Discs'", new { });
            file.JSONDisc.Interfaces = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='interfaces' , @table ='Discs'", new { });
            file.JSONDisc.Memory_type = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='memory_type' , @table ='Discs'", new { });
            file.JSONDisc.Type = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='disctype' , @table ='Discs'", new { });

            //computercase
            file.JSONComputerCase.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='ComputerCases'", new { });
            file.JSONComputerCase.Backlight = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='backlight' , @table ='ComputerCases'", new { });
            file.JSONComputerCase.Power_supply_type = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='power_supply_type' , @table ='ComputerCases'", new { });
            file.JSONComputerCase.Side_panel = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='side_panel' , @table ='ComputerCases'", new { });
            file.JSONComputerCase.Type = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='casetype' , @table ='ComputerCases'", new { });           
            
            List<string> coverted_strings = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='motherboards_typeSTR' , @table ='ComputerCases'", new { });
            List<string> types_result = new List<string>();
            foreach (var item in coverted_strings)
            {
                foreach (var item2 in item.Split('`'))
                {
                    types_result.Add(item2);
                }
            }
            file.JSONComputerCase.Motherboardstype = types_result.Distinct().ToList();


            //graphic card
            file.JSONGraphicCard.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Rtx = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='rtx' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Producent = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='producent' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Graphics_processing = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='graphics_processing' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Memory_Size = await _data.LoadData<int, dynamic>("EXEC distinctvalues @column ='memory_size' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Card_bus = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='card_bus' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Cooling = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='cooling' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Memory_type = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='memory_type' , @table ='GraphicCards'", new { });
            file.JSONGraphicCard.Power_connectors = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='power_connectors' , @table ='GraphicCards'", new { });

            //motherboard
            file.JSONMotherboard.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='Motherboards'", new { });

            file.JSONMotherboard.Audio = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='audio' , @table ='Motherboards'", new { });
            file.JSONMotherboard.Chipset = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='chipset' , @table ='Motherboards'", new { });
            file.JSONMotherboard.Format = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='boardformat' , @table ='Motherboards'", new { });
            file.JSONMotherboard.Memory_channel = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='memory_channel' , @table ='Motherboards'", new { });
            file.JSONMotherboard.Multi_cards = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='multi_cards' , @table ='Motherboards'", new { });
            file.JSONMotherboard.Socket = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='socket' , @table ='Motherboards'", new { });

            //powersupply
            file.JSONPowerSupply.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='PowerSupply'", new { });
            file.JSONPowerSupply.Power = await _data.LoadData<int, dynamic>("EXEC distinctvalues @column ='power_' , @table ='PowerSupply'", new { });
            file.JSONPowerSupply.Cables_types = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='cables_types' , @table ='PowerSupply'", new { });
            file.JSONPowerSupply.Certificate = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='certificate_' , @table ='PowerSupply'", new { });
            file.JSONPowerSupply.Pfc = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='pfc' , @table ='PowerSupply'", new { });
            file.JSONPowerSupply.Standard = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='standard_' , @table ='PowerSupply'", new { });

            //radiator
            file.JSONRadiator.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='Radiators'", new { });
            file.JSONRadiator.Rps = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='rps' , @table ='Radiators'", new { });
            file.JSONRadiator.Bearing = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='bearing' , @table ='Radiators'", new { });
            file.JSONRadiator.Connectors = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='connectors' , @table ='Radiators'", new { });
            file.JSONRadiator.Cooling_type = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='cooling_type' , @table ='Radiators'", new { });
            List<string> coverted_strings2 = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='socketsSTR' , @table ='Radiators'", new { });
            List<string> socket_result = new List<string>();
            foreach (var item in coverted_strings2)
            {
                foreach (var item2 in item.Split('`'))
                {
                    socket_result.Add(item2);
                }
            }
            file.JSONRadiator.Socket = socket_result.Distinct().ToList();

            //ram
            file.JSONRam.Brand = await _data.LoadData<string, dynamic>("EXEC distinctvaluesINNER @column ='brand' , @table ='Rams'", new { });
            file.JSONRam.Memory_size_full = await _data.LoadData<int, dynamic>("EXEC distinctvalues @column ='memory_size_full' , @table ='Rams'", new { });
            file.JSONRam.Items = await _data.LoadData<int, dynamic>("EXEC distinctvalues @column ='items' , @table ='Rams'", new { });
            file.JSONRam.Cooling = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='cooling' , @table ='Rams'", new { });
            file.JSONRam.Cycle_latency = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='cycle_latency' , @table ='Rams'", new { });
            file.JSONRam.Frequency = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='frequency' , @table ='Rams'", new { });
            file.JSONRam.Memory_type = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='memory_type' , @table ='Rams'", new { });
            file.JSONRam.Series = await _data.LoadData<string, dynamic>("EXEC distinctvalues @column ='series' , @table ='Rams'", new { });

            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\distinct.json");         
                JsonSerializer serializer = new ();
                serializer.Serialize(file1, file);           
        }
    }
    public class JSON_Processor
    {
        public List<string> Brand { get; set; }
        public List<string> Family { get; set; }
        public List<string> Socket { get; set; }
        public List<string> Arch { get; set; }
        public List<int> Cores { get; set; }
        public List<string> Cache { get; set; }
        public List<string> Processor_graphic { get; set; }
        public List<string> Memory_types { get; set; }
        public List<string> Lithography { get; set; }
    }
    public class JSON_Disc
    {
        public List<string> Brand { get; set; }
        public List<string> Destiny { get; set; }
        public List<string> Type { get; set; }
        public List<string> Format { get; set; }
        public List<string> Interfaces { get; set; }
        public List<string> Memory_type { get; set; }
    }
    public class JSON_ComputerCase
    {
        public List<string> Brand { get; set; }
        public List<string> Type { get; set; }
        public List<string> Power_supply_type { get; set; }
        public List<string> Backlight { get; set; }
        public List<string> Side_panel { get; set; }
        public List<string> Motherboardstype { get; set; }
    }
    public class JSON_GraphicCard
    {
        public List<string> Brand { get; set; }
        public List<string> Card_bus { get; set; }
        public List<string> Producent { get; set; }
        public List<string> Graphics_processing { get; set; }
        public List<string> Rtx { get; set; }
        public List<string> Memory_type { get; set; }
        public List<string> Cooling { get; set; }
        public List<string> Power_connectors { get; set; }
        public List<int> Memory_Size { get; set; }
    }
    public class JSON_Motherboard
    {
        public List<string> Brand { get; set; }
        public List<string> Socket { get; set; }
        public List<string> Chipset { get; set; }
        public List<string> Memory_channel { get; set; }
        public List<string> Multi_cards { get; set; }
        public List<string> Audio { get; set; }
        public List<string> Format { get; set; }
    }
    public class JSON_PowerSupply
    {
        public List<string> Brand { get; set; }
        public List<int> Power { get; set; }
        public List<string> Standard { get; set; }
        public List<string> Certificate { get; set; }
        public List<string> Cables_types { get; set; }
        public List<string> Pfc { get; set; }
    }
    public class JSON_Product
    {
        public List<string> Brand { get; set; }
        public List<string> Warranty { get; set; }
    }
    public class JSON_Radiator
    {
        public List<string> Brand { get; set; }
        public List<string> Rps { get; set; }
        public List<string> Socket { get; set; }
        public List<string> Cooling_type { get; set; }
        public List<string> Bearing { get; set; }
        public List<string> Connectors { get; set; }

    }
    public class JSON_Ram
    {
        public List<string> Brand { get; set; }
        public List<int> Memory_size_full { get; set; }
        public List<int> Items { get; set; }
        public List<string> Series { get; set; }
        public List<string> Memory_type { get; set; }
        public List<string> Frequency { get; set; }
        public List<string> Cycle_latency { get; set; }
        public List<string> Cooling { get; set; }
    }
}
