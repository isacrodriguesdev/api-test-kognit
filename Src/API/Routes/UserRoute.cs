// WebApplication

using Domain;
using Dto;

namespace Route
{
    public class UserRoute(WebApplication app)
    {
        public void Create(string pattern)
        {
            app.MapPost(
                pattern,
                async (UserData user, UserController controller) =>
                {
                    return await controller.Create(user);
                }
            );
        }

        public void Login(string pattern)
        {
            app.MapPost(
                pattern,
                async (UserLoginDto user, UserController controller) =>
                {
                    return await controller.Login(user.Email, user.Password);
                }
            );
        }
    }
}
