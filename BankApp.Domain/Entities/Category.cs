﻿namespace BankApp.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<BankTransaction>? BankTransactions { get; set; }
    }
}
