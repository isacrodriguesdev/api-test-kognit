using System.Text.Json.Serialization;

namespace Domain
{
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }
        public string Cpf { get; set; }
    }

    public class User : BaseEntity
    {
        public User(
            string name,
            string email,
            string password,
            string birthDate,
            string cpf,
            string? id = null
        )
            : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Cpf = cpf;
        }

        public string Name { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string BirthDate { get; set; }
        public string Cpf { get; set; }

        [JsonIgnore]
        public ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
