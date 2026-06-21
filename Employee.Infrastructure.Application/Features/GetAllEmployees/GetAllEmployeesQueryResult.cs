namespace Employee.Infrastructure.Application.Features.GetAllEmployees;

public class GetAllEmployeesQueryResult
{
    public IEnumerable<EmployeeModel> Employees { get; set; }

    public GetAllEmployeesQueryResult(IEnumerable<EmployeeModel> model)
    {
        Employees = model;
    }
    public static GetAllEmployeesQueryResult CreateResponse(IEnumerable<EmployeeModel> employees) 
    { 
        return new GetAllEmployeesQueryResult(employees);
    }
}
