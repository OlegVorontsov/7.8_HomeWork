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
        static void putInfo(string fileName)
        {
            using (StreamWriter put = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                char key = 'д';
                do
                {
                    string line = string.Empty;

                    Console.Write("\nВведите ID сотрудника: ");
                    int ID = int.Parse(Console.ReadLine());

                    string nowDate = DateTime.Now.ToShortDateString();
                    string nowTime = DateTime.Now.ToShortTimeString();
                    Console.WriteLine($"Дата и время добавления записи: {nowDate} {nowTime}");

                    Console.Write("\nВведите Ф.И.О. сотрудника: ");
                    string fullName = Console.ReadLine();

                    Console.Write("\nВведите день рождения сотрудника: ");
                    int dayOfBirth = int.Parse(Console.ReadLine());
                    Console.Write("\nВведите месяц рождения сотрудника: ");
                    int monthOfBirth = int.Parse(Console.ReadLine());
                    Console.Write("\nВведите год рождения сотрудника: ");
                    int yearOfBirth = int.Parse(Console.ReadLine());

                    DateTime dateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                    string dateBirth = dateOfBirth.ToShortDateString();

                    int yearBirth = Convert.ToInt32(dateBirth.Substring(6));
                    int nowYear = Convert.ToInt32(nowDate.Substring(6));
                    int age = nowYear - yearBirth;
                    string ageTaken = Convert.ToString(age);
                    Console.WriteLine($"Возраст сотрудника: {ageTaken}");

                    Console.Write("\nВведите рост сотрудника: ");
                    int height = int.Parse(Console.ReadLine());

                    Console.Write("\nВведите место рождения сотрудника: ");
                    string placeBirth = Console.ReadLine();

                    line = $"{ID}#" + $"{nowDate} {nowTime}#" + $"{fullName}#" + $"{ageTaken}#" + $"{height}#" + $"{dateBirth}#" + $"{placeBirth}";

                    put.WriteLine(line);

                    Console.Write("Продожить (н/д): ");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }
        }
        static void Main(string[] args)
        {
            string Path = "Справочник.txt";
            Repository rep = new Repository(Path);

            Console.Write("Введите '0', чтобы создать файл Справочник сотрудников\n" +
                          "Введите '1', чтобы вывести данные о сотрудниках на экран\n" +
                          "Введите '2', чтобы внести данные о новых сотрудниках в Справочник: ");
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
                default:
                    Console.Write("Вы ввели не '1' и не '2'");
                    break;
            }



            Console.ReadLine();
        }
    }
}
