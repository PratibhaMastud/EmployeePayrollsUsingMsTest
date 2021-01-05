using EmployeeManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EmployeeManagementTest
{
    [TestClass]
    public class EmployeePayrollTest
    {
        [TestMethod]
        public void Given10Employee_WhenAddedList_ShouldMatchWithEmployeeEntries()
        {
            List<SalaryDetailsModel> employeeDetails = new List<SalaryDetailsModel>();
            employeeDetails.Add(new SalaryDetailsModel( EmployeeId: 1, EmployeeName: "Ankita", JobDiscription: "IT", Month: "jan", EmployeeSalary: 24000, SalaryId: 7, date: new DateTime(2019 - 10 - 11), gender: 'F'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 2, EmployeeName: "nikita", JobDiscription: "EXTC", Month: "jan", EmployeeSalary: 30000, SalaryId: 4, date: new DateTime(2015 - 8 - 12), gender: 'F'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 3, EmployeeName: "Anita", JobDiscription: "IT", Month: "march", EmployeeSalary: 50000, SalaryId: 4, date: new DateTime(2003 - 4 - 4), gender: 'M'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 4, EmployeeName: "Mita", JobDiscription: "IT", Month: "April", EmployeeSalary: 50000, SalaryId: 4, date: new DateTime(2016 - 1 - 6), gender: 'F'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 5, EmployeeName: "bita", JobDiscription: "IT", Month: "April", EmployeeSalary: 80000, SalaryId: 5, date: new DateTime(2017 - 10 - 8), gender: 'F'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 6, EmployeeName: "papita", JobDiscription: "Comp", Month: "Feb", EmployeeSalary: 60000, SalaryId: 6, date: new DateTime(2018 - 6 - 9), gender: 'M'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 7, EmployeeName: "rani", JobDiscription: "Comp", Month: "Feb", EmployeeSalary: 50000, SalaryId: 5, date: new DateTime(2020 - 10 - 11), gender: 'M'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 8, EmployeeName: "prasad", JobDiscription: "Comp", Month: "Feb", EmployeeSalary: 40000, SalaryId: 6, date: new DateTime(2021 - 11 - 5), gender: 'F'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 9, EmployeeName: "supu", JobDiscription: "EXTC", Month: "jan", EmployeeSalary: 40000, SalaryId: 5, date: new DateTime(2010 - 5 - 16), gender: 'M'));
            employeeDetails.Add(new SalaryDetailsModel(EmployeeId: 10, EmployeeName: "chetna", JobDiscription: "EXTC", Month: "jan", EmployeeSalary: 44000, SalaryId: 7, date: new DateTime(2011 - 12 - 25), gender: 'F'));

            EmployeePayrollOperation employeePayrollOperation = new EmployeePayrollOperation();
            DateTime statDateTime = DateTime.Now;
            employeePayrollOperation.addEmployeePayroll(employeeDetails);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration of Insertion in list without using thread "+ (stopDateTime - statDateTime));

            Salary salary = new Salary();
            SalaryDetailsModel model = new SalaryDetailsModel()
            {
                EmployeeId = 15,
                EmployeeName = "Manish",
                JobDiscription = "Marketing",
                Month = "jan",
                EmployeeSalary = 450000.00,
                SalaryId = 22,
                date = new DateTime(2010, 2, 12),
                gender = 'M'

            };
            DateTime startDateTime = DateTime.Now;
            salary.addEmployee(model);
            DateTime stopDateAndTime = DateTime.Now;
            Console.WriteLine("Duration for Insertion in DataBase without thread : " + (stopDateAndTime - startDateTime));
        }
    }
}
