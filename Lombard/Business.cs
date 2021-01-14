using System;

namespace Rental
{
    class Business : Auto // бытовая техника
    {
        public Business(string name, double cost) // конструктор
        {
            this.name = name; this.cost = cost;
            // категория автомобиля - бизнес
            autoCategory = "Бизнес";

            // сумму за бытовую технику нужно вернуть через 2 года
            DreturnDate = new DateTime(3, 1, 1);
        }

        public Business(string[] arr) // конструктор для чтения из файла
        {
            name = arr[1]; cost = Convert.ToDouble(arr[2]);

            // категория товара - бытовая техника
            autoCategory = "Бизнес";

            // авто нужно вернуть через месяц
            DreturnDate = new DateTime(1, 2, 1);

        }
    }
}
