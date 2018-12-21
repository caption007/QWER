using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    class Staff
    {
        public void STAFF(int id, string firstname, string lastname, char gender, string address, DateTime birth, long phone)
        {
            EmployeeId = id;
            EmployeeFName = firstname ;
            EmployeeLName = lastname;
            EmployeeGED = gender;
            EmployeeAddr = address;
            EmployeeBirth = birth;
            EmployeePhone = phone;
        }


        public int EmployeeId { get; set; }

        public string EmployeeFName { get; set; }

        public string EmployeeLName { get; set; }

        public char  EmployeeGED { get; set; }

        public string EmployeeAddr { get; set; }

        public DateTime EmployeeBirth { get; set; }

        public long EmployeePhone { get; set; }


        public void ShowStaff()
        {
            Console.Write("\n {0,-10}", EmployeeId);
            Console.Write(" {0,-15}", EmployeeFName);
            Console.Write(" {0,-15}", EmployeeLName);
            Console.Write(" {0,-30}", EmployeeGED);
            Console.Write(EmployeeBirth.ToString("yyyy / MM / dd"), EmployeeBirth);
            Console.Write("      {0,-20}", EmployeeAddr);
            Console.Write(" {0,-15}\n", EmployeePhone);
        }
    }
}
