public class ServiceFactory
{
    public static void Create(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<UserLogin>();
        builder.Services.AddScoped<GetWallet>();
        builder.Services.AddScoped<CreateUser>();
        builder.Services.AddScoped<CreateWallet>();
    }
}
