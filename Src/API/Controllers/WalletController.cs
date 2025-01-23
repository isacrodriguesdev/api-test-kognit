using Domain;

public class WalletController(GetWallet getWallet, CreateWallet createWallet)
{
    private readonly GetWallet _getWallet = getWallet;
    private readonly CreateWallet _createWallet = createWallet;

    public async Task<IResult> GetWallet(string userId)
    {
        var result = await _getWallet.Execute(userId);

        if (result != null)
        {
            return Results.Ok(result);
        }
        else
        {
            return Results.NotFound();
        }
    }

    public async Task<IResult> Create(string userId, string bank)
    {
        var result = await _createWallet.Execute(userId, bank);

        if (result != null)
        {
            return Results.Ok(result);
        }
        else
        {
            return Results.BadRequest();
        }
    }
}
