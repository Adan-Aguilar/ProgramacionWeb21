using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EstadosMexico.Models
{
    public partial class mexicoContext : DbContext
    {
        public mexicoContext()
        {
        }

        public mexicoContext(DbContextOptions<mexicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=mexico", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("estados");

                entity.Property(e => e.Abrev)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("abrev")
                    .HasComment("NOM_ABR - Nombre abreviado de la entidad");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nombre")
                    .HasComment("NOM_ENT - Nombre de la entidad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
