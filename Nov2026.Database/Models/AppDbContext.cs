using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nov2026.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project1Answer> Project1Answers { get; set; }

    public virtual DbSet<Project1Number> Project1Numbers { get; set; }

    public virtual DbSet<Project1Question> Project1Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Sep2026Db;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project1Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId);

            entity.ToTable("Project1Answer");

            entity.HasOne(d => d.Question).WithMany(p => p.Project1Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project1Answer_Project1QuestionId");
        });

        modelBuilder.Entity<Project1Number>(entity =>
        {
            entity.HasKey(e => e.NumberId);

            entity.ToTable("Project1Number");
        });

        modelBuilder.Entity<Project1Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Project1__0DC06FAC9B1CF376");

            entity.ToTable("Project1Question");

            entity.Property(e => e.QuestionId).ValueGeneratedNever();
            entity.Property(e => e.QuestionName).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
