using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement
{
    class Department
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }       
    }
    class DepartmentRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DataConnectivity"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand insertCommand;
        SqlDataAdapter adapter = new SqlDataAdapter();
        int sqlRows = 0;
        public void AddDepartment()
        {
            connection.Open();
            insertCommand = new SqlCommand("InsertDepartment", connection);
            insertCommand.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("ENTER THE EMPLOYEE ID");
            int departmentId = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER THE EMPLOYEE NAME");
            string departmentName = Console.ReadLine();
            
            string employeeDesignation = Console.ReadLine();
            insertCommand.Parameters.Add(new SqlParameter("@getDepartmentId", departmentId));
            insertCommand.Parameters.Add(new SqlParameter("@getDepartmentName",departmentName));
            
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
        public void DisplayDepartment()
        {
            connection.Open();

            List<Department> departmentList = new List<Department>();
            insertCommand = new SqlCommand("spData", connection);
            insertCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter display = new SqlDataAdapter("spData", connection);
            DataSet dataSet = new DataSet();
            display.Fill(dataSet, "Department");
            foreach (DataRow row in dataSet.Tables["Department"].Rows)
            {
                Department departmentInput = new Department();
                departmentInput.departmentId = (int)row["departmentId"];
                departmentInput.departmentName = row["departmentName"].ToString();
                departmentList.Add(departmentInput);
                
            }
            insertCommand.Dispose();
            connection.Close();


        }
    }
}

