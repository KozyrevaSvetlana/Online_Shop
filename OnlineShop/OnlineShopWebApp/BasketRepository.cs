using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineShopWebApp.Models.Basket;

namespace OnlineShopWebApp
{
    public static class BasketRepository
    {
        public static string Path = "BascetRepository.json";
        public static List<BasketList> Get(BasketList product)
        {
            var bascetList = new List<BasketList>();
            if (!FileProvider.Exists(Path))
            {
                bascetList.Add(product);
                Save(bascetList);
            }
            else
            {
                var fileData = FileProvider.Get(Path);
                bascetList = JsonConvert.DeserializeObject<List<BasketList>>(fileData);
            }
            return bascetList;

        }

        public static void Add(BasketList product)
        {
            var bascetList = GetBascet();
            bascetList.Add(product);
            Save(bascetList);
        }
        private static void Save(List<BasketList> product)
        {
            var serializedData = JsonConvert.SerializeObject(product, Formatting.Indented);
            FileProvider.Replace(Path, product);
        }
    }

}
