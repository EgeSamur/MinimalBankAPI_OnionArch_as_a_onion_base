using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;
using System.Reflection;

namespace MinimalBankAPI_OnionArch.Persistance.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transactionn> Transactions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RoleOperationClaim> RoleOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configrasyonları Assmbly olarak implament eder..
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EGE_SAMUR\\SQLEXPRESS;Database=minimalBankOnionArchDb;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}
