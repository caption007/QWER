using System;
using System.Collections.Generic;
using System.IO;

struct Employee
{
    public int Id;
    public string Firstname;
    public string Lastname;
    public char Gender;
    public string Address;
    public DateTime Birth;
    public long Phone;
}

namespace EmployeeManagement
{

    class Program
    {

        static void Main(string[] args)
        {
            EmployeeManager st = new EmployeeManager();
            List<Staff> employee = new List<Staff>();
            Login();
            Menu();
            while (true)
            {
                StartCase(employee, st);
            }

        }

        private static void Login()  //登录
        {
            Console.WriteLine("please tall me,who are you?");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"Hello ,{name}, welcome to Employee Management System");

        }

        public static void Menu()  //菜单
        {

            Console.WriteLine("\n\n--------------------------------------------------------");
            Console.WriteLine("1.Display all existing employees    2. Add new employees");
            Console.WriteLine("3.Search existing employee info     4. Update employee info ");
            Console.WriteLine("5.Delete employee                   6. Exict    \n");
            Console.WriteLine("input  number! please!");
        }

        public static void StartCase(List<Staff> employee, EmployeeManager st) //功能实现
        {
            string index = Console.ReadLine();

            switch (index)
            {
                case "1":
                    st.ShowAll(employee);
                    Menu();
                    break;
                case "2": st.AddNew(employee); Menu(); break;
                case "3": st.Search(employee); Menu(); break;
                case "4": st.UpDate(employee); Menu(); break;
                case "5": st.Delete(employee); Menu(); break;
                case "6": Environment.Exit(0); break;
                default: st.ShowERR(employee); Menu(); break;

            }
        }

    }

}
