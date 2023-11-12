using DDD.Domain.ClienteContext;
using DDD.Domain.ClinicaContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SqlServer
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=tcp:petcon.database.windows.net,1433;Initial Catalog=PetConDatabase;Persist Security Info=False;User ID=PetConUser;Password=PetCon2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PetConDb");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Clientes)
                .WithMany(c => c.Animais)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<Solicitacao>()
                .HasOne(s => s.Cliente)
                .WithMany(c => c.Solicitacoes)
                .HasForeignKey(s => s.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Solicitacao>()
                .HasOne(s => s.Animal)
                .WithMany(a => a.Solicitacoes)
                .HasForeignKey(s => s.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento entre Clinica e Veterinario
            modelBuilder.Entity<Clinica>()
                .HasMany(clinica => clinica.Veterinarios) // Uma clínica tem muitos veterinários
                .WithOne(veterinario => veterinario.Clinica) // Um veterinário pertence a uma única clínica
                .HasForeignKey(veterinario => veterinario.ClinicaId); // Chave estrangeira em Veterinario

            modelBuilder.Entity<Veterinario>()
                .HasMany(e => e.Animais)
                .WithMany(e => e.Veterinarios)
                .UsingEntity<Consulta>();


                    modelBuilder.Entity<Consulta>()
                        .HasOne(c => c.Veterinarios)
                        .WithMany(v => v.Consultas)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
    .HasOne(c => c.Veterinarios)
    .WithMany(v => v.Consultas)
    .OnDelete(DeleteBehavior.ClientNoAction);






            // Configuração do relacionamento entre Clinica e Cliente
            modelBuilder.Entity<Clinica>()
                .HasMany(clinica => clinica.Clientes) // Uma clínica tem muitos veterinários
                .WithOne(cliente => cliente.Clinica) // Um cliente pertence a uma única clínica
                .HasForeignKey(cliente => cliente.ClinicaId); // Chave estrangeira em Veterinario

            // Configuração do relacionamento entre Cliente e Animal
            modelBuilder.Entity<Cliente>()
                .HasMany(cliente => cliente.Animais) // Um cliente tem muitos animais
                .WithOne(animal => animal.Clientes) // Um animal pertence a uma único cliente
                .HasForeignKey(animal => animal.ClienteId); // Chave estrangeira em animal

            modelBuilder.Entity<User>().UseTpcMappingStrategy();

            modelBuilder.Entity<User>().
                Property(c => c.DataCadastro)
                .ValueGeneratedNever();

            modelBuilder.Entity<Clinica>()
                .Property(c => c.DataCadastro)
                .ValueGeneratedNever();

            modelBuilder.Entity<Consulta>()
                .HasKey(c => c.IdConsulta);

            modelBuilder.Entity<Solicitacao>()
                .HasKey(c => c.SolicitacaoId);
        }

        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Solicitacao> Solicitacoes { get; set; }

    }
}