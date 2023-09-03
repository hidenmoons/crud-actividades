using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crud_Actividades.Models;

public partial class DbActividadesContext : DbContext
{
    public DbActividadesContext()
    {
    }

    public DbActividadesContext(DbContextOptions<DbActividadesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=DB_Actividades; Trusted_Connection=True;TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.IdActivity).HasName("PK__Activity__BA4B2B1F0663D052");

            entity.ToTable("Activity");

            entity.Property(e => e.IdActivity).HasColumnName("id_Activity");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Schedule)
                .HasColumnType("datetime")
                .HasColumnName("schedule");
            entity.Property(e => e.Status)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Property).WithMany(p => p.Activities)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Activity__proper__267ABA7A");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.IdProperty).HasName("PK__Property__7B66B6931BE0D163");

            entity.ToTable("Property");

            entity.Property(e => e.IdProperty).HasColumnName("id_Property");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DisableAt)
                .HasColumnType("datetime")
                .HasColumnName("disable_at");
            entity.Property(e => e.Status)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Tittle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tittle");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.IdSurvey).HasName("PK__survey__F6237DE735BB6C9B");

            entity.ToTable("survey");

            entity.Property(e => e.IdSurvey).HasColumnName("id_survey");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.Answers).HasColumnName("answers");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Activity).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__survey__activity__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
