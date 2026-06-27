using FluentValidation;

namespace Employee.Infrastructure.Application.Features.Emloyee.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(cmd => cmd.FirstName)
            .NotEmpty();

        RuleFor(cmd => cmd.LastName)
            .NotEmpty();
    }
}
