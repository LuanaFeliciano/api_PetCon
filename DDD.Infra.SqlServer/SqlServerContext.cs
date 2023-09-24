using DDD.Domain.SecretariaContext;
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

        public DbSet<Clinica> Clinicas { get; set; }
        
        public DbSet<User> Users { get; set; }

    }
}