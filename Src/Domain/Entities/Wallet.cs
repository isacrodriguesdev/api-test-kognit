namespace Domain
{
    // wallet data
    public class WalletData
    {
        private string _bank;

        public string UserId { get; set; }
        public decimal Balance { get; set; } = 0;
        public string Bank
        {
            get => _bank;
            set => _bank = value.ToLower();
        }
    }

    public class Wallet : BaseEntity
    {
        public string UserId { get; set; }
        public decimal Balance { get; set; } = 0;
        public string Bank { get; set; }

        public Wallet(string userId, string bank, decimal balance, string? id = null)
            : base(id)
        {
            UserId = userId;
            Bank = bank.ToLower();
            Balance = balance;
        }
    }
}
