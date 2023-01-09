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
                          "Введите '3', чтобы вывести данные о сотруднике по его ID\n" +
                          "Введите '4', чтобы удалить данные о сотруднике по его ID\n" +
                          "Введите '5', чтобы вывести данные о сотрудниках, чьи даты рождения находятся в указанном диапазоне дат \n");
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
                    int IDtoGet = int.Parse(Console.ReadLine());
                    rep.getWorkerByID(Path, IDtoGet);
                    break;
                case "4":
                    rep.CreateRepository(Path);
                    Console.Write("Введите ID сотрудника: ");
                    int IDtoDelete = int.Parse(Console.ReadLine());
                    rep.deleteWorkerByID(Path, IDtoDelete);
                    break;
                case "5":
                    rep.CreateRepository(Path);
                    Console.Write("Введите нижний предел диапазона дат (дд.мм.гггг): ");
                    DateTime dateFrom = DateTime.Parse(Console.ReadLine());
                    Console.Write("Введите верхний предел диапазона дат (дд.мм.гггг): ");
                    DateTime dateTo = DateTime.Parse(Console.ReadLine());
                    rep.GetWorkersBetweenTwoDates(Path, dateFrom, dateTo);
                    break;
                default:
                    Console.Write("Вы ввели недопустимый символ");
                    break;
            }
            Console.ReadLine();
        }
    }
}
