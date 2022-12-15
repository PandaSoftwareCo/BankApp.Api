using BankApp.Domain.Entities;
using FluentValidation;

namespace BankApp.Api.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.Name).Length(0, 100);
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}
