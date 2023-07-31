using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models.EF;

public partial class EmployeeManagementContext : DbContext
{
    public EmployeeManagementContext()
    {
    }

    public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptInfo> DeptInfos { get; set; }

    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

    public virtual DbSet<JobOpening> JobOpenings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=EmployeeManagement;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptInfo>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__deptInfo__BE2D3F55A38BD274");

            entity.ToTable("deptInfo");

            entity.Property(e => e.DeptNo)
                .ValueGeneratedNever()
                .HasColumnName("deptNo");
            entity.Property(e => e.DeptLocation)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("deptLocation");
            entity.Property(e => e.DeptName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<EmployeeInfo>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__employee__AFB33592D3A17DB8");

            entity.ToTable("employeeInfo");

            entity.Property(e => e.EmpNo)
                .ValueGeneratedNever()
                .HasColumnName("empNo");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("empDesignation");
            entity.Property(e => e.EmpIsPermenant).HasColumnName("empIsPermenant");
            entity.Property(e => e.EmpName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSalary).HasColumnName("empSalary");
        });

        modelBuilder.Entity<JobOpening>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__jobOpeni__B07CF5AE06CFE163");

            entity.ToTable("jobOpening");

            entity.Property(e => e.PositionId)
                .ValueGeneratedNever()
                .HasColumnName("positionId");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.IsPositionOpen).HasColumnName("isPositionOpen");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("jobTitle");
            entity.Property(e => e.PositionDept).HasColumnName("positionDept");
            entity.Property(e => e.TotalPositions).HasColumnName("totalPositions");

            entity.HasOne(d => d.PositionDeptNavigation).WithMany(p => p.JobOpenings)
                .HasForeignKey(d => d.PositionDept)
                .HasConstraintName("FK__jobOpenin__posit__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
