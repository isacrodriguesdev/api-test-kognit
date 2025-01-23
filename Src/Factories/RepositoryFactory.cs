using Repositories;

public class RepositoryFactory
{
    public static void Create(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<UserRepository, DbContextUserRepository>();
        builder.Services.AddScoped<WalletRepository, DbContextWalletRepository>();
    }
}
