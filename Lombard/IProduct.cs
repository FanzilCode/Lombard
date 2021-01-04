using System;

namespace Lombard
{
    interface IProduct
    {
        string productCategory { get; set; } // категория товара
        string name { get; set; } // название
        string notation { get; set; } // примечание
        double actualCost { get; set; } // цена, заявленная при сдаче

        double maxCost { get; set; } // максимальная цена
        DateTime dateOfSaleToMaxCost { get; set; } // потенциальная дата продажи товара за максимальную цену
        
        double minCost { get; set; } // минимальная цена при распродаже
        DateTime dateOfSaleToMinCost { get; set; } // потенциальная дата продажи товара за минимальную цену

        DateTime DreturnDate { get; set; } // время, спустя которое нужно вернуть товар

        public abstract double GetCost();

        public void PrintProduct();
    }
}
