using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    class SalaryUpdateModel
    {
        public int EmployeeId { get; set; }
        public string Month { get; set; }
        public int EmployeeSalary { get; set; }
        public int SalaryId { get; set; }
    }
}
