using BankApp.Domain.Entities;
using BankApp.Domain.Enums;

namespace BankApp.Application.DTOs
{
    public class BankTransactionDto
    {
        public int BankTransactionId { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public int? AccountId { get; set; }
        public AccountDto? Account { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
