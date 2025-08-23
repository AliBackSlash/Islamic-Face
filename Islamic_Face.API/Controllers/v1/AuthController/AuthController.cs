using IslamicFace.Application.Features.AuthFeature.Commands.LoginCommand;
using IslamicFace.Application.Features.AuthFeature.Commands.RegisterCommand;
using IslamicFace.Domain.Abstractions.IServices;
using IslamicFace.Domain.ErrorHandleClasses;
using IslamicFace.Infrastructure.Services.EmailServices;
using IslamicFace.Presentation.API.Controllers.v1.AuthController.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace IslamicFace.Presentation.API.Controllers.v1.AuthController
{
    [Route("api/Auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController(ISender _sender,IEmailService emailService,IConfiguration _config ) : ControllerBase
    {

        [HttpPost("Register")]
        [ProducesResponseType<RegisterCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel request)
        {
            Result<RegisterCommandResponse> result = await _sender.Send(new RegisterCommand(request.Email, request.UserName, request.Password));

            return result.ToActionResult();
        }

        [HttpPost("Login")]
        [ProducesResponseType<RegisterCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel request)
        {
            Result<LoginCommandResponse> result = await _sender.Send(new LoginCommand(request.UserNameOrEmail,request.Password));

            return result.ToActionResult();
        }
    }
}
