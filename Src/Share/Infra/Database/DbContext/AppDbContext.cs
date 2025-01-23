using Microsoft.EntityFrameworkCore;
using Model;

namespace Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Users = Set<UserModel>();
            Wallets = Set<WalletModel>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para chave composta em LoanModel
            modelBuilder.Entity<WalletModel>().HasKey(w => new { w.Id, w.UserId });

            modelBuilder
                .Entity<UserModel>()
                .HasMany(u => u.Wallets)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<WalletModel> Wallets { get; set; }
    }
}