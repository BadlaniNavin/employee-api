using Employee.Infrastructure.Application.Repositories;
using MediatR;

namespace Employee.Infrastructure.Application.Features.GetAllEmployees;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, GetAllEmployeesQueryResult>
{
    public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRespository = employeeRepository;
    }
    public async Task<GetAllEmployeesQueryResult> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRespository.GetAllAsync(cancellationToken);

        return GetAllEmployeesQueryResult.CreateResponse(employees);
    }

    private readonly IEmployeeRepository _employeeRespository;
}
