using BankApp.Domain.Entities;

namespace BankApp.Application.DTOs
{
    public class BalanceDto
    {
        public int BalanceId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public int? AccountId { get; set; }
        public AccountDto? Account { get; set; }
    }
}
