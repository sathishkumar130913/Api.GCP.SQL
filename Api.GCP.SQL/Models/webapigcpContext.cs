using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.GCP.SQL.Models
{
    public partial class webapigcpContext : DbContext
    {
        public webapigcpContext()
        {
        }

        public webapigcpContext(DbContextOptions<webapigcpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Empdetails> Empdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=35.232.70.106;Database=webapigcp;User ID=testuser;Password=testuser;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("department");

                entity.Property(e => e.Depname)
                    .HasColumnName("depname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Deptid)
                    .HasColumnName("deptid")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Empdetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("empdetails");

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Emplocation)
                    .HasColumnName("emplocation")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Empname)
                    .HasColumnName("empname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
