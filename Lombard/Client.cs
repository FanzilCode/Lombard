using System;

namespace Rental
{
    class Client
    {
        public string lastName { get; private set; } // Фамилия
        public string name { get; private set; } // имя
        public string middleName { get; private set; } // отчество
        public string adress { get; private set; } // адрес
        public string email { get; private set; } // почта

        public Client(string line) // конструктор
        {
            string[] arr = line.Split('#'); // получаем на вход строку данных и делим её на элеметны по #
            // инициализуем автосв-ва класса
            string[] arr1 = arr[0].Split();
            lastName = arr1[0]; name = arr1[1]; middleName = arr1[2]; adress = arr[1]; email = arr[2];
        }

        public override string ToString() // переопределеняем метод ToString() для сохранения в файл
        {
            return $"{lastName} {name} {middleName}#{adress}#{email}";
        }
        // перегружаем операторы == и != для поиска клиентов в списке по данным
        public static bool operator ==(Client c1, Client c2)
        {
            return (c1.lastName == c2.lastName) && (c1.name == c2.name) && (c1.middleName == c2.middleName) && (c1.adress == c2.adress);
        }
        public static bool operator !=(Client c1, Client c2)
        {
            return !(c1 == c2);
        }

        public void PrintName() // печатаем ФИО клиента
        {
            Console.Write($"{lastName} {name} {middleName}");
        }
    }
}
