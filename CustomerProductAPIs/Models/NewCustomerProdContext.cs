using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerProductAPIs.Models;

public partial class NewCustomerProdContext : DbContext
{
    public NewCustomerProdContext()
    {
    }

    public NewCustomerProdContext(DbContextOptions<NewCustomerProdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerProd> CustomerProds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-BQRQRJNL\\SQLEXPRESS;Initial Catalog=newCustomerProd;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB855D660483");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerFname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_fname");
            entity.Property(e => e.CustomerLname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_lname");
            entity.Property(e => e.CustomerPass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customer_pass");
        });

        modelBuilder.Entity<CustomerProd>(entity =>
        {
            entity.HasKey(e => e.CustomerProdId).HasName("PK__Customer__F7EA3B050F6B9481");

            entity.ToTable("CustomerProd");

            entity.Property(e => e.CustomeridFk).HasColumnName("Customerid_fk");
            entity.Property(e => e.ProdidFk).HasColumnName("prodid_fk");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchaseDate");
            entity.Property(e => e.TypeofPayment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typeofPayment");

            entity.HasOne(d => d.ProdidFkNavigation).WithMany(p => p.CustomerProds)
                .HasForeignKey(d => d.ProdidFk)
                .HasConstraintName("FK__CustomerP__prodi__4E88ABD4");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__3214EC07D041CE98");

            entity.Property(e => e.ProdBrand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prodBrand");
            entity.Property(e => e.ProdName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prodName");
            entity.Property(e => e.ProdPrice)
                .HasColumnType("money")
                .HasColumnName("prodPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
