using Domain;
using Model;

namespace Mapper
{
    public static class DbContextUserRepositoryMapper
    {
        public static User toDomain(UserModel walletModel)
        {
            return new User(
                walletModel.Name,
                walletModel.Email,
                walletModel.Password,
                walletModel.BirthDate,
                walletModel.Cpf,
                walletModel.Id
            );
        }

        // to persistence
        public static UserModel toPersistence(User user)
        {
            return new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                BirthDate = user.BirthDate,
                Cpf = user.Cpf,
                Id = user.Id,
            };
        }
    }
}
