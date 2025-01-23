using Domain;

namespace Repositories
{
    public interface UserRepository
    {
        Task<User?> GetById(string id);
        Task<User?> GetByEmail(string email);
        Task<User> Create(User user);
    }
}
