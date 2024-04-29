using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab1
{
    public class Shedule
    {

        private string educationalInstitutionNumber;
        private string address;
        private string elem;


        public List<Shedule> shedules = new List<Shedule>();
        public List<Lesson> lessons = new List<Lesson>();
        public Shedule[] sheduleArray = new Shedule[5];

        //int countArr = 0;
        public Shedule()
        {
            this.educationalInstitutionNumber = null;
            this.address = null;
            Console.Write("Вызван конструктор без парметров\n");
        }
        public Shedule(string educationalInstitutionNumber, string address)
        {
            this.educationalInstitutionNumber = educationalInstitutionNumber;
            this.address = address;
            Console.WriteLine("Вызван конструктор с параметрами\n");
        }
        public Shedule(Shedule shed)
        {
            educationalInstitutionNumber = shed.educationalInstitutionNumber;
            address = shed.address;
            shedules = shed.shedules;
            Console.WriteLine("Вызван конструктор копирования");
        }
        public Shedule(Shedule shed, Shedule shedu)
        {
            educationalInstitutionNumber = shedu.educationalInstitutionNumber;
            address = shedu.address;
            shedules = shedu.shedules;
            educationalInstitutionNumber = null;
            address = null;
            shedules = new List<Shedule>();
            Console.WriteLine("Вызван конструктор перемещания:)");
        }


        ~Shedule()
        {
            this.educationalInstitutionNumber = null;
            this.address = null;
            Console.WriteLine("Вызван деструктор");
        }
        //int GetCountArr()
        //{
        //    return countArr;
        //}
        //void SetShedule(sheduleArray )
        //{

        //}
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
        private void EditS(string newEducationalInstitutionNumber, string newAddress)
        {
            educationalInstitutionNumber = newEducationalInstitutionNumber;
            address = newAddress;
        }

        public void CreateCopies(Shedule shedule, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Shedule copiedShedule = new Shedule(shedule);
                shedules.Add(copiedShedule);
            }
        }

        public void UseMoveConstructor(Shedule shed1, Shedule shed2)
        {
            Shedule moveShedule = new Shedule(shed1, shed2);

            moveShedule.shedules.Add(moveShedule);
        }

        public void Add()
        {
            while (true)
            {
                Console.WriteLine("Введите номер учебного заведения ");
                educationalInstitutionNumber = Console.ReadLine();
                if (!CheckNumber(educationalInstitutionNumber))
                {
                    Console.WriteLine("Номер введен некорректно");
                    continue;
                }
                Console.WriteLine("Введите адресс учебного заведения ");
                address = Console.ReadLine();
                Shedule shedule = new Shedule(educationalInstitutionNumber, address);
                shedules.Add(shedule);
                break;
            }
        }
        public void ShowShedule()
        {
            for (int i = 0; i < shedules.Count; i++)
            {
                Console.WriteLine($"Номер учебного заведения: {shedules[i].educationalInstitutionNumber}, " +
                    $"Адресс учебного заведения: {shedules[i].address}");
            }
        }
        public void RemoveShedule()
        {

            Console.WriteLine("Введите адресс учебного заведения которое хотите удалить");
            elem = Console.ReadLine();

            for (int i = 0; i < shedules.Count; i++)
            {
                if (shedules[i].address == elem)
                {
                    shedules.RemoveAt(i);
                }
            }
            elem = null;

        }
        public void EditShedule()
        {
            while (true)
            {
                Console.WriteLine("Введите адресс учебного заведения которое чтобы редактировать расписание");
                elem = Console.ReadLine();
                for (int i = 0; i < shedules.Count; i++)
                {
                    if (shedules[i].address == elem)
                    {
                        Console.WriteLine("Введите новый номер учебного заведения ");
                        string newNumber = Console.ReadLine();
                        if (!CheckNumber(newNumber))
                        {
                            Console.WriteLine("Номер введен некорректно");
                        }
                        Console.WriteLine("Введите новый адресс учебного заведения ");
                        string newAddress = Console.ReadLine();
                        shedules[i].EditS(newNumber, newAddress);
                    }


                }
                elem = null;
            }
        }


        public static Shedule operator +(Shedule shed, LaboratoryWork lab)
        {
            shed.lessons.Add(lab);
            return shed;
        }


        public static Shedule operator ++(Shedule shedule)
        {
            for (int i = 0; i < shedule.sheduleArray.Length - 1; i++)
            {
                shedule.sheduleArray[i] = new Shedule("asdasd", "sdasda");
            }

            return shedule;
        }
        public static Shedule operator <<(Shedule shed, int a)
        {
            Console.WriteLine($"Номер чего-то {shed.educationalInstitutionNumber} " +
                $"адресс чего-то {shed.address}");
            return shed;
        }
    }
}
