using System;

namespace Lombard
{
    abstract class Product : IProduct
    {
        public string productCategory { get; set; } // категория товара
        public string name { get; set; } // название
        public string notation { get; set; } // примечание
        public double actualCost { get; set; } // цена, заявленная при сдаче

        public double maxCost { get; set; } // максимальная цена
        public DateTime dateOfSaleToMaxCost { get; set; } // потенциальная дата продажи товара за максимальную цену

        public double minCost { get; set; } // минимальная цена при распродаже
        public DateTime dateOfSaleToMinCost { get; set; } // потенциальная дата продажи товара за минимальную цену

        public DateTime DreturnDate { get; set; } // время, спустя которое нужно вернуть товар

        public override string ToString() // переопределяем метод ToString() для сохранения в файл
        {
            return $"{productCategory}#{name}#{notation}#{actualCost}#{maxCost}#{dateOfSaleToMaxCost}#{minCost}#{dateOfSaleToMinCost}";
        }
        public abstract double GetCost();
    }
}
