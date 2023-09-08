using FluentValidation;

namespace Mc2.CrudTest.Application.Features.Commands.Customer.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.FirstName)
            .MaximumLength(100);

            RuleFor(command => command.LastName)
                .MaximumLength(100);

            RuleFor(command => command.Email)
               .NotEmpty()
               .MaximumLength(100)
               .EmailAddress();

            RuleFor(command => command.BankAccountNumber)
              .NotEmpty()
              .MaximumLength(35);

            RuleFor(command => command.PhoneNumber)
               .MaximumLength(25);
        }
    }
}
