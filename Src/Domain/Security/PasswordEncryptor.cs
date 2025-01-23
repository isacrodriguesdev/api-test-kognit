public interface PasswordEncryptor
{
    string Encrypt(string password);
    bool Compare(string password, string hash);
}
