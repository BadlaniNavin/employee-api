namespace Employee.Infrastructure.Application.Features.Emloyee;

public class UpdateEmployeeRequestModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
