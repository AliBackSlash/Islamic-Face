using IslamicFace.Application.Features.UserFolder.AddTheRestOfTheUser_DataCommand;
using IslamicFace.Application.Features.UserFolder.ChangePasswordCommand;
using IslamicFace.Domain.Entities;
using IslamicFace.Domain.Layer_Dtos.AppUser.response;
using IslamicFace.Presentation.API.Controllers.v1.UserController.DTOs;
using IslamicFace.Presentation.API.Services;

namespace IslamicFace.Presentation.API.Controllers.v1.UserController;

[Route("api/Users")]
[ApiController]
public class UsersController(ISender _sender,IFileService fileService) : ControllerBase
{


    [HttpPut("Update-User")]
    [ProducesResponseType<ConfirmEmailResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<IEnumerable<Error>>(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromForm] AddUserModel request)
    {

        var UploadResult = await fileService.UploadProfileImageAsync(request.profilePictureURL);

            if(UploadResult is not null)
                if (UploadResult.IsFailure)
                    return UploadResult.ToActionResult();

        Result<AddTheRestOfTheUser_DataCommandResponse> result = await _sender.Send(new AddTheRestOfTheUser_DataCommand
            (request.Id, request.fName, request.lName, request.countryID, request.cityID,
                request.dateOfBirth, request.gender, UploadResult?.Value, request.bio, request.PhoneNumber, request.settingId));

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

