using IslamicFace.Application.Features.UserFolder.ChangePasswordCommand;
using IslamicFace.Presentation.API.Controllers.v1.UserController.DTOs;

namespace IslamicFace.Presentation.API.Controllers.v1.UserController;

[Route("api/Users")]
[ApiController]
public class UsersController(ISender _sender) : ControllerBase
{
    [HttpPost("Change-Password")]
    [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordModel request)
    {
        Result<ChangePasswordCommandResponse> result = await _sender.Send(new ChangePasswordCommand(request.Id, request.CurrentPassword,
            request.Password, request.ConfermPassword));

        return result.ToActionResult();
    }
}

