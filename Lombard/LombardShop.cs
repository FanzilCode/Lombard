using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace Lombard
{
    class LombardShop
    {
        List<PawnShop> pawnShop = new List<PawnShop>(); // связка товаров и клиентов

        public void SaveToFile(string path) // сохранение в файл
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
        public void ReadOnFile(string path) // чтение из файла
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] arr = sr.ReadLine().Split("#");
                IProduct product;
                switch(arr[0])
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
}
