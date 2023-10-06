﻿// <auto-generated />
using System;
using DDD.Infra.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infra.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20231006015614_petCon2")]
    partial class petCon2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("UserSequence");

            modelBuilder.Entity("DDD.Domain.ClienteContext.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("ClienteUserId")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalId");

                    b.HasIndex("ClienteUserId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("DDD.Domain.ClinicaContext.Consulta", b =>
                {
                    b.Property<int>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsulta"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime2");

                    b.Property<int>("VeterinariosUserId")
                        .HasColumnType("int");

                    b.Property<int>("animalId")
                        .HasColumnType("int");

                    b.Property<int>("idVeterinario")
                        .HasColumnType("int");

                    b.HasKey("IdConsulta");

                    b.HasIndex("VeterinariosUserId");

                    b.HasIndex("animalId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Clinica", b =>
                {
                    b.Property<int>("ClinicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicaId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaAcesso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinicaId");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("DDD.Domain.UserManagementContext.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [UserSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("UserId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DDD.Domain.ClienteContext.Cliente", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Veterinario", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.Property<int>("ClinicaId")
                        .HasColumnType("int");

                    b.HasIndex("ClinicaId");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("DDD.Domain.ClienteContext.Animal", b =>
                {
                    b.HasOne("DDD.Domain.ClienteContext.Cliente", null)
                        .WithMany("Animais")
                        .HasForeignKey("ClienteUserId");
                });

            modelBuilder.Entity("DDD.Domain.ClinicaContext.Consulta", b =>
                {
                    b.HasOne("DDD.Domain.SecretariaContext.Veterinario", "Veterinarios")
                        .WithMany()
                        .HasForeignKey("VeterinariosUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.ClienteContext.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("animalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Veterinarios");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Veterinario", b =>
                {
                    b.HasOne("DDD.Domain.SecretariaContext.Clinica", "Clinica")
                        .WithMany("Veterinarios")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Clinica", b =>
                {
                    b.Navigation("Veterinarios");
                });

            modelBuilder.Entity("DDD.Domain.ClienteContext.Cliente", b =>
                {
                    b.Navigation("Animais");
                });
#pragma warning restore 612, 618
        }
    }
}