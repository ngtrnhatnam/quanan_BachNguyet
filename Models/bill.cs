namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill
    {
        [Key]
        public int bill_id { get; set; }

        public DateTime payment_date { get; set; }

        public decimal total_amount { get; set; }

        [Required]
        [StringLength(5)]
        public string payment_method { get; set; }

        public int order_id { get; set; }

        public int employee_id { get; set; }

        public virtual employee employee { get; set; }

        public virtual order order { get; set; }
    }
}
