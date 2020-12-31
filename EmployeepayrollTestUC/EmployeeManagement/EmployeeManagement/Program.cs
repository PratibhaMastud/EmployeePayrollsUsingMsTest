using EmployeeManagement.Model;
using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome employee Management Using TDD");
            SalaryDetailsModel salaryDetailsModel = new SalaryDetailsModel();
            Salary salary = new Salary();
            salary.checkConnection();
            int count = salary.getAllEmployee();
            Console.WriteLine(count);
        }
    }
}
