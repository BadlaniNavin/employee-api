using MediatR;

namespace Employee.Infrastructure.Application.Features.Emloyee.Update;

public class UpdateEmployeeCommand : IRequest<UpdateEmployeeCommandResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UpdateEmployeeCommand()
    {

    }

    public static UpdateEmployeeCommand CreateCommand(
        string firstName,
        string lastName
    )
    {
        return new UpdateEmployeeCommand()
        {
            FirstName = firstName,
            LastName = lastName
        };
    }
}
