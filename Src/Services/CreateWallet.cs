using Domain;
using Domain.Http;
using Repositories;

public class CreateWallet
{
    private readonly WalletRepository _walletRepository;

    public CreateWallet(WalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<HttpResponse<Wallet>> Execute(string userId, string bank)
    {
        var httpResponse = new HttpResponse<Wallet>();

        try
        {
            var wallet = await _walletRepository.GetByUserIdAndBank(userId, bank);
            if (wallet != null)
            {
                return httpResponse.Error(400, "There is already a wallet with that name");
            }

            wallet = new Wallet(userId, bank, 0);
            await _walletRepository.Create(wallet);

            return httpResponse.Result(wallet);
        }
        catch (Exception)
        {
            return httpResponse.InternalServerError();
        }
    }
}
