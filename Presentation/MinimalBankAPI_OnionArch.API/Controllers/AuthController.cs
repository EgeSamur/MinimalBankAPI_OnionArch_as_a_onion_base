﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Login;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Me;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.RefreshToken;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Register;

namespace MinimalBankAPI_OnionArch.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        public async Task<IActionResult> MeAsync([FromQuery] MeCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
