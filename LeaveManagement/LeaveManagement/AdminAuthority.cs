using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement
{
    class AdminAuthority
    {
        internal static string adminName, adminPassword;
        static AdminAuthority()
        {
            adminName = "Priya";
            adminPassword = "PriyaAspire";
        }
        public void adminLogin()
        {
            Console.WriteLine("Enter the User name");
            string checkName = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string checkPassword = Console.ReadLine();
            if (checkName.Equals(adminName) && checkPassword.Equals(adminPassword))
            {
                Console.WriteLine("SUCCESSFULLY ADMIN LOGIN");
                AdminOperation();
            }
            else
            {
                Console.WriteLine("ADMIN LOGIN WAS FAILED");
            }
        }
        public enum select { department = 1, Employee, Exit }
        public void AdminOperation()
        {
            do
            {
                Console.WriteLine("Enter Your Choice \n 1.department\n 2.Employee\n 3.Exit");
                int readChoice = Int32.Parse(Console.ReadLine());
                select myChoice = (select)readChoice;
                switch (myChoice)
                {
                    case select.department:
                        DepartmentRepository departmentValue = new DepartmentRepository();
                        departmentValue.AddDepartment();
                        departmentValue.DisplayDepartment();
                        break;
                    case select.Employee:
                        EmployeeRepository employeeValue = new EmployeeRepository();
                        employeeValue.AddEmployee();
                        employeeValue.DisplayEmployee();
                        break;
                    case select.Exit:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            while (true);

        }
    }
}