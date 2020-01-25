using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement
{
    class Employee
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public int employeePhoneNumber { get; set; }
        public int departmentId { get; set; }
        public int managerId { get; set; }
        public string employeeDesignation { get; set; }
       
    }
    class EmployeeRepository
    {
        
        static string connectionString = ConfigurationManager.ConnectionStrings["DataConnectivity"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand insertCommand;
        SqlDataAdapter adapter = new SqlDataAdapter();
        int sqlRows = 0;

        public void AddEmployee()
        {
            connection.Open();
            insertCommand = new SqlCommand("InsertEmployee", connection);
            insertCommand.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("ENTER THE EMPLOYEE ID");
            int employeeId = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER THE EMPLOYEE NAME");
            string employeeName = Console.ReadLine();
            Console.WriteLine("ENTER THE EMPLOYEE PHONE NUMBER");
            int employeePhoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER THE DEPARTMENT ID OF EMPLOYEE");
            int departmentId = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER THE MANAGER ID OF EMPLOYEE");
            int managerId = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER THE DESIGNATION OF EMPLOYEE");
            string employeeDesignation = Console.ReadLine();
            insertCommand.Parameters.Add(new SqlParameter("@getEmployeeId",employeeId));           
            insertCommand.Parameters.Add(new SqlParameter("@getEmployeeName", employeeName));
            insertCommand.Parameters.Add(new SqlParameter("@getEmployeePhoneNumber", employeePhoneNumber));
            insertCommand.Parameters.Add(new SqlParameter("@getEepartmentId", departmentId));
            insertCommand.Parameters.Add(new SqlParameter("@getManagerId", managerId));
            insertCommand.Parameters.Add(new SqlParameter("@getEmployeeId",employeeDesignation));
            adapter.InsertCommand = insertCommand;
            sqlRows = adapter.InsertCommand.ExecuteNonQuery();
            if (sqlRows >= 1)
            {
                Console.WriteLine("Details are added");
            }
            else
            {
                Console.WriteLine("Details are not added");
            }
            connection.Close();
            insertCommand.Dispose();
        }
        public void DisplayEmployee()
        {
            connection.Open();
            List<Employee> employeeList = new List<Employee>();
            insertCommand = new SqlCommand("spDataEmployee", connection);
            insertCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter display = new SqlDataAdapter("spDataEmployee", connection);
            DataSet dataSet = new DataSet();
            display.Fill(dataSet, "Employee");
            foreach (DataRow row in dataSet.Tables["Employee"].Rows)
            {
                Employee employeeInput = new Employee();
                employeeInput.employeeId = (int)row["employeeId"];
                employeeInput.employeeName = row["employeeName"].ToString();
                employeeInput.employeePhoneNumber = (int)row["employeePhoneNumber"];
                employeeInput.departmentId = (int)row["departmentId"];
                employeeInput.managerId = (int)row["managerId"];
                employeeInput.employeeDesignation = row["employeeDesignation"].ToString();
                employeeList.Add(employeeInput);
            }
            insertCommand.Dispose();
            connection.Close();


        }
    }
}

