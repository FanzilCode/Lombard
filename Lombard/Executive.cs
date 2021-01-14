using System;
namespace Rental
{
    class Executive : Auto // автомобиль
    {
        public Executive(string name, double cost) // конструктор
        {
            this.name = name; this.cost = cost;

            // категория втомобиля - представительский
            autoCategory = "Предтавительский";

            // авто нужно вернуть через 2 недели
            DreturnDate = new DateTime(1, 1, 15);
        }

        public Executive(string[] arr) // конструктор для чтения из файла
        {
            name = arr[1]; cost = Convert.ToDouble(arr[2]);

            // категория втомобиля - представительский
            autoCategory = "Представительский";

            // авто нужно вернуть через 2 недели
            DreturnDate = new DateTime(1, 1, 15);
        }
    }
}
