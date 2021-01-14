using System;

namespace Rental
{
    abstract class Auto : IAuto
    {
        public string autoCategory { get; set; } // категория товара
        public string name { get; set; } // название
        public double cost { get; set; } // цена

        public DateTime DreturnDate { get; set; } // время, спустя которое нужно вернуть товар

        public override string ToString() // переопределяем метод ToString() для сохранения в файл
        {
            return $"{autoCategory}%{name}%{cost}";
        }

        public void PrintAuto()
        {
            Console.WriteLine($"Класс авто: {autoCategory}\n" +
                $"Название авто: {name}\n" +
                $"Стоимость проката(в день): {cost}");
        }
    }
}
