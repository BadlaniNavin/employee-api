using Employee.Infrastructure.Application.Features.Emloyee.Add;

namespace Employee.API.Employee.Add;

public class Request
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public AddEmployeeCommand ToMediator()
    {
        return AddEmployeeCommand.CreateCommand(FirstName, LastName, Email);
    }
}
