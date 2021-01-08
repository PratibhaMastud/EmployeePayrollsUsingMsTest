using EmployeeManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

        [TestMethod]
        public void GivenQuery_WhenInsertInto_ShouldAbleToInsertIntoTwoTableDemo()
        {
            bool expectedResult = true;
            Salary salary = new Salary();
            SalaryDetailsModel empmodel = new SalaryDetailsModel()
            {
                EmployeeId     = 1,
                EmployeeName   = "Pritesh",
                JobDiscription = "Finance",
                Month          = "jan",
                EmployeeSalary = 600000.00,
                date           = new DateTime(2018, 12, 11),
                CompanyId      = 102,
                gender         = 'M',
                SalaryId = 1
            };
            bool result = salary.AddNewEmployeeDEmo(empmodel);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenQuery_WhenSelect_ShouldRetrieveAllData()
        {
            int expectedRetrieveResult = 17;
            Salary salary = new Salary();
            int result = salary.getAllEmployee();
            Assert.AreEqual(expectedRetrieveResult, result);
        }

        /// <summary>
        /// UC 10 : Ensure working of update query to check  updated employee salary in new db structure
        /// </summary>
        [TestMethod]
        public void GivenQuery_ShouldUpdateSalaryInNewDBStructure()
        {
            double expectedResult = 400000.00;
            Salary salary = new Salary();
            SalaryDetailsModel modelSal = new SalaryDetailsModel()
            {
                EmployeeName = "Sujecha",
                EmployeeSalary = 400000.00
            };
            double EmployeeSalary = salary.updateEmployeeSalary(modelSal);

            Assert.AreEqual(expectedResult, salary);
        }

        /// <summary>
        /// UC 10 : Ensure working of retrieve perticular employeee data query in new db structure
        /// </summary>
        [TestMethod]
        public void GivenQuery_whenCount_ShouldReturnCountFromNewDB()
        {
            int expectedResult = 12;
            Salary salary = new Salary();
            int result = salary.getEmployeeDataWithGivenRange();
            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void GiveQuery_WhenInsert_ShouldPerformInsertion()
        {
            bool expectedInsertResult = true;
            Salary salary = new Salary();
            SalaryDetailsModel modelSal = new SalaryDetailsModel()
            {
                EmployeeId = 2,
                EmployeeName = "Prianita",
                JobDiscription = "Finance",
                Month = "jan",
                EmployeeSalary = 600000.00,
                date = new DateTime(2018, 12, 11),
                CompanyId = 102,
                gender = 'M',
                SalaryId = 2
            };
            bool insertResult = salary.addEmployee(modelSal);
            Assert.AreEqual(expectedInsertResult, insertResult);
        }

        [TestMethod]
        public void GiveQuery_WhenInsert_ShouldPerformInsertionASInNewDBStructure()
        {
            bool expectedInsertResult = true;
            Salary salary = new Salary();
            SalaryDetailsModel modelSal = new SalaryDetailsModel()
            {
                EmployeeId = 2,
                EmployeeName = "Prianita",
                JobDiscription = "Finance",
                Month = "jan",
                EmployeeSalary = 600000.00,
                date = new DateTime(2018, 12, 11),
                CompanyId = 102,
                gender = 'M',
                SalaryId = 2
            };
            bool insertResult = salary.addEmployee(modelSal);
            Assert.AreEqual(expectedInsertResult, insertResult);
        }
    }
}


