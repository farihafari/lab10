using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewRestApi.Models;

public partial class CrudDbContext : DbContext
{
    public CrudDbContext()
    {
    }

    public CrudDbContext(DbContextOptions<CrudDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Example: Configure the database provider here  
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC079EC04987");

            entity.Property(e => e.Course)
                .HasMaxLength(100)
                .HasColumnName("course");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fee");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
