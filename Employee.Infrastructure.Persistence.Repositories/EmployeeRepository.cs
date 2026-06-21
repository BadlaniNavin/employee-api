using Employee.Infrastructure.Application;
using Employee.Infrastructure.Application.Features.Emloyee;
using Employee.Infrastructure.Application.Repositories;
using Employee.Infrastructure.Persistence.Database;
using Employee.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DatabaseContext _context;

    public EmployeeRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task AddEmployeeAsync(AddEmployeeRequestModel model, CancellationToken cancellationToken)
    {
        var entity = new EmployeeEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email
        };

        _context.Employees.Add(entity);
        _context.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<EmployeeModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Employees.Select(e=> e.ToModel()).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<IQueryable<EmployeeModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
