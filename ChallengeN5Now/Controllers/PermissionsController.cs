using ChallengeN5Now.Business.Permissions.Methods;
using ChallengeN5Now.Business.Permissions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ChallengeN5Now.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            Log.Information("Get all permissions");

            return Ok(await _mediator.Send(new GetAllPermissions()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePermission data)
        {
            Log.Information("Create permission {@data}", data);
            var result = await _mediator.Send(data);

            return Created(string.Empty, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePermission data)
        {
            Log.Information("Update permission {@data}", data);
            var result = await _mediator.Send(data);

            return Ok(result);
        }
    }
}
