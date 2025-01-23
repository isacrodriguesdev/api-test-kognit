using Domain;

public class UserController(UserLogin userLogin, CreateUser createUser)
{
    private readonly UserLogin _userLogin = userLogin;
    private readonly CreateUser _createUser = createUser;

    public async Task<IResult> Login(string email, string password)
    {
        var result = await _userLogin.Execute(email, password);

        if (result != null)
        {
            return Results.Ok(result);
        }
        else
        {
            return Results.NotFound();
        }
    }

    public async Task<IResult> Create(UserData userData)
    {
        var result = await _createUser.Execute(
            userData.Name,
            userData.Email,
            userData.Password,
            userData.BirthDate,
            userData.Cpf
        );

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
