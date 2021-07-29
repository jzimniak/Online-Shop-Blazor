using OnlineShop.Models.Filtrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Models;
using System.Reflection;
using DataAccess;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace OnlineShop.Services
{
    public class SearchEngine
    {       

        //get products that matches FiltrComponent
        public async static Task<List<Product<Processor>>> Selected_Processors(Filtr_Processor filtr, IWebHostEnvironment env) 
        {
            List<Product<Processor>> result = new List<Product<Processor>>();

            foreach (var item in result)
            {
                item.Attributes = new Processor();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\processors.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Processor>>>(json));
            }
            
            if (filtr.Brand is not null && filtr.Brand.Count!=0)
            {
                result = result.FindAll(x=>filtr.Brand.Contains(x.Brand));

            }
            if (filtr.Family is not null && filtr.Family.Count != 0)
            {
                result = result.FindAll(x => filtr.Family.Contains(x.Attributes.Family));
            }
            if (filtr.Socket is not null && filtr.Socket.Count != 0)
            {
                result = result.FindAll(x => filtr.Socket.Contains(x.Attributes.Socket));
            }
            if (filtr.Arch is not null && filtr.Arch.Count != 0)
            {
                result = result.FindAll(x => filtr.Arch.Contains(x.Attributes.Arch));
            }
            if (filtr.Unlocked is not null && filtr.Unlocked.Count != 0)
            {
                result = result.FindAll(x => filtr.Unlocked.Contains(x.Attributes.Unlocked));
            }
            if (filtr.Cache is not null && filtr.Cache.Count != 0)
            {
                result = result.FindAll(x => filtr.Cache.Contains(x.Attributes.Cache));
            }
            if (filtr.Cores is not null && filtr.Cores.Count != 0)
            {
                result = result.FindAll(x => filtr.Cores.Contains(x.Attributes.Cores.ToString()));
            }
            if (filtr.Intergrated_graphic is not null && filtr.Intergrated_graphic.Count != 0)
            {
                result = result.FindAll(x => filtr.Intergrated_graphic.Contains(x.Attributes.Intergrated_graphic));
            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }
            }

            return result;
        }
        public async static Task<List<Product<ComputerCase>>> Selected_ComputerCase(Filtr_ComputerCase filtr, IWebHostEnvironment env)
        {
            List<Product<ComputerCase>> result = new List<Product<ComputerCase>>();

            foreach (var item in result)
            {
                item.Attributes = new ComputerCase();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\computercases.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<ComputerCase>>>(json));
            }

            if (filtr.Brand is not null && filtr.Brand.Count != 0)
            {
                result = result.FindAll(x => filtr.Brand.Contains(x.Brand));
            }
            if (filtr.Type is not null && filtr.Type.Count != 0)
            {
                result = result.FindAll(x => filtr.Type.Contains(x.Attributes.Type));
            }
            if (filtr.Motherboardstype is not null && filtr.Motherboardstype.Count != 0)
            {
                result = result.FindAll(x => x.Attributes.Motherboards_type.Any(p => filtr.Motherboardstype.Contains(p)));
            }
            if (filtr.Power_supply_type is not null && filtr.Power_supply_type.Count != 0)
            {
                result = result.FindAll(x => filtr.Power_supply_type.Contains(x.Attributes.Power_supply_type));
            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }
            }
            if (filtr.Width!=0)
            {
                result = result.FindAll(x => x.Attributes.Width<=filtr.Width);
            }
            if (filtr.Heigth != 0)
            {
                result = result.FindAll(x => x.Attributes.Heigth <= filtr.Heigth);
            }
            if (filtr.Length != 0)
            {
                result = result.FindAll(x => x.Attributes.Length <= filtr.Length);
            }

            return result;
        }
        public async static Task<List<Product<Disc>>> Selected_Discs(Filtr_Disc filtr, IWebHostEnvironment env)
        {
            List<Product<Disc>> result = new List<Product<Disc>>();

            foreach (var item in result)
            {
                item.Attributes = new Disc();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\discs.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Disc>>>(json));
            }

            if (filtr.Brand is not null && filtr.Brand.Count!=0)
            {
                result = result.FindAll(x => filtr.Brand.Contains(x.Brand));
            }
            if (filtr.Type is not null && filtr.Type.Count != 0)
            {
                result = result.FindAll(x => filtr.Type.Contains(x.Attributes.Type));
            }
            if (filtr.Format is not null && filtr.Format.Count != 0)
            {
                result = result.FindAll(x => filtr.Format.Contains(x.Attributes.Format));
            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }
            }
            if (filtr.Read_speed != 0)
            {
                result = result.FindAll(x => x.Attributes.Read_speed >= filtr.Read_speed);
            }
            if (filtr.Write_speed != 0)
            {
                result = result.FindAll(x => x.Attributes.Write_speed >= filtr.Write_speed);
            }

            return result;
        }
        public async static Task<List<Product<GraphicCard>>> Selected_GraphicCards(Filtr_GraphicCard filtr, IWebHostEnvironment env)
        {
            List<Product<GraphicCard>> result = new List<Product<GraphicCard>>();

            foreach (var item in result)
            {
                item.Attributes = new GraphicCard();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\graphiccards.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<GraphicCard>>>(json));
            }

            if (filtr.Brand is not null && filtr.Brand.Count != 0)
            {
                result = result.FindAll(x => filtr.Brand.Contains(x.Brand));
            }
            if (filtr.Producent is not null && filtr.Producent.Count != 0)
            {
                result = result.FindAll(x => filtr.Producent.Contains(x.Attributes.Producent));
            }
            if (filtr.Graphics_processing is not null && filtr.Graphics_processing.Count != 0)
            {
                result = result.FindAll(x => filtr.Graphics_processing.Contains(x.Attributes.Graphics_processing));
            }
            if (filtr.Rtx is not null && filtr.Rtx.Count != 0)
            {
                result = result.FindAll(x => filtr.Rtx.Contains(x.Attributes.Rtx));
            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }

            }       
            if (filtr.Memory_size is not null && filtr.Memory_size.Count != 0)
            {
                result = result.FindAll(x => filtr.Memory_size.Contains(x.Attributes.Memory_size.ToString()));
            }
            if (filtr.Length != 0)
            {
                result = result.FindAll(x => x.Attributes.Length <=filtr.Length);
            }

            return result;
        }
        public async static Task<List<Product<Motherboard>>> Selected_Motherboards(Filtr_Motherboard filtr, IWebHostEnvironment env)
        {
            List<Product<Motherboard>> result = new List<Product<Motherboard>>();

            foreach (var item in result)
            {
                item.Attributes = new Motherboard();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\motherboards.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Motherboard>>>(json));
            }

            if (filtr.Brand is not null && filtr.Brand.Count != 0)
            {
                result = result.FindAll(x => filtr.Brand.Contains(x.Brand));
            }
            if (filtr.Socket is not null && filtr.Socket.Count != 0)
            {
                result = result.FindAll(x => filtr.Socket.Contains(x.Attributes.Socket));
            }
            if (filtr.Chipset is not null && filtr.Chipset.Count != 0)
            {
                result = result.FindAll(x => filtr.Chipset.Contains(x.Attributes.Chipset));

            }
            if (filtr.Multi_cards is not null && filtr.Multi_cards.Count != 0)
            {
                result = result.FindAll(x => filtr.Multi_cards.Contains(x.Attributes.Multi_cards));

            }
            if (filtr.Audio is not null && filtr.Audio.Count != 0)
            {
                result = result.FindAll(x => filtr.Audio.Contains(x.Attributes.Audio));

            }
            if (filtr.Format is not null && filtr.Format.Count != 0)
            {
                result = result.FindAll(x => filtr.Format.Contains(x.Attributes.Format));

            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }

            }

            return result;
        }
        public async static Task<List<Product<PowerSupply>>> Selected_PowerSupplies(Filtr_PowerSupply filtr, IWebHostEnvironment env)
        {
            List<Product<PowerSupply>> result = new List<Product<PowerSupply>>();

            foreach (var item in result)
            {
                item.Attributes = new PowerSupply();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\powersupplies.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<PowerSupply>>>(json));
            }

            if (filtr.Brand is not null && filtr.Brand.Count != 0)
            {
                result = result.FindAll(x => filtr.Brand.Contains(x.Brand));

            }
            if (filtr.Standard is not null && filtr.Standard.Count != 0)
            {
                result = result.FindAll(x => filtr.Standard.Contains(x.Attributes.Standard));

            }
            if (filtr.Certificate is not null && filtr.Certificate.Count != 0)
            {
                result = result.FindAll(x => filtr.Certificate.Contains(x.Attributes.Certificate));

            }
            if (filtr.Cables_types is not null && filtr.Cables_types.Count != 0)
            {
                result = result.FindAll(x => filtr.Cables_types.Contains(x.Attributes.Cables_types));

            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }
            }
            if (filtr.Power is not null && filtr.Power.Count != 0)
            {
                result = result.FindAll(x => filtr.Power.Contains(x.Attributes.Power.ToString()));
            }

            return result;
        }
        public async static Task<List<Product<Radiator>>> Selected_Radiators(Filtr_Radiator filtr, IWebHostEnvironment env)
        {
            List<Product<Radiator>> result = new List<Product<Radiator>>();

            foreach (var item in result)
            {
                item.Attributes = new Radiator();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\radiators.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Radiator>>>(json));
            }

            if (filtr.Brand is not null && filtr.Brand.Count != 0)
            {
                result = result.FindAll(x => filtr.Brand.Contains(x.Brand));

            }
            if (filtr.Cooling_type is not null && filtr.Cooling_type.Count != 0)
            {
                result = result.FindAll(x => filtr.Cooling_type.Contains(x.Attributes.Cooling_type));
            }
            if (filtr.Socket is not null && filtr.Socket.Count != 0)
            {
                result = result.FindAll(x => x.Attributes.Sockets.Any(p => filtr.Socket.Contains(p)));
            }
            if (filtr.Bearing is not null && filtr.Bearing.Count != 0)
            {
                result = result.FindAll(x => filtr.Bearing.Contains(x.Attributes.Bearing));

            }
            if (filtr.Connectors is not null && filtr.Connectors.Count != 0)
            {
                result = result.FindAll(x => filtr.Connectors.Contains(x.Attributes.Connectors));

            }
            if (filtr.Rps is not null && filtr.Rps.Count != 0)
            {
                result = result.FindAll(x => filtr.Rps.Contains(x.Attributes.Rps));

            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }
            }

            return result;
        }
        public async static Task<List<Product<Ram>>> Selected_Rams(Filtr_Ram filtr, IWebHostEnvironment env)
        {
            List<Product<Ram>> result = new List<Product<Ram>>();

            foreach (var item in result)
            {
                item.Attributes = new Ram();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\rams.json"))
            {
                string json = r.ReadToEnd();
                result = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Ram>>>(json));
            }

            if (filtr.Brand is not null && filtr.Brand.Count != 0)
            {
                result = result.FindAll(x => filtr.Brand.Contains(x.Brand));

            }
            if (filtr.Memory_type is not null && filtr.Memory_type.Count != 0)
            {
                result = result.FindAll(x => filtr.Memory_type.Contains(x.Attributes.Memory_type));

            }
            if (filtr.Cycle_latency is not null && filtr.Cycle_latency.Count != 0)
            {
                result = result.FindAll(x => filtr.Cycle_latency.Contains(x.Attributes.Cycle_latency));

            }
            if (filtr.Frequency is not null && filtr.Frequency.Count != 0)
            {
                result = result.FindAll(x => filtr.Frequency.Contains(x.Attributes.Frequency));

            }
            if (filtr.Items is not null && filtr.Items.Count != 0)
            {
                result = result.FindAll(x => filtr.Items.Contains(x.Attributes.Items.ToString()));

            }
            if (filtr.Price_max != 0 || filtr.Price_min != 0)
            {
                if ((filtr.Price_min > filtr.Price_max) && filtr.Price_max != 0 && filtr.Price_min != 0)
                {
                    decimal z = filtr.Price_min;
                    filtr.Price_min = filtr.Price_max;
                    filtr.Price_max = z;
                }

                if (filtr.Price_min != 0 && filtr.Price_max != 0)
                {
                    result = result.FindAll(x => x.Price >= (float)filtr.Price_min && x.Price <= (float)filtr.Price_max);
                }
                else
                {
                    if (filtr.Price_min != 0)
                    {
                        result = result.FindAll(x => x.Price >= (float)filtr.Price_min);
                    }
                    else
                    {
                        result = result.FindAll(x => x.Price <= (float)filtr.Price_max);
                    }
                }
            }
            if (filtr.Memory_size_full is not null && filtr.Memory_size_full.Count != 0)
            {
                result = result.FindAll(x => filtr.Memory_size_full.Contains(x.Attributes.Memory_size_full.ToString()));

            }

            return result;
        }

        //Get List of products from sql
        public async static Task<List<Product<Processor>>> Processors_List_from_SQL(IConfiguration _config) 
        {
            SqlDataAccess _data = new (_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join processors on processors.productid=products.id" ;
            string sql2 = "select processors.Id,productID,photoSTR,family,processor_number,socket,arch,frequency,cores,threads,unlocked,cache,intergrated_graphic,processor_graphic,memory_types,lithography,TDP,technologiesSTR,cooling_in_box,code from Processors inner join Products on Processors.productID=Products.Id" ;

            List<Product<Processor>> products = await _data.LoadData<Product<Processor>, dynamic>(sql1, new { });
            List<Processor> processors = await _data.LoadData<Processor, dynamic>(sql2, new { });
            if (products.Count == processors.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = processors[i];
                }
            }

            return products;
        }
        public async static Task<List<Product<ComputerCase>>> ComputerCases_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new(_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join computercases on computercases.productid=products.id";
            string sql2 = "SELECT computercases.[Id],[productID],[photoSTR],[casetype] as 'type',[motherboards_typeSTR],[extension_cards],[max_graphic_card_length],[materialsSTR],[additional_informationSTR],[side_panel],[backlight],[power_supply_type],[space_for_discsSTR],[max_height_of_cooling],[max_fans],[fans_typesSTR],[water_cooling_optionsSTR],[fans_installed],[fans_types_installedSTR],[buttonsSTR],[front_panel_outputsSTR],[color],[accessoriesSTR],[width],[heigth],[length_] as 'length',[weigth]  FROM products inner join computercases on computercases.productid=products.id";

            List<Product<ComputerCase>> products = await _data.LoadData<Product<ComputerCase>, dynamic>(sql1, new { });
            List<ComputerCase> attrubutes = await _data.LoadData<ComputerCase, dynamic>(sql2, new { });
            if (products.Count == attrubutes.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = attrubutes[i];
                }
            }

            return products;
        }
        public async static Task<List<Product<Disc>>> Discs_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new (_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join Discs on Discs.productid=products.id";
            string sql2 = "SELECT Discs.[Id] ,[productID] ,[photoSTR] ,[destiny] ,[disctype] as 'type' ,[capacity] ,[discformat] as 'format' ,[interfaces] ,[read_speed] ,[write_speed] ,[random_read_speed] ,[random_write_speed] ,[memory_type] ,[reliability] ,[radiator] ,[additional_informationSTR] ,[accessoriesSTR] ,[color] ,[width] ,[heigth] ,[length_] as 'length',[code] FROM products inner join Discs on Discs.productid=products.id" ;

            List<Product<Disc>> products = await _data.LoadData<Product<Disc>, dynamic>(sql1, new { });
            List<Disc> attrubutes = await _data.LoadData<Disc, dynamic>(sql2, new { });

            if (products.Count == attrubutes.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = attrubutes[i];
                }
            }
            return products;
        }
        public async static Task<List<Product<GraphicCard>>> GraphicCards_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new(_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join GraphicCards on GraphicCards.productid=products.id";
            string sql2 = "SELECT GraphicCards.[Id] ,[productID] ,[photoSTR] ,[rtx] ,[core_clock] ,[graphics_processing] ,[card_bus] ,[memory_size] ,[memory_type] ,[memory_bus] ,[cuda_cores] ,[cooling] ,[outputsSTR] ,[graphic_apiSTR] ,[power_connectors] ,[recommended_psu] ,[tdp] ,[length_] as 'length' ,[width] ,[heigth] ,[accessoriesSTR] ,[code] FROM products inner join GraphicCards on GraphicCards.productid=products.id";
            List<Product<GraphicCard>> products = await _data.LoadData<Product<GraphicCard>, dynamic>(sql1, new { });
            List<GraphicCard> attrubutes = await _data.LoadData<GraphicCard, dynamic>(sql2, new { });

            if (products.Count == attrubutes.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = attrubutes[i];
                }
            }
            return products;
        }
        public async static Task<List<Product<Motherboard>>> Motherboards_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new (_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join Motherboards on Motherboards.productid=products.id";
            string sql2 = " SELECT Motherboards.[Id] ,[productID] ,[photoSTR] ,[socket] ,[chipset] ,[arch_processSTR] ,[memory_typesSTR] ,[memory_types_ocSTR] ,[memory_slots] ,[memory_max_size] ,[memory_channel] ,[internal_connectionSTR] ,[back_panel_portsSTR] ,[raidSTR] ,[multi_cards] ,[can_handle_processor_card] ,[audio] ,[wireless_connection] ,[boardformat] ,[width] ,[length_] as 'length' ,[code] FROM products inner join Motherboards on Motherboards.productid=products.id";
            List<Product<Motherboard>> products = await _data.LoadData<Product<Motherboard>, dynamic>(sql1, new { });
            List<Motherboard> attrubutes = await _data.LoadData<Motherboard, dynamic>(sql2, new { });

            if (products.Count == attrubutes.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = attrubutes[i];
                }
            }
            return products;
        }
        public async static Task<List<Product<PowerSupply>>> PowerSupplies_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new (_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join Powersupply on Powersupply.productid=products.id";
            string sql2 = " SELECT Powersupply.[Id] ,[productID] ,[photoSTR] ,[power_] as 'power' ,[standard_] as 'standard' ,[efficiency] ,[certificate_] as 'certificate' ,[cables_types] ,[fan] ,[pfc] ,[connectorsSTR] ,[securitySTR] ,[additional_informationSTR] ,[length_] as 'length' ,[width] ,[heigth] ,[color] FROM products inner join Powersupply on Powersupply.productid=products.id";

            List<Product<PowerSupply>> products = await _data.LoadData<Product<PowerSupply>, dynamic>(sql1, new { });
            List<PowerSupply> attrubutes = await _data.LoadData<PowerSupply, dynamic>(sql2, new { });

            if (products.Count == attrubutes.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = attrubutes[i];
                }
            }

            return products;
        }
        public async static Task<List<Product<Radiator>>> Radiators_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new(_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join Radiators on Radiators.productid=products.id";
            string sql2 = " SELECT Radiators.[Id] ,[productID] ,[photoSTR] ,[cooling_type] ,[socketsSTR] ,[fansSTR] ,[materials] ,[rps] ,[bearing] ,[max_dB] ,[connectors] ,[backlight] ,[service_life] ,[tdp] ,[additional_informationSTR] ,[heigth] ,[width] ,[length_] as 'length' ,[weight_] as 'weight' ,[accessoriesSTR] ,[code] FROM products inner join Radiators on Radiators.productid=products.id";

            List<Product<Radiator>> products = await _data.LoadData<Product<Radiator>, dynamic>(sql1, new { });
            List<Radiator> attrubutes = await _data.LoadData<Radiator, dynamic>(sql2, new { });

            if (products.Count == attrubutes.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = attrubutes[i];
                }
            }

            return products;
        }
        public async static Task<List<Product<Ram>>> Rams_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new (_config);

            string sql1 = "SELECT products.id,products.prname as name,products.price,products.brand,products.warranty from products inner join Rams on Rams.productid=products.id";
            string sql2 = "SELECT Rams.[Id] ,[productID] ,[photoSTR] ,[series] ,[memory_type] ,[memory_size_full] ,[memory_size_single] ,[items] ,[frequency] ,[cycle_latency] ,[timings] ,[tension] ,[cooling] ,[memory_ecc] ,[memory_backlight] ,[additional_information] ,[color] FROM products inner join Rams on Rams.productid=products.id";

            List<Product<Ram>> products = await _data.LoadData<Product<Ram>, dynamic>(sql1, new { });
            List<Ram> attrubutes = await _data.LoadData<Ram, dynamic>(sql2, new { });

            if (products.Count == attrubutes.Count)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].Attributes = attrubutes[i];
                }
            }

            return products;
        }
        public async static Task<List<Opinions>> Opinions_List_from_SQL(IConfiguration _config)
        {
            SqlDataAccess _data = new(_config);

            string sql = "SELECT [Id],[productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5] FROM Stars";

            List<Opinions> products = await _data.LoadData<Opinions, dynamic>(sql, new { });

            return products;
        }

    }
}
