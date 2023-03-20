using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;

namespace Cs_Event_hw_11
{
    public delegate void WorckDelegate(string s);
    public delegate void MedicalExamination(string s);
    public delegate void DiplomaVerification(string s);
    public delegate void AgeVerification(string s);
    class Employee
    {
        
        public string name { get; set; }
        public string surname { get; set; }
        public string education { get; set; }
        public DateTime BD { get; set; }
        public int ball { get; set; }
        //------------------------------------------------------------
        public Employee() { }
        public Employee(string _name, string _surname, DateTime _bd)
        {
            name = _name;
            surname = _surname;
            BD = _bd;
        }
        public Employee(string _name, string _surname, DateTime _bd, string _education)
        {
            name = _name;
            surname = _surname;
            BD = _bd;
            education = _education;           
        }
        public void Work(string w)   => WriteLine($"{ToString()}  -  {w}");//4
        public void Probation(string w)  => WriteLine($"{ToString()}  -  {w}");//3
        public void Interview(string w) => WriteLine($"{ToString()}  -  {w}");//2
        public void Resumes(string w) => WriteLine($"{ToString()}  -  {w}");//1
        public override string ToString() => $"{surname.PadRight(14)} " +
            $"{name.PadRight(14)} {Convert.ToString(BD.ToShortDateString().PadRight(14))} " +
            $"{DateTime.Now.Year-BD.Year}     {education.PadRight(10)}";
        static public void ShowH()
        {
            WriteLine($"------------------------------------------------------------------");
            WriteLine($"Фамилия     |".PadRight(16)+ $"Имя       |".PadRight(12)+ $"Дата рождения|".PadRight(14)+ $"возраст|".PadRight(7)+ $"Образование |".PadRight(14));
            WriteLine($"------------------------------------------------------------------");
        }
       
    }
    class Employer
    {
        public event WorckDelegate       WorkEvent;
        public event MedicalExamination  ProbationEvent;
        public event DiplomaVerification InterviewEvent;
        public event AgeVerification     ResumesEvent;
        public void Work   (string str)   { if (WorkEvent != null)      WorkEvent(str);}
        public void Probation(string str) { if (ProbationEvent != null) ProbationEvent(str);}
        public void Interview(string str) { if (InterviewEvent != null) InterviewEvent(str);}
        public void Resumes(string str)   { if (ResumesEvent != null)   ResumesEvent(str);}
    } 
}
