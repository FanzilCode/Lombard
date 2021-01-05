using System;
namespace Lombard
{
    class Realty : Product // зимняя одежда
    {
        public Realty(string name, string notation, double actualCost) // конструктор
        {
            this.name = name; this.notation = notation; this.actualCost = actualCost;

            // ставим максимальную цену и потенциальну дату продажи по данной цене
            maxCost = 1.4 * actualCost; dateOfSaleToMaxCost = new DateTime(DateTime.Now.Year + 15, 1, 1);

            // ставим минимальную цену и потенциальную дату продажи по данной цене
            minCost = 0.7 * actualCost; dateOfSaleToMinCost = DateTime.Now;

            // категория товара - Недвижимость
            productCategory = "Недвижимость";

            // сумму за недвижимость нужно вернуть через пол года
            DreturnDate = new DateTime(1, 7, 1);
        }

        public Realty(string[] arr) // конструктор для чтения из файла
        {
            name = arr[1]; notation = arr[2]; actualCost = Convert.ToDouble(arr[3]);
            maxCost = Convert.ToDouble(arr[4]); dateOfSaleToMaxCost = Convert.ToDateTime(arr[5]);
            minCost = Convert.ToDouble(arr[6]); dateOfSaleToMinCost = Convert.ToDateTime(arr[7]);

            // категория товара - Недвижимость
            productCategory = "Недвижимость";

            // сумму за недвижимость нужно вернуть через 20 лет
            DreturnDate = new DateTime(21, 1, 1);
        }

        public override double GetCost()
        {
            if (DateTime.Now >= dateOfSaleToMinCost)
                return minCost;
            if (DateTime.Now <= dateOfSaleToMaxCost)
                return maxCost;
            return Math.Abs(maxCost * (1 - Math.Abs(DateTime.Now.Year + dateOfSaleToMaxCost.Year) * 0.05)); // каждый год цена будет увеличиваться на 5 %
        }
    }
}
