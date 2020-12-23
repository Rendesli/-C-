using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Karina_s_project
{
    class Program
    {
        class Chicken
        {
            public int CKey { get; set; }
            public int Cell { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }
            public int Month_Eggs { get; set; }
            public string Breed { get; set; }
            public Chicken() { }
            public Chicken(int vk, int c, int w, int a, int me, string b)
            { CKey = vk; Cell = c; Weight = w; Age = a; Month_Eggs = me; Breed = b; }
        }
        class Hennery
        {
            public int Cell_Number { get; set; }
            public DateTime Date { get; set; }
            public int SumEgg { get; set; }
            public Hennery() { }
            public Hennery(int cn, DateTime d, int s)
            { Cell_Number = cn; Date = d; SumEgg = s; }
        }
        class Employee//работники
        {
            public string Full_Name { get; set; }//полное имя
            public string Cells { get; set; }//клетки
            public int Salary { get; set; }//зарплата
            public Employee() { }
            public Employee(string fn, string c, int sl)
            { Full_Name = fn; Cells = c; Salary = sl; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите число: 1 - что бы получить среднее количество яиц получаемое от каждой курицы даннного веса и возраста");
            // string n1 = Console.ReadLine();
            Console.WriteLine("Нажмите число: 2 - что бы получить общее кол-во яиц за диапазон дат и их суммарную стоимость.");
            // string n2 = Console.ReadLine();
            Console.WriteLine("Нажмите число: 3 - что бы получить общее кол-во яиц собранных каждым работником.");
            // string n3 = Console.ReadLine();
            Console.WriteLine("Нажмите число: 4 - что бы получить кур, которые снесли кол-во яиц ниже средней яйценоскости по фабрике.");
            // string n4 = Console.ReadLine();
            Console.WriteLine("Нажмите число: 5 - что бы получить клетку, в которой находится курица, от которой получили больше всего яиц");
            // string n5 = Console.ReadLine();
            Console.WriteLine("_____________________________________________________________________________________________________________");

            string answerN = Console.ReadLine();


            StreamReader FileIn = new StreamReader("C:/Users/Lenovo/Desktop/Файлы/ООП Бредихин/courseJob/Chickens.txt", Encoding.Default);
            int ck1, c1, w1, a1, me1;
            string s;
            string[] ms;
            Chicken C1 = new Chicken();
            List<Chicken> List_Chicken = new List<Chicken>(); ;
            while ((s = FileIn.ReadLine()) != null)
            {
                ms = s.Split(';');
                ck1 = int.Parse(ms[0]);
                c1 = int.Parse(ms[1]);
                w1 = int.Parse(ms[2]);
                a1 = int.Parse(ms[3]);
                me1 = int.Parse(ms[4]);
                List_Chicken.Add(new Chicken(ck1, c1, w1, a1, me1, ms[5]));
            }
            if (answerN == "1")
            {
                Console.WriteLine("Введите, пожалуйста, желаемый вес курицы! Курицы весят 5 и 6кг");
                int age = Convert.ToInt32(Console.ReadLine());//6
                Console.WriteLine("Введите, пожалуйста, желаемый возраст курицы. Возраст куриц на нашей фабрике достигает 46 дней | 40 дней | 53 дня");
                int weight = Convert.ToInt32(Console.ReadLine());//53
                Console.WriteLine("\n Выборка с помощью фильтра");

                List<Chicken> flst = new List<Chicken>();
                foreach (Chicken bl in List_Chicken)
                {
                    if (bl.Age == age)
                    {
                        if (bl.Weight == weight)
                        {
                            flst.Add(new Chicken(bl.CKey, bl.Cell, bl.Age, bl.Weight, bl.Month_Eggs, bl.Breed));
                        }
                    }
                }

                foreach (Chicken bl in flst)
                {
                    Console.WriteLine("{0,-12}\t{1,-8}\t{2}\t{3}\t{4}", bl.CKey, bl.Cell, bl.Age, bl.Weight, bl.Month_Eggs);
                }

                var testQuery = flst.Select(p => p.Month_Eggs);
                double sum = 0;
                double ser = 0;
                double i = 0;
                foreach (var testEggs in testQuery)
                {
                    i++;
                    sum += testEggs;
                    ser = sum / i;
                }
                Console.WriteLine("Средняя яйценоскость кур");
                Console.WriteLine(ser);

            }

            StreamReader FileIn2 = new StreamReader("C:/Users/Lenovo/Desktop/Файлы/ООП Бредихин/courseJob/Fabric.txt", Encoding.Default);
            int cn2;
            int sumEgg;
            string s2;
            DateTime dt;
            string[] ms2;
            Hennery H2 = new Hennery();
            List<Hennery> List_Hennery = new List<Hennery>();
            while ((s2 = FileIn2.ReadLine()) != null)
            {
                ms2 = s2.Split(';');
                // dt = DateTime.Parse(ms2[1]);
                sumEgg = int.Parse(ms2[2]);
                dt = DateTime.ParseExact(ms2[1], "dd.MM.yy", null);
                cn2 = int.Parse(ms2[0]);
                List_Hennery.Add(new Hennery(cn2, dt, sumEgg));
            }
            if (answerN == "2")
            {
                List<Hennery> lstHen = new List<Hennery>();
                Console.WriteLine("Введите диапазон дат за который вы хотите получить общее кол-во снесенных яиц");
                Console.WriteLine("Доступный диапазон с 01.06.2020 по 12.06.2020");
                Console.WriteLine("С какого числа:");
                DateTime diapason1 = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yy", null);
                Console.WriteLine("По какое число:");
                DateTime diapason2 = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yy", null);
                var sortList = List_Hennery.Where(item => item.Date >= diapason1 && item.Date <= diapason2).ToList();

                foreach (Hennery dat in sortList)
                {
                    Console.WriteLine("{0,-2}\t{1,-12}\t{2}", dat.Cell_Number, dat.Date.ToString("dd.MM.yy"), dat.SumEgg);
                }
                int sum = sortList.Select(item => item.SumEgg).Sum();
                Console.WriteLine("Общее количество яиц:" + sum);

                Console.WriteLine("Cуммарная стоимость всех яиц:" + sum * 2);
            }
            if (answerN == "4")
            {
                int ser = List_Chicken.Select(elem => elem.Month_Eggs).Sum() / List_Chicken.Count();
                Console.WriteLine("Средняя яйценоскость по фабрике:"+ ser);
                foreach (Chicken ch in List_Chicken)
                {
                    if (ser > ch.Month_Eggs)
                    {
                        Console.WriteLine("{0, -2}\t{1,-2}\t{2,-2}\t{3,-2}\t{4}\t{5}", ch.CKey, ch.Cell, ch.Age, ch.Weight, ch.Month_Eggs, ch.Breed);
                    }
                }
            }
            if (answerN == "5")
            {
                int max = List_Chicken.Select(item => item.Month_Eggs).Max();
                var chikens = List_Chicken.Where(item => item.Month_Eggs == max).Select(item => item.Cell);
                var cells = List_Hennery.Where(item => chikens.Contains(item.Cell_Number));

                foreach (var cell in cells)
                {
                    Console.WriteLine("Номер клетки:" + cell.Cell_Number);
                }
            }
            StreamReader FileIn3 = new StreamReader("C:/Users/Lenovo/Desktop/Файлы/ООП Бредихин/courseJob/Employer.txt", Encoding.Default);
            int sl3;
            string s3;
            string[] ms3;
            Employee E2 = new Employee();
            List<Employee> List_Employee = new List<Employee>();
            while ((s3 = FileIn3.ReadLine()) != null)
            {
                ms3 = s3.Split(';');
                sl3 = int.Parse(ms3[2]);
                List_Employee.Add(new Employee(ms3[0], ms3[1], sl3));
            }

            if (answerN == "3")
            {
                foreach (var emplTets in List_Employee)
                {
                    Console.WriteLine(emplTets.Full_Name);
                    var numberCells = emplTets.Cells.Split(',');
                    var emplWork = List_Hennery.Where(item => numberCells.Contains(item.Cell_Number.ToString())).ToList();
                    int eggs = emplWork.Select(elem => elem.SumEgg).Sum();
                    Console.WriteLine(eggs);
                }
            }
            Console.WriteLine("__________________________________________________________");
        }
    }
}




