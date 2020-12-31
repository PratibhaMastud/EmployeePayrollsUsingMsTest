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
    }

}

