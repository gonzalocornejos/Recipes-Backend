﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using recipes_backend.Data;

#nullable disable

namespace recipes_backend.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("recipes_backend.Models.Domain.Calificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comentarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.Property<int>("RecetaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Calificacion");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Conversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("FactorConversion")
                        .HasColumnType("float");

                    b.Property<int>("UnidadDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadOrigenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnidadDestinoId");

                    b.HasIndex("UnidadOrigenId");

                    b.ToTable("Conversion");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Favorita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecetaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Favorita");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecetaId")
                        .HasColumnType("int");

                    b.Property<string>("UrlFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Multimedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoContenido")
                        .HasColumnType("int");

                    b.Property<string>("UrlContenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PasoId");

                    b.ToTable("Multimedia");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Paso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NroPaso")
                        .HasColumnType("int");

                    b.Property<int>("RecetaId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.ToTable("Paso");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Porciones")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Receta");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.RecetaTipoPlato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecetaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoPlatoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.HasIndex("TipoPlatoId");

                    b.ToTable("RecetaTipoPlato");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.TipoPlato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoPlato");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Unidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Unidad");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Utilizados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecetaId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("RecetaId");

                    b.HasIndex("UnidadId");

                    b.ToTable("Utilizados");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Calificacion", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Receta", "Receta")
                        .WithMany("Calificaciones")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipes_backend.Models.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Conversion", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Unidad", "UnidadDestino")
                        .WithMany()
                        .HasForeignKey("UnidadDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipes_backend.Models.Domain.Unidad", "UnidadOrigen")
                        .WithMany()
                        .HasForeignKey("UnidadOrigenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnidadDestino");

                    b.Navigation("UnidadOrigen");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Favorita", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Receta", "Receta")
                        .WithMany("Favorito")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipes_backend.Models.Domain.Usuario", "Usuario")
                        .WithMany("Favoritas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Foto", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Receta", "Receta")
                        .WithMany("Fotos")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Multimedia", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Paso", "Paso")
                        .WithMany("Multimedias")
                        .HasForeignKey("PasoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paso");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Paso", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Receta", "Receta")
                        .WithMany("Pasos")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Receta", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Usuario", "Usuario")
                        .WithMany("Recetas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.RecetaTipoPlato", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Receta", "Receta")
                        .WithMany("TiposPlato")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipes_backend.Models.Domain.TipoPlato", "TipoPlato")
                        .WithMany()
                        .HasForeignKey("TipoPlatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receta");

                    b.Navigation("TipoPlato");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Utilizados", b =>
                {
                    b.HasOne("recipes_backend.Models.Domain.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipes_backend.Models.Domain.Receta", "Receta")
                        .WithMany("Ingredientes")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipes_backend.Models.Domain.Unidad", "Unidad")
                        .WithMany()
                        .HasForeignKey("UnidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Receta");

                    b.Navigation("Unidad");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Paso", b =>
                {
                    b.Navigation("Multimedias");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Receta", b =>
                {
                    b.Navigation("Calificaciones");

                    b.Navigation("Favorito");

                    b.Navigation("Fotos");

                    b.Navigation("Ingredientes");

                    b.Navigation("Pasos");

                    b.Navigation("TiposPlato");
                });

            modelBuilder.Entity("recipes_backend.Models.Domain.Usuario", b =>
                {
                    b.Navigation("Favoritas");

                    b.Navigation("Recetas");
                });
#pragma warning restore 612, 618
        }
    }
}
