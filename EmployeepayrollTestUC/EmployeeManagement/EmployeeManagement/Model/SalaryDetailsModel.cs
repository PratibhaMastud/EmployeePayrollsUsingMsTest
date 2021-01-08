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
        public DateTime date { get; set; }
        public int CompanyId { get; set; }
        public char gender { get; set; }
        public int SalaryId { get; set; }


        public SalaryDetailsModel(int EmployeeId, string EmployeeName, string JobDiscription, string Month, double EmployeeSalary, DateTime date, int CompanyId, char gender, int SalaryId)
        {
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.JobDiscription = JobDiscription;
            this.Month = Month;
            this.EmployeeSalary = EmployeeSalary;
            this.date = date;
            this.CompanyId = CompanyId;
            this.gender = gender;
            this.SalaryId = SalaryId;

        }

        public SalaryDetailsModel()
        {
        }
    }
}
