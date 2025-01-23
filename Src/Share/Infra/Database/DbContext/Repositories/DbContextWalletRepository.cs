using Domain;
using Infra;
using Mapper;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories
{
    public class DbContextWalletRepository : WalletRepository
    {
        private readonly AppDbContext context;

        public DbContextWalletRepository(AppDbContext context)
        {
            this.context = context;
        }

        public override async Task<Wallet?> GetByUserId(string userId)
        {
            var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
            if (wallet != null)
            {
                return DbContextWalletRepositoryMapper.toDomain(wallet);
            }

            return null;
        }

        public override async Task<Wallet> Create(Wallet wallet)
        {
            var walletModel = new WalletModel
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                Balance = wallet.Balance,
                Bank = wallet.Bank,
                CreatedAt = wallet.CreatedAt,
                UpdatedAt = wallet.UpdatedAt,
            };

            context.Wallets.Add(walletModel);
            await context.SaveChangesAsync();

            return DbContextWalletRepositoryMapper.toDomain(walletModel);
        }

        public override async Task Update(Wallet wallet)
        {
            var walletModel = await context.Wallets.FirstOrDefaultAsync(w =>
                w.UserId == wallet.UserId
            );
            if (walletModel == null)
            {
                throw new ArgumentNullException(nameof(walletModel));
            }

            walletModel.Balance = wallet.Balance;
            walletModel.Bank = wallet.Bank;

            context.Wallets.Update(walletModel);
            await context.SaveChangesAsync();
        }

        public override async Task<Wallet?> GetByUserIdAndBank(string userId, string bank)
        {
            var wallet = await context.Wallets.FirstOrDefaultAsync(w =>
                w.UserId == userId && w.Bank == bank
            );
            if (wallet != null)
            {
                return DbContextWalletRepositoryMapper.toDomain(wallet);
            }

            return null;
        }

        public override async Task<List<Wallet>> ListByUserId(string userId)
        {
            var wallets = await context.Wallets.Where(w => w.UserId == userId).ToListAsync();
            return wallets.Select(w => DbContextWalletRepositoryMapper.toDomain(w)).ToList();
        }
    }
}
