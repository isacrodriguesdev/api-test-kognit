using Domain;

namespace Route
{
    public class WalletRoute(WebApplication app)
    {
        public void Get(string pattern)
        {
            app.MapGet(
                pattern,
                async (string userId, WalletController controller) =>
                {
                    return await controller.GetWallet(userId);
                }
            );
        }

        public void Create(string pattern)
        {
            app.MapPost(
                pattern,
                async (WalletData wallet, WalletController controller) =>
                {
                    return await controller.Create(wallet.UserId, wallet.Bank);
                }
            );
        }
    }
}
