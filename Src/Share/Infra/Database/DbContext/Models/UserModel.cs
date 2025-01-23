using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain;
using Model;
using NpgsqlTypes;

public class UserModel
{
    [Key]
    [Column("id")]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [Required]
    [JsonPropertyName("name")]
    [Column("name")]
    public string Name { get; set; }

    [Required]
    [JsonPropertyName("email")]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [JsonPropertyName("password")]
    [Column("password")]
    public string Password { get; set; }

    // cpf and birthdate
    [Required]
    [JsonPropertyName("cpf")]
    [Column("cpf")]
    public string Cpf { get; set; }

    [Required]
    [JsonPropertyName("birth_date")]
    [Column("birth_date")]
    public string BirthDate { get; set; }

    [Required]
    [JsonPropertyName("created_at")]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    public ICollection<WalletModel> Wallets { get; set; } = new List<WalletModel>();
}
