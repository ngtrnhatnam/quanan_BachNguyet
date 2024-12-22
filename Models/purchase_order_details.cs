namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class purchase_order_details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pod_id { get; set; }

        public int po_id { get; set; }

        public int ingredient_id { get; set; }

        public decimal quantity { get; set; }

        public decimal unit_price { get; set; }

        public decimal subtotal { get; set; }

        public virtual ingredient ingredient { get; set; }

        public virtual purchase_orders purchase_orders { get; set; }
    }
}
