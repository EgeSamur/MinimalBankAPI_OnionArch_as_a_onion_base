using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Login;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Me;
using MinimalBankAPI_OnionArch.Application.Features.Role.Command.Create;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Delete;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Update;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetAllRoles;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetRoleById;

namespace MinimalBankAPI_OnionArch.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRolesIPaginate([FromQuery] GetAllRolesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoleById([FromQuery] GetRoleByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
