using Npgsql;
using NpgsqlTypes;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.DBModels;

namespace RockPaperScissors.DBContext
{
    public class RPSDataContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MatchHistory> MatchHistory { get; set; } = null!;
        public DbSet<GameTransaction> GameTransactions { get; set; } = null!;

        public RPSDataContext(DbContextOptions<RPSDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(user => user.Balance);
            modelBuilder.Entity<MatchHistory>().HasIndex(matchHistory => matchHistory.PlayedAt);
            modelBuilder.Entity<GameTransaction>().HasIndex(transaction => transaction.CreatedAt);
        }

    }
}
