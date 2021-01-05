using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    public class EmployeePayrollOperation
    {
        public List<SalaryDetailsModel> employeePayrollList = new List<SalaryDetailsModel>();

        /// <summary>
        /// Here we creatinglist and adding                       
        /// </summary>
        /// <param name="employeePayrollList"></param>
        public void addEmployeePayroll(List<SalaryDetailsModel> employeePayrollList)
        {
            employeePayrollList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee added : " + employeeData.EmployeeName);
                this.addEmployeePayroll(employeeData);
                Console.WriteLine("Emplyee added" + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollList.ToString());
        }

        /// <summary>
        /// Method to add employee to the employee list
        /// </summary>
        /// <param name="employee"></param>
        public void addEmployeePayroll(SalaryDetailsModel employee)
        {
            employeePayrollList.Add(employee);
        }
    }
}
