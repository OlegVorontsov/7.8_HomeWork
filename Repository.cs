using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._8_HomeWork
{
    class Repository
    {
        private Worker[] Workers;

        private string path;
        int index;
        string[] titles;

        #region Коструктор
        /// <summary>
        /// Создание репозитория
        /// </summary>
        /// <param name="Path"></param>
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[7];
            this.Workers = new Worker[2];
        }
        #endregion

        #region Методы
        /// <summary>
        /// Создание файла Справочник сотрудников
        /// </summary>
        /// <param name="Path"></param>
        public void CreateRepository(string Path)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
                using (StreamWriter makeTitles = new StreamWriter(Path, true, Encoding.UTF8))
                {
                    string line = string.Empty;
                    line = "Номер, Дата записи, Ф.И.О., Возраст, Рост, Дата рождения, Место рождения";
                    makeTitles.WriteLine(line);
                    Console.WriteLine("Файл Справочник создан");
                }
            }
            else
            {
                Console.WriteLine("Файл Справочник существует");
            }
        }

        /// <summary>
        /// Загрузка данных о сотрудниках из Справочника
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Add(new Worker(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));
                }
            }
        }

        /// <summary>
        /// Вывод Справочника сотрудников в консоль
        /// </summary>
        public void getInfo()
        {
            Console.WriteLine($"{this.titles[0],5}{this.titles[1],20}{this.titles[2],25}{this.titles[3],20}{this.titles[4],8}{this.titles[5],17}{this.titles[6],20}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.Workers[i].Print());
            }
        }

        /// <summary>
        /// Увеличение массива сотрудников
        /// </summary>
        /// <param name="Flag"></param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.Workers, this.Workers.Length * 2);
            }
        }

        /// <summary>
        /// Добавление сотрудника в массив
        /// </summary>
        /// <param name="NewWorker"></param>
        public void Add(Worker NewWorker)
        {
            this.Resize(index >= this.Workers.Length);
            this.Workers[index] = NewWorker;
            this.index++;
        }

        /// <summary>
        /// Добавление данных о сотрудниках в конец Справочника
        /// </summary>
        /// <param name="Path"></param>
        public void putWorker(string Path)
        {
            using (StreamWriter put = new StreamWriter(Path, true, Encoding.UTF8))
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

                    Console.Write("\nВведите дату рождения сотрудника (дд.мм.гггг): ");
                    DateTime enteredDate = DateTime.Parse(Console.ReadLine());
                    string dateBirth = enteredDate.ToShortDateString();

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

        /// <summary>
        /// Вывод данных о сотруднике по его ID
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="ID"></param>
        public void getWorkerByID(string Path, int ID)
        {
            int i = 0;
            bool IDnotFound = true;
            bool TitlesNotPrinted = true;
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Add(new Worker(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));

                    if (args[0] == ID.ToString())
                    {
                        if (TitlesNotPrinted)
                        {
                            Console.WriteLine($"{this.titles[0],5}{this.titles[1],20}{this.titles[2],25}{this.titles[3],20}{this.titles[4],8}{this.titles[5],17}{this.titles[6],20}");
                            TitlesNotPrinted = false;
                        }
                        Console.WriteLine(this.Workers[i].Print());
                        IDnotFound = false;
                    }
                    i++;
                }
                if (IDnotFound)
                {
                    Console.WriteLine($"Сотрудника с ID: {ID} нет в Справочнике");
                }
            }
        }

        /// <summary>
        /// Удаление данных о сотруднике по его ID
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="ID"></param>
        public void deleteWorkerByID(string Path, int ID)
        {
            int i = 0;
            bool IDnotFound = true;
            bool alreadyFound = true;

            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    if (args[0] != ID.ToString())
                    {
                        Add(new Worker(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));
                    }
                    else
                    {
                        if (alreadyFound)
                        {
                            Console.WriteLine($"Сотрудник(и) с ID: {ID} удален(ы) из Справочника");
                            alreadyFound = false;
                            IDnotFound = false;
                        }
                    }
                    i++;
                }
                if (IDnotFound)
                {
                    Console.WriteLine($"Сотрудника с ID: {ID} нет в Справочнике");
                }
            }
            File.Delete(Path);
            File.Create(Path).Close();
            using (StreamWriter sw = new StreamWriter(this.path, true, Encoding.UTF8))
            {
                string line = string.Empty;
                line = "Номер, Дата записи, Ф.И.О., Возраст, Рост, Дата рождения, Место рождения";
                sw.WriteLine(line);

                for (int j = 0; j < index; j++)
                {
                    string lineWorker = string.Empty;
                    lineWorker = $"{this.Workers[j].ID}#" + 
                                 $"{this.Workers[j].DateAndTime}#" + 
                                 $"{this.Workers[j].FullName}#" + 
                                 $"{this.Workers[j].Age}#" + 
                                 $"{this.Workers[j].Height}#" + 
                                 $"{this.Workers[j].DateBirth}#" + 
                                 $"{this.Workers[j].PlaceBirth}";
                    sw.WriteLine(lineWorker);
                }
            }
        }

        public void GetWorkersBetweenTwoDates(string Path, DateTime dateFrom, DateTime dateTo)
        {
            int i = 0;
            bool dateNotFound = true;
            bool TitlesNotPrinted = true;
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Add(new Worker(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));
                    DateTime dateBirthToCheck = DateTime.Parse(args[5]);

                    if ((dateFrom < dateBirthToCheck) && (dateBirthToCheck < dateTo))
                    {
                        if (TitlesNotPrinted)
                        {
                            Console.WriteLine($"{this.titles[0],5}{this.titles[1],20}{this.titles[2],25}{this.titles[3],20}{this.titles[4],8}{this.titles[5],17}{this.titles[6],20}");
                            TitlesNotPrinted = false;
                        }
                        Console.WriteLine(this.Workers[i].Print());
                        dateNotFound = false;
                    }
                    i++;
                }
                if (dateNotFound)
                {
                    Console.WriteLine($"В Справочнике нет сотрудников, чьи даты рождения находятся в диапазоне дат от {dateFrom.ToShortDateString()} до {dateTo.ToShortDateString()}");
                }
            }
        }

        #endregion
    }
}
