using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace EmployeeManagement
{
    class EmployeeManager
    {
        public void Delete(List<Staff> employee)   //删除员工
        {
            Console.WriteLine("input you want delete Id！");
            string Id = Convert.ToString(Console.ReadLine());
            string result = System.Text.RegularExpressions.Regex.Replace(Id, @"[^0-9]+", "");
            if (result == "")
            {
                Console.WriteLine("you input sting inexistence Number ！");
                Delete(employee);
                return;
            }
            int changeId = int.Parse(result);
            var major_key = employee.Find(em => em.EmployeeId == changeId);
            if (major_key != null)
            {
                employee.Remove(major_key);
                Console.WriteLine(" delete Id succeed！");
            }
            else
            {
                Console.WriteLine("sorry cannot delete is employee！");
                Console.WriteLine("this Id not exit!,you should input again!or exit");
                Console.WriteLine("if you want to  exit ,input: 0");
                string exitid = Console.ReadLine();
                int exitId = int.Parse(exitid);
                if (exitId == 0)
                {
                    return;
                }
                else
                {
                    Delete(employee);
                    return;
                }
            }
        }  

        public void AddNew(List<Staff> employee)  // 添加员工
        {
            Employee stf;
            Random ro = new Random();
            int iResult;
            int iUp = 100;
            int iDown = 1;
            iResult = ro.Next(iDown, iUp);
            Console.WriteLine("\nNow input in rule");
            while (true)
            {
                Console.WriteLine("input Id(I only record Numbers )");
                string Id = Convert.ToString(Console.ReadLine());
                string result2 = System.Text.RegularExpressions.Regex.Replace(Id, @"[^0-9]+", "");
                if (result2 == "")
                {
                    stf.Id = iResult;
                }
                else {
                    stf.Id = int.Parse(result2);
                }
                

                var major_key = employee.Find(em => em.EmployeeId == stf.Id);
                if (major_key == null)
                {
                    Console.WriteLine("this Id can register!");
                    break;
                }
                else
                {
                    Console.WriteLine("this Id had registered!,please change others Id!");

                }

            }  //id 验证输入

            Console.WriteLine("input firstname(Note: only read string)");  
            string result = Convert.ToString(Console.ReadLine());
            stf.Firstname =Regex.Replace(result, @"[^A-Za-z]+", "");

            Console.WriteLine("input lastname(Note: only read string)");
            string result1 = Convert.ToString(Console.ReadLine());
            stf.Lastname = Regex.Replace(result1, @"[^A-Za-z]+", "");

            while (true)
            {
                Console.WriteLine("input Gender: (M – Male; F – Female)");
                string Sex = Convert.ToString(Console.ReadLine());
                char EmployeeSex =char.Parse( Regex.Replace(Sex, @"[MFmf]+", ""));

                char sex = char.ToUpper(EmployeeSex);
                stf.Gender = sex;
                if (stf.Gender == 'M' || stf.Gender == 'F')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You input SEX wrong! input again!");
                }
            }//性别验证输入

            Console.WriteLine("input Address");
            stf.Address = Convert.ToString(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("input Birth:1990/01/01");

                try
                {
                    string date = Console.ReadLine();
                    stf.Birth = Convert.ToDateTime(date);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("wrong input in rule(1990/01/01)");
                }
            }//生日验证输入

            while (true)
            {
                Console.WriteLine("input phone(Note:length=11 )");
                stf.Phone = long.Parse(Console.ReadLine());
                string Vphone = stf.Phone.ToString();
                if (Vphone.Length == 11)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("input phone wrong!");
                }
            } //电话验证输入

            Staff st = new Staff();
            st.STAFF(stf.Id, stf.Firstname, stf.Lastname, stf.Gender, stf.Address, stf.Birth, stf.Phone);
            employee.Add(st);
        }

        public void UpDate(List<Staff> employee)  //更新员工数据
        {
            Console.WriteLine("input you want change Id！");
            string Id = Convert.ToString(Console.ReadLine());
            string result = System.Text.RegularExpressions.Regex.Replace(Id, @"[^0-9]+", "");
            if (result == "") {
                Console.WriteLine("you input sting inexistence Number ！");
                UpDate(employee);
                return;
            }
            
            int changeId = int.Parse(result);
           
            var major_key = employee.Find(em => em.EmployeeId == changeId);
            if (major_key != null)
            {
                Console.WriteLine("this Id exist!");

            }
            else
            {
                Console.WriteLine("this Id not exit!,you should input again!or exit");
                Console.WriteLine("if you want to  exit ,input: 0");
                string exitid = Console.ReadLine();
                int exitId = int.Parse(exitid);
                if (exitId == 0)
                {
                   
                    return;
                }
                else
                {
                    UpDate(employee);
                    return;
                }

            }


            Console.WriteLine("what date you want to change!");
            Console.WriteLine("1.change Id              2.change name");
            Console.WriteLine("3.change birth           4.change   address");
            Console.WriteLine("5.change phone           6.change   gender");
            Console.WriteLine("7,Back to Previous Level");
            Console.WriteLine("input you number, please!");
            string updatenumber = Console.ReadLine();
            switch (updatenumber)
            {
                case "1": UpId(changeId, employee); break;
                case "2": UpName(changeId, employee); break;
                case "3": UpBirth(changeId, employee); break;
                case "4": UpAddr(changeId, employee); break;
                case "5": UpPhone(changeId, employee); break;
                case "6": UpGender(changeId, employee); break;
                case "7":; break;
                default: ShowERR(employee); UpDate(employee); break;
            }

        }

        public void ShowAll(List<Staff> employee)  //输出所有员工
        {

            Console.Write("\n {0,-10}", "Id");
            Console.Write(" {0,-15}", "Firstname");
            Console.Write(" {0,-15}", "Lastname");
            Console.Write(" {0,-30}", "Gender(M–Male;F–Female)");
            Console.Write(" {0,-16}", "Birth");
            Console.Write(" {0,-20}", "Address ");
            Console.Write(" {0,-15}", "Phone");
            foreach (Staff people in employee)
            {
                people.ShowStaff();
            }

        }

        public void Search(List<Staff> employee)   //查找员工
        {
            Console.WriteLine("the way ,what you want to search!");
            Console.WriteLine("1.use Id         2. use name");
            Console.WriteLine("3.use phone      4,Back to Previous Level");
            Console.WriteLine("input you want do things number!");
            string searchnum = Console.ReadLine();
            switch (searchnum)
            {
                case "1": UseId(employee); break;
                case "2": UseName(employee); break;
                case "3": UsePhone(employee); break;
                case "4":; break;
                default: ShowERR(employee); Search(employee); break;
            }

        }

        public void ShowERR(List<Staff> employee)  //错误信息提示
        {
            Console.WriteLine("err ,You input number is wrong ,please input again\n");
        }


        //UpDate的子函数

        private static void UpPhone(int changeId, List<Staff> employee) //更新电话   
        {
            var st = employee.Find(em => em.EmployeeId == changeId);


            if (st != null)
            {
                while (true)
                {
                    Console.WriteLine("input phone(Note:length=11 )");
                    long changephone = long.Parse(Console.ReadLine());
                    string Vphone = changephone.ToString();
                    if (Vphone.Length == 11)
                    {
                        st.EmployeePhone = changephone;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("input phone wrong!");
                    }
                }

            }
            else
            {
                Console.WriteLine("change wrong!");
            }
            st.ShowStaff();

        }

        private static void UpAddr(int changeId, List<Staff> employee) //更新住址   
        {
            var st = employee.Find(em => em.EmployeeId == changeId);

            if (st != null)
            {
                Console.WriteLine("input chang Adderss");
                string changeaddr = Convert.ToString(Console.ReadLine());
                st.EmployeeAddr = changeaddr;
            }
            st.ShowStaff();

        }

        private static void UpBirth(int changeId, List<Staff> employee) //更新生日   
        {
            var st = employee.Find(em => em.EmployeeId == changeId);
            if (st != null)
            {
                while (true)
                {
                    Console.WriteLine("input Birth:1990/01/01");

                    try
                    {
                        string date = Console.ReadLine();
                        DateTime changedate = Convert.ToDateTime(date);
                        st.EmployeeBirth = changedate;
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("wrong input in rule(1990/01/01)");
                    }
                }

            }
            st.ShowStaff();

        }

        private static void UpGender(int changeId, List<Staff> employee) //更新性别   
        {
            var st = employee.Find(em => em.EmployeeId == changeId);
            if (st != null)
            {
                while (true)
                {
                    Console.WriteLine("input Gender: (M – Male; F – Female)");
                    string Sex = Convert.ToString(Console.ReadLine());
                    char EmployeeSex = char.Parse(Regex.Replace(Sex, @"[MFmf]+", ""));

                    char changesex = char.ToUpper(EmployeeSex);
                    
                    if (changesex == 'M' || changesex == 'F')
                    {
                        st.EmployeeGED = changesex;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You input SEX wrong! input again!");
                    }
                }

            }
            st.ShowStaff();

        }

        private static void UpName(int changeId, List<Staff> employee) //更新名字   
        {
            var st = employee.Find(em => em.EmployeeId == changeId);
            if (st != null)
            {
                Console.WriteLine("input chang fname");
                string changefname = Convert.ToString(Console.ReadLine());
                Console.WriteLine("input chang lname");
                string changelname = Convert.ToString(Console.ReadLine());

                st.EmployeeFName = changefname;
                st.EmployeeLName = changelname;
            }
            st.ShowStaff();

        }

        private static void UpId(int changeId, List<Staff> employee) //更新Id   
        {
            Staff st = employee.Find(em => em.EmployeeId == changeId);
            if (st != null)
            {
                Console.WriteLine("input chang Id,Note(you change Id not some as others)");
                string Id = Convert.ToString(Console.ReadLine());
                string result = System.Text.RegularExpressions.Regex.Replace(Id, @"[^0-9]+", "");
                if (result == "")
                {
                    Console.WriteLine("you input sting inexistence Number ！");
                    UpId(changeId,employee);
                    return;
                }
                int changeid = int.Parse(result);

                var major_key = employee.Find(em => em.EmployeeId == changeid);
                if (major_key == null)
                {
                    Console.WriteLine("this Id can register!");

                }
                else
                {
                    Console.WriteLine("this Id had registered!,please change others Id!");
                    UpId(changeId, employee);
                    return;

                }
                st.EmployeeId = changeid;
                st.ShowStaff();
            }

        }


        //search的子函数


        private static void UseId(List<Staff> employee)  //通过Id查找   
        {
            Console.WriteLine("input you want to search employee Id!");
            string ID = Console.ReadLine();
            string result = System.Text.RegularExpressions.Regex.Replace(ID, @"[^0-9]+", "");
            if (result == "")
            {
                Console.WriteLine("you input sting inexistence Number ！");
                UseId(employee);
                return;
            }

            int id = int.Parse(result);
            var st = employee.Find(em => em.EmployeeId == id);
            if (st != null)
            {
                Console.WriteLine("\n find this Id employee!");
                st.ShowStaff();
            }
            else
            {
                Console.WriteLine("\n no find this Id employee!");
            }

        }

        private static void UseName(List<Staff> employee)//通过Lname查找
        {

            Console.WriteLine("input you want to search employee lastname(Tom)!");
            string name = Convert.ToString(Console.ReadLine());
            List<Staff> employees = employee.FindAll(em => em.EmployeeLName.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (employees != null)
            {
                Console.WriteLine("\n find this name employee!");
                foreach(Staff st in employees)
                st.ShowStaff();
            }
            else
            {
                Console.WriteLine("\n no find this name employee!");
            }


        }

        private static void UsePhone(List<Staff> employee)//通过电话查找
        {
            Console.WriteLine("input you want to search employee phone!");
            long phone = long.Parse(Console.ReadLine());
            var st = employee.Find(em => em.EmployeePhone == phone);

            if (st != null)
            {
                Console.WriteLine("\n find this phone employee");
                st.ShowStaff();
            }
            else
            {
                Console.WriteLine("\n no find this phone employee!");
            }


        }

       
    }
   }

