namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            bills = new HashSet<bill>();
            orders = new HashSet<order>();
            users = new HashSet<user>();
        }

        [Key]
        public int employee_id { get; set; }

        [Required]
        [StringLength(12)]
        public string cccd { get; set; }

        [Required]
        [StringLength(40)]
        public string fullname { get; set; }

        [Required]
        [StringLength(50)]
        public string position { get; set; }

        [Required]
        [StringLength(10)]
        public string phonenumber { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime hire_date { get; set; }

        public decimal salary { get; set; }

        public bool status { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
