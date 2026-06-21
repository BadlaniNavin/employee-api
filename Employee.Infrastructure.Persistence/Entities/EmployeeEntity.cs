using Employee.Infrastructure.Application;

namespace Employee.Infrastructure.Persistence.Entities;

public class EmployeeEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Type { get; set; }

    public EmployeeModel ToModel()
    {
        return new EmployeeModel
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email
        };
    }
}
