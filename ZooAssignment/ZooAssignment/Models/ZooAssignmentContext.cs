using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZooAssignment.Models;

public partial class ZooAssignmentContext : DbContext
{
    public ZooAssignmentContext()
    {
    }

    public ZooAssignmentContext(DbContextOptions<ZooAssignmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Habitat> Habitats { get; set; }

    public virtual DbSet<Park> Parks { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZooAssignment;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animals__3214EC0737072DA9");

            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Habitat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Habitats__3214EC07191CEFC6");
        });

        modelBuilder.Entity<Park>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parks__3214EC076FA19943");

            entity.Property(e => e.TicketPrize).HasColumnType("money");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC07D5D4BF66");

            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visits__3214EC07EB75D9E9");

            entity.Property(e => e.VisitDate).HasColumnType("datetime");

            entity.HasOne(d => d.Visitor).WithMany(p => p.Visits)
                .HasForeignKey(d => d.VisitorId)
                .HasConstraintName("FK__Visits__VisitorI__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
