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
        public override bool Equals(object obj) // переопределяем метод Equals для перегрузки операторов == и !=
        {
            Client c = obj as Client;

            if (c == null)
                return false;
            return (c.lastName == lastName) && (c.name == name) && (c.middleName == middleName) && (c.passNumber == passNumber)
                && (c.passSeries == passSeries) && (c.passDate == passDate);
        }
        // перегружаем операторы == и != для поиска клиентов в списке по данным
        public static bool operator ==(Client c1, Client c2)
        {
            return c1.Equals(c2);
        }
        public static bool operator !=(Client c1, Client c2)
        {
            return !c1.Equals(c2);
        }
    }
}
