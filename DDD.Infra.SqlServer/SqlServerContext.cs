﻿using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SqlServer
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PetConDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento entre Clinica e Veterinario
            modelBuilder.Entity<Clinica>()
                .HasMany(clinica => clinica.Veterinarios) // Uma clínica tem muitos veterinários
                .WithOne(veterinario => veterinario.Clinica) // Um veterinário pertence a uma única clínica
                .HasForeignKey(veterinario => veterinario.ClinicaId); // Chave estrangeira em Veterinario

            modelBuilder.Entity<User>().UseTpcMappingStrategy();

        }

        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<User> Users { get; set; }

    }
}