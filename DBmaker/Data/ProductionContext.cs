using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DBmaker.Models;

namespace DBmaker.Data
{
    public partial class ProductionContext : DbContext
    {
        public ProductionContext()
        {
        }

        public ProductionContext(DbContextOptions<ProductionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BOM> BOM { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryItem> DeliveryItem { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<OpCode> OpCode { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<SubAssembly> SubAssembly { get; set; }
        public virtual DbSet<TransActionType> TransActionType { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }

        public virtual DbSet<JobSite>  JobSite { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.10.3;database=Production;uid=sa;pwd=Kx09a32x");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOM>(entity =>
            {
                entity.HasNoKey();

            });

            modelBuilder.Entity<JobSite>(entity =>
               entity.HasKey(d => d.JobSiteID)
               );

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(entity => entity.DeliveryID);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.EmployeeID)
                    .HasConstraintName("FK_Delivery_Employee");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.JobID)
                    .HasConstraintName("FK_Delivery_Job");
            });

            modelBuilder.Entity<DeliveryItem>(entity =>
            {
                entity.HasKey(e => e.DeliveryItemID);

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.DeliveryItem)
                    .HasForeignKey(d => d.DeliveryID)
                    .HasConstraintName("FK_DeliveryItem_Delivery");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.employeeID).ValueGeneratedNever();

                entity.HasKey(entity => entity.employeeID);
       
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobID).ValueGeneratedNever();

                entity.Property(e => e.JobDescription).HasMaxLength(170);

                entity.Property(e => e.JobName).HasMaxLength(75);

                entity.Property(e => e.start_ts).HasColumnType("datetime");
            });

            modelBuilder.Entity<OpCode>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OpCodeID).ValueGeneratedOnAdd();

                entity.Property(e => e.OperationName).HasMaxLength(50);
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddedBy).HasMaxLength(60);

                entity.Property(e => e.Amount_Required).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CARBlevel).HasMaxLength(50);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription).HasMaxLength(512);

                entity.Property(e => e.ItemName).HasMaxLength(120);

                entity.Property(e => e.Location)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ManuPartNum)
                    .HasMaxLength(120)
                    .IsFixedLength();

                entity.Property(e => e.MarkUp).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ModifiedBy).HasMaxLength(60);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PartNum)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.SKU).HasMaxLength(50);

                entity.Property(e => e.SupplierDescription)
                    .HasMaxLength(240)
                    .IsFixedLength();

                entity.Property(e => e.UOP).HasMaxLength(50);

                entity.Property(e => e.UOPCost).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UnitToPurchaseFactor).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Waste).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ArchDescription).HasMaxLength(200);

                entity.Property(e => e.D).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DeliveredDate).HasColumnType("date");

                entity.Property(e => e.H).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ProductionDate).HasColumnType("date");

                entity.Property(e => e.RoomName).HasMaxLength(50);

                entity.Property(e => e.UnitName).HasMaxLength(50);

                entity.Property(e => e.W).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.JobID)
                    .HasConstraintName("FK_Product_Job");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderGrandTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderSubtotal).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SubAssembly>(entity =>
            {
                entity.Property(e => e.D).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.H).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MakeFile).HasMaxLength(240);

                entity.Property(e => e.SubAssemblyName).HasMaxLength(50);

                entity.Property(e => e.W).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SubAssembly)
                    .HasForeignKey(d => d.ProductID)
                    .HasConstraintName("FK_SubAssembly_Unit");
            });

            modelBuilder.Entity<TransActionType>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.TransactionTypeName).HasMaxLength(35);
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UOM)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
