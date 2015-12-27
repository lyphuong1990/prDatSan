namespace projectDatSan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<city> citys { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<feed_back_product> feed_back_product { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<group_page> group_page { get; set; }
        public virtual DbSet<group_role> group_role { get; set; }
        public virtual DbSet<maping_page> maping_page { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<oder_product> oder_product { get; set; }
        public virtual DbSet<page> pages { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<province> provinces { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<time> times { get; set; }
        public virtual DbSet<time_product> time_product { get; set; }
        public virtual DbSet<type_payment> type_payment { get; set; }
        public virtual DbSet<type> types { get; set; }
        public virtual DbSet<vote> votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<city>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<city>()
                .HasMany(e => e.provinces)
                .WithOptional(e => e.city)
                .HasForeignKey(e => e.city_id);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.oder_product)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.customer_id);

            modelBuilder.Entity<group_page>()
                .HasMany(e => e.group_role)
                .WithOptional(e => e.group_page)
                .HasForeignKey(e => e.id_group);

            modelBuilder.Entity<group_page>()
                .HasMany(e => e.maping_page)
                .WithOptional(e => e.group_page)
                .HasForeignKey(e => e.id_group);

            modelBuilder.Entity<maping_page>()
                .Property(e => e.control_string)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<oder_product>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<page>()
                .Property(e => e.control_string)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<page>()
                .HasMany(e => e.maping_page)
                .WithOptional(e => e.page)
                .HasForeignKey(e => e.id_page);

            modelBuilder.Entity<product>()
                .HasMany(e => e.oder_product)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<product>()
                .HasMany(e => e.time_product)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<product>()
                .HasMany(e => e.votes)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<province>()
                .HasMany(e => e.products)
                .WithOptional(e => e.province)
                .HasForeignKey(e => e.province_id);

            modelBuilder.Entity<role>()
                .HasMany(e => e.accounts)
                .WithOptional(e => e.role1)
                .HasForeignKey(e => e.role);

            modelBuilder.Entity<role>()
                .HasMany(e => e.group_role)
                .WithOptional(e => e.role)
                .HasForeignKey(e => e.role_id);

            modelBuilder.Entity<time>()
                .HasMany(e => e.time_product)
                .WithOptional(e => e.time)
                .HasForeignKey(e => e.time_id);

            modelBuilder.Entity<type_payment>()
                .HasMany(e => e.oder_product)
                .WithOptional(e => e.type_payment)
                .HasForeignKey(e => e.type_payment_id);

            modelBuilder.Entity<type>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<type>()
                .HasMany(e => e.products)
                .WithOptional(e => e.type)
                .HasForeignKey(e => e.type_id);
        }
    }
}
