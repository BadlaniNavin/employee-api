namespace Employee.Infrastructure.Application.Features.Emloyee.Add;

public class AddEmployeeCommandResult
{
    public Guid Id { get; set; }

    public static AddEmployeeCommandResult CreateResponse(Guid id)
    {
        return new AddEmployeeCommandResult { Id = id };
    }
}
