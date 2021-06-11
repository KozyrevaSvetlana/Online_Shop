using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public static class ProductGenerator
    {
        private static Random random = new Random();
        public static Product GeneradeRandomProduct()
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = names[random.Next(0, 21)],
                Cost = random.Next(1, 100001),
                Description = descriptions[random.Next(0, 28)],
                Image = "/img/Products/empty.gif"
            };
            return product;
        }

        private static List<string> names = new List<string>
        {
            "Мишка", "Кукла", "Конструктор", "Памперсы", "Детская смесь", "Ползунки", "Пирамидка",
            "Чашка", "Ложка", "Вилка", "Соска", "Пистолетик", "Распашонка", "Пелёнка", "Трусы", "Детское пюре",
            "Крем", "Мячик", "Журнал", "Настольная игра", "Шапка"
        };

        private static List<string> descriptions = new List<string>
        {
            "Супер", "Восторг", "Прекрасно", "Отлично", "Великолепно", "Ништяк", "Класс",
            "Гениально", "Превосходно", "Фантастика", "Нет слов", "Отменно", "Отпад", "Так себе",
            "Пойдёт", "Сойдёт", "Выше всяких похвал", "Сносно", "Неплохо", "Посредственно", "Никуда не годится",
            "Огонь!", "Потрясног", "Неказисто", "Непонятно", "Высший сорт", "Удивительно", "Приятно"
        };
    }
}

