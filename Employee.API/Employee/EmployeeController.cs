using Employee.Infrastructure.Application.Features.GetAllEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Employee.API.Employee
{
    /// <summary>
    /// Employee endpoints
    /// </summary>
    [Authorize] // 🔒 Enforces that a user must be authenticated via Azure AD
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        [RequiredScope("Employee.Read")]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = GetAllEmployeesQuery.CreateQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Add employee
        /// </summary>
        [RequiredScope("Employee.Write")]
        [HttpPost]       
        public async Task<IActionResult> Post([FromBody] Add.Request request,CancellationToken cancellationToken)
        {
            //var query = AddEmployeeCommand.CreateCommand(request.FirstName, request.LastName, request.Email);
            var result = await _mediator.Send(request.ToMediator(), cancellationToken);
            return Ok(result);
        }

        private readonly IMediator _mediator;
    }
}
