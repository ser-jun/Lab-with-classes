﻿using System;

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
            Console.WriteLine("15- оператор +");
            Console.WriteLine("16- оператор ++");
            Console.WriteLine("17- оператор <<");
            Console.WriteLine("18- оператор сравнения для класса Lecture");
            Console.WriteLine("19- оператор сравнения для класса LaboratoryWork");
            Console.WriteLine("20- оператор []");
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

                        LaboratoryWork laba = new LaboratoryWork(2, "dffwdf");
                        Shedule shedule2 = new Shedule();
                        shedule2 += laba;

                        foreach (Lesson lesson in shedule2.lessons)
                        {
                            Console.WriteLine(lesson);
                        }
                        break;
                    case 16:
                        shedule++;
                        Console.WriteLine(shedule);
                        break;
                        case 17:
                        Shedule shedule3 = new Shedule("3","dferfr");
                        int d=0;
                        shedule3=shedule3 << d;
                        break;
                        case 18:
                        Lecture lecture1 = new Lecture("time", "str", 4);
                        Lecture lecture2 = new Lecture("time", "str", 7);
                        Console.WriteLine($"{lecture1 > lecture2}\n {lecture1 < lecture2} \n {lecture1==lecture2}\n {lecture1!=lecture2}");
                        break;
                    case 19:
                        LaboratoryWork lab1 = new LaboratoryWork(2, "top");
                        LaboratoryWork lab2 = new LaboratoryWork(5, "top1");
                        Console.WriteLine($"{lab1 > lab2}\n {lab1<lab2} \n {lab1==lab2}\n {lab1!=lab2}");
                        break;
                    case 20:
                 
                        Shedule shedule6 = new Shedule();                        
                        shedule6[0] = new LaboratoryWork(2, "ded");                  
                        LaboratoryWork lab6 = shedule6[0];
                
                        break;
                }
                GC.Collect();

            }

        }

    }
}

