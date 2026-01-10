using IslamicFace.Application.Features.AuthFeature.Commands.ConfirmEmailCommand;
using IslamicFace.Application.Features.SendEmailFeature.EmailConfirmationTokenCommand;
using IslamicFace.Application.Features.SendEmailFeature.SendResetTokenCommand;
using IslamicFace.Domain.ErrorHandleClasses;
using IslamicFace.Presentation.API.Controllers.v1.AuthController.DTOs;
using MediatR;

namespace IslamicFace.Presentation.API.Controllers.v1.EmailsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController(ISender _sender) : ControllerBase
    {
        [HttpPost("send-confirmation-email-token")]
        [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConfirmEmailAsync(string email)
        {
            Result result = await _sender.Send(new EmailConfirmationTokenCommand(email));

            return result.ToActionResult();
        }

        [HttpPost("send-Rest-Password-email-token")]
        [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RestPasswordemailAsync(string email)
        {
            Result result = await _sender.Send(new SendResetTokenCommand(email));

            return result.ToActionResult();
        }
    }
}
