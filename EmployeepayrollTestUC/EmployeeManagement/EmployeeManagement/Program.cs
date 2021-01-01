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
            SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel();
            Salary salary = new Salary();
            salary.checkConnection();
          //int count = salary.getAllEmployee();
          //Console.WriteLine(count);
            salaryUpdateModel.EmployeeId = 101;
            salaryUpdateModel.EmployeeSalary = 300000.00;
            //salary.UpdateEmployeeSalary(salaryUpdateModel);
             int count = salary.getEmployeeDataWithGivenRange();
             Console.WriteLine(count);

        }
    }
}
