using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Helper
{
    public static class ProductGenerator
    {
        private static Random random = new Random();
        private static string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
            " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim " +
            "ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
            "ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate " +
            "velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat " +
            "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
        public static Product GeneradeRandomProduct(List<Image> images)
        {
            var product = new Product()
            {
                Id = System.Guid.NewGuid(),
                Name = names[random.Next(0, 21)],
                Cost = random.Next(1, 100001),
                Description = lorem.Substring(0, random.Next(10, lorem.Length)),
                Images = images
            };
            return product;
        }

        private static List<string> names = new List<string>
        {
            "Мишка", "Кукла", "Конструктор", "Памперсы", "Детская смесь", "Ползунки", "Пирамидка",
            "Чашка", "Ложка", "Вилка", "Соска", "Пистолетик", "Распашонка", "Пелёнка", "Трусы", "Детское пюре",
            "Крем", "Мячик", "Журнал", "Настольная игра", "Шапка"
        };

        public static Image[] GenerateBaseImages()
        {
            return new Image[]
            {
                new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/1.jpg",
                    ProductId = Guid.Parse("a3f432a9-17a0-4307-984b-290611a248f5")
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/2.jpg",
                    ProductId = Guid.Parse("c9f07f92-c9d5-4e8f-8093-5c242997ba82")
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/3.jpg",
                    ProductId = Guid.Parse("fe7524c9-a431-4b5b-83b2-9568c7f37bfa")
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/3.jpg",
                    ProductId = Guid.Parse("fce4ebfe-1ae7-4e47-b29f-1d34916fc298")
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/5.jpg",
                    ProductId = Guid.Parse("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/6.jpg",
                    ProductId = Guid.Parse("56db2983-947f-45d5-ba51-5d5cef5cf7a5")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/6.jpg",
                    ProductId = Guid.Parse("8002540c-9944-4b42-ac8c-01ad787e81e6")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/5.jpg",
                    ProductId = Guid.Parse("7a2227e4-4603-444f-ae2d-099079474ea0")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/4.jpg",
                    ProductId = Guid.Parse("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/3.jpg",
                    ProductId = Guid.Parse("e54fae4f-7d6c-4e34-aa1b-820cdc772653")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/2.jpg",
                    ProductId = Guid.Parse("615496eb-0537-4657-8237-f033266a3a57")
                }, new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/1.jpg",
                    ProductId = Guid.Parse("0cb8d9f0-c806-462c-a1b6-3f095b324761")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/2.jpg",
                    ProductId = Guid.Parse("27baabe2-d81b-4c46-86e0-23b97d7637c8")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/3.jpg",
                    ProductId = Guid.Parse("fbb6b537-d539-47ee-95c6-386b5ac0679a")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/4.jpg",
                    ProductId = Guid.Parse("a1ffa88c-1316-42a8-8601-95d70a65d150")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/5.jpg",
                    ProductId = Guid.Parse("0794a187-dfea-4807-9259-a7ff279455f2")
                }, new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/6.jpg",
                    ProductId = Guid.Parse("bb71353d-1a58-45a2-84da-9b4137bec6f6")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/4.jpg",
                    ProductId = Guid.Parse("755221a6-0f45-4e86-9948-6e9f85872734")
                }, new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/3.jpg",
                    ProductId = Guid.Parse("133788f9-139f-453e-b543-98b5876c4cb7")
                },new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "/img/Products/1.jpg",
                    ProductId = Guid.Parse("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f")
                }
            };
        }

        public static Product[] GenerateBaseProducts()
        {
            return new Product[]
            {
                new Product()
                {
                    Id = Guid.Parse("a3f432a9-17a0-4307-984b-290611a248f5"),
                    Cost = 11426,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    Name = "Пистолетик",
                },
                new Product()
                {
                    Id = Guid.Parse("c9f07f92-c9d5-4e8f-8093-5c242997ba82"),
                    Cost = 11426,
                    Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim",
                    Name = "Шапка",
                },
                new Product()
                {
                    Id = Guid.Parse("fe7524c9-a431-4b5b-83b2-9568c7f37bfa "),
                    Cost = 10398,
                    Description = "Ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ",
                    Name = "Конструктор",
                },
                new Product()
                {
                    Id = Guid.Parse("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"),
                    Cost = 94608,
                    Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate",
                    Name = "Пистолетик",
                },
                new Product()
                {
                    Id = Guid.Parse("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"),
                    Cost = 83000,
                    Description = "Velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat",
                    Name = "Мишка",
                },
                new Product()
                {
                    Id = Guid.Parse("56db2983-947f-45d5-ba51-5d5cef5cf7a5"),
                    Cost = 38020,
                    Description = "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                    Name = "Пирамидка",
                },
                new Product()
                {
                    Id = Guid.Parse("8002540c-9944-4b42-ac8c-01ad787e81e6"),
                    Cost = 59657,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing",
                    Name = "Трусы",
                },
                new Product()
                {
                    Id = Guid.Parse("7a2227e4-4603-444f-ae2d-099079474ea0"),
                    Cost = 73815,
                    Description = "Ex ea commodo consequat.Duis aute irure dolor",
                    Name = "Пистолетик",
                },
                new Product()
                {
                    Id = Guid.Parse("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"),
                    Cost = 66068,
                    Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna ",
                    Name = "Пистолетик",
                },
                new Product()
                {
                    Id = Guid.Parse("e54fae4f-7d6c-4e34-aa1b-820cdc772653"),
                    Cost = 51625,
                    Description = "Velit esse cillum dolore eu fugiat nulla pariatur.E",
                    Name = "Ложка",
                },
                new Product()
                {
                    Id = Guid.Parse("615496eb-0537-4657-8237-f033266a3a57"),
                    Cost = 76311,
                    Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                    Name = "Пистолетик",
                },
                new Product()
                {
                    Id = Guid.Parse("0cb8d9f0-c806-462c-a1b6-3f095b324761"),
                    Cost = 12248,
                    Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in v",
                    Name = "Соска",
                },
                new Product()
                {
                    Id = Guid.Parse("27baabe2-d81b-4c46-86e0-23b97d7637c8"),
                    Cost = 4225,
                    Description = "Ex ea commodo consequat.Duis aute i ",
                    Name = "Ложка",
                },
                new Product()
                {
                    Id = Guid.Parse("fbb6b537-d539-47ee-95c6-386b5ac0679a "),
                    Cost = 54643,
                    Description = "Minim veniam, quis nostrud exercitation ullamco laboris ",
                    Name = "Конструктор",
                },
                new Product()
                {
                    Id = Guid.Parse("a1ffa88c-1316-42a8-8601-95d70a65d150"),
                    Cost = 18346,
                    Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                    Name = "Шапка",
                },
                new Product()
                {
                    Id = Guid.Parse("0794a187-dfea-4807-9259-a7ff279455f2"),
                    Cost = 94741,
                    Description = "Ex ea commodo consequat.Duis aute irure dolor in r",
                    Name = "Кукла",
                },
                new Product()
                {
                    Id = Guid.Parse("bb71353d-1a58-45a2-84da-9b4137bec6f6"),
                    Cost = 6957,
                    Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                    Name = "Кукла",
                },
                new Product()
                {
                    Id = Guid.Parse("755221a6-0f45-4e86-9948-6e9f85872734"),
                    Cost = 82167,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    Name = "Ложка",
                },
                new Product()
                {
                    Id = Guid.Parse("133788f9-139f-453e-b543-98b5876c4cb7"),
                    Cost = 82167,
                    Description = "Velit esse cillum dolore eu fugiat nulla pariatur",
                    Name = "Чашка",
                },
                new Product()
                {
                    Id = Guid.Parse("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"),
                    Cost = 88268,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    Name = "Ползунки",
                }
            };
        }
    }
}

