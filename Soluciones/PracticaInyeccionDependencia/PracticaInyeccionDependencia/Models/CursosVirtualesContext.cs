using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PracticaInyeccionDependencia.Models
{
    public partial class CursosVirtualesContext : DbContext
    {
        public CursosVirtualesContext()
        {
        }

        public CursosVirtualesContext(DbContextOptions<CursosVirtualesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Continente> Continentes { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Paise> Paises { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CursosVirtuales; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continente>(entity =>
            {
                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasMany(d => d.PersonaPersonas)
                    .WithMany(p => p.CursoCursos)
                    .UsingEntity<Dictionary<string, object>>(
                        "CursoPersona",
                        l => l.HasOne<Persona>().WithMany().HasForeignKey("PersonaPersonaId").HasConstraintName("FK_dbo.CursoPersona_dbo.Personas_Persona_PersonaId"),
                        r => r.HasOne<Curso>().WithMany().HasForeignKey("CursoCursoId").HasConstraintName("FK_dbo.CursoPersona_dbo.Cursos_Curso_CursoId"),
                        j =>
                        {
                            j.HasKey("CursoCursoId", "PersonaPersonaId").HasName("PK_dbo.CursoPersona");

                            j.ToTable("CursoPersona");

                            j.HasIndex(new[] { "CursoCursoId" }, "IX_Curso_CursoId");

                            j.HasIndex(new[] { "PersonaPersonaId" }, "IX_Persona_PersonaId");

                            j.IndexerProperty<int>("CursoCursoId").HasColumnName("Curso_CursoId");

                            j.IndexerProperty<int>("PersonaPersonaId").HasColumnName("Persona_PersonaId");
                        });
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.PaisId)
                    .HasName("PK_dbo.Paises");

                entity.HasIndex(e => e.ContinenteId, "IX_ContinenteId");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.Continente)
                    .WithMany(p => p.Paises)
                    .HasForeignKey(d => d.ContinenteId)
                    .HasConstraintName("FK_dbo.Paises_dbo.Continentes_ContinenteId");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasIndex(e => e.PaisId, "IX_PaisId");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.TipoPersona).HasMaxLength(25);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("FK_dbo.Personas_dbo.Paises_PaisId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
