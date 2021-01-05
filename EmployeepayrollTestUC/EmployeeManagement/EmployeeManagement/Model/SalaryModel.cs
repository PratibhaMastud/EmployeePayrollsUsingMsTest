using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Model
{
    public class SalaryModel
    {
        public int emp_id { get; set; }
        public double basic_pay { get; set; }
        public double deductions { get; set; }
        public double taxable_pay { get; set; }
        public double tax { get; set; }
        public double net_pay { get; set; }
        public int EmployeeId { get; set; }

    }
}
