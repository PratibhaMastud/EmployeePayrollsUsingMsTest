using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Model
{
    public class SalaryModel
    {
        public int SalaryId { get; set; }
        public double deduction { get; set; }
        public double taxable_pay { get; set; }
        public double tax { get; set; }
        public double net_salary { get; set; }

    }
}
