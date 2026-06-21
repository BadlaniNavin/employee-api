using MediatR;

namespace Employee.Infrastructure.Application.Features.Emloyee.Add;

public class AddEmployeeCommand : IRequest<AddEmployeeCommandResult>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public AddEmployeeCommand()
    {
        
    }
    
    public static AddEmployeeCommand CreateCommand(
        string firstName,
        string lastName,
        string email
    )
    {
        return new AddEmployeeCommand()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
    }
}
