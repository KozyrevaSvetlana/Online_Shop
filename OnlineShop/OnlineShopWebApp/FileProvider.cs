using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static OnlineShopWebApp.Models.Cart;

namespace OnlineShopWebApp
{
    public static class FileProvider
    {
        public static void Append(string path, List<BasketList> value)
        {
            var writer = new StreamWriter(path, true);
            writer.WriteLine(value);
            writer.Close();
        }

        public static void Replace(string path, List<BasketList> value)
        {
            var writer = new StreamWriter(path, true);
            writer.WriteLine(value);
            writer.Close();
        }

        public static string Get(string path)
        {
            var reader = new StreamReader(path);
            var fileData = reader.ReadToEnd();
            reader.Close();
            return fileData;
        }
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
