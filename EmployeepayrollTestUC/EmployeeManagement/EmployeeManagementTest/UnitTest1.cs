using EmployeeManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///  when retrieve then return employee salary deatils from data base.
        /// </summary>
        [TestMethod]
        public void GivenEmployeePayroll_WhenRetrieve_ThenReturnEmployeePayrollFromDataBase()
        {
            int expected = 3;
            Salary salary = new Salary();
            int count = salary.getAllEmployee();
            Assert.AreEqual(expected, count);
        }

        [TestMethod]
        public void GivenQuery_ShouldUpdateSalary()
        {
            double expectedResult = 200000.00;
            Salary salary1 = new Salary();
            SalaryUpdateModel model = new SalaryUpdateModel()
            {
                EmployeeId = 101,
                EmployeeSalary = 200000.00
            };
            double salary = salary1.UpdateEmployeeSalary(model);
            Assert.AreEqual(expectedResult, salary);
        }
    }

}

