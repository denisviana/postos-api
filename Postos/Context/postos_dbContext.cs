using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Postos.Model;

namespace Postos.Context
{
    public partial class postos_dbContext : DbContext
    {

        postos_dbContext()
        {
        }

        public postos_dbContext(DbContextOptions<postos_dbContext> options)
            : base(options)
        {

        }



        public virtual DbSet<Posto> Posto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:sv-postos.database.windows.net,1433;Initial Catalog=postos_db;Persist Security Info=False;User ID=up2019;Password=Nisasta12*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=180;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posto>(entity =>
            {
                entity.Property(e => e.PostoId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bandeira).HasMaxLength(50);

                entity.Property(e => e.Estado).HasMaxLength(30);

                entity.Property(e => e.Municipio).HasMaxLength(30);

                entity.Property(e => e.Produto).HasMaxLength(30);

                entity.Property(e => e.Revenda).HasMaxLength(50);

                entity.Property(e => e.ValordeCompra).HasMaxLength(10);

                entity.Property(e => e.ValordeVenda).HasMaxLength(10);
            });
        }
    }
}
