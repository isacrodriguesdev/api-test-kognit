namespace Infra.Security
{
    public class BCryptPasswordEncryptor : PasswordEncryptor
    {
        public string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Compare(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
