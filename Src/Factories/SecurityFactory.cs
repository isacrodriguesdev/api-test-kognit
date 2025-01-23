using Infra.Security;

public class SecurityFactory
{
    public static void Create(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<PasswordEncryptor, BCryptPasswordEncryptor>();
    }
}
