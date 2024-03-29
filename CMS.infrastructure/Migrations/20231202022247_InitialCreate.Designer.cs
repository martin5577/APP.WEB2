﻿// <auto-generated />
using System;
using CMS.infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMS.infraestructure.Migrations
{
    [DbContext(typeof(CMSContext))]
    [Migration("20231202022247_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CMS.domain.Categorias.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CMS.domain.Preguntas.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActualizadoEn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreadoEn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeComentario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("CMS.domain.Respuestas.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActualizadoEn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreadoEn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRespuesta")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.Property<string>("Respuestas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("CMS.domain.Categorias.Categoria", b =>
                {
                    b.HasOne("CMS.domain.Preguntas.Pregunta", null)
                        .WithMany("Categorias")
                        .HasForeignKey("PreguntaId");
                });

            modelBuilder.Entity("CMS.domain.Respuestas.Respuesta", b =>
                {
                    b.HasOne("CMS.domain.Preguntas.Pregunta", "Pregunta")
                        .WithMany("Respuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pregunta");
                });

            modelBuilder.Entity("CMS.domain.Preguntas.Pregunta", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Respuestas");
                });
#pragma warning restore 612, 618
        }
    }
}
