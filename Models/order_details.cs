namespace quan_an_Bach_Nguyet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_details
    {
        [Key]
        public int order_detail_id { get; set; }

        public int order_id { get; set; }

        public int menuitem_id { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public decimal subtotal { get; set; }

        public virtual menu_items menu_items { get; set; }

        public virtual order order { get; set; }
    }
}
