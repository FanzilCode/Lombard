using System;

namespace Lombard
{
    class Appliances : Product // бытовая техника
    {
        public Appliances(string name, string notation, double actualCost) // конструктор
        {
            this.name = name; this.notation = notation; this.actualCost = actualCost;

            // ставим максимальную цену и потенциальну дату продажи по данной цене
            maxCost = 1.2 * actualCost; dateOfSaleToMaxCost = DateTime.Now; // лучше продать сейчас же

            // ставим минимальную цену и потенциальную дату продажи по данной цене
            minCost = 0.8 * actualCost; dateOfSaleToMinCost = new DateTime(DateTime.Now.Year + 3, DateTime.Now.Month + 6, DateTime.Now.Day); // ч/з 3.5 года уже лучше продать

            // категория товара - бытовая техника
            productCategory = "Бытовая техника";

            // сумму за бытовую технику нужно вернуть через 2 года
            DreturnDate = new DateTime(2, 0, 0);
        }

        public Appliances(string[] arr) // конструктор для чтения из файла
        {
            name = arr[1]; notation = arr[2]; actualCost = Convert.ToDouble(arr[3]);
            maxCost = Convert.ToDouble(arr[4]); dateOfSaleToMaxCost = Convert.ToDateTime(arr[5]);
            minCost = Convert.ToDouble(arr[6]); dateOfSaleToMinCost = Convert.ToDateTime(arr[7]);

            // категория товара - бытовая техника
            productCategory = "Бытовая техника";

            // сумму за бытовую технику нужно вернуть через 2 года
            DreturnDate = new DateTime(2, 0, 0);

        }
        public override double GetCost()
        {
            if (DateTime.Now >= dateOfSaleToMinCost)
                return minCost;
            if (DateTime.Now <= dateOfSaleToMaxCost)
                return maxCost;
            return Math.Abs(maxCost * (1 - Math.Abs(DateTime.Now.Year - dateOfSaleToMaxCost.Year) * 0.1)); // каждый год цена будет уменьшаться на 10%
        }
    }
}
