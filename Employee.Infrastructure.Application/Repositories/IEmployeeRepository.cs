using Employee.Infrastructure.Application.Features.Emloyee;

namespace Employee.Infrastructure.Application.Repositories;

public interface IEmployeeRepository
{
    /// <summary>
    /// Returns a raw IQueryable — callers decide when to materialise.
    /// </summary>
    Task<IEnumerable<EmployeeModel>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Returns a single-row IQueryable filtered by id.
    /// </summary>
    Task<IQueryable<EmployeeModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Add employee
    /// </summary>
    Task AddEmployeeAsync(AddEmployeeRequestModel model, CancellationToken cancellationToken);

    /// <summary>
    /// Update employee
    /// </summary>
    Task UpdateEmployeeAsync(UpdateEmployeeRequestModel model, CancellationToken cancellationToken);
}
