using System;
namespace Lombard
{
    class Car : Product // автомобиль
    {
        public Car(string name, string notation, double actualCost) // конструктор
        {
            this.name = name; this.notation = notation; this.actualCost = actualCost;

            // ставим максимальную цену и потенциальну дату продажи по данной цене
            maxCost = 1.3 * actualCost; dateOfSaleToMaxCost = DateTime.Now; // лучше продать сейчас же

            // ставим минимальную цену и потенциальную дату продажи по данной цене
            minCost = 0.6 * actualCost; dateOfSaleToMinCost = new DateTime(DateTime.Now.Year + 15, DateTime.Now.Month, DateTime.Now.Day); // ч/з 15 лет уже лучше продать

            // категория товара - автомобиль
            productCategory = "Автомобиль";

            // сумму за автомобиль нужно вернуть через 5 лет
            DreturnDate = new DateTime(6, 1, 1);
        }

        public Car(string[] arr) // конструктор для чтения из файла
        {
            name = arr[1]; notation = arr[2]; actualCost = Convert.ToDouble(arr[3]);
            maxCost = Convert.ToDouble(arr[4]); dateOfSaleToMaxCost = Convert.ToDateTime(arr[5]);
            minCost = Convert.ToDouble(arr[6]); dateOfSaleToMinCost = Convert.ToDateTime(arr[7]);

            // категория товара - автомобиль
            productCategory = "Автомобиль";

            // сумму за автомобиль нужно вернуть через 6 лет
            DreturnDate = new DateTime(7, 1, 1);
        }

        public override double GetCost()
        {
            if (DateTime.Now >= dateOfSaleToMinCost)
                return minCost;
            if (DateTime.Now <= dateOfSaleToMaxCost)
                return maxCost;
            return Math.Abs(maxCost * (1 - Math.Abs(DateTime.Now.Year - dateOfSaleToMaxCost.Year) * 0.06)); // каждый год цена будет уменьшаться на 6%
        }
    }
}
