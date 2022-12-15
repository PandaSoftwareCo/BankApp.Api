namespace BankApp.Application.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<BankTransactionDto>? BankTransactions { get; set; } = new HashSet<BankTransactionDto>();
    }
}
