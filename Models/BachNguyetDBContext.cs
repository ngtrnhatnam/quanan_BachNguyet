using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace quan_an_Bach_Nguyet.Models
{
    public partial class BachNguyetDBContext : DbContext
    {
        public BachNguyetDBContext()
            : base("name=BachNguyetDBContext")
        {
        }

        public virtual DbSet<attendance> attendances { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<ingredient> ingredients { get; set; }
        public virtual DbSet<menu_items> menu_items { get; set; }
        public virtual DbSet<order_detail> order_detail { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<payroll> payrolls { get; set; }
        public virtual DbSet<purchase_order_details> purchase_order_details { get; set; }
        public virtual DbSet<purchase_orders> purchase_orders { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<attendance>()
                .Property(e => e.hours_worked)
                .HasPrecision(5, 2);

            modelBuilder.Entity<bill>()
                .Property(e => e.total_amount)
                .HasPrecision(10, 0);

            modelBuilder.Entity<bill>()
                .Property(e => e.payment_method)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.menu_items)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.cccd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.phonenumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.salary)
                .HasPrecision(10, 0);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.attendances)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.payrolls)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.purchase_orders)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.users)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ingredient>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ingredient>()
                .Property(e => e.unit)
                .IsUnicode(false);

            modelBuilder.Entity<ingredient>()
                .Property(e => e.stock_quantity)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ingredient>()
                .HasMany(e => e.purchase_order_details)
                .WithRequired(e => e.ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<menu_items>()
                .Property(e => e.price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<menu_items>()
                .HasMany(e => e.order_detail)
                .WithRequired(e => e.menu_items)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order_detail>()
                .Property(e => e.subtotal)
                .HasPrecision(10, 0);

            modelBuilder.Entity<order>()
                .HasMany(e => e.bills)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_detail)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<payroll>()
                .Property(e => e.base_salary)
                .HasPrecision(10, 0);

            modelBuilder.Entity<payroll>()
                .Property(e => e.total_hours)
                .HasPrecision(5, 2);

            modelBuilder.Entity<payroll>()
                .Property(e => e.overtime_hours)
                .HasPrecision(5, 2);

            modelBuilder.Entity<payroll>()
                .Property(e => e.deductions)
                .HasPrecision(10, 0);

            modelBuilder.Entity<payroll>()
                .Property(e => e.bonus)
                .HasPrecision(10, 0);

            modelBuilder.Entity<payroll>()
                .Property(e => e.total)
                .HasPrecision(10, 0);

            modelBuilder.Entity<purchase_order_details>()
                .Property(e => e.quantity)
                .HasPrecision(5, 2);

            modelBuilder.Entity<purchase_order_details>()
                .Property(e => e.unit_price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<purchase_order_details>()
                .Property(e => e.subtotal)
                .HasPrecision(10, 0);

            modelBuilder.Entity<purchase_orders>()
                .Property(e => e.total_cost)
                .HasPrecision(10, 0);

            modelBuilder.Entity<purchase_orders>()
                .HasMany(e => e.purchase_order_details)
                .WithRequired(e => e.purchase_orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<supplier>()
                .Property(e => e.phonenumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<supplier>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<supplier>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<supplier>()
                .HasMany(e => e.purchase_orders)
                .WithRequired(e => e.supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
