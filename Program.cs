using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._8_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "Справочник.txt";
            Repository rep = new Repository(Path);

            Console.Write("Введите '0', чтобы создать файл Справочник сотрудников\n" +
                          "Введите '1', чтобы вывести данные о сотрудниках из Справочника\n" +
                          "Введите '2', чтобы внести данные о новых сотрудниках в конец Справочника\n" +
                          "Введите '3', чтобы вывести данные о сотруднике по его ID\n");
            var input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    rep.CreateRepository(Path);
                    break;
                case "1":
                    rep.Load();
                    rep.getInfo();
                    break;
                case "2":
                    rep.CreateRepository(Path);
                    rep.putWorker(Path);
                    break;
                case "3":
                    rep.CreateRepository(Path);
                    Console.Write("Введите ID сотрудника: ");
                    int ID = int.Parse(Console.ReadLine());
                    rep.getWorkerByID(Path, ID);
                    break;
                default:
                    Console.Write("Вы ввели недопустимый символ");
                    break;
            }
            Console.ReadLine();
        }
    }
}
