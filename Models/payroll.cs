namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("payroll")]
    public partial class payroll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int payroll_id { get; set; }

        public int employee_id { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public decimal base_salary { get; set; }

        public decimal total_hours { get; set; }

        public decimal overtime_hours { get; set; }

        public decimal deductions { get; set; }

        public decimal bonus { get; set; }

        public decimal total { get; set; }

        public virtual employee employee { get; set; }
    }
}
