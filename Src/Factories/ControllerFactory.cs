
public class ControllerFactory
{
    public static void Create(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<UserController>();
        builder.Services.AddScoped<WalletController>();
    }
}