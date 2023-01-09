using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._8_HomeWork
{
    struct Worker
    {
        #region Поля
        /// <summary>
        /// Поле "Порядковый номер"
        /// </summary>
        private string id;

        /// <summary>
        /// Поле "Дата и время записи"
        /// </summary>
        private string dateandtime;

        /// <summary>
        /// Поле "Ф.И.О."
        /// </summary>
        private string fullName;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private string age;

        /// <summary>
        /// Поле "Рост"
        /// </summary>
        private string height;

        /// <summary>
        /// Поле "Дата рождения"
        /// </summary>
        private string dateBirth;

        /// <summary>
        /// Поле "Место рождения"
        /// </summary>
        private string placeBirth;
        #endregion

        #region Свойства
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Дата и время записи
        /// </summary>
        public string DateAndTime
        {
            get { return this.dateandtime; }
            set { this.dateandtime = value; }
        }

        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public string Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        /// <summary>
        /// Рост
        /// </summary>
        public string Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DateBirth
        {
            get { return this.dateBirth; }
            set { this.dateBirth = value; }
        }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceBirth
        {
            get { return this.placeBirth; }
            set { this.placeBirth = value; }
        }

        #endregion

        #region Конструктор
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="DateAndTime"></param>
        /// <param name="FullName"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="DateBirth"></param>
        /// <param name="PlaceBirth"></param>
        public Worker(string ID, string DateAndTime, string FullName, string Age, string Height, string DateBirth, string PlaceBirth)
        {
            this.id = ID;
            this.dateandtime = DateAndTime;
            this.fullName = FullName;
            this.age = Age;
            this.height = Height;
            this.dateBirth = DateBirth;
            this.placeBirth = PlaceBirth;
        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"{this.id,3}{this.dateandtime,25}{this.fullName,30}{this.age,10}{this.height,10}{this.dateBirth,15}{this.placeBirth,20}";
        }

        #endregion
    }
}
