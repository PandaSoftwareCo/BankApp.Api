using BankApp.Domain.Entities;
using FluentValidation;

namespace BankApp.Api.Validation
{
    public class BalanceValidator : AbstractValidator<Balance>
    {
        public BalanceValidator()
        {
            RuleFor(x => x.Date).NotNull();
            //RuleFor(x => x.AccountName).Length(0, 100);
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}
