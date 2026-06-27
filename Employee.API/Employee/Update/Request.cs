using Employee.Infrastructure.Application.Features.Emloyee.Update;

namespace Employee.API.Employee.Update;
/// <summary>
/// Update employee request
/// </summary>
public class Request
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UpdateEmployeeCommand ToMediator()
    {
        return UpdateEmployeeCommand.CreateCommand(FirstName, LastName);
    }
}
