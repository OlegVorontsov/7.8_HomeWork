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
                Console.WriteLine("Файл уже существует");
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
        /// <param name="Path"></param>
        public void getInfo()
        {
            Console.WriteLine($"{this.titles[0],5}{this.titles[1],20}{this.titles[2],25}{this.titles[3],20}{this.titles[4],8}{this.titles[5],17}{this.titles[6],20}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.Workers[i].Print());
            }
        }

        /// <summary>
        /// Увеличение количества сотрудников
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
        /// Добавление сотрудника
        /// </summary>
        /// <param name="NewWorker"></param>
        public void Add(Worker NewWorker)
        {
            this.Resize(index >= this.Workers.Length);
            this.Workers[index] = NewWorker;
            this.index++;
        }

        #endregion
    }
}
