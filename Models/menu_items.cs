namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class menu_items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public menu_items()
        {
            order_detail = new HashSet<order_detail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int menuitem_id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public int category_id { get; set; }

        public decimal price { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public bool availability { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_detail> order_detail { get; set; }
    }
}