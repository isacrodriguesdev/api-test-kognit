using Domain;
using Model;

namespace Mapper
{
    public static class DbContextWalletRepositoryMapper
    {
        public static Wallet toDomain(WalletModel walletModel)
        {
            var wallet = new Wallet(
                walletModel.UserId,
                walletModel.Bank,
                walletModel.Balance,
                walletModel.Id
            );

            wallet.CreatedAt = walletModel.CreatedAt;
            wallet.UpdatedAt = walletModel.UpdatedAt;

            return wallet;
        }
    }
}
