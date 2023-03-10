using BankApp.Domain.Enums;

namespace BankApp.Domain.Entities
{
    public class BankTransaction
    {
        public int BankTransactionId { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
