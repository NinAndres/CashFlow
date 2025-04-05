using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        override
            protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=12345678a.";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
