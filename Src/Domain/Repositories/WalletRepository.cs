using Domain;
using Model;

namespace Repositories
{
    public abstract class WalletRepository
    {
        public abstract Task<Wallet?> GetByUserId(string userId);
        public abstract Task<Wallet?> GetByUserIdAndBank(string userId, string bank);
        public abstract Task<List<Wallet>> ListByUserId(string userId);
        public abstract Task<Wallet> Create(Wallet wallet);
        public abstract Task Update(Wallet wallet);
    }
}
