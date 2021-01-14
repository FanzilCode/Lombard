using System;

namespace Rental
{
    interface IAuto
    {
        string autoCategory { get; set; } // категория товара
        string name { get; set; } // название
        double cost { get; set; } // цена в день

        DateTime DreturnDate { get; set; } // время, спустя которое нужно вернуть авто

        public void PrintAuto();
    }
}
