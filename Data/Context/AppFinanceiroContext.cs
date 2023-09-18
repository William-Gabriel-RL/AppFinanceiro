using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppFinanceiroContext : DbContext
    {
        public AppFinanceiroContext(DbContextOptions<AppFinanceiroContext> opt) : base(opt)
        {
            
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host = localhost; Port = 5432; Pooling = true; Database = AppFinanceiro; User Id=postgres; Password=admin");
            }
        }
    }
}