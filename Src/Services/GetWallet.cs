using Domain;
using Domain.Http;
using Repositories;

public class GetWallet
{
    private readonly WalletRepository _walletRepository;

    public GetWallet(WalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<HttpResponse<List<Wallet>>> Execute(string userId)
    {
        var httpResponse = new HttpResponse<List<Wallet>>();

        var wallets = await _walletRepository.ListByUserId(userId);
        return httpResponse.Result(wallets);
    }
}
