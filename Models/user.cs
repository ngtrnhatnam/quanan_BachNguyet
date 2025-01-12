namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [Key]
        public int account_id { get; set; }

        public int employee_id { get; set; }

        [Required]
        [StringLength(24)]
        public string username { get; set; }

        [Required]
        [StringLength(128)]
        public string password { get; set; }

        public bool permission { get; set; }

        public virtual employee employee { get; set; }
    }
}
