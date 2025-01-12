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

        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<menu_items> menu_items { get; set; }
        public virtual DbSet<order_details> order_details { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
                .HasMany(e => e.bills)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.users)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<menu_items>()
                .Property(e => e.price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<menu_items>()
                .HasMany(e => e.order_details)
                .WithRequired(e => e.menu_items)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order_details>()
                .Property(e => e.price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<order_details>()
                .Property(e => e.subtotal)
                .HasPrecision(10, 0);

            modelBuilder.Entity<order>()
                .HasMany(e => e.bills)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_details)
                .WithRequired(e => e.order)
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
