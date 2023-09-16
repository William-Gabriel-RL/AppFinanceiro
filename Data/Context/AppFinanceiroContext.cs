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
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}