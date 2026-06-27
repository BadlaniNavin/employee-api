namespace Employee.Infrastructure.Application.Features.Emloyee.Update;

public class UpdateEmployeeCommandResult
{
    public Guid Id { get; set; }

    public static UpdateEmployeeCommandResult CreateResponse(Guid id)
    {
        return new UpdateEmployeeCommandResult { Id = id };
    }
}
