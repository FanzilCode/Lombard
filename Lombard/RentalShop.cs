using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rental
{
    class RentalShop
    {
        static List<IAuto> cars = new List<IAuto>();
        static List<AutoShop> rental = new List<AutoShop>(); // аренда
        public static void SaveToFileCars(string path)
        {
            string strings = "";
            foreach (var c in cars)
                strings += c + "\n";
            strings = strings.Trim();

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(strings);
            }
        }
        public static void ReadOnFileCars(string path)
        {
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.Split("%");
                    IAuto auto;
                    if (arr[0] == "Представительский")
                    {
                        auto = new Executive(arr);
                    }
                    else
                    {
                        auto = new Business(arr);
                    }
                    cars.Add(auto);
                }
            }
        }

        public static void SaveToFile(string path) // сохранение в файл
        {
            string strings = "";
            foreach (var p in rental)
            {
                strings += p + "\n";
            }
            strings = strings.Trim();

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(strings);
            }
        }
        public static void ReadOnFile(string path) // чтение из файла
        {
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.Split("%");
                    IAuto auto;
                    if (arr[0] == "Представительский")
                    {
                        auto = new Executive(arr);
                    }
                    else
                    {
                        auto = new Business(arr);
                    }
                    Client client = new Client(sr.ReadLine());
                    arr = sr.ReadLine().Split();
                    rental.Add(new AutoShop(auto, client, arr));
                }
            }
        }
        public static void Refund(Client client)
        {
            bool IsAvailable = rental.Any(x => x.client == client); // проверяем, имеется ли данный клиент в базе

            if (IsAvailable)
            {
                int index = GetIndexClient(client);

                int choise = rental[index].Refund();

                if (choise == 1)
                {
                    Console.WriteLine($"Отлично!");
                    rental[index].Check();
                    Console.WriteLine("Поздравляю! Вы вернули автомобиль.");
                    rental.RemoveAt(index);
                }
            }
            else
            {
                Console.WriteLine("К сожалению, мы не нашли вас в нашей базе.");
            }
        }
        public static int GetIndexClient(Client client)
        {
            for (int i = 0; i < rental.Count; i++)
            {
                if (rental[i].client == client)
                    return i;
            }
            return -1;
        }

        public static void GetAuto(Client client)
        {
            int i = 0;

            Console.WriteLine("У нас есть следующие автомобили:");
            foreach (var c in cars)
            {
                c.PrintAuto();
                Console.WriteLine("Индекс: " + i);
                i++;
            }
            Console.WriteLine("Выберите авто(введите индекс): ");
            i = Convert.ToInt32(Console.ReadLine());
            IAuto auto = cars[i];
            auto.PrintAuto();
            Console.WriteLine("Вы согласны? Выберите:\n1) Да\t2) Нет");

            int choise2 = Convert.ToInt32(Console.ReadLine());

            if (choise2 == 1)
            {
                rental.Add(new AutoShop(auto, client));
            }
        }
        static void LogInAsClient()
        {

            int choise = 1;
            while (choise == 1 || choise == 2)
            {
                Console.WriteLine("Выберите:\n1) Хочу вернуть вам автомобиль\n2) Хочу арендовать автомобиль\n3) Выход");
                choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1 || choise == 2)
                {
                    Console.Write("Введите свои данные:\nФИО: ");
                    string strings = "";
                    strings += Console.ReadLine().Trim() + "#";
                    Console.Write("Адрес проживания: ");
                    strings += Console.ReadLine().Trim() + "#";
                    Console.Write("Email: ");
                    strings += Console.ReadLine().Trim() + "#";

                    Client client = new Client(strings);
                    if (choise == 1)
                        Refund(client);
                    else
                    {
                        GetAuto(client);
                    }
                }
            }
        }
        static void LogInAsAdmin()
        {
            string pass = " ";
            while (pass != "ТимурКрутой")
            {
                Console.Write("Пожалуйста, введите пароль: ");
                pass = Console.ReadLine();
                if (pass != "ТимурКрутой")
                    Console.WriteLine("Неверный пароль. Повторите попытку");
                else break;
            }
            if (pass == "ТимурКрутой")
            {
                Console.WriteLine("Пароль верный.");
                string choise = "1";
                while (choise != "4")
                {
                    Console.WriteLine("Выберите действие:\n1) Добавить автомобиль\t2) Посмотреть список арендованных авто\n3) Посмотреть список всех имеющихся автомобилей\t4) Выход");
                    choise = Console.ReadLine();
                    if (choise == "1")
                    {
                        Console.WriteLine("Выберите тип автомобиля:\n1) Представительский класс\t2) Бизнес-класс\n");
                        string type = Console.ReadLine();
                        Console.Write("Введите марку автомобиля: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите стоимость аренды в день (в рублях): ");
                        double cost = Convert.ToDouble(Console.ReadLine());

                        if (type == "1")
                            cars.Add(new Executive(name, cost));
                        else cars.Add(new Business(name, cost));
                    }
                    else if (choise == "2")
                    {
                        foreach (var r in rental)
                        {
                            r.PrintCheck();
                            Console.WriteLine();
                        }
                    }
                    else if (choise == "3")
                    {
                        foreach (var c in cars)
                        {
                            Console.WriteLine();
                            c.PrintAuto();
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"AutoShop.txt";
            ReadOnFile(path);
            string pathCar = @"Cars.txt";
            ReadOnFileCars(pathCar);
            Console.WriteLine("Выберите способ входа:\n1) Я клиент\t2) Я Администратор");
            string ch = Console.ReadLine();
            if (ch == "1")
                LogInAsClient();
            else if (ch == "2") LogInAsAdmin();
            SaveToFile(path);
            SaveToFileCars(pathCar);
        }

    }
}
