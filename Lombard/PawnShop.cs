using System;

namespace Lombard
{
    class PawnShop
    {
        public IProduct product { get; private set; } // товар
        public Client client { get; private set; } // клиент
        public double cost { get; private set; } // сумма
        public double commissions { get; private set; } // комиссионные
        public bool IsExpired { get; private set; } // перешёл ли товар в нашу собственность?
        DateTime deliveryDate { get; set; } // дата сдачи
        DateTime returnDate { get; set; } // дата возврата

        public PawnShop(IProduct product, Client client, double cost)
        {
            this.product = product; this.client = client; this.cost = cost; IsExpired = false;

            commissions = cost * 0.05; // комиссионные составляют 5% от стоимости товара
            deliveryDate = DateTime.Now;
            returnDate = new DateTime(deliveryDate.Year + product.DreturnDate.Year - 1, deliveryDate.Month + product.DreturnDate.Month - 1, deliveryDate.Day);


            Console.WriteLine($"Поздравляем! Вы получили {cost} рублей за залог.");
            PrintCheck();
        }

        public PawnShop(IProduct product, Client client, string[] arr)
        {
            this.product = product; this.client = client;
            cost = Convert.ToDouble(arr[0]); commissions = Convert.ToDouble(arr[1]);
            IsExpired = Convert.ToBoolean(arr[2]);
            deliveryDate = Convert.ToDateTime(arr[3]); returnDate = Convert.ToDateTime(arr[4]);
        }

        public bool Check() // проверяем, перешёл ли товар в нашу собственность и если да, то возвращаем true, иначе - false
        {
            if (IsExpired) // если товар уже в нашей собственности, то возвращаем true
                return true;
            if (DateTime.Now > returnDate) // если срок возврата истёк, товар переходит в нашу собственность
                IsExpired = true;
            return IsExpired;
        }

        public override string ToString()
        {
            Check();

            return $"{product}\n" +
                $"{client}\n" +
                $"{cost} {commissions} {IsExpired} {deliveryDate} {returnDate}";
        }

        public int Refund()
        {
            client.PrintName();
            Console.WriteLine($", вы хотите вернуть нам сумму в размере {cost} и получить свой залог обратно?\n1)Да\n2)Нет");
            int choise = Convert.ToInt32(Console.ReadLine());

            return choise;
        }

        public void PrintCheck()
        {

            Console.WriteLine("Клиент:");
            Console.WriteLine(client);

            Console.WriteLine("Товар:");
            product.PrintProduct();

            Console.WriteLine($"Дата сдачи: {deliveryDate}\n" +
                $"Необходимо вернуть до: {returnDate}\n");
        }
    }
}
