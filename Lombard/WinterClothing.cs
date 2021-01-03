using System;
namespace Lombard
{
    class WinterClothing : Product // зимняя одежда
    {
        public WinterClothing(string name, string notation, double actualCost) // конструктор
        {
            this.name = name; this.notation = notation; this.actualCost = actualCost;

            // ставим максимальную цену и потенциальну дату продажи по данной цене
            maxCost = 1.4 * actualCost; dateOfSaleToMaxCost = new DateTime(DateTime.Now.Year, 12, 1);

            // ставим минимальную цену и потенциальную дату продажи по данной цене
            minCost = 0.7 * actualCost; dateOfSaleToMinCost = new DateTime(DateTime.Now.Year, 2, 28);

            // категория товара - зимняя одежда
            productCategory = "Зимняя одежда";

            // сумму за зимнюю одежду нужно вернуть через пол года
            DreturnDate = new DateTime(0, 6, 0);
        }

        public WinterClothing(string[] arr) // конструктор для чтения из файла
        {
            name = arr[1]; notation = arr[2]; actualCost = Convert.ToDouble(arr[3]);
            maxCost = Convert.ToDouble(arr[4]); dateOfSaleToMaxCost = Convert.ToDateTime(arr[5]);
            minCost = Convert.ToDouble(arr[6]); dateOfSaleToMinCost = Convert.ToDateTime(arr[7]);

            // категория товара - зимняя одежда
            productCategory = "Зимняя одежда";

            // сумму за зимнюю одежду нужно вернуть через пол года
            DreturnDate = new DateTime(0, 6, 0);
        }

        public override double GetCost()
        {
            
            if (DateTime.Now.Month == dateOfSaleToMaxCost.Month)
                return maxCost;
            if (DateTime.Now.Month == dateOfSaleToMinCost.Month)
                return minCost;
            return (maxCost - minCost)/2.0;
        }
    }
}
