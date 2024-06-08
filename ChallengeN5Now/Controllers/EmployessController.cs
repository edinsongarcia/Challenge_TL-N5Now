using ChallengeN5Now.Business.Employess.Methods;
using ChallengeN5Now.Business.Employess.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ChallengeN5Now.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            Log.Information("Get all employees");

            return Ok(await _mediator.Send(new GetAllEmployees()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            Log.Information("Get employee by Id {@id}", id);

            return Ok(await _mediator.Send(new GetEmployeeById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployee data)
        {
            Log.Information("Create employee {@data}", data);
            var result = await _mediator.Send(data);

            return Created(string.Empty, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployee data)
        {
            Log.Information("Update employee {@data}", data);
            var result = await _mediator.Send(data);

            return Ok(result);
        }
    }
}
