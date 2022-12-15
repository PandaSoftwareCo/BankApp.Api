using BankApp.Domain.Enums;

namespace BankApp.Application.DTOs
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? TransitNumber { get; set; }
        public string? BankNumber { get; set; }
        public string? AbaRoutingNumber { get; set; }
        public string? SwiftCode { get; set; }
        public AccountType? AccountType { get; set; }
        public ICollection<BankTransactionDto>? BankTransactions { get; set; } = new HashSet<BankTransactionDto>();
        public ICollection<BalanceDto>? Balances { get; set; } = new HashSet<BalanceDto>();
    }
}
