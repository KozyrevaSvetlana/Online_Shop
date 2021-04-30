using Newtonsoft.Json;
using OnlineShopWebApp.Models;
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
        public static List<BasketList> GetAll()
        {
            if (!FileProvider.Exists(Path))
            {
                return new List<BasketList>();
            }
            var fileData = FileProvider.Get(Path);
            var bascetList = JsonConvert.DeserializeObject<List<BasketList>>(fileData);
            return bascetList;
        }

        public static void Save(List<BasketList> bascetList)
        {
            var jsonData = JsonConvert.SerializeObject(bascetList);
            FileProvider.Replace(Path, bascetList);
        }
    }
}
