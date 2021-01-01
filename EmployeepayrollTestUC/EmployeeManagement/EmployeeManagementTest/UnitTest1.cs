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

        /// <summary>
        /// Get count of employee from perticular range
        /// </summary>
        [TestMethod]
        public void GivenQuery_whenCount_ShouldReturnCount()
        {
            int expectedResult = 3;
            Salary salary = new Salary();
            int result = salary.getEmployeeDataWithGivenRange();
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Givens the employee names when update salary then return expected sum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_ThenReturnExpectedSumSalary()
        {
            int expected = 170000;
            Salary salary = new Salary();
            int sum = salary.getSumSalary();
            Assert.AreEqual(expected, sum);
        }

        /// <summary>
        /// Givens the employee names when average salary then return expected average salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenAvgSalary_ThenReturnExpectedAvgSalary()
        {
            int expected = 50000;
            Salary salary = new Salary();
            int avg = salary.getAverageSalary();
            Assert.AreEqual(expected, avg);
        }

        /// <summary>
        /// Givens the employee names when minimum salary then return expected minimum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenMinSalary_ThenReturnExpectedMinSalary()
        {
            int expected = 50000;
            Salary salary = new Salary();
            int min = salary.getMinSalary();
            Assert.AreEqual(expected, min);
        }

        /// <summary>
        /// Givens the employee names when maximum then return expected maximum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenMax_ThenReturnExpectedMaxSalary()
        {
            int expected = 70000;
            Salary salary = new Salary();
            int max = salary.getMaxSalary();
            Assert.AreEqual(expected, max);
        }

        /// <summary>
        /// Givens the employee names when count by salary then return expected count by salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenCountBySalary_ThenReturnExpectedCountBySalary()
        {
            int expected = 2;
            Salary salary = new Salary();
            int count = salary.getCountSalary();
            Assert.AreEqual(expected, count);
        }
    }
}

