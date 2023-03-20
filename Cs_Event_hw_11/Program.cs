using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;

namespace Cs_Event_hw_11
{
   
    class Program
    {
        static bool Age_V(Employee em)=> (DateTime.Now.Year- em.BD.Year) > 18 && (DateTime.Now.Year- em.BD.Year) < 50;
        static bool Work_w(Employee em) => em.ball>2;
        static void Main(string[] args)
        {
            p:
            int index = 0, i=0;
            Employer emp = new Employer();
            Random rnd = new Random();
            List<Employee> group = new List<Employee>
            {
                new Employee ( rndName1[rnd.Next(rndName1.Length)],rndSurName1[rnd.Next(rndSurName1.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                 new Employee ( rndName1[rnd.Next(rndName1.Length)],rndSurName1[rnd.Next(rndSurName1.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                new Employee ( rndName1[rnd.Next(rndName1.Length)],rndSurName1[rnd.Next(rndSurName1.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                 new Employee ( rndName1[rnd.Next(rndName1.Length)],rndSurName1[rnd.Next(rndSurName1.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                new Employee ( rndName1[rnd.Next(rndName1.Length)],rndSurName1[rnd.Next(rndSurName1.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                 new Employee ( rndName2[rnd.Next(rndName2.Length)],rndSurName2[rnd.Next(rndSurName2.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                 new Employee ( rndName2[rnd.Next(rndName2.Length)],rndSurName2[rnd.Next(rndSurName2.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                new Employee ( rndName2[rnd.Next(rndName2.Length)],rndSurName2[rnd.Next(rndSurName2.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                ,
                 new Employee ( rndName2[rnd.Next(rndName2.Length)],rndSurName2[rnd.Next(rndSurName2.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])
                 ,
                  new Employee ( rndName2[rnd.Next(rndName2.Length)],rndSurName2[rnd.Next(rndSurName2.Length)],
                new DateTime( rnd.Next(1973,2007),rnd.Next(1,12),rnd.Next(1,30)),rndEduc[rnd.Next(rndEduc.Length)])

            }; 

            do
            {
                Clear();
                if(i==0)WriteLine($"Резюме:");
                else if (i == 1) WriteLine($"Собеседование:");
                else if (i == 2) WriteLine($"Стажировка");
                Employee.ShowH();                
                Menu(group, index);
                WriteLine($"------------------------------------------------------------------");

                try
                {
                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (index < group.Count() - 1)
                                index++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (index > 0)
                                index--;
                            break;
                        case ConsoleKey.Enter:
                            {
                                Clear();
                                if (i==0)
                                {                                    
                                    if (group[index].ball == 0) 
                                    {
                                        emp.ResumesEvent += group[index].Resumes;
                                        group[index].ball++;
                                    } 
                                }
                                else if (i == 1)
                                {                                   
                                    if (group[index].ball == 1)
                                    {
                                        emp.InterviewEvent += group[index].Interview;
                                        group[index].ball++;
                                    }                                   
                                }
                                else if (i == 2)
                                {                                    
                                    if (group[index].ball == 2) 
                                    {
                                        emp.ProbationEvent += group[index].Probation;
                                        group[index].ball++;
                                    } 
                                }
                            }
                            break;
                        case ConsoleKey.Escape:
                            {
                                Environment.Exit(0);
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            {
                                Employee.ShowH();
                                if (i == 0)
                                {
                                    emp.Resumes("Приглашаем вас на собеседование");  
                                    group.RemoveAll(g=>g.ball<1);
                                    i++;
                                }                               
                                else  if (i == 1)
                                {
                                    emp.Interview("Приглашаем вас на стажировку");
                                    group.RemoveAll(g => g.ball < 2);
                                    i++;
                                }                               
                                else if (i == 2)
                                {
                                    emp.Probation("Вы успешно прошли стажировку");
                                    group.RemoveAll(g => g.ball < 3);
                                    i++;
                                }
                                ReadKey();
                                index = 0;
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    WriteLine($"{ex.Message}");
                }
            } while (i<3);

            Clear();
            List<Employee> em_w = group.FindAll(Work_w);
            foreach (Employee item in em_w)
            {
                emp.WorkEvent+=item.Work;
            }
            Employee.ShowH();
            emp.Work("Добро пожаловать в штат");
            WriteLine(); WriteLine();
            WriteLine();
            WriteLine($"Возобновить?\n1 - Да");i=int.Parse(ReadLine());
            if (i == 1) goto p;
        }
        private static void Menu(List<Employee> st, int _index)
        {
            for (int i = 0; i < st.Count; i++)
            {
                if (i == _index)
                {
                    BackgroundColor = ForegroundColor;
                    ForegroundColor = ConsoleColor.Black;
                }
                WriteLine(st[i]);
                ResetColor();
            }
            WriteLine();
        }


        static public string[] rndName1 = new string[] { "Константин", "Александр", "Лев", "Леонид", "Артём", "Иван", "Виталий", "Денис", "Илья", "Петр" };
        static public string[] rndSurName1 = new string[] { "Соколов", "Злобин", "Кулаков", "Ильин", "Кузнецов", "Антонов", "Чеботарев", "Зорин", "Иванов", "Головин" };
        static public string[] rndEduc = new string[] { "среднее", "ср.-спец.", "высшее" };
        static public string[] rndName2 = new string[] { "Виктория", "Диана", "Варвара", "Ольга", "Александра", "Дарья", "Анна", "Ева", "Клавдия", "Софья" };
        static public string[] rndSurName2 = new string[] { "Николаева", "Антонова", "Горохова", "Муравьева", "Воробьева", "Шилова", "Логинова", "Грачева", "Карпова", "Никольская" };
    }
}
