using Domain;
using Domain.Http;
using Repositories;

public class CreateUser
{
    private readonly UserRepository _userRepository;
    private readonly PasswordEncryptor _passwordEncryptor;

    public CreateUser(UserRepository userRepository, PasswordEncryptor passwordEncryptor)
    {
        _userRepository = userRepository;
        _passwordEncryptor = passwordEncryptor;
    }

    public async Task<HttpResponse<User>> Execute(
        string name,
        string email,
        string password,
        string birthDate,
        string cpf
    )
    {
        var httpResponse = new HttpResponse<User>();

        try
        {
            var user = await _userRepository.GetByEmail(email);
            if (user != null)
            {
                return httpResponse.Error(400, "User already exists");
            }

            password = _passwordEncryptor.Encrypt(password);
            user = new User(name, email, password, birthDate, cpf);

            await _userRepository.Create(user);

            return httpResponse.Result(user);
        }
        catch (Exception)
        {
            return httpResponse.InternalServerError();
        }
    }
}
