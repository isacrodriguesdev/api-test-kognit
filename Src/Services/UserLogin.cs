using Domain;
using Domain.Http;
using Repositories;

public class UserLogin
{
    private readonly UserRepository _userRepository;
    private readonly PasswordEncryptor _passwordEncryptor;

    public UserLogin(UserRepository userRepository, PasswordEncryptor passwordEncryptor)
    {
        _userRepository = userRepository;
        _passwordEncryptor = passwordEncryptor;
    }

    public async Task<HttpResponse<User>> Execute(string email, string password)
    {
        var user = await _userRepository.GetByEmail(email);

        if (user != null)
        {
            bool isValidPassword = _passwordEncryptor.Compare(password, user.Password);
            if (isValidPassword)
            {
                return new HttpResponse<User> { Data = user };
            }
            else
            {
                return new HttpResponse<User>
                {
                    StatusCode = 401,
                    Message = "Invalid email or password",
                };
            }
        }

        return new HttpResponse<User> { StatusCode = 404, Message = "User not found" };
    }
}
