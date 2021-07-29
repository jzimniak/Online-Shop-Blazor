using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using OnlineShop.Services;
using System.IO;
using Newtonsoft.Json;
using DataAccess;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebUtilities;
using OnlineShop.Models.User;
using Microsoft.Extensions.Configuration;

namespace OnlineShop.Functions
{
    public class Additional_Functions
    {

        public async static Task FillProductsWithRandomOpinions(IConfiguration _config, IWebHostEnvironment env) {

            SqlDataAccess _data = new SqlDataAccess(_config);

            List<int> z  = await _data.LoadData<int, dynamic>("select productID from stars where opinions=0", new { });

            foreach (var item in z)
            {
                Random ran = new Random();
                int[] st= new int[6];
                st[0] = ran.Next(0,15);
                st[1] = ran.Next(0, 20);
                st[2] = ran.Next(0, 25);
                st[3] = ran.Next(0, 30);
                st[4] = ran.Next(0, 35);
                st[5] = ran.Next(0, 40);
                int sum = st[0] + st[1] + st[2] + st[3] + st[4] + st[5];
                float rating = (float)(st[1] + st[2] * 2 + st[3] * 3 + st[4] * 4 + st[5] * 5) / (float)sum;
                Opinions opinion2 = await Additional_Functions.Read_Opinion_From_JSON(item,env);

                opinion2.opinions = sum;
                opinion2.rating = rating;
                opinion2.star0 = st[0];
                opinion2.star1 = st[1];
                opinion2.star2 = st[2];
                opinion2.star3 = st[3];
                opinion2.star4 = st[4];
                opinion2.star5 = st[5];
                await Edit_Opinion_JSON(opinion2,env);


                await _data.Update("UPDATE Stars SET [rating] = @rating,[opinions] = @opinions,[star0] = @star0,[star1] = @star1,[star2] = @star2,[star3] = @star3,[star4] = @star4,[star5] = @star5 WHERE productID= @productID",new { @rating = rating, @opinions = sum, @star0 = st[0], @star1 = st[1], @star2 = st[2], @star3 = st[3], @star4 = st[4], @star5 = st[5], @productID = item });
            }

        }

        //Attributes used in ProductPage
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<Processor> product)
        {
            string[] lista1 = { "Rodzina procesorów", "Seria procesora", "Gniazdo procesora (socket)", "Architektura", "Taktowanie rdzenia", "Liczba rdzeni fizycznych", "Liczba wątków", "Odblokowany mnożnik", "Pamięć podręczna", "Zintegrowany układ graficzny", "Model układu graficznego", "Rodzaj obsługiwanej pamięci", "Proces litograficzny", "Pobór mocy (TDP)", "Zastosowane technologie", "Chłodzenie w zestawie", "Gwarancja", "Kod producenta" };
            string[] lista2 = { product.Attributes.Family, product.Attributes.Processor_number, product.Attributes.Socket, product.Attributes.Arch, product.Attributes.Frequency, product.Attributes.Cores.ToString(), product.Attributes.Threads.ToString(), product.Attributes.Unlocked, product.Attributes.Cache, product.Attributes.Intergrated_graphic, product.Attributes.Processor_graphic, product.Attributes.Memory_types, product.Attributes.Lithography, product.Attributes.TDP, product.Attributes.TechnologiesSTR?.Replace('`', '\n'), product.Attributes.Cooling_in_box, product.Warranty, product.Attributes.Code };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];

            int index = 0;
            for (int i = 0; i < lista2.Length; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<GraphicCard> product)
        {
            string[] lista1 = { "Obsługa Ray tracingu","Producent", "Układ graficzny", "Rodzaj złącza", "Pamięć", "Rodzaj pamięci", "Szyna pamięci", "Taktowanie rdzenia", "Rdzenie CUDA", "Typ chłodzenia", "Rodzaje wyjść", "Obsługiwane biblioteki", "Złącze zasilania", "Rekomendowana moc zasilacza", "Pobór mocy (TDP)", "Długość", "Szerokość", "Wysokość", "Gwarancja", "Kod producenta" };
            string[] lista2 = { product.Attributes.Rtx,product.Attributes.Producent, product.Attributes.Graphics_processing, product.Attributes.Card_bus, product.Attributes.Memory_size.ToString() + " MB", product.Attributes.Memory_type, product.Attributes.Memory_bus.ToString() + "-bit", product.Attributes.Core_clock.ToString() + " MHz", product.Attributes.Cuda_cores?.ToString(), product.Attributes.Cooling, product.Attributes.OutputsSTR?.Replace('`', '\n'), product.Attributes.Graphic_apiSTR?.Replace('`', '\n'), product.Attributes.Power_connectors, (product.Attributes.Recommended_psu is null) ? null : product.Attributes.Recommended_psu.ToString() + " W", (product.Attributes.Tdp is null) ? null : product.Attributes.Tdp.ToString() + " W", product.Attributes.Length.ToString() + " mm", product.Attributes.Width.ToString() + " mm", product.Attributes.Heigth.ToString() + " mm", product.Warranty, product.Attributes.Code };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];
            int index = 0;
            for (int i = 0; i < lista2.Length ; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<ComputerCase> product)
        {
            string[] lista1 = { "Typ obudowy", "Panel boczny", "Podświetlenie", "Standard płyty głównej", "Standard zasilacza", "Miejsca na wewnętrzne dyski/napędy", "Miejsca na karty rozszerzeń", "Maksymalna długość karty graficznej", "Maksymalna wysokość chłodzenia CPU", "Maksymalna liczba wentylatorów", "Opcje montażu wentylatorów", "Opcje montażu chłodzenia wodnego", "Liczba zainstalowanych wentylatorów", "Zainstalowane wentylatory", "Przyciski i regulatory", "Wyprowadzone złącza", "Materiał", "Kolor", "Dodatkowe informacje", "Dołączone akcesoria", "Wysokość", "Szerokość", "Głębokość", "Waga", "Gwarancja" };
            string[] lista2 = { product.Attributes.Type, product.Attributes.Side_panel, product.Attributes.Backlight, product.Attributes.Motherboards_typeSTR?.Replace('`', '\n'), product.Attributes.Power_supply_type, product.Attributes.Space_for_discsSTR?.Replace('`', '\n'), product.Attributes.Extension_cards.ToString(), product.Attributes.Max_graphic_card_length.ToString() + " mm", product.Attributes.Max_height_of_cooling.ToString() + " mm", product.Attributes.Max_fans.ToString(), product.Attributes.Fans_typesSTR?.Replace('`', '\n'), product.Attributes.Water_cooling_optionsSTR?.Replace('`', '\n'), product.Attributes.Fans_installed.ToString(), product.Attributes.Fans_types_installedSTR?.Replace('`', '\n'), product.Attributes.ButtonsSTR?.Replace('`', '\n'), product.Attributes.Front_panel_outputsSTR?.Replace('`', '\n'), product.Attributes.MaterialsSTR?.Replace('`', '\n'), product.Attributes.Color, product.Attributes.Additional_informationSTR?.Replace('`', '\n'), product.Attributes.AccessoriesSTR?.Replace('`', '\n'), product.Attributes.Heigth.ToString() + " mm", product.Attributes.Width.ToString() + " mm", product.Attributes.Length.ToString() + " mm", product.Attributes.Weigth.ToString() + " kg", product.Warranty };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];

            int index = 0;
            for (int i = 0; i < lista2.Length; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<Disc> product)
        {
            string[] lista1 = { "Przeznaczenie produktu", "Pojemność", "Format", "Interfejs", "Prędkość odczytu (maksymalna)", "Prędkość zapisu (maksymalna)", "Odczyt losowy", "Zapis losowy", "Rodzaj kości pamięci", "Niezawodność MTBF", "Radiator", "Dodatkowe informacje", "Dołączone akcesoria", "Kolor", "Wysokość", "Szerokość", "Głębokość", "Gwarancja", "Kod producenta" };
            string[] lista2 = { product.Attributes.Destiny, product.Attributes.Capacity.ToString() + " GB", product.Attributes.Format, product.Attributes.Interfaces, product.Attributes.Read_speed.ToString() + " MB/s", product.Attributes.Write_speed.ToString() + " MB/s", product.Attributes.Random_read_speed.ToString() + " IOPS", product.Attributes.Random_write_speed.ToString() + " IOPS", product.Attributes.Memory_type, product.Attributes.Reliability.ToString() + " godz.", product.Attributes.Radiator, product.Attributes.Additional_informationSTR?.Replace('`', '\n'), product.Attributes.AccessoriesSTR?.Replace('`', '\n'), product.Attributes.Color, product.Attributes.Heigth.ToString() + " mm", product.Attributes.Width.ToString() + " mm", product.Attributes.Length.ToString() + " mm", product.Warranty, product.Attributes.Code };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];

            int index = 0;
            for (int i = 0; i < lista2.Length; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<Motherboard> product)
        {
            string[] lista1 = { "Gniazdo procesora", "Chipset", "Architektura procesora", "Typ obsługiwanej pamięci", "Typ obsługiwanej pamięci OC", "Liczba banków pamięci", "Maksymalna wielkość pamięci RAM", "Architektura pamięci", "Wewnętrzne złącza", "Zewnętrzne złącza", "Obsługa RAID", "Obsługa wielu kart graficznych", "Obsługa układów graficznych w procesorach", "Układ audio", "Łączność bezprzewodowa", "Format", "Szerokość", "Wysokość", "Gwarancja" };
            string[] lista2 = { product.Attributes.Socket, product.Attributes.Chipset, product.Attributes.Arch_processSTR?.Replace('`', '\n'), product.Attributes.Memory_typesSTR?.Replace('`', '\n'), product.Attributes.Memory_types_ocSTR?.Replace('`', '\n'), product.Attributes.Memory_slots.ToString() + " DIMM", product.Attributes.Memory_max_size.ToString() + " GB", product.Attributes.Memory_channel, product.Attributes.Internal_connectionSTR?.Replace('`', '\n'), product.Attributes.Back_panel_portsSTR?.Replace('`', '\n'), product.Attributes.RaidSTR?.Replace('`', '\n'), product.Attributes.Multi_cards, product.Attributes.Can_handle_processor_card, product.Attributes.Audio, product.Attributes.Wireless_connection, product.Attributes.Format, product.Attributes.Width.ToString() + " mm", product.Attributes.Length.ToString() + " mm", product.Warranty };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];

            int index = 0;
            for (int i = 0; i < lista2.Length; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<PowerSupply> product)
        {
            string[] lista1 = { "Moc maksymalna", "Standard", "Złącza", "Sprawność", "Certyfikat", "Zabezpieczenia", "Układ PFC (korekcja współczynnika mocy)", "Typ okablowania", "Średnica wentylatora", "Dodatkowe informacje", "Kolor", "Wysokość", "Szerokość", "Głębokość", "Gwarancja" };
            string[] lista2 = { product.Attributes.Power.ToString() + " W", product.Attributes.Standard, product.Attributes.ConnectorsSTR?.Replace('`', '\n'), product.Attributes.Efficiency, product.Attributes.Certificate, product.Attributes.SecuritySTR?.Replace('`', '\n'), product.Attributes.Pfc, product.Attributes.Cables_types, product.Attributes.Fan, product.Attributes.Additional_informationSTR?.Replace('`', '\n'), product.Attributes.Color, product.Attributes.Heigth.ToString() + " mm", product.Attributes.Width.ToString() + " mm", product.Attributes.Length.ToString() + " mm", product.Warranty };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];

            int index = 0;
            for (int i = 0; i < lista2.Length; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<Radiator> product)
        {
            string[] lista1 = { "Rodzaj chłodzenia", "Kompatybilność", "Rozmiar radiatora", "Materiał radiatora", "Prędkość obrotowa", "Rodzaj łożyska", "Maksymalny poziom hałasu", "Złącze", "Podświetlenie", "Żywotność MTBF", "TDP", "Dodatkowe informacje", "Wysokość", "Szerokość", "Głębokość", "Waga", "Dołączone akcesoria", "Gwarancja", "Kod producenta" };
            string[] lista2 = { product.Attributes.Cooling_type, product.Attributes.SocketsSTR?.Replace('`', '\n'), product.Attributes.FansSTR?.Replace('`', '\n'), product.Attributes.Materials, product.Attributes.Rps, product.Attributes.Bearing, product.Attributes.Max_dB, product.Attributes.Connectors, product.Attributes.Backlight, product.Attributes.Service_life, product.Attributes.Tdp, product.Attributes.Additional_informationSTR?.Replace('`', '\n'), product.Attributes.Heigth.ToString() + " mm", product.Attributes.Width.ToString() + " mm", product.Attributes.Length.ToString() + " mm", product.Attributes.Weight.ToString() + " g", product.Attributes.Additional_informationSTR?.Replace('`', '\n'), product.Warranty, product.Attributes.Code };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];

            int index = 0;
            for (int i = 0; i < lista2.Length; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }
        public static string[,] Convert_Attributes_To_Two_Dim_Array(Product<Ram> product)
        {
            string[] lista1 = { "Seria", "Rodzaj pamięci", "Pojemność całkowita", "Pojemność kości", "Liczba modułów", "Taktowanie", "Opóźnienia (cycle latency)", "Timingi", "Napięcie", "Chłodzenie", "Pamięć ECC", "Podświetlenie pamięci", "Dodatkowe informacje", "Kolor", "Gwarancja" };
            string[] lista2 = { product.Attributes.Series, product.Attributes.Memory_type, product.Attributes.Memory_size_full.ToString() + " GB", product.Attributes.Memory_size_single.ToString() + " GB", product.Attributes.Items.ToString(), product.Attributes.Frequency, product.Attributes.Cycle_latency, product.Attributes.Timings, product.Attributes.Tension.ToString() + " V", product.Attributes.Cooling, product.Attributes.Memory_ecc, product.Attributes.Memory_backlight, product.Attributes.Additional_information, product.Attributes.Color, product.Warranty };
            int Null_values = lista2.Count(s => s == null);
            string[,] result = new string[2, lista2.Length - Null_values];

            int index = 0;
            for (int i = 0; i < lista2.Length; i++)
            {
                if (lista2[i] is not null)
                {
                    result[0, index] = lista1[i];
                    result[1, index] = lista2[i];
                    index++;
                }
            }

            return result;
        }


        public async static void Add_Product_To_JSON(Product<Processor> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<Processor>> products = new List<Product<Processor>>();
            foreach (var item in products)
            {
                item.Attributes = new Processor();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath + $"\\json\\processors.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Processor>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }

            using StreamWriter file1 = File.CreateText(env.WebRootPath + $"\\json\\processors.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }
        public async static void Add_Product_To_JSON(Product<ComputerCase> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<ComputerCase>> products = new List<Product<ComputerCase>>();
            foreach (var item in products)
            {
                item.Attributes = new ComputerCase();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\computercases.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<ComputerCase>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\computercases.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }
        public async static void Add_Product_To_JSON(Product<Disc> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<Disc>> products = new List<Product<Disc>>();
            foreach (var item in products)
            {
                item.Attributes = new Disc();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\discs.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Disc>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\discs.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }
        public async static void Add_Product_To_JSON(Product<GraphicCard> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<GraphicCard>> products = new List<Product<GraphicCard>>();
            foreach (var item in products)
            {
                item.Attributes = new GraphicCard();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\graphiccards.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<GraphicCard>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\graphiccards.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }
        public async static void Add_Product_To_JSON(Product<Motherboard> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<Motherboard>> products = new List<Product<Motherboard>>();
            foreach (var item in products)
            {
                item.Attributes = new Motherboard();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\motherboards.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Motherboard>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\motherboards.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }
        public async static void Add_Product_To_JSON(Product<PowerSupply> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<PowerSupply>> products = new List<Product<PowerSupply>>();
            foreach (var item in products)
            {
                item.Attributes = new PowerSupply();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\powersupplies.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<PowerSupply>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\powersupplies.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }
        public async static void Add_Product_To_JSON(Product<Radiator> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<Radiator>> products = new List<Product<Radiator>>();
            foreach (var item in products)
            {
                item.Attributes = new Radiator();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\radiators.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Radiator>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\radiators.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }
        public async static void Add_Product_To_JSON(Product<Ram> product, bool Is_Product_Exist, IWebHostEnvironment env)
        {

            List<Product<Ram>> products = new List<Product<Ram>>();
            foreach (var item in products)
            {
                item.Attributes = new Ram();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\rams.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Ram>>>(json));

            }

            if (Is_Product_Exist)
            {
                int index = products.IndexOf(products.Find(x => x.Id == product.Id));
                products[index] = product;
            }
            else
            {
                products.Add(product);
            }


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\rams.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, products);

        }

        public async static Task<List<Product<Processor>>> Read_Processors_From_JSON( IWebHostEnvironment env)
        {
            List<Product<Processor>> products = new List<Product<Processor>>();
            foreach (var item in products)
            {
                item.Attributes = new Processor();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\processors.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Processor>>>(json));

            }
            return products;
        }
        public async static Task<List<Product<ComputerCase>>> Read_Computercases_From_JSON(IWebHostEnvironment env)
        {
            List<Product<ComputerCase>> products = new List<Product<ComputerCase>>();
            foreach (var item in products)
            {
                item.Attributes = new ComputerCase();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\computercases.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<ComputerCase>>>(json));

            }
            return products;
        }
        public async static Task<List<Product<Disc>>> Read_Discs_From_JSON(IWebHostEnvironment env)
        {
            List<Product<Disc>> products = new List<Product<Disc>>();
            foreach (var item in products)
            {
                item.Attributes = new Disc();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\discs.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Disc>>>(json));

            }
            return products;
        }
        public async static Task<List<Product<GraphicCard>>> Read_GraphicCards_From_JSON(IWebHostEnvironment env)
        {
            List<Product<GraphicCard>> products = new List<Product<GraphicCard>>();
            foreach (var item in products)
            {
                item.Attributes = new GraphicCard();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\graphiccards.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<GraphicCard>>>(json));

            }
            return products;
        }
        public async static Task<List<Product<Motherboard>>> Read_Motherboards_From_JSON(IWebHostEnvironment env)
        {
            List<Product<Motherboard>> products = new List<Product<Motherboard>>();
            foreach (var item in products)
            {
                item.Attributes = new Motherboard();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\motherboards.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Motherboard>>>(json));

            }
            return products;
        }
        public async static Task<List<Product<PowerSupply>>> Read_PowerSupplies_From_JSON(IWebHostEnvironment env)
        {
            List<Product<PowerSupply>> products = new List<Product<PowerSupply>>();
            foreach (var item in products)
            {
                item.Attributes = new PowerSupply();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\powersupplies.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<PowerSupply>>>(json));

            }
            return products;
        }
        public async static Task<List<Product<Radiator>>> Read_Radiators_From_JSON(IWebHostEnvironment env)
        {
            List<Product<Radiator>> products = new List<Product<Radiator>>();
            foreach (var item in products)
            {
                item.Attributes = new Radiator();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\radiators.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Radiator>>>(json));

            }
            return products;
        }
        public async static Task<List<Product<Ram>>> Read_Rams_From_JSON(IWebHostEnvironment env)
        {
            List<Product<Ram>> products = new List<Product<Ram>>();
            foreach (var item in products)
            {
                item.Attributes = new Ram();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\rams.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Ram>>>(json));

            }
            return products;
        }

        public async static Task<(Product<Processor>, List<Opinions>)> Add_Product_To_SQL(Product<Processor> processor, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = processor.Name, Price = processor.Price, Brand = processor.Brand, Warranty = processor.Warranty, @producttype="processor" });

            processor.Attributes.Photo = getPhotos(id[0], loadedFiles);
            processor.Id = id[0];
            if (processor.Attributes.TechnologiesSTR is not null)
            {
                processor.Attributes.Technologies = convertInputTextAreaToProjectSyntax(processor.Attributes.TechnologiesSTR);
            }

            string sql2 = "insert into Processors (productID,photoSTR,family,processor_number,socket,arch,frequency,cores,threads,unlocked,cache,intergrated_graphic,processor_graphic,memory_types,lithography,tdp,technologiesSTR,cooling_in_box,code) values (@productID,@PhotoSTR,@Family,@Processor_number,@Socket,@Arch,@Frequency,@Cores,@Threads,@Unlocked,@Cache,@Intergrated_graphic,@Processor_graphic,@Memory_types,@Lithography,@Tdp,@TechnologiesSTR,@Cooling_in_box,@Code) SELECT CAST(scope_identity() AS int)";
            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = processor.Attributes.PhotoSTR, @Family = processor.Attributes.Family, @Processor_number = processor.Attributes.Processor_number, @Socket = processor.Attributes.Socket, @Arch = processor.Attributes.Arch, @Frequency = processor.Attributes.Frequency, @Cores = processor.Attributes.Cores, @Threads = processor.Attributes.Threads, @Unlocked = processor.Attributes.Unlocked, @Cache = processor.Attributes.Cache, @Intergrated_graphic = processor.Attributes.Intergrated_graphic, @Processor_graphic = processor.Attributes.Processor_graphic, @Memory_types = processor.Attributes.Memory_types, @Lithography = processor.Attributes.Lithography, @Tdp = processor.Attributes.TDP, @TechnologiesSTR = processor.Attributes.TechnologiesSTR, @Cooling_in_box = processor.Attributes.Cooling_in_box, @Code = processor.Attributes.Code });
            processor.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0 = 0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });

            return (processor, op);
        }
        public async static Task<(Product<ComputerCase>, List<Opinions>)> Add_Product_To_SQL(Product<ComputerCase> computercase, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = computercase.Name, Price = computercase.Price, Brand = computercase.Brand, Warranty = computercase.Warranty, @producttype="computercase" });

            computercase.Id = id[0];
            computercase.Attributes.Photo = getPhotos(id[0], loadedFiles);
            computercase.Attributes.Motherboards_type = convertInputTextAreaToProjectSyntax(computercase.Attributes.Motherboards_typeSTR);
            computercase.Attributes.Materials = convertInputTextAreaToProjectSyntax(computercase.Attributes.MaterialsSTR);
            computercase.Attributes.Additional_information = convertInputTextAreaToProjectSyntax(computercase.Attributes.Additional_informationSTR);
            computercase.Attributes.Space_for_discs = convertInputTextAreaToProjectSyntax(computercase.Attributes.Space_for_discsSTR);
            computercase.Attributes.Fans_types = convertInputTextAreaToProjectSyntax(computercase.Attributes.Fans_typesSTR);
            computercase.Attributes.Water_cooling_options = convertInputTextAreaToProjectSyntax(computercase.Attributes.Water_cooling_optionsSTR);
            computercase.Attributes.Fans_types_installed = convertInputTextAreaToProjectSyntax(computercase.Attributes.Fans_types_installedSTR);
            computercase.Attributes.Buttons = convertInputTextAreaToProjectSyntax(computercase.Attributes.ButtonsSTR);
            computercase.Attributes.Front_panel_outputs = convertInputTextAreaToProjectSyntax(computercase.Attributes.Front_panel_outputsSTR);
            computercase.Attributes.Accessories = convertInputTextAreaToProjectSyntax(computercase.Attributes.AccessoriesSTR);

            string sql2 = "insert into ComputerCases (productID,photoSTR,caseType,motherboards_typeSTR,extension_cards,max_graphic_card_length,materialsSTR,additional_informationSTR,side_panel,backlight,power_supply_type,space_for_discsSTR,max_height_of_cooling,max_fans,fans_typesSTR,water_cooling_optionsSTR,fans_installed,fans_types_installedSTR,buttonsSTR,front_panel_outputsSTR,color,accessoriesSTR,width,heigth,length_,weigth) values (@productID,@PhotoSTR,@caseType,@Motherboards_typeSTR,@Extension_cards,@Max_graphic_card_length,@MaterialsSTR,@Additional_informationSTR,@Side_panel,@Backlight,@Power_supply_type,@Space_for_discsSTR,@Max_height_of_cooling,@Max_fans,@Fans_typesSTR,@Water_cooling_optionsSTR,@Fans_installed,@Fans_types_installedSTR,@ButtonsSTR,@Front_panel_outputsSTR,@Color,@AccessoriesSTR,@Width,@Heigth,@Length_,@Weigth) SELECT CAST(scope_identity() AS int)";

            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = computercase.Attributes.PhotoSTR, @caseType = computercase.Attributes.Type, @Motherboards_typeSTR = computercase.Attributes.Motherboards_typeSTR, @Extension_cards = computercase.Attributes.Extension_cards, @Max_graphic_card_length = computercase.Attributes.Max_graphic_card_length, @MaterialsSTR = computercase.Attributes.MaterialsSTR, @Additional_informationSTR = computercase.Attributes.Additional_informationSTR, @Side_panel = computercase.Attributes.Side_panel, @Backlight = computercase.Attributes.Backlight, @Power_supply_type = computercase.Attributes.Power_supply_type, @Space_for_discsSTR = computercase.Attributes.Space_for_discsSTR, @Max_height_of_cooling = computercase.Attributes.Max_height_of_cooling, @Max_fans = computercase.Attributes.Max_fans, @Fans_typesSTR = computercase.Attributes.Fans_typesSTR, @Water_cooling_optionsSTR = computercase.Attributes.Water_cooling_optionsSTR, @Fans_installed = computercase.Attributes.Fans_installed, @Fans_types_installedSTR = computercase.Attributes.Fans_types_installedSTR, @ButtonsSTR = computercase.Attributes.ButtonsSTR, @Front_panel_outputsSTR = computercase.Attributes.Front_panel_outputsSTR, @Color = computercase.Attributes.Color, @AccessoriesSTR = computercase.Attributes.AccessoriesSTR, @Width = computercase.Attributes.Width, @Heigth = computercase.Attributes.Heigth, @Length_ = computercase.Attributes.Length, @Weigth = computercase.Attributes.Weigth });
            computercase.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0 = 0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });


            return (computercase, op);
        }
        public async static Task<(Product<Disc>, List<Opinions>)> Add_Product_To_SQL(Product<Disc> disc, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = disc.Name, Price = disc.Price, Brand = disc.Brand, Warranty = disc.Warranty, @producttyp="disc" });

            disc.Id = id[0];
            disc.Attributes.Photo = getPhotos(id[0], loadedFiles);
            disc.Attributes.Additional_information = convertInputTextAreaToProjectSyntax(disc.Attributes.Additional_informationSTR);
            disc.Attributes.Accessories = convertInputTextAreaToProjectSyntax(disc.Attributes.AccessoriesSTR);

            string sql2 = "insert into Discs (productID,photoSTR,destiny,discType,capacity,discFormat,interfaces,read_speed,write_speed,random_read_speed,random_write_speed,memory_type,reliability,radiator,additional_informationSTR,accessoriesSTR,color,width,heigth,length_,code) values (@productID,@PhotoSTR,@Destiny,@discType,@Capacity,@discFormat,@Interfaces,@Read_speed,@Write_speed,@Random_read_speed,@Random_write_speed,@Memory_type,@Reliability,@Radiator,@Additional_informationSTR,@AccessoriesSTR,@Color,@Width,@Heigth,@Length_,@Code) SELECT CAST(scope_identity() AS int)";

            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = disc.Attributes.PhotoSTR, @Destiny = disc.Attributes.Destiny, @discType = disc.Attributes.Type, @Capacity = disc.Attributes.Capacity, @discFormat = disc.Attributes.Format, @Interfaces = disc.Attributes.Interfaces, @Read_speed = disc.Attributes.Read_speed, @Write_speed = disc.Attributes.Write_speed, @Random_read_speed = disc.Attributes.Random_read_speed, @Random_write_speed = disc.Attributes.Random_write_speed, @Memory_type = disc.Attributes.Memory_type, @Reliability = disc.Attributes.Reliability, @Radiator = disc.Attributes.Radiator, @Additional_informationSTR = disc.Attributes.Additional_informationSTR, @AccessoriesSTR = disc.Attributes.AccessoriesSTR, @Color = disc.Attributes.Color, @Width = disc.Attributes.Width, @Heigth = disc.Attributes.Heigth, @Length_ = disc.Attributes.Length, @Code = disc.Attributes.Code });
            disc.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0 = 0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });


            return (disc, op);
        }
        public async static Task<(Product<Motherboard>, List<Opinions>)> Add_Product_To_SQL(Product<Motherboard> motherboard, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = motherboard.Name, Price = motherboard.Price, Brand = motherboard.Brand, Warranty = motherboard.Warranty, @producttype="motherboard" });

            motherboard.Attributes.Photo = getPhotos(id[0], loadedFiles);
            motherboard.Id = id[0];
            motherboard.Attributes.Arch_process = convertInputTextAreaToProjectSyntax(motherboard.Attributes.Arch_processSTR);
            motherboard.Attributes.Memory_types = convertInputTextAreaToProjectSyntax(motherboard.Attributes.Memory_typesSTR);
            motherboard.Attributes.Memory_types_oc = convertInputTextAreaToProjectSyntax(motherboard.Attributes.Memory_types_ocSTR);
            motherboard.Attributes.Internal_connection = convertInputTextAreaToProjectSyntax(motherboard.Attributes.Internal_connectionSTR);
            motherboard.Attributes.Back_panel_ports = convertInputTextAreaToProjectSyntax(motherboard.Attributes.Back_panel_portsSTR);

            string sql2 = "insert into Motherboards (productID,photoSTR,socket,chipset,arch_processSTR,memory_typesSTR,memory_types_ocSTR,memory_slots,memory_max_size,memory_channel,internal_connectionSTR,back_panel_portsSTR,raidSTR,multi_cards,can_handle_processor_card,audio,wireless_connection,boardFormat,width,length_,code) values (@productID,@PhotoSTR,@Socket,@Chipset,@Arch_processSTR,@Memory_typesSTR,@Memory_types_ocSTR,@Memory_slots,@Memory_max_size,@Memory_channel,@Internal_connectionSTR,@Back_panel_portsSTR,@RaidSTR,@Multi_cards,@Can_handle_processor_card,@Audio,@Wireless_connection,@boardFormat,@Width,@Length_,@Code) SELECT CAST(scope_identity() AS int)";

            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = motherboard.Attributes.PhotoSTR, @Socket = motherboard.Attributes.Socket, @Chipset = motherboard.Attributes.Chipset, @Arch_processSTR = motherboard.Attributes.Arch_processSTR, @Memory_typesSTR = motherboard.Attributes.Memory_typesSTR, @Memory_types_ocSTR = motherboard.Attributes.Memory_types_ocSTR, @Memory_slots = motherboard.Attributes.Memory_slots, @Memory_max_size = motherboard.Attributes.Memory_max_size, @Memory_channel = motherboard.Attributes.Memory_channel, @Internal_connectionSTR = motherboard.Attributes.Internal_connectionSTR, @Back_panel_portsSTR = motherboard.Attributes.Back_panel_portsSTR, @RaidSTR = motherboard.Attributes.RaidSTR, @Multi_cards = motherboard.Attributes.Multi_cards, @Can_handle_processor_card = motherboard.Attributes.Can_handle_processor_card, @Audio = motherboard.Attributes.Audio, @Wireless_connection = motherboard.Attributes.Wireless_connection, @boardFormat = motherboard.Attributes.Format, @Width = motherboard.Attributes.Width, @Length_ = motherboard.Attributes.Length, @Code = motherboard.Attributes.Code });
            motherboard.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0 = 0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });

            return (motherboard, op);
        }
        public async static Task<(Product<GraphicCard>, List<Opinions>)> Add_Product_To_SQL(Product<GraphicCard> graphiccard, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = graphiccard.Name, Price = graphiccard.Price, Brand = graphiccard.Brand, Warranty = graphiccard.Warranty, @producttype="graphiccard" });

            graphiccard.Attributes.Photo = getPhotos(id[0], loadedFiles);
            graphiccard.Id = id[0];
            graphiccard.Attributes.Outputs = convertInputTextAreaToProjectSyntax(graphiccard.Attributes.OutputsSTR);
            graphiccard.Attributes.Graphic_api = convertInputTextAreaToProjectSyntax(graphiccard.Attributes.Graphic_apiSTR);
            graphiccard.Attributes.Accessories = convertInputTextAreaToProjectSyntax(graphiccard.Attributes.AccessoriesSTR);

            string sql2 = "insert into GraphicCards (productID,photoSTR,rtx,core_clock,graphics_processing,card_bus,memory_size,memory_type,memory_bus,cuda_cores,cooling,outputsSTR,graphic_apiSTR,power_connectors,recommended_psu,tdp,length_,width,heigth,accessoriesSTR,code,producent) values (@productID,@PhotoSTR,@Rtx,@Core_clock,@Graphics_processing,@Card_bus,@Memory_size,@Memory_type,@Memory_bus,@Cuda_cores,@Cooling,@OutputsSTR,@Graphic_apiSTR,@Power_connectors,@Recommended_psu,@Tdp,@Length_,@Width,@Heigth,@AccessoriesSTR,@Code,@Producent) SELECT CAST(scope_identity() AS int)";

            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = graphiccard.Attributes.PhotoSTR, @Rtx = graphiccard.Attributes.Rtx, @Core_clock = graphiccard.Attributes.Core_clock, @Graphics_processing = graphiccard.Attributes.Graphics_processing, @Card_bus = graphiccard.Attributes.Card_bus, @Memory_size = graphiccard.Attributes.Memory_size, @Memory_type = graphiccard.Attributes.Memory_type, @Memory_bus = graphiccard.Attributes.Memory_bus, @Cuda_cores = graphiccard.Attributes.Cuda_cores, @Cooling = graphiccard.Attributes.Cooling, @OutputsSTR = graphiccard.Attributes.OutputsSTR, @Graphic_apiSTR = graphiccard.Attributes.Graphic_apiSTR, @Power_connectors = graphiccard.Attributes.Power_connectors, @Recommended_psu = graphiccard.Attributes.Recommended_psu, @Tdp = graphiccard.Attributes.Tdp, @Length_ = graphiccard.Attributes.Length, @Width = graphiccard.Attributes.Width, @Heigth = graphiccard.Attributes.Heigth, @AccessoriesSTR = graphiccard.Attributes.AccessoriesSTR, @Code = graphiccard.Attributes.Code, @Producent=graphiccard.Attributes.Producent });
            graphiccard.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0=0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });

            return (graphiccard, op);
        }
        public async static Task<(Product<PowerSupply>, List<Opinions>)> Add_Product_To_SQL(Product<PowerSupply> Powersupply, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = Powersupply.Name, Price = Powersupply.Price, Brand = Powersupply.Brand, Warranty = Powersupply.Warranty , @producttype ="powersupply"});

            Powersupply.Attributes.Photo = getPhotos(id[0], loadedFiles);
            Powersupply.Id = id[0];
            Powersupply.Attributes.Connectors = convertInputTextAreaToProjectSyntax(Powersupply.Attributes.ConnectorsSTR);
            Powersupply.Attributes.Security = convertInputTextAreaToProjectSyntax(Powersupply.Attributes.SecuritySTR);
            Powersupply.Attributes.Additional_information = convertInputTextAreaToProjectSyntax(Powersupply.Attributes.Additional_informationSTR);

            string sql2 = "insert into PowerSupply (productID,photoSTR,power_,standard_,efficiency,certificate_,cables_types,fan,pfc,connectorsSTR,securitySTR,additional_informationSTR,length_,width,heigth,color) values (@productID,@PhotoSTR,@Power_,@Standard_,@Efficiency,@Certificate_,@Cables_types,@Fan,@Pfc,@ConnectorsSTR,@SecuritySTR,@Additional_informationSTR,@Length_,@Width,@Heigth,@Color) SELECT CAST(scope_identity() AS int)";

            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = Powersupply.Attributes.PhotoSTR, @Power_ = Powersupply.Attributes.Power, @Standard_ = Powersupply.Attributes.Standard, @Efficiency = Powersupply.Attributes.Efficiency, @Certificate_ = Powersupply.Attributes.Certificate, @Cables_types = Powersupply.Attributes.Cables_types, @Fan = Powersupply.Attributes.Fan, @Pfc = Powersupply.Attributes.Pfc, @ConnectorsSTR = Powersupply.Attributes.ConnectorsSTR, @SecuritySTR = Powersupply.Attributes.SecuritySTR, @Additional_informationSTR = Powersupply.Attributes.Additional_informationSTR, @Length_ = Powersupply.Attributes.Length, @Width = Powersupply.Attributes.Width, @Heigth = Powersupply.Attributes.Heigth, @Color = Powersupply.Attributes.Color });
            Powersupply.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0 = 0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });

            return (Powersupply, op);
        }
        public async static Task<(Product<Radiator>, List<Opinions>)> Add_Product_To_SQL(Product<Radiator> Radiator, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = Radiator.Name, Price = Radiator.Price, Brand = Radiator.Brand, Warranty = Radiator.Warranty, @producttype="radiator" });

            Radiator.Attributes.Photo = getPhotos(id[0], loadedFiles);
            Radiator.Id = id[0];
            Radiator.Attributes.Sockets = convertInputTextAreaToProjectSyntax(Radiator.Attributes.SocketsSTR);
            Radiator.Attributes.Fans = convertInputTextAreaToProjectSyntax(Radiator.Attributes.FansSTR);
            Radiator.Attributes.Additional_information = convertInputTextAreaToProjectSyntax(Radiator.Attributes.Additional_informationSTR);
            Radiator.Attributes.Accessories = convertInputTextAreaToProjectSyntax(Radiator.Attributes.AccessoriesSTR);

            string sql2 = "insert into Radiators (productID,photoSTR,cooling_type,socketsSTR,fansSTR,materials,rps,bearing,max_dB,connectors,backlight,service_life,tdp,additional_informationSTR,heigth,width,length_,weight_,accessoriesSTR,code) values (@productID,@PhotoSTR,@Cooling_type,@SocketsSTR,@FansSTR,@Materials,@Rps,@Bearing,@Max_dB,@Connectors,@Backlight,@Service_life,@Tdp,@Additional_informationSTR,@Heigth,@Width,@Length_,@Weight_,@AccessoriesSTR,@Code) SELECT CAST(scope_identity() AS int)";

            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = Radiator.Attributes.PhotoSTR, @Cooling_type = Radiator.Attributes.Cooling_type, @SocketsSTR = Radiator.Attributes.SocketsSTR, @FansSTR = Radiator.Attributes.FansSTR, @Materials = Radiator.Attributes.Materials, @Rps = Radiator.Attributes.Rps, @Bearing = Radiator.Attributes.Bearing, @Max_dB = Radiator.Attributes.Max_dB, @Connectors = Radiator.Attributes.Connectors, @Backlight = Radiator.Attributes.Backlight, @Service_life = Radiator.Attributes.Service_life, @Tdp = Radiator.Attributes.Tdp, @Additional_informationSTR = Radiator.Attributes.Additional_informationSTR, @Heigth = Radiator.Attributes.Heigth, @Width = Radiator.Attributes.Width, @Length_ = Radiator.Attributes.Length, @Weight_ = Radiator.Attributes.Weight, @AccessoriesSTR = Radiator.Attributes.AccessoriesSTR, @Code = Radiator.Attributes.Code });
            Radiator.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0 = 0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });

            return (Radiator, op);
        }
        public async static Task<(Product<Ram>, List<Opinions>)> Add_Product_To_SQL(Product<Ram> ram, SqlDataAccess _data, List<IBrowserFile> loadedFiles)
        {
            string sql = "insert into products (prName,price,brand,warranty,producttype) values (@prName,@Price,@Brand,@Warranty,@producttype) SELECT CAST(scope_identity() AS int)";
            List<int> id = await _data.LoadData<int, dynamic>(sql, new { prName = ram.Name, Price = ram.Price, Brand = ram.Brand, Warranty = ram.Warranty, @producttype="ram" });

            ram.Attributes.Photo = getPhotos(id[0], loadedFiles);
            ram.Id = id[0];
            string sql2 = "insert into Rams (productID,photoSTR,series,memory_type,memory_size_full,memory_size_single,items,frequency,cycle_latency,timings,tension,cooling,memory_ecc,memory_backlight,additional_information,color) values (@productID,@PhotoSTR,@Series,@Memory_type,@Memory_size_full,@Memory_size_single,@Items,@Frequency,@Cycle_latency,@Timings,@Tension,@Cooling,@Memory_ecc,@Memory_backlight,@Additional_information,@Color) SELECT CAST(scope_identity() AS int)";

            List<int> id2 = await _data.LoadData<int, dynamic>(sql2, new { @productID = id[0], @PhotoSTR = ram.Attributes.PhotoSTR, @Series = ram.Attributes.Series, @Memory_type = ram.Attributes.Memory_type, @Memory_size_full = ram.Attributes.Memory_size_full, @Memory_size_single = ram.Attributes.Memory_size_single, @Items = ram.Attributes.Items, @Frequency = ram.Attributes.Frequency, @Cycle_latency = ram.Attributes.Cycle_latency, @Timings = ram.Attributes.Timings, @Tension = ram.Attributes.Tension, @Cooling = ram.Attributes.Cooling, @Memory_ecc = ram.Attributes.Memory_ecc, @Memory_backlight = ram.Attributes.Memory_backlight, @Additional_information = ram.Attributes.Additional_information, @Color = ram.Attributes.Color });
            ram.Attributes.Id = id2[0];
            string sql3 = "insert into Stars ([productID],[rating],[opinions],[star0],[star1],[star2],[star3],[star4],[star5]) values (@productID,@rating,@opinions,@stars0,@stars1,@stars2,@stars3,@stars4,@stars5) SELECT * from Stars where Stars.Id=CAST(scope_identity() AS int)";
            List<Opinions> op = await _data.LoadData<Opinions, dynamic>(sql3, new { @productID = id[0], @rating = 0, @opinions = 0, @stars0 = 0, @stars1 = 0, @stars2 = 0, @stars3 = 0, @stars4 = 0, @stars5 = 0 });

            return (ram, op);
        }    
      
        public static Product<Processor> Return_checked_product(Product<Processor> processor)
        {
            processor.Attributes.PhotoSTR = (processor.Attributes.PhotoSTR is null) ? null : (processor.Attributes.PhotoSTR.Length == 0) ? null : processor.Attributes.PhotoSTR;
            processor.Attributes.Arch = (processor.Attributes.Arch is null) ? null : (processor.Attributes.Arch.Length == 0) ? null : processor.Attributes.Arch;
            processor.Attributes.Processor_graphic = (processor.Attributes.Processor_graphic is null) ? null : (processor.Attributes.Processor_graphic.Length == 0) ? null : processor.Attributes.Processor_graphic;
            processor.Attributes.TechnologiesSTR = (processor.Attributes.TechnologiesSTR is null) ? null : (processor.Attributes.TechnologiesSTR == "Brak") ? null : processor.Attributes.TechnologiesSTR;
            processor.Attributes.Code = (processor.Attributes.Code is null) ? null : (processor.Attributes.Code.Length == 0) ? null : processor.Attributes.Code;
            return processor;
        }
        public static Product<ComputerCase> Return_checked_product(Product<ComputerCase> computercase)
        {
            computercase.Attributes.PhotoSTR = (computercase.Attributes.PhotoSTR is null) ? null : (computercase.Attributes.PhotoSTR.Length == 0) ? null : computercase.Attributes.PhotoSTR;
            computercase.Attributes.MaterialsSTR = (computercase.Attributes.MaterialsSTR is null) ? null : (computercase.Attributes.MaterialsSTR == "Brak") ? null : computercase.Attributes.MaterialsSTR;
            computercase.Attributes.Additional_informationSTR = (computercase.Attributes.Additional_informationSTR is null) ? null : (computercase.Attributes.Additional_informationSTR == "Brak") ? null : computercase.Attributes.Additional_informationSTR;
            computercase.Attributes.Side_panel = (computercase.Attributes.Side_panel is null) ? null : (computercase.Attributes.Side_panel.Length == 0) ? null : computercase.Attributes.Side_panel;
            computercase.Attributes.Backlight = (computercase.Attributes.Backlight is null) ? null : (computercase.Attributes.Backlight.Length == 0) ? null : computercase.Attributes.Backlight;
            computercase.Attributes.Power_supply_type = (computercase.Attributes.Power_supply_type is null) ? null : (computercase.Attributes.Power_supply_type.Length == 0) ? null : computercase.Attributes.Power_supply_type;
            computercase.Attributes.Space_for_discsSTR = (computercase.Attributes.Space_for_discsSTR is null) ? null : (computercase.Attributes.Space_for_discsSTR == "Brak") ? null : computercase.Attributes.Space_for_discsSTR;
            computercase.Attributes.Max_height_of_cooling = (computercase.Attributes.Max_height_of_cooling is null) ? null : (computercase.Attributes.Max_height_of_cooling == 0) ? null : computercase.Attributes.Max_height_of_cooling;
            computercase.Attributes.Fans_typesSTR = (computercase.Attributes.Fans_typesSTR is null) ? null : (computercase.Attributes.Fans_typesSTR.Length == 0) ? null : computercase.Attributes.Fans_typesSTR;
            computercase.Attributes.Water_cooling_optionsSTR = (computercase.Attributes.Water_cooling_optionsSTR is null) ? null : (computercase.Attributes.Water_cooling_optionsSTR == "Brak") ? null : computercase.Attributes.Water_cooling_optionsSTR;
            computercase.Attributes.Fans_types_installedSTR = (computercase.Attributes.Fans_types_installedSTR is null) ? null : (computercase.Attributes.Fans_types_installedSTR == "Brak") ? null : computercase.Attributes.Fans_types_installedSTR;
            computercase.Attributes.ButtonsSTR = (computercase.Attributes.ButtonsSTR is null) ? null : (computercase.Attributes.ButtonsSTR == "Brak") ? null : computercase.Attributes.ButtonsSTR;
            computercase.Attributes.Front_panel_outputsSTR = (computercase.Attributes.Front_panel_outputsSTR is null) ? null : (computercase.Attributes.Front_panel_outputsSTR == "Brak") ? null : computercase.Attributes.Front_panel_outputsSTR;
            computercase.Attributes.AccessoriesSTR = (computercase.Attributes.AccessoriesSTR is null) ? null : (computercase.Attributes.AccessoriesSTR == "Brak") ? null : computercase.Attributes.AccessoriesSTR;
            return computercase;
        }
        public static Product<Disc> Return_checked_product(Product<Disc> disc)
        {
            disc.Attributes.Destiny = (disc.Attributes.Destiny is null) ? null : (disc.Attributes.Destiny.Length == 0) ? null : disc.Attributes.Destiny;
            disc.Attributes.Write_speed = (disc.Attributes.Write_speed is null) ? null : (disc.Attributes.Write_speed == 0) ? null : disc.Attributes.Write_speed;
            disc.Attributes.Random_read_speed = (disc.Attributes.Random_read_speed is null) ? null : (disc.Attributes.Random_read_speed == 0) ? null : disc.Attributes.Random_read_speed;
            disc.Attributes.Random_write_speed = (disc.Attributes.Random_write_speed is null) ? null : (disc.Attributes.Random_write_speed == 0) ? null : disc.Attributes.Random_write_speed;
            disc.Attributes.Memory_type = (disc.Attributes.Memory_type is null) ? null : (disc.Attributes.Memory_type.Length == 0) ? null : disc.Attributes.Memory_type;
            disc.Attributes.Additional_informationSTR = (disc.Attributes.Additional_informationSTR is null) ? null : (disc.Attributes.Additional_informationSTR == "Brak") ? null : disc.Attributes.Additional_informationSTR;
            disc.Attributes.AccessoriesSTR = (disc.Attributes.AccessoriesSTR is null) ? null : (disc.Attributes.AccessoriesSTR == "Brak") ? null : disc.Attributes.AccessoriesSTR;
            disc.Attributes.Code = (disc.Attributes.Code is null) ? null : (disc.Attributes.Code.Length == 0) ? null : disc.Attributes.Code;
            disc.Attributes.PhotoSTR = (disc.Attributes.PhotoSTR is null) ? null : (disc.Attributes.PhotoSTR.Length == 0) ? null : disc.Attributes.PhotoSTR;
            return disc;
        }
        public static Product<Motherboard> Return_checked_product(Product<Motherboard> motherboard)
        {
            motherboard.Attributes.PhotoSTR = (motherboard.Attributes.PhotoSTR is null) ? null : (motherboard.Attributes.PhotoSTR.Length == 0) ? null : motherboard.Attributes.PhotoSTR;
            motherboard.Attributes.Arch_processSTR = (motherboard.Attributes.Arch_processSTR is null) ? null : (motherboard.Attributes.Arch_processSTR == "Brak") ? null : motherboard.Attributes.Arch_processSTR;
            motherboard.Attributes.Memory_typesSTR = (motherboard.Attributes.Memory_typesSTR is null) ? null : (motherboard.Attributes.Memory_typesSTR == "Brak") ? null : motherboard.Attributes.Memory_typesSTR;
            motherboard.Attributes.Memory_types_ocSTR = (motherboard.Attributes.Memory_types_ocSTR is null) ? null : (motherboard.Attributes.Memory_types_ocSTR == "Brak") ? null : motherboard.Attributes.Memory_types_ocSTR;
            motherboard.Attributes.Memory_max_size = (motherboard.Attributes.Memory_max_size is null) ? null : (motherboard.Attributes.Memory_max_size == 0) ? null : motherboard.Attributes.Memory_max_size;
            motherboard.Attributes.Memory_channel = (motherboard.Attributes.Memory_channel is null) ? null : (motherboard.Attributes.Memory_channel.Length == 0) ? null : motherboard.Attributes.Memory_channel;
            motherboard.Attributes.Internal_connectionSTR = (motherboard.Attributes.Internal_connectionSTR is null) ? null : (motherboard.Attributes.Internal_connectionSTR == "Brak") ? null : motherboard.Attributes.Internal_connectionSTR;
            motherboard.Attributes.Back_panel_portsSTR = (motherboard.Attributes.Back_panel_portsSTR is null) ? null : (motherboard.Attributes.Back_panel_portsSTR == "Brak") ? null : motherboard.Attributes.Back_panel_portsSTR;
            motherboard.Attributes.RaidSTR = (motherboard.Attributes.RaidSTR is null) ? null : (motherboard.Attributes.RaidSTR == "Brak") ? null : motherboard.Attributes.RaidSTR;
            motherboard.Attributes.Multi_cards = (motherboard.Attributes.Multi_cards is null) ? null : (motherboard.Attributes.Multi_cards.Length == 0) ? null : motherboard.Attributes.Multi_cards;
            motherboard.Attributes.Audio = (motherboard.Attributes.Audio is null) ? null : (motherboard.Attributes.Audio.Length == 0) ? null : motherboard.Attributes.Audio;
            motherboard.Attributes.Wireless_connection = (motherboard.Attributes.Wireless_connection is null) ? null : (motherboard.Attributes.Wireless_connection.Length == 0) ? null : motherboard.Attributes.Wireless_connection;
            motherboard.Attributes.Code = (motherboard.Attributes.Code is null) ? null : (motherboard.Attributes.Code.Length == 0) ? null : motherboard.Attributes.Code;
            return motherboard;
        }
        public static Product<GraphicCard> Return_checked_product(Product<GraphicCard> graphiccard)
        {
            graphiccard.Attributes.Cuda_cores = (graphiccard.Attributes.Cuda_cores is null) ? null : (graphiccard.Attributes.Cuda_cores == 0) ? null : graphiccard.Attributes.Cuda_cores;
            graphiccard.Attributes.Cooling = (graphiccard.Attributes.Cooling is null) ? null : (graphiccard.Attributes.Cooling.Length == 0) ? null : graphiccard.Attributes.Cooling;
            graphiccard.Attributes.OutputsSTR = (graphiccard.Attributes.OutputsSTR is null) ? null : (graphiccard.Attributes.OutputsSTR == "Brak") ? null : graphiccard.Attributes.OutputsSTR;
            graphiccard.Attributes.Graphic_apiSTR = (graphiccard.Attributes.Graphic_apiSTR is null) ? null : (graphiccard.Attributes.Graphic_apiSTR == "Brak") ? null : graphiccard.Attributes.Graphic_apiSTR;
            graphiccard.Attributes.Recommended_psu = (graphiccard.Attributes.Recommended_psu is null) ? null : (graphiccard.Attributes.Recommended_psu == 0) ? null : graphiccard.Attributes.Recommended_psu;
            graphiccard.Attributes.Tdp = (graphiccard.Attributes.Tdp is null) ? null : (graphiccard.Attributes.Tdp == 0) ? null : graphiccard.Attributes.Tdp;
            graphiccard.Attributes.AccessoriesSTR = (graphiccard.Attributes.AccessoriesSTR is null) ? null : (graphiccard.Attributes.AccessoriesSTR == "Brak") ? null : graphiccard.Attributes.AccessoriesSTR;
            graphiccard.Attributes.Code = (graphiccard.Attributes.Code is null) ? null : (graphiccard.Attributes.Code.Length == 0) ? null : graphiccard.Attributes.Code;
            graphiccard.Attributes.PhotoSTR = (graphiccard.Attributes.PhotoSTR is null) ? null : (graphiccard.Attributes.PhotoSTR.Length == 0) ? null : graphiccard.Attributes.PhotoSTR;
            return graphiccard;
        }
        public static Product<PowerSupply> Return_checked_product(Product<PowerSupply> Powersupply)
        {
            Powersupply.Attributes.PhotoSTR = (Powersupply.Attributes.PhotoSTR is null) ? null : (Powersupply.Attributes.PhotoSTR.Length == 0) ? null : Powersupply.Attributes.PhotoSTR;
            Powersupply.Attributes.Efficiency = (Powersupply.Attributes.Efficiency is null) ? null : (Powersupply.Attributes.Efficiency.Length == 0) ? null : Powersupply.Attributes.Efficiency;
            Powersupply.Attributes.Additional_informationSTR = (Powersupply.Attributes.Additional_informationSTR is null) ? null : (Powersupply.Attributes.Additional_informationSTR == "Brak") ? null : Powersupply.Attributes.Additional_informationSTR;
            Powersupply.Attributes.SecuritySTR = (Powersupply.Attributes.SecuritySTR is null) ? null : (Powersupply.Attributes.SecuritySTR == "Brak") ? null : Powersupply.Attributes.SecuritySTR;
            Powersupply.Attributes.ConnectorsSTR = (Powersupply.Attributes.ConnectorsSTR is null) ? null : (Powersupply.Attributes.ConnectorsSTR == "Brak") ? null : Powersupply.Attributes.ConnectorsSTR;
            Powersupply.Attributes.Pfc = (Powersupply.Attributes.Pfc is null) ? null : (Powersupply.Attributes.Pfc.Length == 0) ? null : Powersupply.Attributes.Pfc;
            Powersupply.Attributes.Fan = (Powersupply.Attributes.Fan is null) ? null : (Powersupply.Attributes.Fan.Length == 0) ? null : Powersupply.Attributes.Fan;
            return Powersupply;
        }
        public static Product<Radiator> Return_checked_product(Product<Radiator> Radiator)
        {
            Radiator.Attributes.PhotoSTR = (Radiator.Attributes.PhotoSTR is null) ? null : (Radiator.Attributes.PhotoSTR.Length == 0) ? null : Radiator.Attributes.PhotoSTR;
            Radiator.Attributes.FansSTR = (Radiator.Attributes.FansSTR is null) ? null : (Radiator.Attributes.FansSTR.Length == 0) ? null : Radiator.Attributes.FansSTR;
            Radiator.Attributes.Materials = (Radiator.Attributes.Materials is null) ? null : (Radiator.Attributes.Materials.Length == 0) ? null : Radiator.Attributes.Materials;
            Radiator.Attributes.Rps = (Radiator.Attributes.Rps is null) ? null : (Radiator.Attributes.Rps.Length == 0) ? null : Radiator.Attributes.Rps;
            Radiator.Attributes.Bearing = (Radiator.Attributes.Bearing is null) ? null : (Radiator.Attributes.Bearing.Length == 0) ? null : Radiator.Attributes.Bearing;
            Radiator.Attributes.Max_dB = (Radiator.Attributes.Max_dB is null) ? null : (Radiator.Attributes.Max_dB.Length == 0) ? null : Radiator.Attributes.Max_dB;
            Radiator.Attributes.Connectors = (Radiator.Attributes.Connectors is null) ? null : (Radiator.Attributes.Connectors.Length == 0) ? null : Radiator.Attributes.Connectors;
            Radiator.Attributes.Backlight = (Radiator.Attributes.Backlight is null) ? null : (Radiator.Attributes.Backlight.Length == 0) ? null : Radiator.Attributes.Backlight;
            Radiator.Attributes.Tdp = (Radiator.Attributes.Tdp is null) ? null : (Radiator.Attributes.Tdp.Length == 0) ? null : Radiator.Attributes.Tdp;
            Radiator.Attributes.Additional_informationSTR = (Radiator.Attributes.Additional_informationSTR is null) ? null : (Radiator.Attributes.Additional_informationSTR == "Brak") ? null : Radiator.Attributes.Additional_informationSTR;
            Radiator.Attributes.AccessoriesSTR = (Radiator.Attributes.AccessoriesSTR is null) ? null : (Radiator.Attributes.AccessoriesSTR == "Brak") ? null : Radiator.Attributes.AccessoriesSTR;
            Radiator.Attributes.Code = (Radiator.Attributes.Code is null) ? null : (Radiator.Attributes.Code.Length == 0) ? null : Radiator.Attributes.Code;
            return Radiator;
        }
        public static Product<Ram> Return_checked_product(Product<Ram> ram)
        {
            ram.Attributes.PhotoSTR = (ram.Attributes.PhotoSTR is null) ? null : (ram.Attributes.PhotoSTR.Length == 0) ? null : ram.Attributes.PhotoSTR;
            ram.Attributes.Series = (ram.Attributes.Series is null) ? null : (ram.Attributes.Series.Length == 0) ? null : ram.Attributes.Series;
            ram.Attributes.Timings = (ram.Attributes.Timings is null) ? null : (ram.Attributes.Timings.Length == 0) ? null : ram.Attributes.Timings;
            ram.Attributes.Memory_ecc = (ram.Attributes.Memory_ecc is null) ? null : (ram.Attributes.Memory_ecc.Length == 0) ? null : ram.Attributes.Memory_ecc;
            ram.Attributes.Additional_information = (ram.Attributes.Additional_information is null) ? null : (ram.Attributes.Additional_information.Length == 0) ? null : ram.Attributes.Additional_information;
            return ram;
        }

        private static string[] convertInputTextAreaToProjectSyntax(string input)
        {
            string[] result = input?.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            return result;
        }
        private static string[] getPhotos(int idproduct, List<IBrowserFile> loadedFiles)
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
        public static string How_long_ago(DateTime date)
        {
            string result = "";

            if ((DateTime.Now - date).Days == 0)
            {
                if ((DateTime.Now - date).Hours != 0)
                {
                    List<int> pl1 = new List<int> { 2, 3, 4, 22, 23, 24 };
                    if ((DateTime.Now - date).Hours == 1)
                    {
                        result = (DateTime.Now - date).Hours + " godzinę temu";
                    }
                    else
                    {
                        result = (pl1.Contains((DateTime.Now - date).Hours)) ? (DateTime.Now - date).Hours + " godziny temu" : (DateTime.Now - date).Hours + " godzin temu";
                    }
                }
                else
                {
                    if ((DateTime.Now - date).Minutes != 0)
                    {
                        List<int> pl1 = new List<int> { 2, 3, 4, 22, 23, 24, 32, 33, 34, 42, 43, 44, 52, 53, 54 };
                        if ((DateTime.Now - date).Minutes == 1)
                        {
                            result = (DateTime.Now - date).Minutes + " minutę temu";
                        }
                        else
                        {
                            result = (pl1.Contains((DateTime.Now - date).Minutes)) ? (DateTime.Now - date).Minutes + " minuty temu" : (DateTime.Now - date).Minutes + " minut temu";

                        }
                    }
                    else
                    {
                        List<int> pl1 = new List<int> { 2, 3, 4, 22, 23, 24, 32, 33, 34, 42, 43, 44, 52, 53, 54 };
                        if ((DateTime.Now - date).Seconds == 1)
                        {
                            result = (DateTime.Now - date).Seconds + " sekundę temu";
                        }
                        else
                        {
                            result = (pl1.Contains((DateTime.Now - date).Seconds)) ? (DateTime.Now - date).Seconds + " sekundy temu" : (DateTime.Now - date).Seconds + " sekund temu";
                        }
                    }
                }
            }
            else
            {
                if ((DateTime.Now - date).Days / 365 > 0)
                {
                    List<int> pl1 = new List<int> { 2, 3, 4, 22, 23, 24, 32, 33, 34, 42, 43, 44, 52, 53, 54 };
                    if ((DateTime.Now - date).Days / 365 == 1)
                    {
                        result = (DateTime.Now - date).Days / 365 + " rok temu";
                    }
                    else
                    {
                        result = (pl1.Contains((DateTime.Now - date).Days / 365)) ? (DateTime.Now - date).Days / 365 + " lata temu" : (DateTime.Now - date).Days / 365 + " lat temu";
                    }
                }
                else
                {
                    if ((DateTime.Now - date).Days / 7 > 0)
                    {
                        List<int> pl1 = new List<int> { 2, 3, 4, 22, 23, 24, 32, 33, 34, 42, 43, 44, 52, 53, 54 };
                        if ((DateTime.Now - date).Days / 7 == 1)
                        {
                            result = (DateTime.Now - date).Days / 7 + " tydzień temu";
                        }
                        else
                        {
                            result = (pl1.Contains((DateTime.Now - date).Days / 7)) ? (DateTime.Now - date).Days / 7 + " tygodnie temu" : (DateTime.Now - date).Days / 7 + " tygodni temu";

                        }
                    }
                    else
                    {
                        List<int> pl1 = new List<int> { 2, 3, 4, 22, 23, 24, 32, 33, 34, 42, 43, 44, 52, 53, 54 };

                        if ((DateTime.Now - date).Days == 1)
                        {
                            result = (DateTime.Now - date).Days + " dzień temu";
                        }
                        else
                        {
                            result = (DateTime.Now - date).Days + " dni temu";

                        }
                    }
                }
            }

            return result;
        }
        public static bool Check_if_url_has_right_query(Uri uri, int categoryId) {

            bool result = false;

            switch (categoryId)
            {
                case 1:
                    List<string> attributes = new List<string> {"brand","family" };
                    foreach (var item in attributes)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case 2:
                    List<string> attributes2 = new List<string> { "casetype","motherboard_type" };
                    foreach (var item in attributes2)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case 3:
                    List<string> attributes3 = new List<string> { "disctype","discformat" };
                    foreach (var item in attributes3)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case 4:
                    List<string> attributes4 = new List<string> {"producent","processor"  };
                    foreach (var item in attributes4)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case 5:
                    List<string> attributes5 = new List<string> { "format","socket" };
                    foreach (var item in attributes5)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case 6:
                    List<string> attributes6 = new List<string> { "standard", "certificate" };
                    foreach (var item in attributes6)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case 7:
                    List<string> attributes7 = new List<string> { "type","socket" };
                    foreach (var item in attributes7)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                case 8:
                    List<string> attributes8 = new List<string> { "type","gb" };
                    foreach (var item in attributes8)
                    {
                        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(item, out var _initialCount))
                        {
                            result = true;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;       
        }

        public async static Task Delete_Product_From_JSON(int index, string table,IWebHostEnvironment env)
        {
            switch (table)
            {
                case "Processors":
                    List<Product<Processor>> products = new List<Product<Processor>>();
                    foreach (var item in products)
                    {
                        item.Attributes = new Processor();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\processors.json"))
                    {
                        string json = r.ReadToEnd();
                        products = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Processor>>>(json));

                    }

                    products.Remove(products.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\processors.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products);
                    }
                    break;
                case "ComputerCases":
                    List<Product<ComputerCase>> products2 = new List<Product<ComputerCase>>();
                    foreach (var item in products2)
                    {
                        item.Attributes = new ComputerCase();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\computercases.json"))
                    {
                        string json = r.ReadToEnd();
                        products2 = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<ComputerCase>>>(json));

                    }

                    products2.Remove(products2.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\computercases.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products2);
                    }
                    break;
                case "Discs":
                    List<Product<Disc>> products3 = new List<Product<Disc>>();
                    foreach (var item in products3)
                    {
                        item.Attributes = new Disc();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\discs.json"))
                    {
                        string json = r.ReadToEnd();
                        products3 = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Disc>>>(json));

                    }

                    products3.Remove(products3.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\discs.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products3);
                    }
                    break;
                case "Motherboards":
                    List<Product<Motherboard>> products4 = new List<Product<Motherboard>>();
                    foreach (var item in products4)
                    {
                        item.Attributes = new Motherboard();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\motherboards.json"))
                    {
                        string json = r.ReadToEnd();
                        products4 = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Motherboard>>>(json));

                    }

                    products4.Remove(products4.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\motherboards.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products4);
                    }
                    break;
                case "GraphicCards":
                    List<Product<GraphicCard>> products5 = new List<Product<GraphicCard>>();
                    foreach (var item in products5)
                    {
                        item.Attributes = new GraphicCard();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\graphiccards.json"))
                    {
                        string json = r.ReadToEnd();
                        products5 = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<GraphicCard>>>(json));

                    }

                    products5.Remove(products5.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\graphiccards.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products5);
                    }
                    break;
                case "Powersupply":
                    List<Product<PowerSupply>> products6 = new List<Product<PowerSupply>>();
                    foreach (var item in products6)
                    {
                        item.Attributes = new PowerSupply();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\powersupplies.json"))
                    {
                        string json = r.ReadToEnd();
                        products6 = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<PowerSupply>>>(json));

                    }

                    products6.Remove(products6.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\powersupplies.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products6);
                    }
                    break;
                case "Radiators":
                    List<Product<Radiator>> products7 = new List<Product<Radiator>>();
                    foreach (var item in products7)
                    {
                        item.Attributes = new Radiator();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\radiators.json"))
                    {
                        string json = r.ReadToEnd();
                        products7 = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Radiator>>>(json));

                    }

                    products7.Remove(products7.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\radiators.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products7);
                    }
                    break;
                case "Rams":
                    List<Product<Ram>> products8 = new List<Product<Ram>>();
                    foreach (var item in products8)
                    {
                        item.Attributes = new Ram();
                    }
                    using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\rams.json"))
                    {
                        string json = r.ReadToEnd();
                        products8 = await Task.Run(() => JsonConvert.DeserializeObject<List<Product<Ram>>>(json));

                    }

                    products8.Remove(products8.Find(x => x.Id == index));

                    using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\rams.json"))
                    {
                        JsonSerializer serializer1 = new();
                        serializer1.Serialize(file1, products8);
                    }
                    break;
                default:
                    break;
            }


        }
        public async static void Create_JSON_From_ALLProducts(IConfiguration _config, IWebHostEnvironment env)
        {
            List<Product<Processor>> Processors = await SearchEngine.Processors_List_from_SQL(_config);
            List<Product<Disc>> Discs = await SearchEngine.Discs_List_from_SQL(_config);
            List<Product<GraphicCard>> GraphicCards = await SearchEngine.GraphicCards_List_from_SQL(_config);
            List<Product<Motherboard>> Motherboards = await SearchEngine.Motherboards_List_from_SQL(_config);
            List<Product<PowerSupply>> PowerSupplies = await SearchEngine.PowerSupplies_List_from_SQL(_config);
            List<Product<ComputerCase>> ComputerCases = await SearchEngine.ComputerCases_List_from_SQL(_config);
            List<Product<Radiator>> Radiators = await SearchEngine.Radiators_List_from_SQL(_config);
            List<Product<Ram>> Rams = await SearchEngine.Rams_List_from_SQL(_config);

            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\processors.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, Processors);

            using StreamWriter file2 = File.CreateText(env.WebRootPath +$"\\json\\discs.json");
            JsonSerializer serializer2 = new();
            serializer2.Serialize(file2, Discs);

            using StreamWriter file3 = File.CreateText(env.WebRootPath +$"\\json\\graphiccards.json");
            JsonSerializer serializer3 = new();
            serializer3.Serialize(file3, GraphicCards);

            using StreamWriter file4 = File.CreateText(env.WebRootPath +$"\\json\\motherboards.json");
            JsonSerializer serializer4 = new();
            serializer4.Serialize(file4, Motherboards);

            using StreamWriter file5 = File.CreateText(env.WebRootPath +$"\\json\\powersupplies.json");
            JsonSerializer serializer5 = new();
            serializer5.Serialize(file5, PowerSupplies);

            using StreamWriter file6 = File.CreateText(env.WebRootPath +$"\\json\\computercases.json");
            JsonSerializer serializer6 = new();
            serializer6.Serialize(file6, ComputerCases);

            using StreamWriter file7 = File.CreateText(env.WebRootPath +$"\\json\\radiators.json");
            JsonSerializer serializer7 = new();
            serializer7.Serialize(file7, Radiators);

            using StreamWriter file8 = File.CreateText(env.WebRootPath +$"\\json\\rams.json");
            JsonSerializer serializer8 = new();
            serializer8.Serialize(file8, Rams);

        }
        public async static Task<List<RandomProduct>> Get_Random_products(int amount, IWebHostEnvironment env)
        { 
             List<Product<Processor>> processor = await Read_Processors_From_JSON(env);
             List<Product<ComputerCase>> computercase = await Read_Computercases_From_JSON(env);
             List<Product<Disc>> disc = await Read_Discs_From_JSON(env);
             List<Product<Motherboard>> motherboard = await Read_Motherboards_From_JSON(env);
             List<Product<GraphicCard>> graphiccard = await Read_GraphicCards_From_JSON(env);
             List<Product<PowerSupply>> Powersupply = await Read_PowerSupplies_From_JSON(env);
             List<Product<Radiator>> radiator = await Read_Radiators_From_JSON(env);
             List<Product<Ram>> ram = await Read_Rams_From_JSON(env);

            List<RandomProduct> products = new List<RandomProduct>();
            foreach (var item in processor)
            {
                products.Add(new RandomProduct { ID = item.Id, Name=item.Name, Photo=item.Attributes.Photo[0], Price=(decimal)item.Price, Path="c/1/"+item.Id }) ;
            }
            foreach (var item in computercase)
            {
                products.Add(new RandomProduct { ID = item.Id, Name = item.Name, Photo = item.Attributes.Photo[0], Price = (decimal)item.Price, Path = "c/2/" + item.Id });
            }
            foreach (var item in disc)
            {
                products.Add(new RandomProduct { ID = item.Id, Name = item.Name, Photo = item.Attributes.Photo[0], Price = (decimal)item.Price, Path = "c/3/" + item.Id });
            }
            foreach (var item in motherboard)
            {
                products.Add(new RandomProduct { ID = item.Id, Name = item.Name, Photo = item.Attributes.Photo[0], Price = (decimal)item.Price, Path = "c/5/" + item.Id });
            }
            foreach (var item in graphiccard)
            {
                products.Add(new RandomProduct { ID = item.Id, Name = item.Name, Photo = item.Attributes.Photo[0], Price = (decimal)item.Price, Path = "c/4/" + item.Id });
            }
            foreach (var item in Powersupply)
            {
                products.Add(new RandomProduct { ID = item.Id, Name = item.Name, Photo = item.Attributes.Photo[0], Price = (decimal)item.Price, Path = "c/6/" + item.Id });
            }
            foreach (var item in radiator)
            {
                products.Add(new RandomProduct { ID = item.Id, Name = item.Name, Photo = item.Attributes.Photo[0], Price = (decimal)item.Price, Path = "c/7/" + item.Id });
            }
            foreach (var item in ram)
            {
                products.Add(new RandomProduct { ID = item.Id, Name = item.Name, Photo = item.Attributes.Photo[0], Price = (decimal)item.Price, Path = "c/8/" + item.Id });
            }
            var rnd = new Random();
            var randomNumbers = Enumerable.Range(0, products.Count-1).OrderBy(x => rnd.Next()).Take(amount).ToList();

            List<RandomProduct> result = new List<RandomProduct>();
            foreach (var item in randomNumbers)
            {
                result.Add(products[item]);
            }
            return result;
        }

        public async static Task Delete_Opinion_From_JSON(int index,IWebHostEnvironment env)
        {

            List<Opinions> products = new List<Opinions>();
            foreach (var item in products)
            {
                item.opinions_text = new List<Opinion>();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\opinions.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Opinions>>(json));
            }

            products.Remove(products.Find(x => x.productID == index));

            using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\opinions.json"))
            {
                JsonSerializer serializer1 = new();
                serializer1.Serialize(file1, products);
            }
        }
        public async static Task Add_Opinion_To_JSON(Opinions opinion, IWebHostEnvironment env)
        {
            List<Opinions> products = new List<Opinions>();
            foreach (var item in products)
            {
                item.opinions_text = new List<Opinion>();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\opinions.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Opinions>>(json));
            }

            products.Add(opinion);

            using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\opinions.json"))
            {
                JsonSerializer serializer1 = new();
                serializer1.Serialize(file1, products);
            }
        }
        public async static Task Edit_Opinion_JSON(Opinions opinion, IWebHostEnvironment env)
        {

            List<Opinions> products = new List<Opinions>();
            foreach (var item in products)
            {
                item.opinions_text = new List<Opinion>();
            }
            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\opinions.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Opinions>>(json));
            }

            products[products.IndexOf(products.Find(x => x.productID == opinion.productID))] = opinion;

            using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\opinions.json"))
            {
                JsonSerializer serializer1 = new();
                serializer1.Serialize(file1, products);
            }

        }
        public async static Task<List<Opinions>> Read_Opinions_From_JSON( IWebHostEnvironment env)
        {

            List<Opinions> products = new List<Opinions>();
            foreach (var item in products)
            {
                item.opinions_text = new List<Opinion>();
            }

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\opinions.json"))
            {
                string json = r.ReadToEnd();
                products = await Task.Run(() => JsonConvert.DeserializeObject<List<Opinions>>(json));

            }
            return products;
        }
        public async static Task<Opinions> Read_Opinion_From_JSON(int productID, IWebHostEnvironment env)
        {

            List<Opinions> products = await Read_Opinions_From_JSON(env);

            return products.Find(x => x.productID == productID);
        }      
        public async static Task Create_OPINIONS_FROM_ALL(IConfiguration _config, IWebHostEnvironment env)
        {

            List<Opinions> opinions = await SearchEngine.Opinions_List_from_SQL(_config);
            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\opinions.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, opinions);
        }

        public async static Task Add_Description_To_DB(ShortDesc desc, int productID, IWebHostEnvironment env, IConfiguration _config)
        {

            Description full_desc = new Description();
            full_desc.productID = productID;
            int count_not_null = 0;
            for (int i = 0; i < desc.Text.Length; i++)
            {
                if (!(desc.Title[i] is null || desc.Title[i].Length == 0 || desc.Text[i] is null || desc.Text[i].Length == 0))
                {
                    count_not_null++;

                }
            }

            string[] Text = new string[count_not_null];
            string[] Title = new string[count_not_null];
            string[] Photos = new string[count_not_null];

            for (int i = 0; i < desc.Text.Length; i++)
            {
                if (!(desc.Title[i] is null || desc.Title[i].Length == 0 || desc.Text[i] is null || desc.Text[i].Length == 0))
                {
                    Text[i] = desc.Text[i];
                    Title[i] = desc.Title[i];
                    if (desc.photos[i] is not null)
                    {
                        Stream stream = desc.photos[i].OpenReadStream(3072000);
                        var path = $"\\img\\photos_on_desc\\" + productID + "_" + i + "." + desc.photos[i].ContentType.Split('/')[desc.photos[i].ContentType.Split('/').Length - 1];
                        Photos[i] = path;
                        FileStream fs = File.Create(env.WebRootPath + path);
                        await stream.CopyToAsync(fs);
                        stream.Close();
                        fs.Close();
                    }
                    else
                    {
                        Photos[i] = null;
                    }
                }
            }
            full_desc.Photos = Photos;
            full_desc.Text = Text;
            full_desc.Title = Title;
            SqlDataAccess _data = new SqlDataAccess(_config);
            await _data.Update("insert into [Descriptions] ([productID],[TitleSTR],[TextSTR],[PhotosSTR]) values (@productID,@TitleSTR,@TextSTR,@PhotosSTR)", new { @productID = full_desc.productID, @TitleSTR = full_desc.TitleSTR, @TextSTR = full_desc.TextSTR, @PhotosSTR = full_desc.PhotosSTR });

            if (File.Exists(env.WebRootPath +$"\\json\\description.json"))
            {
                List<Description> descriptions = new List<Description>();

                using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\description.json"))
                {
                    string json = r.ReadToEnd();
                    descriptions = await Task.Run(() => JsonConvert.DeserializeObject<List<Description>>(json));
                }
                descriptions.Add(full_desc);

                using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\description.json"))
                {
                    JsonSerializer serializer1 = new();
                    serializer1.Serialize(file1, descriptions);
                }
            }
            else
            {
                List<Description> descriptions = new List<Description>();

                descriptions = await _data.LoadData<Description, dynamic>("Select * from Descriptions", new { });
                descriptions.Add(full_desc);
                using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\description.json"))
                {
                    JsonSerializer serializer1 = new();
                    serializer1.Serialize(file1, descriptions);
                }

            }
        }
        public async static Task Create_description_JSON(IConfiguration _config, IWebHostEnvironment env) {
            List<Description> descriptions = new List<Description>();
            SqlDataAccess _data = new SqlDataAccess(_config);
            descriptions = await _data.LoadData<Description, dynamic>("Select * from Descriptions", new { });
            using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\description.json"))
            {
                JsonSerializer serializer1 = new();
                serializer1.Serialize(file1, descriptions);
            }
        }
        public async static Task Edit_Description_To_DB(ShortDesc desc, int productID, IWebHostEnvironment env, IConfiguration _config)
        {

            Description full_desc = new Description();
            full_desc.productID = productID;
            int count_not_null = 0;
            for (int i = 0; i < desc.Text.Length; i++)
            {
                if (!(desc.Title[i] is null || desc.Title[i].Length == 0 || desc.Text[i] is null || desc.Text[i].Length == 0))
                {
                    count_not_null++;

                }
            }

            string[] Text = new string[count_not_null];
            string[] Title = new string[count_not_null];
            string[] Photos = new string[count_not_null];

            for (int i = 0; i < desc.Text.Length; i++)
            {
                if (!(desc.Title[i] is null || desc.Title[i].Length == 0 || desc.Text[i] is null || desc.Text[i].Length == 0))
                {
                    Text[i] = desc.Text[i];
                    Title[i] = desc.Title[i];
                    if (desc.photos[i] is not null)
                    {
                        Stream stream = desc.photos[i].OpenReadStream(3072000);
                        var path = $"\\img\\photos_on_desc\\" + productID + "_" + i + "." + desc.photos[i].ContentType.Split('/')[desc.photos[i].ContentType.Split('/').Length - 1];
                        Photos[i] = path;
                        FileStream fs = File.Create(env.WebRootPath + path);
                        await stream.CopyToAsync(fs);
                        stream.Close();
                        fs.Close();
                    }
                    else
                    {
                        Photos[i] = null;
                    }
                }
            }
            full_desc.Photos = Photos;
            full_desc.Text = Text;
            full_desc.Title = Title;

            SqlDataAccess _data = new SqlDataAccess(_config);
            List<int> checkidexist = await _data.LoadData<int, dynamic>("Select Count(*) from Descriptions where productID=@productID", new { @productID = productID });
            if (checkidexist[0] == 0)
            {
                await _data.Update("insert into [Descriptions] ([productID],[TitleSTR],[TextSTR],[PhotosSTR]) values (@productID,@TitleSTR,@TextSTR,@PhotosSTR)", new { @productID = full_desc.productID, @TitleSTR = full_desc.TitleSTR, @TextSTR = full_desc.TextSTR, @PhotosSTR = full_desc.PhotosSTR });

            }
            else
            {
                await _data.Update("update [Descriptions] set [TitleSTR]=@TitleSTR,[TextSTR]=@TextSTR,[PhotosSTR]=@PhotosSTR where [productID]=@productID", new { @productID = full_desc.productID, @TitleSTR = full_desc.TitleSTR, @TextSTR = full_desc.TextSTR, @PhotosSTR = full_desc.PhotosSTR });
            }

            if (File.Exists(env.WebRootPath +$"\\json\\description.json"))
            {
                List<Description> descriptions = new List<Description>();

                using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\description.json"))
                {
                    string json = r.ReadToEnd();
                    descriptions = await Task.Run(() => JsonConvert.DeserializeObject<List<Description>>(json));
                }
                if (descriptions.Find(x => x.productID == productID) is null)
                {
                    descriptions.Add(full_desc);
                }
                else
                {
                    descriptions[descriptions.IndexOf(descriptions.Find(x => x.productID == productID))] = full_desc;
                }


                using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\description.json"))
                {
                    JsonSerializer serializer1 = new();
                    serializer1.Serialize(file1, descriptions);
                }
            }
            else
            {
                List<Description> descriptions = new List<Description>();

                descriptions = await _data.LoadData<Description, dynamic>("Select * from Descriptions", new { });
                descriptions.Add(full_desc);
                using (StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\description.json"))
                {
                    JsonSerializer serializer1 = new();
                    serializer1.Serialize(file1, descriptions);
                }

            }

        }
        public async static Task<Description> Get_Discription_From_ProductID(int productID, IWebHostEnvironment env) {

            List<Description> descriptions = new List<Description>();
            Description result = new Description();

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\description.json"))
            {
                string json = r.ReadToEnd();
                descriptions = await Task.Run(() => JsonConvert.DeserializeObject<List<Description>>(json));
            }

            result = descriptions.Find(x => x.productID == productID);

            return result;
        }
        
        public async static Task Create_User(Register login, IConfiguration _config) 
        {
            SqlDataAccess _data = new(_config);

            var hasing = PasswordHashing.HashPassword(login.Password);

            await _data.Update("INSERT INTO [dbo].[Users]([UserName] ,[Salt] ,[Passhash] ,[Email],[UserRole]) VALUES (@UserName ,@Salt ,@Passhash ,@Email,@UserRole) ", new { @UserName=login.UserName, @Salt=hasing.Item1, @Passhash=hasing.Item2, @Email=login.Email, @UserRole="User" });

        }
        public async static Task<bool> UserExist(string username, IConfiguration _config)
        {
            SqlDataAccess _data = new(_config);
            List<int> exist= await _data.LoadData<int,dynamic>("SELECT COUNT(*) from Users where UserName=@username",new { @username=username });
            if (exist[0]==0)
            {
                return false;
            }
            return true;
        }
        public async static Task<UserSQL> Get_User_From_SQL(string username, IConfiguration _config) {

            SqlDataAccess _data = new(_config);
            List<UserSQL> result =await _data.LoadData<UserSQL, dynamic>("SELECT * from Users where UserName=@username", new { @username = username });

            return result[0];
        }
       
        public async static Task Create_TopMenu_JSON(IConfiguration _config, IWebHostEnvironment env) {

            Json_distinct dis = new Json_distinct();

            using (StreamReader r = new StreamReader(env.WebRootPath +$"\\json\\distinct.json"))
            {
                string json = r.ReadToEnd();
                dis = await Task.Run(() => JsonConvert.DeserializeObject<Json_distinct>(json));
            }

            TopMenuModel menu = new TopMenuModel();
            menu.Products_List = new List<Products>();

            SqlDataAccess _data = new SqlDataAccess(_config);

            Products p1 = new Products();
            p1.Product_name = "Procesory";
            p1.Product_link = "c/1";
            p1.Categories = new List<Category>();
            foreach (var item in dis.JSONProcessor.Brand)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = "Procesory "+item;
                c1.Category_link = "c/1?brand="+item;
                List<string> z = await _data.LoadData<string,dynamic>(@"exec distinctvaluesINNERADV @column='family', @table='Processors',@where='brand=''"+item+"'''", new { });
                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2;
                    s1.Subcategory_link = "c/1?brand=" + item +"&family="+item2;
                    c1.Subcategories.Add(s1);
                }
                p1.Categories.Add(c1);
            
            }
            menu.Products_List.Add(p1);

            Products p2 = new Products();
            p2.Product_name = "Obudowy";
            p2.Product_link = "c/2";
            p2.Categories = new List<Category>();
            foreach (var item in dis.JSONComputerCase.Type)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = item;
                c1.Category_link = "c/2?casetype=" + item;
                List<string> z = await _data.LoadData<string, dynamic>(@"exec distinctvaluesINNERADV @column='motherboards_typeSTR', @table='ComputerCases',@where='casetype=''" + item + "'''", new { });
                string[] single_values = new string[0];

                foreach (var item3 in z)
                {
                    single_values.Concat(item3?.Split('`'));
                }

                z = single_values.Distinct().ToList();

                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2;
                    s1.Subcategory_link = "c/2?casetype=" + item + "&motherboard_type=" + item2;
                    c1.Subcategories.Add(s1);
                }
                p2.Categories.Add(c1);

            }
            menu.Products_List.Add(p2);

            Products p3 = new Products();
            p3.Product_name = "Dyski";
            p3.Product_link = "c/3";
            p3.Categories = new List<Category>();
            foreach (var item in dis.JSONDisc.Type)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = "Dyski " + item;
                c1.Category_link = "c/3?disctype=" + item;
                List<string> z = await _data.LoadData<string, dynamic>(@"exec distinctvaluesINNERADV @column='discformat', @table='Discs',@where='disctype=''" + item + "'''", new { });
                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2;
                    s1.Subcategory_link = "c/3?disctype=" + item + "&discformat=" + item2;
                    c1.Subcategories.Add(s1);
                }
                p3.Categories.Add(c1);

            }
            menu.Products_List.Add(p3);

            Products p4 = new Products();
            p4.Product_name = "Karty Graficzne";
            p4.Product_link = "c/4";
            p4.Categories = new List<Category>();
            foreach (var item in dis.JSONGraphicCard.Producent)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = "Karty " + item;
                c1.Category_link = "c/4?producent=" + item;
                List<string> z = await _data.LoadData<string, dynamic>(@"exec distinctvaluesINNERADV @column='graphics_processing', @table='GraphicCards',@where='producent=''" + item + "'''", new { });
                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2;
                    s1.Subcategory_link = "c/4?producent=" + item + "&processor=" + item2;
                    c1.Subcategories.Add(s1);
                }
                p4.Categories.Add(c1);

            }
            menu.Products_List.Add(p4);

            Products p5 = new Products();
            p5.Product_name = "Płyty Główne";
            p5.Product_link = "c/5";
            p5.Categories = new List<Category>();
            foreach (var item in dis.JSONMotherboard.Format)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = "Płyty główne " + item;
                c1.Category_link = "c/5?format=" + item;
                List<string> z = await _data.LoadData<string, dynamic>(@"exec distinctvaluesINNERADV @column='socket', @table='Motherboards',@where='boardformat=''" + item + "'''", new { });
                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2;
                    s1.Subcategory_link = "c/5?format=" + item + "&socket=" + item2;
                    c1.Subcategories.Add(s1);
                }
                p5.Categories.Add(c1);

            }
            menu.Products_List.Add(p5);

            Products p6 = new Products();
            p6.Product_name = "Zasilacze";
            p6.Product_link = "c/6";
            p6.Categories = new List<Category>();
            foreach (var item in dis.JSONPowerSupply.Standard)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = "Zasilacze " + item;
                c1.Category_link = "c/6?standard=" + item;
                List<string> z = await _data.LoadData<string, dynamic>(@"exec distinctvaluesINNERADV @column='certificate_', @table='PowerSupply',@where='standard_=''" + item + "'''", new { });
                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2;
                    s1.Subcategory_link = "c/6?standard=" + item + "&certificate=" + item2;
                    c1.Subcategories.Add(s1);
                }
                p6.Categories.Add(c1);

            }
            menu.Products_List.Add(p6);

            Products p7 = new Products();
            p7.Product_name = "Chłodzenie CPU";
            p7.Product_link = "c/7";
            p7.Categories = new List<Category>();
            foreach (var item in dis.JSONRadiator.Cooling_type)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = "Chłodzenie " + item;
                c1.Category_link = "c/7?type=" + item;
                List<string> z = await _data.LoadData<string, dynamic>(@"exec distinctvaluesINNERADV @column='socketsSTR', @table='Radiators',@where='cooling_type=''" + item + "'''", new { });

                string[] single_values = new string[0];

                foreach (var item3 in z)
                {
                    single_values.Concat(item3?.Split('`'));
                }

                z = single_values.Distinct().ToList();

                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2;
                    s1.Subcategory_link = "c/7?type=" + item + "&socket=" + item2;
                    c1.Subcategories.Add(s1);
                }
                p7.Categories.Add(c1);

            }
            menu.Products_List.Add(p7);

            Products p8 = new Products();
            p8.Product_name = "Pamięci RAM";
            p8.Product_link = "c/8";
            p8.Categories = new List<Category>();
            foreach (var item in dis.JSONRam.Memory_type)
            {
                Category c1 = new Category();
                c1.Subcategories = new List<Subcategory>();
                c1.Category_name = "Pamięć Ram " + item;
                c1.Category_link = "c/8?type=" + item;
                List<int> z = await _data.LoadData<int, dynamic>(@"exec distinctvaluesINNERADV @column='memory_size_full', @table='Rams',@where='memory_type=''" + item + "'''", new { });
                
                foreach (var item2 in z)
                {
                    Subcategory s1 = new Subcategory();
                    s1.Subcategory_name = item2.ToString();
                    s1.Subcategory_link = "c/8?type=" + item + "&gb=" + item2;
                    c1.Subcategories.Add(s1);
                }
                p8.Categories.Add(c1);

            }
            menu.Products_List.Add(p8);


            using StreamWriter file1 = File.CreateText(env.WebRootPath +$"\\json\\topmenu.json");
            JsonSerializer serializer1 = new();
            serializer1.Serialize(file1, menu);


            Console.WriteLine();
        }        
    }
}
