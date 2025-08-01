using IslamicFace.Application.Features.AuthFeature.Commands;
using IslamicFace.Domain.ErrorHandleClasses;
using IslamicFace.Presentation.API.Controllers.v1.AuthController.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IslamicFace.Presentation.API.Controllers.v1.AuthController
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController(ISender _sender) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType<RegisterCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAsync(RegisterModel request)
        {
            Result<RegisterCommandResponse> result = await _sender.Send(new RegisterCommand(request.Email, request.UserName, request.Password));

            if(result.IsSuccess) 
                return Ok(result);

            if (result.Errors.FirstOrDefault().Type == ErrorType.Validation)
                return BadRequest(result.Errors);

            return StatusCode(500, result.Errors);
        }
    }
}
