using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace Hospital_Ovning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor1 = new Doctor("Aldor", "Male", 39, "Doctor", 70000, "day", "surgeon");
            Doctor doctor2 = new Doctor("Chris", "Male", 38, "Doctor", 70000, "day", "Allround");
            Nurse nurse1 = new Nurse("Jon", "Male", 22, "Nurse", 30000, "day");
            Nurse nurse2 = new Nurse("Hanna", "Female", 30, "Nurse", 30000, "day");
            Nurse nurse3 = new Nurse("Ellen", "Female", 27, "Nurse", 30000, "night");
            Patient patience1 = new Patient("Alex", "Male", 25, "Headeach", "231020 15:00");

            doctor2.ClockIn();
            doctor2.EmployeeInfo();
            Console.WriteLine();
            nurse2.ClockIn();
            nurse2.EmployeeInfo();
            Console.WriteLine();           
            patience1.PatienceInfo();
            Console.WriteLine();
            nurse2.TakeBloodTest();
            Console.WriteLine();
            doctor2.WritePrescription();
            Console.WriteLine();
            patience1.PatienceDone();


        }
        //Person Class
        internal class Person
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int PersNr { get; set; }

            public Person(string name, string gender, int age)
            {
                Name = name;
                Gender = gender;
                Age = age;
            }
        }
        internal class HospitalEmployee : Person
        {
            public HospitalEmployee(string name, string gender, int age) : base(name, gender, age)
            {
            }

            public string Proffession { get; set; }
            public int Salary { get; set; }
            public string Shift { get; set; }

            public HospitalEmployee(string name, string gender, int age, string proffession, int salary, string shift) : base(name, gender, age)
            {
                Proffession = proffession;
                Salary = salary;
                Shift = shift;
            }

            //Method
            public void ClockIn()
            {
                Console.WriteLine($"{Name} clocked in {DateTime.Now}");
            }
            public void ClockOut()
            {
                Console.WriteLine($"{Name} clocked out {DateTime.Now}");
            }
            public void EmployeeInfo()
            {
                if (Proffession == "Doctor")
                {
                    Console.WriteLine($"Name:{Name} \nProffession:{Proffession} \nSalary:{Salary} \nShift:{Shift}");
                }
                else if (Proffession == "Nurse")
                {
                    Console.WriteLine($"Name:{Name} \nProffession:{Proffession} \nShift:{Shift}");
                }
                
            }
        }
        //Doctor Class
        internal class Doctor: HospitalEmployee
        {
            public Doctor(string name, string gender, int age) : base(name, gender, age)
            {
            }

            public Doctor(string name, string gender, int age, string proffession, int salary, string shift) : base(name, gender, age, proffession, salary, shift)
            {
            }

            public string Speciality { get; set; }
            public Doctor(string name, string gender, int age, string proffession, int salary, string shift, string speciality) : base(name, gender, age, proffession, salary, shift)
            {
                Speciality = speciality;
            }

            //Doctor Method
            public void WritePrescription()
            {
                Console.WriteLine($"{Name} writes prescription");
            }
        }
        //Nurse Class
        internal class Nurse : HospitalEmployee
        {
            public Nurse(string name, string gender, int age) : base(name, gender, age)
            {
            }

            public Nurse(string name, string gender, int age, string proffession, int salary, string shift) : base(name, gender, age, proffession, salary, shift)
            {
            }

            //Nurse Method
            public void TakeBloodTest()
            {
                Console.WriteLine($"{Name} took bloodtest");
            }
        }
        //Patience Class
        internal class Patient : Person
        {
            public Patient(string name, string gender, int age) : base(name, gender, age)
            {
            }

            public string Diagnosis { get; set; }
            public string AppointmentTime { get; set; }
            public string Prescription { get; set; }

            public Patient(string name, string gender, int age, string diagnosis, string appointmentTime) : base(name, gender, age)
            {
                Diagnosis = diagnosis;
                AppointmentTime = appointmentTime;
                //Prescription = presciption;
            }
            public Patient(string name, string gender, int age, string diagnosis, string appointmentTime, string presciption) : base(name, gender, age)
            {
                Diagnosis = diagnosis;
                AppointmentTime = appointmentTime;
                Prescription = presciption;
            }
            //Patience Method
            public bool Paid()
            {
                return true;
            }
            public void PatienceInfo()
            {
                Console.WriteLine($"Name:{Name} Appintment:{AppointmentTime}. Diagnos:{Diagnosis} ");
            }

            public void PatienceDone()
            {
                Prescription = "Alvedon";
                Console.WriteLine($"Name:{Name} Diagnos:{Diagnosis} Prescription:{Prescription} ");
            }

        }
    }
}