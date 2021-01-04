using System;

namespace Lombard
{
    class Client
    {
        public string lastName { get; private set; } // Фамилия
        public string name { get; private set; } // имя
        public string middleName { get; private set; } // отчество
        public int passNumber { get; private set; } // номер паспорта
        public int passSeries { get; private set; } // серия паспорта
        public DateTime passDate { get; private set; } // дата выдачи паспорта

        public Client(string line) // конструктор
        {
            string[] arr = line.Split(); // получаем на вход строку данных и делим её на элеметны по пробелам
            // инициализуем автосв-ва класса
            lastName = arr[0]; name = arr[1]; middleName = arr[2];
            passNumber = Convert.ToInt32(arr[3]); passSeries = Convert.ToInt32(arr[4]);
            passDate = Convert.ToDateTime(arr[5]);
        }

        public override string ToString() // переопределеняем метод ToString() для сохранения в файл
        {
            return $"{lastName} {name} {middleName} {passNumber} {passSeries} {passDate}";
        }
        // перегружаем операторы == и != для поиска клиентов в списке по данным
        public static bool operator ==(Client c1, Client c2)
        {
            return (c1.lastName == c2.lastName) && (c1.name == c2.name) && (c1.middleName == c2.middleName) && (c1.passNumber == c2.passNumber)
                && (c1.passSeries == c2.passSeries) && (c1.passDate == c2.passDate);
        }
        public static bool operator !=(Client c1, Client c2)
        {
            return !(c1 == c2);
        }

        public void PrintName() // печатаем ФИО клиента
        {
            Console.Write($"{lastName} {name} {middleName}, ");
        }
    }
}
