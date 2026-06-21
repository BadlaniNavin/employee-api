using MediatR;

namespace Employee.Infrastructure.Application.Features.GetAllEmployees;

public class GetAllEmployeesQuery : IRequest<GetAllEmployeesQueryResult>
{
    public static GetAllEmployeesQuery CreateQuery()
    {
        return new GetAllEmployeesQuery();
    }
}
