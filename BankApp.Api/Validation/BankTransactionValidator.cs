using BankApp.Domain.Entities;
using FluentValidation;

namespace BankApp.Api.Validation
{
    public class BankTransactionValidator : AbstractValidator<BankTransaction>
    {
        public BankTransactionValidator()
        {
            RuleFor(x => x.BankTransactionId).NotNull();
            RuleFor(x => x.Location).Length(0, 1000);
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}
