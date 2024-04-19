using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab1
{
    public abstract class Lesson
    {
        protected string name;
        protected string dayOfWeek;
        protected string time;
        private string elem;

        public List<Lesson> lessons = new List<Lesson>();
        public string GetName() { return name; }
        public string GetDayOfWeek() { return dayOfWeek; }
        public string GetTime() { return time; }
        public string SetName(string name) { return this.name = name; }
        public string SetDayOfWeek(string day) { return this.dayOfWeek = day; }
        public string SetTime(string time) { return this.time = time; }

        public Lesson(string Name, string DayOfWeek, string Time)
        {
            name = Name;
            dayOfWeek = DayOfWeek;
            time = Time;
            Console.WriteLine("Вызван конструктор с параметрами");
        }
        public Lesson()
        {
            this.name = null;
            this.dayOfWeek = null;
            this.time = null;
            Console.Write("Вызван конструктор без парметров\n");
        }
        public Lesson(Lesson lesson)
        {
            name = lesson.name;
            dayOfWeek = lesson.dayOfWeek;
            time = lesson.time;
            Console.WriteLine("Вызван конструктор копирования");
        }
        public void Edit(string newName, string newDayOfWeek, string newTime)
        {
            name = newName;
            dayOfWeek = newDayOfWeek;
            time = newTime;
        }
        public abstract void RemoveFromShedule();
        public abstract void Show();
        public abstract void EditLesson();

        public virtual void Add()
        {

            Console.WriteLine("Введите название предмета");
            string name = Console.ReadLine();

            Console.WriteLine("Введите день недели");
            string dayOfWeek = Console.ReadLine();
            if (!CheckDayOfWeek(dayOfWeek))
            {
                Console.WriteLine("День недели введен некорректно");

            }

            Console.WriteLine("Введите время");
            string time = Console.ReadLine();
            if (!CheckTime(time))
            {
                Console.WriteLine("Время введено некорректно");

            }
            SetName(name);
            SetDayOfWeek(dayOfWeek);
            SetTime(time);
            lessons.Add(this);


        }
        private bool CheckNumber(string num)
        {
            return int.TryParse(num, out _);
        }
        private bool CheckTime(string time)
        {
            string pattern = @"^(?:[01]\d|2[0-3]):[0-5]\d$";
            return Regex.IsMatch(time, pattern);
        }
        private bool CheckDayOfWeek(string day)
        {
            switch (day.ToLower())
            {
                case "понедельник":

                case "вторник":

                case "среда":

                case "четверг":

                case "пятница":

                case "суббота":

                case "воскресенье":

                    return true;
                default: return false;
            }
        }

        public void AddObjToList(Lecture lec)
        {
            lessons.Add(lec);
        }






    }


    public class LaboratoryWork : Lesson
    {
        private int numberOfLaboratoryWork;
        private string topic;

        public int GetNumber() { return numberOfLaboratoryWork; }
        public string GetTopic() { return topic; }
        public int SetNumber(int num)
        {
            numberOfLaboratoryWork = num;
            return numberOfLaboratoryWork;
        }
        public string SetTopic(string top)
        {
            topic = top;
            return topic;
        }

        public LaboratoryWork(string name, string dayOfWeek, string time, int numLab, string Top) : base(name, dayOfWeek, time)
        {

            numberOfLaboratoryWork = numLab;
            topic = Top;
            Console.WriteLine("Вызван конструктор с параметрами для класса LaboratoryWork");
        }
        public LaboratoryWork(int numLab, string Top)
        {

            numberOfLaboratoryWork = numLab;
            topic = Top;
            Console.WriteLine("Вызван конструктор с параметрами для класса LaboratoryWork");
        }
        public LaboratoryWork()
        {
            this.numberOfLaboratoryWork = 0;
            this.topic = null;

            Console.Write("Вызван конструктор без парметров\n");
        }
        public LaboratoryWork(LaboratoryWork lab)
        {
            numberOfLaboratoryWork = lab.numberOfLaboratoryWork;
            topic = lab.topic;

            Console.WriteLine("Вызван конструктор копирования");
        }

        ~LaboratoryWork()
        {
            numberOfLaboratoryWork = 0;
            topic = null;
            Console.WriteLine("вызван деструктор LAboratory Work");
        }
        public override void Add()
        {

            Console.WriteLine("Введите номер лабораторной работы\n");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите тему лабораторной работы");
            string topic = Console.ReadLine();
            base.Add();
            LaboratoryWork labWork = new LaboratoryWork(base.name, base.dayOfWeek, base.time, number, topic);
            lessons.Add(labWork);
        }

        public override void Show()
        {

            for (int i = 0; i < lessons.Count - 1; i++)
            {
                Console.WriteLine($"Название предмета {name}, день недели {dayOfWeek}, время {time} ");
            }

            foreach (var lab in lessons)
            {
                if (lab is LaboratoryWork && lab != null)
                {
                    LaboratoryWork labw = (LaboratoryWork)lab;
                    if (lab != null)
                    {

                        Console.WriteLine($"Номер лабораторной работы: {labw.GetNumber()}, Тема: {labw.GetTopic()}");
                    }
                }
            }


        }
        public override void RemoveFromShedule()
        {
            Console.WriteLine("Введите номер лабораторной работы, которую хотите удалить");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < lessons.Count; i++)
            {
                if (lessons[i] is LaboratoryWork)
                {
                    LaboratoryWork labWork = (LaboratoryWork)lessons[i];
                    if (labWork.GetNumber() == num)
                    {
                        lessons.RemoveAt(i);

                        return;
                    }
                }
            }


            Console.WriteLine($"Лабораторная работа с номером {num} не найдена.");
        }

        public override void EditLesson()
        {
            Console.WriteLine("Введите номер лабы которую хотите редачить");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < lessons.Count; i++)
            {
                if (lessons[i] is LaboratoryWork)
                {
                    LaboratoryWork labWork = (LaboratoryWork)lessons[i];
                    if ((labWork.GetNumber() == num))
                    {
                        Console.WriteLine("Введите новый номер лабы");
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новую тему лабы");
                        string top = Console.ReadLine();
                        labWork.SetNumber(number);
                        labWork.SetTopic(top);
                    }

                }
            }
        }
    }

    public class Lecture : Lesson
    {
        private string timel;
        private string nameOfLector;
        public string GetNameOfLector() { return nameOfLector; }
        public string GetTime() { return timel; }
        public string SetNameOfLector(string name)
        {
            return nameOfLector = name;

        }
        public string SetTime(string newTime)
        {
            return timel = newTime;
        }

        public Lecture(string TimeLect, string nameLect)
        {
            timel = TimeLect;
            nameOfLector = nameLect;
            Console.WriteLine("Вызван конструктор с параметрами для класса Lecture");
        }
        public Lecture(string name, string dayOfWeek, string time, string TimeLect, string nameLect) : base(name, dayOfWeek, time)
        {
            timel = TimeLect;
            nameOfLector = nameLect;
            Console.WriteLine("Вызван конструктор с параметрами для класса Lecture");
        }
        public Lecture()
        {
            this.timel = null;
            this.nameOfLector = null;
            Console.Write("Вызван конструктор без парметров\n");
        }
        public override void Add()
        {
            Console.WriteLine("Введите время лекции");
            timel = Console.ReadLine();
            Console.WriteLine("Введите название лекции");
            nameOfLector = Console.ReadLine();
            Lecture lec = new Lecture(timel, nameOfLector);
            base.Add();
            lessons.Add(lec);
        }
        public override void Show()
        {
            for (int i = 0; i < lessons.Count - 1; i++)
            {
                Console.WriteLine($"Название предмета {name}, день недели {dayOfWeek}, время {time} ");
            }
            for (int i = 0; i < lessons.Count - 1; i++)
            {
                Lecture lec = lessons[i] as Lecture;
                if (lec != null)
                {

                    Console.WriteLine($"Время лекции {lec.GetTime()}, Название лекции {lec.GetNameOfLector()}");
                }
            }

        }
        public override void RemoveFromShedule()
        {
            Console.WriteLine("Введите название лекции которую хотите удалить");
            string name = Console.ReadLine();
            for (int i = 0; i < lessons.Count; i++)
            {
                if (lessons[i] is Lecture)
                {
                    Lecture lec = (Lecture)lessons[i];

                    if (lec.GetNameOfLector() == name)
                    {
                        lessons.RemoveAt(i);
                        return;
                    }

                }
            }
        }
        public override void EditLesson()
        {
            Console.WriteLine("введите название лекии которую хоитите редачить");
            string name = Console.ReadLine();
            Console.WriteLine("Введите новое время лекции");
            string newTime = Console.ReadLine();
            Console.WriteLine("Введите новое название лекции");
            string newName = Console.ReadLine();
            for (int i = 0; i < lessons.Count; i++)
            {
                if (lessons[i] is Lecture)
                {
                    Lecture lec = (Lecture)lessons[i];
                    if (lec.GetNameOfLector() == name)
                    {
                        lec.SetNameOfLector(newName);
                        lec.SetTime(newTime);
                    }
                }
            }
        }
    }
}
