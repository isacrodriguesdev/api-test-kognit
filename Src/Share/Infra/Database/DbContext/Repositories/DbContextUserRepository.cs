using Domain;
using Infra;
using Mapper;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DbContextUserRepository : UserRepository
    {
        private readonly AppDbContext context;

        public DbContextUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<User> Create(User user)
        {
            try
            {
                context.Users.Add(DbContextUserRepositoryMapper.toPersistence(user));
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Task.FromResult(user);
        }

        public async Task<User?> GetByEmail(string email)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    return DbContextUserRepositoryMapper.toDomain(user);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        public async Task<User?> GetById(string id)
        {
            try
            {
                var user = context.Users.Find(id);
                if (user != null)
                {
                    return await Task.FromResult(DbContextUserRepositoryMapper.toDomain(user));
                }
            }
            catch (System.Exception)
            {
                throw;
            }

            return null;
        }
    }
}
