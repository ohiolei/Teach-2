using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teach2
{
    public abstract class person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public person(int id, string name, int age)
        {
            ID = id;
            Name = name;
            Age = age;
        }
        public virtual void display()
        {
            Console.WriteLine("ID: {0} Name: {1} Age: {2}", ID, Name, Age);
        }

    }
    public abstract class employee : person
    {
        public int wage { get; set; }
        public employee(int id, string name, int age, int wage) : base(id, name, age)
        {
            this.wage = wage;
        }

        public override void display()
        {
            Console.WriteLine("ID: {0} Name: {1} Age: {2} Wage: {3}", ID, Name, Age, wage);
        }
    }

    public class programmer : employee
    {

        public programmer(int id, string name, int age, int wage) : base(id, name, age, wage)
        {

        }
        public override void display()
        {
            Console.WriteLine("Programmer   ID: {0} Name: {1} Age: {2} Wage: {3}", ID, Name, Age, wage);
        }
    }

    public class HR : employee
    {
        public HR(int id, string name, int age, int wage) : base(id, name, age, wage)
        {

        }
        public override void display()
        {
            Console.WriteLine("HR  ID: {0} Name: {1} Age: {2} Wage: {3}", ID, Name, Age, wage);
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {

            List<employee> human = new List<employee>();
            Console.WriteLine("Number of Employees");
            int noOfEmployee = Convert.ToInt32(Console.ReadLine());
            if (human.Count == 0)
            {
                for (int i = 0; i < noOfEmployee; i++)
                {
                    Console.WriteLine("press 1 for programmer and 2 for HR");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        programmer pr = new programmer(GetInt("enter ID"), GetString("enter name"), GetInt("enter age"), GetInt("enter wage"));
                        human.Add(pr);

                    }
                    if (choice == 2)
                    {
                        HR hr = new HR(GetInt("enter ID"), GetString("enter name"), GetInt("enter age"), GetInt("enter wage"));
                        human.Add((hr));
                    }
                }
            }

            IEnumerable<employee> employees = human.Where(h1 => h1.wage > 2000);
            foreach (employee employee in employees)
            {
                employee.display();
            }

        }

        public static int GetInt(string prompt)
        {
            Console.WriteLine("{0}", prompt);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static string GetString(string prompt)
        {
            Console.WriteLine("{0}", prompt);
            return Console.ReadLine();
        }
    }
}