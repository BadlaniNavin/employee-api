namespace Employee.Infrastructure.Application.Features.Emloyee;

public class AddEmployeeRequestModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
