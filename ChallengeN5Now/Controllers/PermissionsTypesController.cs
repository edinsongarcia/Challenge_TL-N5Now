using ChallengeN5Now.Business.PermissionsTypes.Methods;
using ChallengeN5Now.Business.PermissionsTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ChallengeN5Now.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePermissionType(CreatePermissionType data)
        {
            Log.Information("Create permission type {@data}", data);
            var result = await _mediator.Send(data);

            return Created(string.Empty, result);
        }

        [HttpGet]
        //[SwaggerOperation(summary: "Get all permissions types", description: "Allow get all permission types")]
        //[SwaggerResponse(StatusCodes.Status200OK, null, typeof(IEnumerable<PermissionType>))]
        //[SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPermissionTypes()
        {
            Log.Information("Get all permission types");
            return Ok(await _mediator.Send(new GetAllPermissionTypes()));
        }

    }
}
