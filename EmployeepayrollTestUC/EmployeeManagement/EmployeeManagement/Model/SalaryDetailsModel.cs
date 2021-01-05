using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    public class SalaryDetailsModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobDiscription { get; set; }
        public string Month { get; set; }
        public double EmployeeSalary { get; set; }
        public int SalaryId { get; set; }
        public DateTime date { get; set; }
        public char gender { get; set; }

        public SalaryDetailsModel(int EmployeeId, string EmployeeName, string JobDiscription, string Month, double EmployeeSalary, int SalaryId, DateTime date, char gender)
        {
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.JobDiscription = JobDiscription;
            this.Month = Month;
            this.EmployeeSalary = EmployeeSalary;
            this.SalaryId = SalaryId;
            this.date = date;
            this.gender = gender;
        }

        public SalaryDetailsModel()
        {
        }
    }
}
