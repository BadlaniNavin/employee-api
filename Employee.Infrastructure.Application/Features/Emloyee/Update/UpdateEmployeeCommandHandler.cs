using Employee.Infrastructure.Application.Repositories;
using MediatR;

namespace Employee.Infrastructure.Application.Features.Emloyee.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeCommandResult>
{
    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRespository = employeeRepository;
    }
    public async Task<UpdateEmployeeCommandResult> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var requestModel = GetRequestModel(request);
        await _employeeRespository.UpdateEmployeeAsync(requestModel, cancellationToken);
        return UpdateEmployeeCommandResult.CreateResponse(requestModel.Id);
    }

    private UpdateEmployeeRequestModel GetRequestModel(UpdateEmployeeCommand request)
    {
        return new UpdateEmployeeRequestModel
        {            
            FirstName = request.FirstName,
            LastName = request.LastName,            
        };
    }

    private readonly IEmployeeRepository _employeeRespository;
}
