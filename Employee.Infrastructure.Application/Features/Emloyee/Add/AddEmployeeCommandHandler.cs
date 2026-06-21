using Employee.Infrastructure.Application.Repositories;
using MediatR;

namespace Employee.Infrastructure.Application.Features.Emloyee.Add;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, AddEmployeeCommandResult>
{
    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRespository = employeeRepository;
    }
    public async Task<AddEmployeeCommandResult> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var requestModel = GetRequestModel(request);
        await _employeeRespository.AddEmployeeAsync(requestModel, cancellationToken);
        return AddEmployeeCommandResult.CreateResponse(requestModel.Id);        
    }

    private AddEmployeeRequestModel GetRequestModel(AddEmployeeCommand request)
    {
        return new AddEmployeeRequestModel
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };
    }

    private readonly IEmployeeRepository _employeeRespository;
}
