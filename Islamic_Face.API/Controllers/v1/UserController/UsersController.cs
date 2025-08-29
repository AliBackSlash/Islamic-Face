namespace IslamicFace.Presentation.API.Controllers.v1.UserController;

[Route("api/Users")]
[ApiController]
//will take the user id from token in the future when perform Auth

public class UsersController(ISender _sender) : ControllerBase
{


    [HttpPut("Update-User")]
    [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUserInfo([FromBody] AddUserModel request)
    {
        Result<UpdateUserInfoCommandResponse> result = await _sender.Send(new UpdateUserInfoCommand
            (request.Id, request.fName, request.lName, request.countryID, request.cityID,
                request.dateOfBirth, request.gender, request.bio, request.PhoneNumber, request.settingId));

        return result.ToActionResult();
    }

    

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

