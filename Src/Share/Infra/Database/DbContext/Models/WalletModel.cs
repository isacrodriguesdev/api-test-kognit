using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain;

namespace Model
{
    public class WalletModel
    {
        [Column("id")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [Required]
        [JsonPropertyName("userId")]
        [Column("user_id")]
        public string UserId { get; set; }

        [Required]
        [JsonPropertyName("balance")]
        [Column("balance")]
        public decimal Balance { get; set; }

        // bank
        [Required]
        [JsonPropertyName("bank")]
        [Column("bank")]
        public string Bank { get; set; }

        [Required]
        [JsonPropertyName("created_at")]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // update_at
        [JsonPropertyName("updated_at")]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
    }
}
