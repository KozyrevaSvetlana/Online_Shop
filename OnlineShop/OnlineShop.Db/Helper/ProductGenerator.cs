using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using Image = OnlineShop.Db.Models.Image;

namespace OnlineShop.Db.Helper
{
    public static class ProductGenerator
    {
        public static List<Product> BaseProducts { get; set; } = new List<Product>();
        public static List<Image> BaseImages { get; set; } = new List<Image>();
        private static Random random = new Random();
        private static int count = 5;
        private static List<string> names = new List<string>
        {
            "Вилка",
            "Детское пюре",
            "Журнал",
            "Конструктор",
            "Крем",
            "Кукла",
            "Мишка",
            "Мячик",
            "Настольная игра",
            "Пирамидка",
            "Пистолетик",
            "Соска",
            "Чашка"
        };
        private static string rusLorem = @"Прежде всего, базовый вектор развития однозначно фиксирует необходимость своевременного 
выполнения сверхзадачи. Задача организации, в особенности же повышение уровня гражданского сознания не оставляет шанса для позиций, 
занимаемых участниками в отношении поставленных задач. Задача организации, в особенности же внедрение современных методик говорит о 
возможностях экспериментов, поражающих по своей масштабности и грандиозности. Внезапно, реплицированные с зарубежных источников,
современные исследования представлены в исключительно положительном свете. Ясность нашей позиции очевидна: постоянное 
информационно-пропагандистское обеспечение нашей деятельности прекрасно подходит для реализации соответствующих условий активизации. 
Принимая во внимание показатели успешности, реализация намеченных плановых заданий в значительной степени обусловливает важность системы 
обучения кадров, соответствующей насущным потребностям.
Прежде всего, внедрение современных методик создаёт необходимость включения в производственный план целого ряда внеочередных мероприятий 
с учётом комплекса модели развития. Принимая во внимание показатели успешности, укрепление и развитие внутренней структуры является 
качественно новой ступенью направлений прогрессивного развития. Однозначно, диаграммы связей набирают популярность среди определенных 
слоев населения, а значит, должны быть объявлены нарушающими общечеловеческие нормы этики и морали. С учётом сложившейся международной 
обстановки, разбавленное изрядной долей эмпатии, рациональное мышление позволяет оценить значение анализа существующих паттернов поведения.
Равным образом, современная методология разработки не даёт нам иного выбора, кроме определения позиций, занимаемых участниками в отношении
поставленных задач.
В рамках спецификации современных стандартов, представители современных социальных резервов неоднозначны и будут смешаны с не уникальными 
данными до степени совершенной неузнаваемости, из-за чего возрастает их статус бесполезности. Учитывая ключевые сценарии поведения, 
глубокий уровень погружения создаёт предпосылки для прогресса профессионального сообщества. Повседневная практика показывает, что 
повышение уровня гражданского сознания не оставляет шанса для экспериментов, поражающих по своей масштабности и грандиозности. 
Как принято считать, диаграммы связей и по сей день остаются уделом либералов, которые жаждут быть рассмотрены исключительно в разрезе 
маркетинговых и финансовых предпосылок. Равным образом, перспективное планирование выявляет срочную потребность дальнейших направлений 
развития. Являясь всего лишь частью общей картины, тщательные исследования конкурентов лишь добавляют фракционных разногласий и 
представлены в исключительно положительном свете.
Предварительные выводы неутешительны: новая модель организационной деятельности в значительной степени обусловливает важность 
благоприятных перспектив. Банальные, но неопровержимые выводы, а также интерактивные прототипы формируют глобальную экономическую 
сеть и при этом — заблокированы в рамках своих собственных рациональных ограничений. Сложно сказать, почему стремящиеся вытеснить 
традиционное производство, нанотехнологии и по сей день остаются уделом либералов, которые жаждут быть объявлены нарушающими 
общечеловеческие нормы этики и морали. Следует отметить, что высококачественный прототип будущего проекта обеспечивает актуальность 
направлений прогрессивного развития.
Современные технологии достигли такого уровня, что новая модель организационной деятельности влечет за собой процесс внедрения и 
модернизации модели развития. Современные технологии достигли такого уровня, что реализация намеченных плановых заданий обеспечивает 
актуальность анализа существующих паттернов поведения.";
        public static Product[] GeneradeRandomProduct()
        {
            foreach (var name in names)
            {
                var imagePath = $"wwwroot\\Images\\{name}\\";
                var files = Directory.GetFiles(imagePath);
                var nameImages = files.Select(x => new Image() { Id = Guid.NewGuid(), Url = x }).ToList();
                for (int i = 0; i < count; i++)
                {
                    var product = new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = $"{name} №{i + 1}",
                        Cost = random.Next(1, Int32.MaxValue),
                        Description = rusLorem.Substring(0, random.Next(rusLorem.Length / 2, rusLorem.Length))
                    };
                    nameImages.All(x => { x.ProductId = product.Id; return true; });
                    product.Images = nameImages;
                    BaseProducts.Add(product);
                    BaseImages.AddRange(nameImages);
                }

            }
            return BaseProducts.ToArray();
        }


        #region ToRemove
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
        #endregion
    }
}

