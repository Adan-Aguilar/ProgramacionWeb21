using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Actividad3MapaCurricular.Models
{
    public partial class mapa_curricularContext : DbContext
    {
        public mapa_curricularContext()
        {
        }

        public mapa_curricularContext(DbContextOptions<mapa_curricularContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=mapa_curricular", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("carreras");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Clave, "Clave_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Plan)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("materias");

                entity.HasIndex(e => e.IdCarrera, "fkmat_idx1");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Creditos).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.HorasPracticas).HasColumnType("tinyint(4)");

                entity.Property(e => e.HorasTeoricas).HasColumnType("tinyint(4)");

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.Semestre).HasColumnType("tinyint(3) unsigned");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkmat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
