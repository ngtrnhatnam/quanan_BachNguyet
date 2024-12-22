namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("attendance")]
    public partial class attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int attendance_id { get; set; }

        public int employee_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime work_date { get; set; }

        public TimeSpan check_in { get; set; }

        public TimeSpan check_out { get; set; }

        public decimal hours_worked { get; set; }

        public virtual employee employee { get; set; }
    }
}
