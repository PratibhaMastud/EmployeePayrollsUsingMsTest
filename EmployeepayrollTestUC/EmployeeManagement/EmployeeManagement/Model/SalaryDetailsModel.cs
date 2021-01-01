using Microsoft.OData.Edm;
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
        public Date date { get; set; }


    }
}
