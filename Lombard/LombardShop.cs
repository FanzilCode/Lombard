using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lombard
{
    class LombardShop
    {
        static List<PawnShop> pawnShop = new List<PawnShop>(); // связка товаров и клиентов
        public static void SaveToFile(string path) // сохранение в файл
        {
            string strings = "";
            foreach(var p in pawnShop)
            {
                strings += p + "\n";
            }
            strings = strings.Trim();

            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(strings);
            }
        }
        public static void ReadOnFile(string path) // чтение из файла
        {
            string line;
            using (StreamReader sr = new StreamReader(path, true))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.Split("#");
                    IProduct product;
                    switch (arr[0])
                    {
                        case "Бытовая техника":
                            {
                                product = new Appliances(arr);
                                break;
                            }
                        case "Автомобиль":
                            {
                                product = new Car(arr);
                                break;
                            }
                        case "Зимняя одежда":
                            {
                                product = new WinterClothing(arr);
                                break;
                            }
                        default:
                            {
                                product = new Appliances(arr);
                                break;
                            }
                    }

                    Client client = new Client(sr.ReadLine());
                    arr = sr.ReadLine().Split();
                    pawnShop.Add(new PawnShop(product, client, arr));
                }
            }
        }

        public static void LogInAsClient() // Вход/регистрация как клиент
        {
            Console.Write("Введите свои данные:\nФИО: ");
            string strings = "";
            strings += Console.ReadLine().Trim() + " ";
            Console.Write("Серия паспорта: ");
            strings += Console.ReadLine().Trim() + " ";
            Console.Write("Номер паспорта: ");
            strings += Console.ReadLine().Trim() + " ";
            Console.Write("Дата выдачи паспорта: ");
            strings += Console.ReadLine().Trim();

            Client client = new Client(strings);

            Console.WriteLine("Выберите:\n1) Хочу вернуть вам деньги и забрать свой залог\n2) Хочу получить денежные средства под залог определённого товара");

            int choise = Convert.ToInt32(Console.ReadLine());

            if (choise == 1)
                Refund(client);
            else
            {
                GetMoney(client);
            }
        }
        public static void Refund(Client client)
        {
            bool IsAvailable = pawnShop.Any(x => x.client == client); // проверяем, имеется ли данный клиент в базе

            if(IsAvailable)
            {
                int index = GetIndexClient(client);

                int choise = pawnShop[index].Refund();

                if(choise == 1)
                {
                    Console.WriteLine($"Отлично! К оплате будет {pawnShop[index].cost} руб.");
                    Console.WriteLine("Поздравляю! Вы вернули долг, можете забрать свой залог.");
                    pawnShop.RemoveAt(index);
                }
            }
            else
            {
                Console.WriteLine("К сожалению, мы не нашли вас в нашей базе. Скорее всего срок возрата уже истёк.");
            }
        }
        public static int GetIndexClient(Client client)
        {
            for(int i = 0; i < pawnShop.Count; i++)
            {
                if (pawnShop[i].client == client)
                    return i;
            }
            return -1;
        }

        public static void GetMoney(Client client)
        {
            client.PrintName();
            Console.WriteLine("пожалуйста, введите данные о товаре, который вы хотите оставить в залог:");
            Console.WriteLine("Выберите категорию товара:\n1) Зимняя одежда\t2) Автомобиль\t3) Бытовая техника");
            int choise = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите название товара: ");
            string name = Console.ReadLine();
            Console.Write("Примечания: "); string notation = Console.ReadLine();
            Console.Write("Введите цену товара и покажите чек о покупке, пожалуйста: "); // что не обманули :)
            double cost = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Отлично, комиссионные будут составлять {cost * 0.15} руб, поэтому мы можем выдать вам {0.85 * cost} руб.");

            Console.WriteLine("Вы согласны? Выберите:\n1) Да\t2) Нет");

            int choise2 = Convert.ToInt32(Console.ReadLine());

            IProduct product;

            if(choise2 == 1)
            {
                switch(choise)
                {
                    case 1:
                        {
                            product = new WinterClothing(name, notation, cost);
                            break;
                        }
                    case 2:
                        {
                            product = new Car(name, notation, cost);
                            break;
                        }
                    default:
                        {
                            product = new Appliances(name, notation, cost);
                            break;
                        }
                }
                pawnShop.Add(new PawnShop(product, client, cost));
            }
        }

        static void Main(string[] args)
        {
            string path = @"PawnShop.txt";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            ReadOnFile(path);

            Console.WriteLine("Здравствуйте! Пожалуйста, выберите способ выхода:\n1) Я клиент\t2) Я администратор");

            int choise = Convert.ToInt32(Console.ReadLine());

            if (choise == 1)
                LogInAsClient();

            SaveToFile(path);

        }
    }
}
