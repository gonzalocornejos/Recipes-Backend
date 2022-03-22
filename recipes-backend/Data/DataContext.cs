using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using recipes_backend.Models.Domain;

namespace recipes_backend.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<Conversion> Conversion { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<Paso> Paso { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<TipoPlato> TipoPlato { get; set; }
        public DbSet<Unidad> Unidad { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Utilizados> Utilizados { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TK7UKT7\\LOCAL;Initial Catalog=recetas_dev;User ID=sa;Password=santiago;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
