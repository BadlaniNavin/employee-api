using FluentValidation;

namespace Employee.Infrastructure.Application.Features.Emloyee.Add;

public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
{
    public AddEmployeeCommandValidator()
    {
        RuleFor(cmd => cmd.FirstName)
            .NotEmpty();

        RuleFor(cmd => cmd.LastName)
            .NotEmpty();

        RuleFor(cmd => cmd.Email)
            .NotEmpty();
    }
}
