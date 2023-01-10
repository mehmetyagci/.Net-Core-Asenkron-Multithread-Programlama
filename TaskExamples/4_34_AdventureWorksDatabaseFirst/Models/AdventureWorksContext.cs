using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _4_34_AdventureWorksDatabaseFirst.Models
{
    public partial class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
        {
        }

        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MKBEOKP\\MY;Initial Catalog=AdventureWorks;Integrated Security=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Production");

                entity.HasComment("Products sold or used in the manfacturing of sold products.");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber)
                    .HasName("AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasComment("Primary key for Product records.");

                entity.Property(e => e.Class)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasComment("H = High, M = Medium, L = Low");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasComment("Product color.");

                entity.Property(e => e.DaysToManufacture).HasComment("Number of days required to manufacture the product.");

                entity.Property(e => e.DiscontinuedDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was discontinued.");

                entity.Property(e => e.FinishedGoodsFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

                entity.Property(e => e.ListPrice)
                    .HasColumnType("money")
                    .HasComment("Selling price.");

                entity.Property(e => e.MakeFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Name of the product.");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

                entity.Property(e => e.ProductModelId)
                    .HasColumnName("ProductModelID")
                    .HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComment("Unique product identification number.");

                entity.Property(e => e.ProductSubcategoryId)
                    .HasColumnName("ProductSubcategoryID")
                    .HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. ");

                entity.Property(e => e.ReorderPoint).HasComment("Inventory level that triggers a purchase order or work order. ");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.Property(e => e.SafetyStockLevel).HasComment("Minimum inventory quantity. ");

                entity.Property(e => e.SellEndDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was no longer available for sale.");

                entity.Property(e => e.SellStartDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was available for sale.");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .HasComment("Product size.");

                entity.Property(e => e.SizeUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength()
                    .HasComment("Unit of measure for Size column.");

                entity.Property(e => e.StandardCost)
                    .HasColumnType("money")
                    .HasComment("Standard cost of the product.");

                entity.Property(e => e.Style)
                    .HasMaxLength(2)
                    .IsFixedLength()
                    .HasComment("W = Womens, M = Mens, U = Universal");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(8, 2)")
                    .HasComment("Product weight.");

                entity.Property(e => e.WeightUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength()
                    .HasComment("Unit of measure for Weight column.");

                entity.HasOne(d => d.ProductSubcategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSubcategoryId);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory", "Production");

                entity.HasComment("High-level product categorization.");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductCategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductCategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("ProductCategoryID")
                    .HasComment("Primary key for ProductCategory records.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Category description.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            });

            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory", "Production");

                entity.HasComment("Product subcategories. See ProductCategory table.");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductSubcategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductSubcategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductSubcategoryId)
                    .HasColumnName("ProductSubcategoryID")
                    .HasComment("Primary key for ProductSubcategory records.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Subcategory description.");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("ProductCategoryID")
                    .HasComment("Product category identification number. Foreign key to ProductCategory.ProductCategoryID.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductSubcategory)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
