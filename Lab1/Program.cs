using System;

namespace Lab1
{
    internal class Program
    {
        public void Menu()
        {
          
            Console.WriteLine("1-Добавить расписание");
            Console.WriteLine("2-Просмотреть список расписаний");
            Console.WriteLine("3-Удалить расписание");
            Console.WriteLine("4-Редактировать расписание");
            Console.WriteLine("5-Продемонстрировать работу конструктора копирования");
            Console.WriteLine("6-Вызов конструктора перемещения");
            Console.WriteLine("7-Добавить лабараторнуб работу");
            Console.WriteLine("8-Просмотреть");
            Console.WriteLine("9-Удалить лабу");
            Console.WriteLine("10-Редачить лабу");
            Console.WriteLine("11-Добавть лекцию");
            Console.WriteLine("12- просмотреть лекции");
            Console.WriteLine("13- Удалить лекцию");
            Console.WriteLine("14- редачить лекцию");
            Console.WriteLine("0-Выход=вызов деструктора");
        }
        static void Main(string[] args)
        {

            Shedule shedule = new Shedule();
            Shedule shedule1 = new Shedule();
            Program program = new Program();
            LaboratoryWork lab = new LaboratoryWork();
            Lecture lecture = new Lecture();
            int a = 1;

            while (a != 0)
            {
                program.Menu();
                a = Convert.ToInt32(Console.ReadLine());

                switch (a)
                {
                    
                    case 1:
                        shedule.Add();

                        break;
                    case 2:
                        shedule.ShowShedule();
                        break;
                    case 3:
                        shedule.RemoveShedule();
                        break;
                    case 4:
                        shedule.EditShedule();
                        break;
                    case 5:

                        Console.WriteLine("Введите количество копий:");
                        int copyCount = Convert.ToInt32(Console.ReadLine());
                        shedule.CreateCopies(shedule, copyCount);
                        break;
                    case 6:
                        shedule.UseMoveConstructor(shedule1, shedule);
                        break;
                   
                    case 7:

                        lab.Add();
                        break;
                    case 8:
                        lab.Show();
                        break;
                    case 9:
                        lab.RemoveFromShedule();
                        break;
                    case 10:
                        lab.EditLesson();
                        break;
                    case 11:
                        lecture.Add();
                        break;
                    case 12:
                        lecture.Show();
                        break;
                    case 13:
                        lecture.RemoveFromShedule();
                        break;
                    case 14:
                        lecture.EditLesson();
                        break;
                    case 15:
                        Lecture lecture1 = new Lecture();
                        Shedule shedule2 = new Shedule();
                        shedule2 = lecture1 + shedule2;
                        break;

                }
                GC.Collect();

            }

        }

    }
}

