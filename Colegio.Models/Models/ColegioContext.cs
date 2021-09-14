using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Colegio.Models.Models
{
    public partial class ColegioContext : DbContext
    {
        public ColegioContext()
        {
        }

        public ColegioContext(DbContextOptions<ColegioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Materium> Materia { get; set; }
        public virtual DbSet<MatriculaMaterium> MatriculaMateria { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<ProfesorAsignatura> ProfesorAsignaturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JDL66LH\\SQLEXPRESS2019;Database=Colegio; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("Alumno");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MatriculaMaterium>(entity =>
            {
                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.MatriculaMateria)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK_MatriculaMateria_Alumno");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.MatriculaMateria)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK_MatriculaMateria_Materia");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.ToTable("Profesor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfesorAsignatura>(entity =>
            {
                entity.ToTable("ProfesorAsignatura");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.ProfesorAsignaturas)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK_ProfesorAsignatura_Materia");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.ProfesorAsignaturas)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK_ProfesorAsignatura_Profesor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
