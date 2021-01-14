using System;

namespace Rental
{
    class AutoShop
    {
        public IAuto auto { get; private set; } // товар
        public Client client { get; private set; } // клиент
        DateTime deliveryDate { get; set; } // дата сдачи
        DateTime returnDate { get; set; } // дата возврата

        public AutoShop(IAuto auto, Client client)
        {
            this.auto = auto; this.client = client;

            deliveryDate = DateTime.Now;
            returnDate = new DateTime(deliveryDate.Year + auto.DreturnDate.Year - 1, deliveryDate.Month + auto.DreturnDate.Month - 1, deliveryDate.Day);

            PrintCheck();
        }

        public AutoShop(IAuto auto, Client client, string[] arr)
        {
            this.auto = auto; this.client = client;
            deliveryDate = Convert.ToDateTime(arr[0]); returnDate = Convert.ToDateTime(arr[1]);
        }

        public override string ToString()
        {
            return $"{auto}\n" +
                $"{client}\n" +
                $"{deliveryDate.ToShortDateString()} {returnDate.ToShortDateString()}";
        }

        public int Refund()
        {
            client.PrintName();
            Console.WriteLine($", вы хотите вернуть нам автомобиль обратно?\n1)Да\n2)Нет");
            int choise = Convert.ToInt32(Console.ReadLine());

            return choise;
        }

        public void PrintCheck()
        {

            Console.WriteLine("Клиент:");
            Console.WriteLine(client);

            Console.WriteLine("Товар:");
            auto.PrintAuto();

            Console.WriteLine($"Дата сдачи: {deliveryDate}\n" +
                $"Необходимо вернуть до: {returnDate}\n");
        }
        public void Check()
        {
            if(DateTime.Now > returnDate)
            {
                Console.WriteLine("Вы должны оплатить штраф на сумму " + 2*auto.cost*(365*(DateTime.Now.Year - returnDate.Year) + 30*(DateTime.Now.Month - returnDate.Month) + (DateTime.Now.Day - returnDate.Day)));
                Console.WriteLine("Пожалуйста подтвердите оплату.");
            }
        }
    }
}
